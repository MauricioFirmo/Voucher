import { ChangeDetectorRef, Component, EventEmitter, Input, OnChanges, OnInit, Output, TrackByFunction, } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { VagasHotel } from 'src/app/shared/model/vagas-hotel.model';
import { Passenger } from '../../listar-passageiros/listar-passageiros.component';

export class Group {
  level = 0;
  parent: Group;
  expanded = true;
  totalCounts = 0;
  get visible(): boolean {
    return !this.parent || (this.parent.visible && this.parent.expanded);
  }
}

@Component({
  selector: 'app-data-table-distribuicao-vagas',
  templateUrl: './data-table-distribuicao-vagas.component.html',
  styleUrls: ['./data-table-distribuicao-vagas.component.scss']
})
export class DataTableDistribuicaoVagasComponent implements OnInit, OnChanges {
  title = 'Grid Grouping';

  public dataSource = new MatTableDataSource<any | Group>([]);

  @Input() _alldata: any[] = [];
  @Input() columns: any[];
  @Input() displayedColumns: string[];
  @Input() groupByColumns: string[] = [];
  @Input() tableName: string;
  @Input() isPassengersTable = false;
  @Input() qtdQuartos = 0;
  @Input() noDataMsg = 'Nenhum Passageiro Vinculado'
  @Input() hotel: VagasHotel;

  @Output() onUpdateQtdQuartos = new EventEmitter<number>();

  @Output() onAddSinglePassengerAction = new EventEmitter<any>();
  @Output() onAddCompartilhadoPassengerAction = new EventEmitter<any>();

  @Output() onRemovePassengerAction = new EventEmitter<any>();
  @Output() onRemoveCompartilhadoPassengerAction = new EventEmitter<any>();

  @Input() qtdQuartosCompartilhados: number[] = [];

  constructor(private changeDetectorRefs: ChangeDetectorRef
  ) { }

  ngOnChanges() {
    this.dataSource.data = this.addGroups(this._alldata, this.groupByColumns);
    this.dataSource.filterPredicate = this.customFilterPredicate.bind(this);
    this.dataSource.filter = performance.now().toString();
    this.changeDetectorRefs.detectChanges();
    if (this.hotel) {
      this.qtdQuartosCompartilhados = [];
      this.hotel.qtdQuartosCompartilhadosArray = Array(this.hotel.qtdQuartosCompartilhados).fill(0).map((x, i) => i + 1);
    }
  }

  ngOnInit() {
    this.dataSource.data = this.addGroups(this._alldata, this.groupByColumns);
    this.dataSource.filterPredicate = this.customFilterPredicate.bind(this);
    this.dataSource.filter = performance.now().toString();
    if (this.hotel) {
      this.hotel.qtdQuartosCompartilhadosArray = Array(this.hotel.qtdQuartosCompartilhados).fill(0).map((x, i) => i + 1);
    }
  }

  atualizaQtdQuartos() {
    this.onUpdateQtdQuartos.emit(this.qtdQuartos);
  }

  addPassenger(passageiro: Passenger, type: string, numeroQuarto: any) {
    switch (type) {
      case 'single':
        this.onAddSinglePassengerAction.emit({ passageiro, numeroQuarto });
        return;
      case 'compartilhado':
        this.onAddCompartilhadoPassengerAction.emit({ passageiro, numeroQuarto });
        return;
    }
  }


  removePassenger(passageiro: Passenger, type: string) {
    switch (type) {
      case 'single':
        // this.onRemoveSinglePassengerAction.emit(passageiro);
        return;
      case 'compartilhado':
        this.onRemoveCompartilhadoPassengerAction.emit(passageiro);
        return;
    }
  }

  // below is for grid row grouping
  customFilterPredicate(data: any | Group, filter: string): boolean {
    return (data instanceof Group) ? data.visible : this.getDataRowVisible(data);
  }

  getDataRowVisible(data: any): boolean {
    const groupRows = this.dataSource.data.filter(
      row => {
        if (!(row instanceof Group)) {
          return false;
        }
        let match = true;
        this.groupByColumns.forEach(column => {
          if (!row[column] || !data[column] || row[column] !== data[column]) {
            match = false;
          }
        });
        return match;
      }
    );

    if (groupRows.length === 0) {
      return true;
    }
    const parent = groupRows[0] as Group;
    return parent.visible && parent.expanded;
  }

  groupHeaderClick(row) {
    row.expanded = !row.expanded;
    this.dataSource.filter = performance.now().toString();  // bug here need to fix
  }

  addGroups(data: any[], groupByColumns: string[]): any[] {
    const rootGroup = new Group();
    rootGroup.expanded = true;
    return this.getSublevel(data, 0, groupByColumns, rootGroup);
  }

  getSublevel(data: any[], level: number, groupByColumns: string[], parent: Group): any[] {
    if (level >= groupByColumns.length) {
      return data;
    }
    const groups = this.uniqueBy(
      data.map(
        row => {
          const result = new Group();
          result.level = level + 1;
          result.parent = parent;
          for (let i = 0; i <= level; i++) {
            result[groupByColumns[i]] = row[groupByColumns[i]];
          }
          return result;
        }
      ),
      JSON.stringify);

    const currentColumn = groupByColumns[level];
    let subGroups = [];
    groups.forEach(group => {
      const rowsInGroup = data.filter(row => group[currentColumn] === row[currentColumn]);
      group.totalCounts = rowsInGroup.length;
      const subGroup = this.getSublevel(rowsInGroup, level + 1, groupByColumns, group);
      subGroup.unshift(group);
      subGroups = subGroups.concat(subGroup);
    });
    return subGroups;
  }

  uniqueBy(a, key) {
    const seen = {};
    return a.filter((item) => {
      const k = key(item);
      return seen.hasOwnProperty(k) ? false : (seen[k] = true);
    });
  }

  isGroup(index, item): boolean {
    return item.level;
  }
}

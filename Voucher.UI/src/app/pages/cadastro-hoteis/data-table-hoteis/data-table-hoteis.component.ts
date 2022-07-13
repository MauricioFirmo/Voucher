import { SelectionModel } from '@angular/cdk/collections';
import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-data-table-hoteis',
  templateUrl: './data-table-hoteis.component.html',
  styleUrls: ['./data-table-hoteis.component.scss']
})
export class DataTableHoteisComponent implements OnInit, OnChanges, AfterViewInit {

  @Input() columnsToDisplay: string[] = [];
  @Input() data: any[] = [];
  @Input() isLoadingResults = false;
  @Input() noDataMessage = 'Nenhum hotel encontrado.';

  @Input() showEditButton = false;
  @Input() showDeleteButton = false;
  @Input() showViewButton = false;
  @Input() showSelectBox = false;
  @Input() showUpdateButton = false;

  @Output() onSelectRowAction = new EventEmitter();
  @Output() onDeleteAction = new EventEmitter();
  @Output() onEditAction = new EventEmitter();
  @Output() onViewAction = new EventEmitter();
  @Output() onUpdateAction = new EventEmitter();

  private selection = new SelectionModel<any>(false, []);
  dataSource: MatTableDataSource<any>;
  private paginator: MatPaginator;

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) set matPaginator(mp: MatPaginator) {
    this.paginator = mp;
  }

  constructor() { }

  ngOnInit() {
    this.dataSource = new MatTableDataSource(this.data);
    this.dataSource.sort = this.sort;
  }

  convertSnakeCaseToTitleCase(str) {
    return str.replace(/([A-Z]+)/g, ' $1').replace(/([A-Z][a-z])/g, ' $1').toUpperCase();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnChanges() {
    this.dataSource = new MatTableDataSource(this.data);
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  onClick(element, action) {
    switch (action) {
      case 'view':
        this.onViewAction.emit(element);
        break;
      case 'delete':
        this.onDeleteAction.emit(element);
        break;
      case 'edit':
        this.onEditAction.emit(element);
        break;
      case 'update-vagas':
        this.onUpdateAction.emit(element);
        break;
      default:
        this.onViewAction.emit(element);
        break;
    }
  }

  onSelectRow(row) {
    this.onSelectRowAction.emit(row);
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource ? this.dataSource.data.length : 0;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select(row));
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: any): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id + 1}`;
  }

}

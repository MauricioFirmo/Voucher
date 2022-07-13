import { SelectionModel } from '@angular/cdk/collections';
import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Language } from '../../model/email.model';
@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss']
})
export class DataTableComponent implements OnInit, OnChanges, AfterViewInit {

  @Input() columnsToDisplay: string[] = [];
  @Input() data: any[] = [];
  @Input() isLoadingResults = false;

  @Input() showEditButton = false;
  @Input() showDeleteButton = false;
  @Input() showViewButton = false;
  @Input() showSelectBox = false;

  @Output() onSelectRowAction = new EventEmitter();
  @Output() onDeleteAction = new EventEmitter();
  @Output() onEditAction = new EventEmitter();
  @Output() onViewAction = new EventEmitter();

  private selection = new SelectionModel<any>(false, []);
  dataSource: MatTableDataSource<any>;
  private paginator: MatPaginator;
  languageEnum = Language;
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

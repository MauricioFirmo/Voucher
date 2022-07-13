import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataTableAlimentacaoComponent } from './data-table-alimentacao.component';

describe('DataTableAlimentacaoComponent', () => {
  let component: DataTableAlimentacaoComponent;
  let fixture: ComponentFixture<DataTableAlimentacaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DataTableAlimentacaoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DataTableAlimentacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

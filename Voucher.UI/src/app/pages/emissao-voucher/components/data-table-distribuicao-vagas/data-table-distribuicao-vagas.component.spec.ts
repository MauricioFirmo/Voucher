/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DataTableDistribuicaoVagasComponent } from './data-table-distribuicao-vagas.component';

describe('DataTableDistribuicaoVagasComponent', () => {
  let component: DataTableDistribuicaoVagasComponent;
  let fixture: ComponentFixture<DataTableDistribuicaoVagasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DataTableDistribuicaoVagasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DataTableDistribuicaoVagasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

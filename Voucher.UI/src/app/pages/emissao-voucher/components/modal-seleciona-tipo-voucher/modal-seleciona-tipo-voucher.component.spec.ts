/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ModalSelecionaTipoVoucherComponent } from './modal-seleciona-tipo-voucher.component';

describe('ModalSelecionaTipoVoucherComponent', () => {
  let component: ModalSelecionaTipoVoucherComponent;
  let fixture: ComponentFixture<ModalSelecionaTipoVoucherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalSelecionaTipoVoucherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalSelecionaTipoVoucherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

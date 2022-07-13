/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ModalDistribuicaoVagasHoteisComponent } from './modal-distribuicao-vagas-hoteis.component';

describe('ModalDistribuicaoVagasHoteisComponent', () => {
  let component: ModalDistribuicaoVagasHoteisComponent;
  let fixture: ComponentFixture<ModalDistribuicaoVagasHoteisComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalDistribuicaoVagasHoteisComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalDistribuicaoVagasHoteisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { VagasHospedagemComponent } from './vagas-hospedagem.component';

describe('VagasHospedagemComponent', () => {
  let component: VagasHospedagemComponent;
  let fixture: ComponentFixture<VagasHospedagemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VagasHospedagemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VagasHospedagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarAlimentacaoComponent } from './cadastrar-alimentacao.component';

describe('CadastrarAlimentacaoComponent', () => {
  let component: CadastrarAlimentacaoComponent;
  let fixture: ComponentFixture<CadastrarAlimentacaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadastrarAlimentacaoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastrarAlimentacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

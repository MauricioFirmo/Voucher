import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarAlimentacaoComponent } from './listar-alimentacao.component';

describe('ListarAlimentacaoComponent', () => {
  let component: ListarAlimentacaoComponent;
  let fixture: ComponentFixture<ListarAlimentacaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListarAlimentacaoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarAlimentacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

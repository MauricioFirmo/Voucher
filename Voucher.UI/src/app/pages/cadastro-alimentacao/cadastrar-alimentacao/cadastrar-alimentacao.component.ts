import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { FoodService } from 'src/app/services/food.service';
import { LoadingService } from 'src/app/services/loading.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { Location } from '@angular/common';
@Component({
  selector: 'app-cadastrar-alimentacao',
  templateUrl: './cadastrar-alimentacao.component.html',
  styleUrls: ['./cadastrar-alimentacao.component.scss']
})
export class CadastrarAlimentacaoComponent implements OnInit {

  formCadastroFornecedor: FormGroup;

  id: number;
  tipoRoute: string;
  isVisualizar: boolean;
  isEditar: boolean;

  constructor(
    private fb: FormBuilder,
    private foodService: FoodService,
    private activeRoute: ActivatedRoute,
    private notification: NotificationService,
    private loading: LoadingService,
    public location: Location,
  ) {
    this.formCadastroFornecedor = this.fb.group({
      airportIataCode: ['', Validators.required],
      name: ['', Validators.required],
      phone: ['', Validators.required],
      email: ['', Validators.required],
      address: ['', Validators.required],
      active: [true, Validators.required],
      priority: ['', Validators.required],
      distance: ['', Validators.required],
      freeText: ['', Validators.required],
      price: [''],
      mealType: [0, Validators.required],
    });

    this.id = this.activeRoute.snapshot.params.id;
    this.tipoRoute = this.activeRoute.snapshot.routeConfig.path.split('/')[0];
    this.isVisualizar = this.tipoRoute === 'visualizar';
    this.isEditar = this.tipoRoute === 'editar';
  }

  get f() { return this.formCadastroFornecedor.controls; }

  ngOnInit(): void {
    if (this.isVisualizar || this.isEditar) {
      this.getFornecedorAlimentacaoPorId();
    }
  }

  onSubmit() {
    // stop here if form is invalid
    if (this.formCadastroFornecedor.invalid) return;

    console.log('this.formCadastroFornecedor', this.formCadastroFornecedor.value)

    if (this.isEditar) {
      this.formCadastroFornecedor.value.id = this.id;
      this.foodService.update(this.formCadastroFornecedor.value).subscribe(
        res => {
          this.loading.showLoading(false);
          this.notification.sucesso('Fornecedor editado com Sucesso!', 3);
          this.location.back();
        }, err => {
          this.loading.showLoading(false);
          this.notification.error('Erro ao cadastrar fornecedor. Contate o Administrador do sistema.', 3);
        });
    } else {
      this.foodService.insert(this.formCadastroFornecedor.value).subscribe(
        res => {
          this.loading.showLoading(false);
          this.notification.sucesso('Fornecedor cadastrado com Sucesso!', 3);
          this.location.back();
        }, err => {
          this.loading.showLoading(false);
          this.notification.error('Erro ao cadastrar fornecedor. Contate o Administrador do sistema.', 3);
        });
    }
  }

  getFornecedorAlimentacaoPorId() {
    this.loading.showLoading(true);
    this.foodService.get(this.id).subscribe(
      res => {
        this.loading.showLoading(false);
        this.formCadastroFornecedor.patchValue(res);
        if (this.isVisualizar) {
          this.formCadastroFornecedor.disable();
        }
      }, err => {
        this.loading.showLoading(false);
        this.notification.error('Erro ao encontrar o fornecedor');
        this.location.back();
      }
    );
  }

}

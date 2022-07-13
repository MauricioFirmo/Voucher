import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { Location } from '@angular/common';
import { TransportService } from 'src/app/services/transport.service';
import { LoadingService } from 'src/app/services/loading.service';
@Component({
  selector: 'app-cadastrar-transporte',
  templateUrl: './cadastrar-transporte.component.html',
  styleUrls: ['./cadastrar-transporte.component.scss']
})
export class CadastrarTransporteComponent implements OnInit {

  formCadastroTransporte: FormGroup;

  transportTypes = [
    {
      id: 0,
      descricao: 'Ônibus',
    },
    {
      id: 1,
      descricao: 'Taxi',
    },
    {
      id: 2,
      descricao: 'Outros',
    }
  ];

  id: number;
  tipoRoute: string;
  isVisualizar: boolean;
  isEditar: boolean;

  constructor(
    private fb: FormBuilder,
    private notification: NotificationService,
    private transportService: TransportService,
    private activeRoute: ActivatedRoute,
    private loading: LoadingService,
    public location: Location,
  ) {
    this.formCadastroTransporte = this.fb.group({
      airportIataCode: ['', Validators.required],
      name: ['', Validators.required],
      phone: ['', Validators.required],
      email: [''],
      address: [''],
      active: [true, Validators.required],
      priority: ['', [Validators.required, Validators.max(100), Validators.min(1)]],
      distance: [''],
      freeText: [''],
      // celular: [''],
      transportType: ['', Validators.required],
      price: [''],
    });

    this.id = this.activeRoute.snapshot.params.id;
    this.tipoRoute = this.activeRoute.snapshot.routeConfig.path.split('/')[0];
    this.isVisualizar = this.tipoRoute === 'visualizar';
    this.isEditar = this.tipoRoute === 'editar';
  }

  get f() { return this.formCadastroTransporte.controls; }

  ngOnInit(): void {
    if (this.isVisualizar || this.isEditar) {
      this.getFornecedorTransportePorId();
    }
  }

  onSubmit() {
    // stop here if form is invalid
    if (this.formCadastroTransporte.invalid) return;

    if (this.isEditar) {
      this.formCadastroTransporte.value.id = this.id;
      this.transportService.update(this.formCadastroTransporte.value).subscribe(
        res => {
          this.loading.showLoading(false);
          this.notification.sucesso('Fornecedor editado com Sucesso!', 3);
          this.location.back();
        }, err => {
          this.loading.showLoading(false);
          this.notification.error('Erro ao cadastrar fornecedor. Contate o Administrador do sistema.', 3);
        });
    } else {
      this.transportService.insert(this.formCadastroTransporte.value).subscribe(
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

  getFornecedorTransportePorId() {
    this.loading.showLoading(true);
    this.transportService.get(this.id).subscribe(
      res => {
        this.loading.showLoading(false);
        this.formCadastroTransporte.patchValue(res);
        if (this.isVisualizar) {
          this.formCadastroTransporte.disable();
        }
      }, err => {
        this.loading.showLoading(false);
        this.notification.error('Erro ao encontrar o fornecedor');
        this.location.back();
      }
    );
  }
}

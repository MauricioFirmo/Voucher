import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { Location } from '@angular/common';
import { EmailService } from 'src/app/services/email.service';
import { LoadingService } from 'src/app/services/loading.service';

@Component({
  selector: 'app-cadastrar-modelo-cartas',
  templateUrl: './cadastrar-modelo-cartas.component.html',
  styleUrls: ['./cadastrar-modelo-cartas.component.scss']
})
export class CadastrarModeloCartasComponent implements OnInit {

  formModeloCartas: FormGroup;

  idiomas = [
    {
      id: 1,
      idioma: 'Inglês',
    },
    {
      id: 0,
      idioma: 'Português',
    },
    {
      id: 2,
      idioma: 'Espanhol',
    },
  ];

  id: number;
  tipoRoute: string;
  isVisualizar: boolean;
  isEditar: boolean;

  constructor(
    private fb: FormBuilder,
    private notification: NotificationService,
    public location: Location,
    private emailService: EmailService,
    private loading: LoadingService,
    private activeRoute: ActivatedRoute,
  ) {
    this.formModeloCartas = this.fb.group({
      language: ['', Validators.required],
      subject: ['', Validators.required],
      body: ['', Validators.required],
    });
    this.id = this.activeRoute.snapshot.params.id;
    this.tipoRoute = this.activeRoute.snapshot.routeConfig.path.split('/')[0];
    this.isVisualizar = this.tipoRoute === 'visualizar';
    this.isEditar = this.tipoRoute === 'editar';
  }

  get f() { return this.formModeloCartas.controls; }

  ngOnInit() {
    if (this.isVisualizar || this.isEditar) {
      this.getCartaPorId();
    }
  }

  onSubmit() {
    // stop here if form is invalid
    if (this.formModeloCartas.invalid) return;
    this.loading.showLoading(true);

    if (this.isEditar) {
      this.formModeloCartas.value.id = this.id;
      this.emailService.update(this.formModeloCartas.value).subscribe(
        res => {
          this.loading.showLoading(false);
          this.notification.sucesso('Modelo de Carta Editado com Sucesso!', 3);
          this.location.back();
        }, err => {
          this.loading.showLoading(false);
          this.notification.error('Erro ao cadastrar modelo de carta. Contate o Administrador do sistema.', 3);
        });
    } else {
      this.emailService.insert(this.formModeloCartas.value).subscribe(
        res => {
          this.loading.showLoading(false);
          this.notification.sucesso('Modelo de Carta cadastrado com Sucesso!', 3);
          this.location.back();
        }, err => {
          this.loading.showLoading(false);
          this.notification.error('Erro ao cadastrar modelo de carta. Contate o Administrador do sistema.', 3);
        });
    }

  }

  getCartaPorId() {
    this.loading.showLoading(true);
    this.emailService.get(this.id).subscribe(
      res => {
        this.loading.showLoading(false);
        this.formModeloCartas.patchValue(res);
        if (this.isVisualizar) {
          this.formModeloCartas.disable();
        }
      }, err => {
        this.loading.showLoading(false);
        this.notification.error('Erro ao encontrar o modelo de carta');
        this.location.back();
      }
    );
  }

}

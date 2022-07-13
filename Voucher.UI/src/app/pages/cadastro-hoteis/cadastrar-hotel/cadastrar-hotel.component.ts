import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AccomodationService } from 'src/app/services/accomodation.service';
import { EmailService } from 'src/app/services/email.service';
import { LoadingService } from 'src/app/services/loading.service';
import { SpecialServicesService } from 'src/app/services/special-services.service';
import { AccommodationEmail, Language } from 'src/app/shared/model/email.model';
import { AccommodationProviderSpecialServices, SpecialService } from 'src/app/shared/model/special-service.model';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { cloneDeep } from 'lodash';
@Component({
  selector: 'app-cadastrar-hotel',
  templateUrl: './cadastrar-hotel.component.html',
  styleUrls: ['./cadastrar-hotel.component.scss']
})
export class CadastrarHotelComponent implements OnInit {

  formCadastroHotel: FormGroup;
  id: number;
  tipoRoute: string;
  isVisualizar: boolean;
  isEditar: boolean;
  language = Language;

  modeloEmails: AccommodationEmail[] = [];
  specialServices: SpecialService[] = [];

  constructor(
    private fb: FormBuilder,
    public location: Location,
    private activeRoute: ActivatedRoute,
    private accomodationService: AccomodationService,
    private emailService: EmailService,
    private notification: NotificationService,
    private loading: LoadingService,
    private speacialServicesService: SpecialServicesService
  ) {
    this.formCadastroHotel = this.fb.group({
      airportIataCode: ['', Validators.required],
      name: ['', Validators.required],
      phone: ['', Validators.required],
      email: ['', Validators.required],
      address: ['', Validators.required],
      active: [true, Validators.required],
      sapCode: [''],
      priority: ['', [Validators.required, Validators.max(1000), Validators.min(1)]],
      distance: ['', Validators.required],
      freeText: [''],
      mealPrice: [''],
      maxPaxPerSharedRoom: ['', Validators.required],
      accommodationEmailTemplateId: ['', Validators.required],
      // celular: [''], // FALTA VERIFICAR!!!
      possuiTranslado: [false, Validators.required], // FALTA VERIFICAR!!
      aceitaPet: [false, Validators.required], // FALTA VERIFICAR!!!!
      accommodationProviderSpecialServices: [[]]
    });

    this.id = this.activeRoute.snapshot.params.id;
    this.tipoRoute = this.activeRoute.snapshot.routeConfig.path.split('/')[0];
    this.isVisualizar = this.tipoRoute === 'visualizar';
    this.isEditar = this.tipoRoute === 'editar';
  }

  get f() { return this.formCadastroHotel.controls; }

  ngOnInit() {
    if (this.isVisualizar || this.isEditar) {
      this.getHotelPorId();
    }

    this.listarEmails();
    this.listarSpecialServices();
  }

  onSubmit() {
    // stop here if form is invalid
    if (this.formCadastroHotel.invalid) return;
    let obj = cloneDeep(this.formCadastroHotel.value);
    obj.accommodationProviderSpecialServices = [];
    this.f.accommodationProviderSpecialServices.value.forEach(e => {
      let model = new AccommodationProviderSpecialServices();
      model.specialServiceId = e.id;
      model.specialService = new SpecialService();
      obj.accommodationProviderSpecialServices.push(model);
    });

    if (this.isEditar) {
      obj.id = this.id;
      this.accomodationService.update(obj).subscribe(
        res => {
          this.loading.showLoading(false);
          this.notification.sucesso('Hotel editado com Sucesso!', 3);
          this.location.back();
        }, err => {
          this.loading.showLoading(false);
          this.notification.error('Erro ao cadastrar hotel. Contate o Administrador do sistema.', 3);
        });
    } else {
      this.accomodationService.insert(obj).subscribe(
        res => {
          this.loading.showLoading(false);
          this.notification.sucesso('Hotel cadastrado com Sucesso!', 3);
          this.location.back();
        }, err => {
          this.loading.showLoading(false);
          this.notification.error('Erro ao cadastrar hotel. Contate o Administrador do sistema.', 3);
        });
    }
  }

  getHotelPorId() {
    this.loading.showLoading(true);
    this.accomodationService.get(this.id).subscribe(
      res => {
        this.loading.showLoading(false);
        this.formCadastroHotel.patchValue(res);
console.log('res---', res);
        this.f.accommodationProviderSpecialServices.setValue(res.specialServices)
        if (this.isVisualizar) {
          this.formCadastroHotel.disable();
        }
      }, err => {
        this.loading.showLoading(false);
        this.notification.error('Erro ao encontrar o hotel');
        this.location.back();
      }
    );
  }

  listarEmails() {
    this.emailService.getList().subscribe(
      res => {
        console.log('listarEmails res', res);
        this.modeloEmails = res;
      }, err => {
        console.log('listarEmails err', err);
      }
    );
  }

  listarSpecialServices() {
    this.speacialServicesService.getList().subscribe(
      res => {
        console.log('listarEmails res', res);
        this.specialServices = res;
      }, err => {
        console.log('listarEmails err', err);
      }
    );
  }

  navBack() {
    this.location.back()
  }

  compareServicesFn(a1, a2): boolean {
    return a1 && a2 ? a1.id === a2.id : a1 === a2;
  }

}

import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AccomodationVacancyService } from 'src/app/services/accomodation-vacancy.service';
import { AccomodationService } from 'src/app/services/accomodation.service';
import { LoadingService } from 'src/app/services/loading.service';
import { AccomodationVacancyLog } from 'src/app/shared/model/accomodation-vacancy-log.mode';
import { NotificationService } from 'src/app/shared/services/notification.service';
@Component({
  selector: 'app-vagas-hospedagem',
  templateUrl: './vagas-hospedagem.component.html',
  styleUrls: ['./vagas-hospedagem.component.scss']
})
export class VagasHospedagemComponent implements OnInit {
  formCadastroVagas: FormGroup;
  vagasData: any[] = [];
  headerVagasHoteis: string[] = ['select', 'base', 'name', 'active', 'date', 'vacancies',];

  isLoadingResults = false;

  idAccProvider: number;
  dateTime: Date;
  iataCode: string;
  hotelName: string;

  savedVacancies: number;
  formatedDate: string;

  constructor(
    private fb: FormBuilder,
    private accomodationService: AccomodationService,
    private accomodationVacancyService: AccomodationVacancyService,
    private activatedRoute: ActivatedRoute,
    private loading: LoadingService,
    public location: Location,
    private notification: NotificationService
  ) {
    this.idAccProvider = this.activatedRoute.snapshot.params.id;
    this.dateTime = new Date();
    this.iataCode = this.activatedRoute.snapshot.params.iataCode;
    this.hotelName = this.activatedRoute.snapshot.params.name;

    this.formCadastroVagas = this.fb.group({
      base: ['', Validators.required],
      nome: [''],
      dateTime: ['', Validators.required],
      vacancies: ['', Validators.required],
    });
  }

  get f() { return this.formCadastroVagas.controls; }

  ngOnInit() {
    this.f.base.setValue(this.iataCode);
    this.f.nome.setValue(this.hotelName);
    this.f.dateTime.setValue(this.dateTime);
    this.f.base.disable();
    this.f.nome.disable();

    this.formatedDate = `${this.dateTime.getFullYear()}-${this.dateTime.getMonth() < 10 ? '0' + (this.dateTime.getMonth() + 1) : this.dateTime.getMonth() + 1}-${this.dateTime.getDate()}`

    this.buscarVagasHotel(this.idAccProvider, this.formatedDate);
  }

  onSubmit() {
    // stop here if form is invalid
    if (this.formCadastroVagas.invalid) return;

    const formatedDate = `${this.f.dateTime.value.getFullYear()}-${this.f.dateTime.value.getMonth() < 10 ? '0' + (this.f.dateTime.value.getMonth() + 1) : this.f.dateTime.value.getMonth() + 1}-${this.f.dateTime.value.getDate()}`
    this.loading.showLoading(true);
    if (this.savedVacancies && this.checkIfIsUpdate(formatedDate)) {
      this.accomodationVacancyService.update(this.idAccProvider, formatedDate, this.f.vacancies.value).subscribe(
        res => {
          this.loading.showLoading(false);
          this.notification.sucesso('Vagas disponíveis salvas com Sucesso!', 3);
          this.location.back();
        }, err => {
          this.loading.showLoading(false);
          this.notification.error('Erro ao salvar vagas. Contate o Administrador do sistema.', 3);
        });
    } else {
      this.accomodationVacancyService.insert(this.idAccProvider, formatedDate, this.f.vacancies.value).subscribe(
        res => {
          this.loading.showLoading(false);
          this.notification.sucesso('Vagas disponíveis salvas com Sucesso!', 3);
          this.location.back();
        }, err => {
          this.loading.showLoading(false);
          this.notification.error('Erro ao salvar vagas. Contate o Administrador do sistema.', 3);
        });
    }
  }

  buscarVagasHotel(idAccProvider: number, dateTime: string) {
    this.loading.showLoading(true);
    this.accomodationVacancyService.get(idAccProvider, dateTime).subscribe(
      res => {
        if (res) {
          this.savedVacancies = res.vacancies;
          this.f.vacancies.setValue(res.vacancies);
          this.getLog(idAccProvider);
        }
        this.loading.showLoading(false);
      },
      err => {
        this.loading.showLoading(false);
      }
    );
  }

  getLog(idAccProvider: number) {
    this.loading.showLoading(true);
    this.accomodationVacancyService.getListByProvider(idAccProvider).subscribe(
      res => {
        let arr = [];
        res.forEach(e => {
          let model = new AccomodationVacancyLog();
          model.active = e.accommodationProvider.active;
          model.base = e.accommodationProvider.airportIataCode;
          model.name = e.accommodationProvider.name
          model.date = e.dateTime;
          model.vacancies = e.vacancies;
          arr.push(model);
        });
        this.vagasData = [...arr];
        this.loading.showLoading(false);
      },
      err => {
        this.loading.showLoading(false);
      }
    );
  }

  checkIfIsUpdate(formatedDate: any) {
    const teste = this.vagasData.find(e => e.date.substr(0, 10) === formatedDate);
    return teste ? true : false;
  }

}



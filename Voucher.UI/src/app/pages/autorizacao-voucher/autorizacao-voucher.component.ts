import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoadingService } from 'src/app/services/loading.service';
import { SabreService } from 'src/app/services/sabre.service';
import { VoucherIssuanceRestrictionService } from 'src/app/services/voucher-issuance-restriction.service';
import { AuthenticatedUser } from 'src/app/shared/model/authenticated-user.model';
import { FlightDetailSabreDTO } from 'src/app/shared/model/DTO/flight-detail-sabre-dto';
import { FlightDetailSabre } from 'src/app/shared/model/flight-detail-sabre.model';
import { VoucherIssuanceRestriction, VoucherType } from 'src/app/shared/model/voucher-issuance-restriction.model';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { cloneDeep } from 'lodash';
import { AirportService } from 'src/app/services/airport.service';
import { Airport } from 'src/app/shared/model/airport.model';
import { FlightData } from 'src/app/shared/model/flight-data.model';

@Component({
  selector: 'app-autorizacao-voucher',
  templateUrl: './autorizacao-voucher.component.html',
  styleUrls: ['./autorizacao-voucher.component.scss']
})
export class AutorizacaoVoucherComponent implements OnInit {

  formAutorizacao: FormGroup;
  searchAuthorizationColumns: string[] = ['flight', 'date', 'origemDestino', 'codeShare'];
  searchauthorizationStatusDataSource = [];
  isLoadingData = false;
  authorizationColumns = ['restrictionType', 'authorized', 'updatedate', 'username'];
  authorizationStatusDataSource = [];

  voucherType = VoucherType;
  infoVoo: FlightDetailSabreDTO;

  airportsData: Airport[] = [];

  user: AuthenticatedUser;

  constructor(
    private fb: FormBuilder,
    private sabreService: SabreService,
    private loading: LoadingService,
    private voucherRestriService: VoucherIssuanceRestrictionService,
    private notification: NotificationService,
    private airportService: AirportService,
  ) {
    this.formAutorizacao = this.fb.group({
      airline: ['G3'],
      origin: ['', Validators.required],
      flight: ['', Validators.required],
      departureDate: ['', Validators.required],
    });

    this.user = JSON.parse(localStorage.getItem('user'));
  }

  ngOnInit() {
   
  }

  onSubmit() {
    // stop here if form is invalid
    if (this.formAutorizacao.invalid) return;

    this.authorizationStatusDataSource = [];
    console.log('this.formAutorizacao.value', this.formAutorizacao.value)
    let form = new FlightDetailSabre();
    const data = this.formAutorizacao.value.departureDate;
    form = cloneDeep(this.formAutorizacao.value)

    form.departureDate = `${data.getFullYear()}-${data.getMonth() < 10 ? '0' + (data.getMonth() + 1) : data.getMonth() + 1}-${data.getDate() < 10 ? '0' + (data.getDate()) : data.getDate()}`
    console.log('form', form);
    this.buscarInfoVoo(form);
  }

  get f() { return this.formAutorizacao.controls; }

  buscarInfoVoo(form: FlightDetailSabre) {
    this.searchauthorizationStatusDataSource = [];
    this.loading.showLoading(true);
    this.sabreService.getFlightDetailSabre(form).subscribe(
      res => {
        console.log('getFlightDetailSabre res', res);
        this.infoVoo = res;

        if (this.infoVoo.acS_FlightDetailRSACS.itineraryResponseList) {
          let flight = new FlightData();
          flight.flight = res.acS_FlightDetailRSACS.itineraryResponseList[0].flight;
          flight.date = res.acS_FlightDetailRSACS.itineraryResponseList[0].arrivalDate;
          flight.origemDestino = `${res.acS_FlightDetailRSACS.legInfoList[0].legCity} -> ${res.acS_FlightDetailRSACS.legInfoList[res.acS_FlightDetailRSACS.legInfoList.length - 1].legCity}`
          flight.codeShare = this.infoVoo.shareCode;

          this.searchauthorizationStatusDataSource.push(flight)
          this.buscarAuthorizationStatus(form);
        } else {
          this.notification.error('Houve um erro ao buscar os dados do voo ou esse voo não existe.')
          this.loading.showLoading(false);
        }

      },
      err => {
        console.log('err ', err);
        this.loading.showLoading(false);
      }
    );
  }

  salvarStatus() {
    console.log('authorizationStatusDataSource', this.authorizationStatusDataSource);

    const qtdNull = this.authorizationStatusDataSource.filter((a: VoucherIssuanceRestriction) => a.authorized === null); // verifica se tem algum Voucher como Null

    if (qtdNull.length > 0) {
      return this.notification.error('Por favor selecione o Status de todos os Vouchers.');
    }

    let obj = new Array<VoucherIssuanceRestriction>();
    obj = cloneDeep(this.authorizationStatusDataSource);
    console.log('this.obj', obj);
    obj.forEach((a: VoucherIssuanceRestriction) => {
      a.flightNumber = this.f.flight.value;
      a.departureAirport = this.infoVoo.acS_FlightDetailRSACS.itineraryResponseList[0].origin;
      a.arrivalAirport = this.infoVoo.acS_FlightDetailRSACS.legInfoList[this.infoVoo.acS_FlightDetailRSACS.legInfoList.length - 1].legCity
      a.username = this.user.username
      a.sta = this.infoVoo.acS_FlightDetailRSACS.itineraryResponseList[0].arrivalDate;
      a.std = this.infoVoo.acS_FlightDetailRSACS.itineraryResponseList[0].departureDate;
      a.updatedate = new Date();
    })
    console.log('this.obj', obj);

    this.loading.showLoading(true);
    if (obj[0].id) {
      this.voucherRestriService.update(obj).subscribe(
        res => {
          this.loading.showLoading(false);
          this.notification.sucesso('Autorização de Vouchers salvas com sucesso!');          
        }, err => {
          this.loading.showLoading(false);
          this.notification.error('Erro ao salvar Autorização de Vouchers. Contate o Administrador do sistema.', 3);
        });
    } else {
      this.voucherRestriService.insert(obj).subscribe(
        res => {
          this.loading.showLoading(false);
          this.notification.sucesso('Autorização de Vouchers salvas com sucesso!');
        }, err => {
          this.loading.showLoading(false);
          this.notification.error('Erro ao salvar Autorização de Vouchers. Contate o Administrador do sistema.', 3);
        });
    }

  }

  buscarAuthorizationStatus(form: FlightDetailSabre) {
    this.voucherRestriService.getList(form.flight, form.departureDate, form.origin).subscribe(
      res => {
        console.log('voucherRestriService res', res);
        this.authorizationStatusDataSource = res.length > 0 ? res : AUTHORIZATION_DEFAULT_DATA;
        this.loading.showLoading(false);
      },
      err => {
        console.log('err ', err);
        this.loading.showLoading(false);
      }
    );
  }
}


const AUTHORIZATION_DEFAULT_DATA: VoucherIssuanceRestriction[] = [
  { restrictionType: 0, authorized: null, username: '' },
  { restrictionType: 1, authorized: null, username: '' },
  { restrictionType: 2, authorized: null, username: '' },
  { restrictionType: 3, authorized: null, username: '' },
];

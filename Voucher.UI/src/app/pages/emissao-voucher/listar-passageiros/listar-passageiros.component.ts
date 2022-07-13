import { SelectionModel } from '@angular/cdk/collections';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { LoadingService } from 'src/app/services/loading.service';
import { SabreService } from 'src/app/services/sabre.service';
import { FlightDetailSabreDTO } from 'src/app/shared/model/DTO/flight-detail-sabre-dto';
import { FlightData } from 'src/app/shared/model/flight-data.model';
import { FlightDetailSabre } from 'src/app/shared/model/flight-detail-sabre.model';
import { VagasHotel } from 'src/app/shared/model/vagas-hotel.model';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { ModalDistribuicaoVagasHoteisComponent } from '../components/modal-distribuicao-vagas-hoteis/modal-distribuicao-vagas-hoteis.component';
import { ModalSelecionaTipoVoucherComponent, TipoVoucher } from '../components/modal-seleciona-tipo-voucher/modal-seleciona-tipo-voucher.component';
import { cloneDeep } from 'lodash';
import { PassengerListSabreRequest } from 'src/app/shared/model/passenger-list-request-sabre.model';
import { PassengerInfo } from 'src/app/shared/model/DTO/passenger-sabre-dto';
import { FoodVoucherService } from 'src/app/services/food-voucher.service';
import { TransportVoucherService } from 'src/app/services/transport-voucher.service';
import { FoodVoucher } from 'src/app/shared/model/food-voucher.model';
import { TransportVoucher } from 'src/app/shared/model/transport-voucher.model';
import { AuthenticatedUser } from 'src/app/shared/model/authenticated-user.model';
import { AccommodationVoucher } from 'src/app/shared/model/accommodation-voucher.model';
import { AccommodationVoucherService } from 'src/app/services/accomodation-voucher.service';
@Component({
  selector: 'app-listar-passageiros',
  templateUrl: './listar-passageiros.component.html',
  styleUrls: ['./listar-passageiros.component.scss']
})
export class ListarPassageirosComponent implements OnInit, AfterViewInit {
  formEmissaoSearch: FormGroup;
  isLoadingData = false;
  user: AuthenticatedUser;
  vooInfoColumns: string[] = ['flight', 'date', 'origemDestino', 'codeShare'];
  vooInfoDataSource = [];

  passageirosColumns = ['select', 'nome', 'pnr', 'status', 'remarksSabre'];
  passageirosDataSource = new MatTableDataSource<Passenger>();
  selection = new SelectionModel<Passenger>(true, []);

  infoVoo: FlightDetailSabreDTO;
  passengerInfo: PassengerInfo[];
  form = new FlightDetailSabre();

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private fb: FormBuilder,
    private modal: MatDialog,
    private loading: LoadingService,
    private notification: NotificationService,
    private sabreService: SabreService,
    private foodVoucherService: FoodVoucherService,
    private transportVoucherService: TransportVoucherService,
    private accommodationVoucherService: AccommodationVoucherService
  ) {
    this.formEmissaoSearch = this.fb.group({
      airline: ['G3'],
      origin: ['', Validators.required],
      flight: ['', Validators.required],
      departureDate: ['', Validators.required],
      nroBilhete: [''],
      localizadorSabre: [''],
    });
    this.user = JSON.parse(localStorage.getItem('user'));
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.passageirosDataSource.paginator = this.paginator;
  }


  onSubmit() {
    // stop here if form is invalid
    if (this.formEmissaoSearch.invalid) return;

    const data = this.formEmissaoSearch.value.departureDate;
    this.form = cloneDeep(this.formEmissaoSearch.value)
    this.form.departureDate = `${data.getFullYear()}-${data.getMonth() < 10 ? '0' + (data.getMonth() + 1) : data.getMonth() + 1}-${data.getDate() < 10 ? '0' + (data.getDate()) : data.getDate()}`

    this.buscarInfoVoo(this.form);
  }

  get f() { return this.formEmissaoSearch.controls; }

  buscarInfoVoo(form: FlightDetailSabre) {
    this.passageirosDataSource.data = [];
    this.loading.showLoading(true);
    this.sabreService.getFlightDetailSabre(form).subscribe(
      res => {
        this.infoVoo = res;

        if (this.infoVoo.acS_FlightDetailRSACS.itineraryResponseList) {
          let flight = new FlightData();
          flight.flight = res.acS_FlightDetailRSACS.itineraryResponseList[0].flight;
          flight.date = res.acS_FlightDetailRSACS.itineraryResponseList[0].arrivalDate;
          flight.origemDestino = `${res.acS_FlightDetailRSACS.legInfoList[0].legCity} -> ${res.acS_FlightDetailRSACS.legInfoList[res.acS_FlightDetailRSACS.legInfoList.length - 1].legCity}`
          flight.codeShare = this.infoVoo.shareCode;

          this.vooInfoDataSource.push(flight)

          let obj = new PassengerListSabreRequest();
          obj.strFilght = res.acS_FlightDetailRSACS.itineraryResponseList[0].flight
          obj.departureDate = form.departureDate;
          obj.strOrigin = form.origin;

          this.buscarListaPassageiros(obj);
        } else {
          this.notification.error('Houve um erro ao buscar os dados do voo ou esse voo não existe.')
          this.loading.showLoading(false);
        }

      },
      err => {
        this.loading.showLoading(false);
        this.notification.error('Não foi possível encontrar as informações do Voo. Tente novamente ou entre em contato com o administrador do sistema.')
      }
    );
  }

  buscarListaPassageiros(form: PassengerListSabreRequest) {
    this.loading.showLoading(true);
    this.sabreService.getPassengerList(form).subscribe(
      res => {
        this.passengerInfo = res;

        const listaPassageiros = [];

        if (this.passengerInfo) {
          this.passengerInfo.forEach((p: PassengerInfo) => {
            let model = new Passenger();
            model.nome = p.passengerName;
            model.pnr = p.pnr;
            model.remarksSabre = p.remark;
            model.id = p.idpassenger;
            listaPassageiros.push(model);
          });
        }

        this.passageirosDataSource.data = listaPassageiros;
        this.loading.showLoading(false);
      },
      err => {
        this.loading.showLoading(false);
        this.notification.error('Não foi possível encontrar a lista de passageiros desse voo. Tente novamente ou entre em contato com o administrador do sistema.')

      }
    );
  }

  cancelarVouchers() {
    if (this.validateStatusCancelado()) {
      this.notification.error('Apenas Vouchers com Status Emito podem ser cancelados.', 3, 'top', 'center');
    }
  }

  validateStatusCancelado(): boolean {
    let cancelado = this.selection.selected.find(p => p.status === 'Cancelado')
    return cancelado ? true : false;
  }

  validateStatusSelecionar(): boolean {
    let podeEmitir = this.selection.selected.find(p => p.status === 'Emitido')
    return podeEmitir ? true : false;
  }

  openModalTiposVoucher(vouchersSelecionados?: TipoVoucher[], vagas?: VagasHotel) {
    const modalRef = this.modal.open(ModalSelecionaTipoVoucherComponent, {
      width: '600px',
      data: { vouchers: vouchersSelecionados, form: this.form, vagas: vagas }
    });

    modalRef.afterClosed().subscribe(tiposVoucherData => {
      if (tiposVoucherData && tiposVoucherData.isDistribuirVagasHoteis && tiposVoucherData.vouchersSelecionados.length > 0) {
        this.openModalDistribuicaoVagasHoteis(tiposVoucherData.vouchersSelecionados);
      } else {
        const transportVoucher = tiposVoucherData.vouchersSelecionados.find(v => v.name === 'Transport');
        const foodVoucher = tiposVoucherData.vouchersSelecionados.find(v => v.name === 'Food');
        const snacksVoucher = tiposVoucherData.vouchersSelecionados.find(v => v.name === 'Snacks');
        const accommodationVoucher = tiposVoucherData.vouchersSelecionados.find(v => v.name === 'Accommodation');
        const vourchers = [];

        const hoteis = tiposVoucherData.hoteis;

        console.log('-----------tiposVoucherData----------------', tiposVoucherData);

        if (foodVoucher) {
          this.selection.selected.forEach(p => {
            let model = new FoodVoucher();
            model.discriminator = foodVoucher.name;
            model.createdBy = this.user.username;
            model.createdDate = new Date();
            model.validUntil = new Date();
            model.validUntil.setMonth(model.validUntil.getMonth() + 4)
            model.printedDate = new Date();
            model.serviceProviderId = foodVoucher.fornecedorId;
            model.freeText = foodVoucher.textoPadrao;
            model.flightId = this.form.flight;
            model.pseudoCityCode = this.form.origin;
            model.idPassenger = p.id;
            model.passengerName = p.nome;
            model.status = 0;
            model.reason = foodVoucher.reason;

            vourchers.push(model);
          });
          this.salvarFoodVoucher(vourchers);
        }

        if (snacksVoucher) {
          this.selection.selected.forEach(p => {
            let model = new FoodVoucher();
            model.discriminator = snacksVoucher.name;
            model.createdBy = this.user.username;
            model.createdDate = new Date();
            model.validUntil = new Date();
            model.validUntil.setMonth(model.validUntil.getMonth() + 4)
            model.createdBy = this.user.username;
            model.serviceProviderId = snacksVoucher.fornecedorId;
            model.freeText = snacksVoucher.textoPadrao;
            model.flightId = this.form.flight;
            model.pseudoCityCode = this.form.origin;
            model.idPassenger = p.id;
            model.passengerName = p.nome;
            model.status = 0;
            model.reason = snacksVoucher.reason;

            vourchers.push(model);
          });
          this.salvarFoodVoucher(vourchers);
        }

        if (transportVoucher) {
          this.selection.selected.forEach(p => {
            let model = new TransportVoucher();
            model.discriminator = transportVoucher.name;
            model.createdBy = this.user.username;
            model.createdDate = new Date();
            model.validUntil = new Date();
            model.validUntil.setMonth(model.validUntil.getMonth() + 4);
            model.createdBy = this.user.username;
            model.serviceProviderId = transportVoucher.fornecedorId;
            model.freeText = transportVoucher.textoPadrao;
            model.flightId = this.form.flight;
            model.pseudoCityCode = this.form.origin;
            model.idPassenger = p.id;
            model.passengerName = p.nome;
            model.status = 0;
            model.isActive = true;
            model.reason = transportVoucher.reason;

            vourchers.push(model);
          });
          this.salvarTransportVoucher(vourchers);
        }

        if (accommodationVoucher) {
          const vouchersToCreate = [];
          hoteis.forEach(hotel => {
            if (hotel.passageirosQuartosCompartilhados.length > 0) {

              hotel.passageirosQuartosCompartilhados.forEach(p => {
                let model = new AccommodationVoucher();
                model.createdBy = this.user.username;
                model.createdDate = new Date();
                model.validUntil = new Date();
                model.validUntil.setMonth(model.validUntil.getMonth() + 4)
                model.serviceProviderId = hotel.id;
                model.freeText = '';
                model.flightId = this.form.flight;
                model.pseudoCityCode = this.form.origin;
                model.idPassenger = p.id;
                model.passengerName = p.nome;
                model.status = 0;
                model.isActive = true;
                model.roomType = 1;
                model.dailyAmount = accommodationVoucher.diarias;
                model.reason = accommodationVoucher.reason;

                vouchersToCreate.push(model);
              });

            }

            if (hotel.passageirosQuartosSingle.length > 0) {
              hotel.passageirosQuartosSingle.forEach(p => {
                let model = new AccommodationVoucher();
                model.createdBy = this.user.username;
                model.createdDate = new Date();
                model.validUntil = new Date();
                model.validUntil.setMonth(model.validUntil.getMonth() + 4)
                model.serviceProviderId = hotel.id;
                model.freeText = '';
                model.flightId = this.form.flight;
                model.pseudoCityCode = this.form.origin;
                model.idPassenger = p.id;
                model.passengerName = p.nome;
                model.status = 0;
                model.isActive = true;
                model.roomType = 0;
                model.dailyAmount = accommodationVoucher.diarias;
                model.reason = accommodationVoucher.reason;

                vouchersToCreate.push(model);
              });
            }

          });

          this.salvarAccommodationVoucher(vouchersToCreate);
        }

      }
    });
  }

  openModalDistribuicaoVagasHoteis(vouchers: any) {
    const modalRef = this.modal.open(ModalDistribuicaoVagasHoteisComponent, {
      width: '250rem',
      data: { passageiros: this.selection.selected, vouchers }
    });

    modalRef.afterClosed().subscribe(data => {
      if (data) {
        this.openModalTiposVoucher(data.vouchers, data.vagas)
      }
    });
  }

  salvarFoodVoucher(vouchers) {
    this.loading.showLoading(true);
    this.foodVoucherService.insertRange(vouchers).subscribe(
      res => {
        this.loading.showLoading(false);
        this.notification.sucesso('Voucher emitido com sucesso!')
        this.onSubmit();
      },
      err => {
        this.loading.showLoading(false);
        this.notification.error('Não foi possível emitir o voucher, se persistir contate o administrador do sistema.')
      }
    );
  }

  salvarTransportVoucher(vouchers) {
    this.loading.showLoading(true);
    this.transportVoucherService.insertRange(vouchers).subscribe(
      res => {
        this.loading.showLoading(false);
        this.notification.sucesso('Voucher emitido com sucesso!')
        this.onSubmit();
      },
      err => {
        this.loading.showLoading(false);
        this.notification.error('Não foi possível emitir o voucher, se persistir contate o administrador do sistema.')
      }
    );
  }

  salvarAccommodationVoucher(vouchers) {
    this.loading.showLoading(true);
    this.accommodationVoucherService.insertRange(vouchers).subscribe(
      res => {
        this.loading.showLoading(false);
        this.notification.sucesso('Voucher emitido com sucesso!')
        this.onSubmit();
      },
      err => {
        this.loading.showLoading(false);
        this.notification.error('Não foi possível emitir o voucher, se persistir contate o administrador do sistema.')
      }
    );
  }

  selecionarVoucher(): void {
    if (this.validateStatusSelecionar()) {
      return this.notification.error('Apenas Vouchers com Status Cancelado ou Não Emitidos podem ser emitidos novos voucher.', 3, 'top', 'center');
    }
    this.openModalTiposVoucher();
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.passageirosDataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.passageirosDataSource.data.forEach(row => this.selection.select(row));
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: Passenger): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id + 1}`;
  }
}


export class Passenger {
  id: string;
  nome: string;
  pnr: string;
  status: string;
  remarksSabre: string;
  quarto?: number;
}

const PASSENGERS_DATA: Passenger[] = [
  // { id: "1, nome: 'Camila Faleiro Rosa', pnr: 'IW5G7U', status: 'Emitido', remarksSabre: 'Pax perdeu a conexão em Salvador. Voucher Hotel: 232928321' },
  // { id: "2, nome: 'Yannick Patrício Abasto', pnr: 'XW6L7', status: 'Emitido', remarksSabre: 'Voucher 12398999 emitido em 24NOV20' },
  // { id: "3, nome: 'Kimi Aldeia lago', pnr: 'W19T2Q', status: 'Cancelado', remarksSabre: 'Transporte: 8273482723/724723823 (ida/volta)' },
  // { id: "4, nome: 'Kailany Santos Franqueir', pnr: 'JN7N2X', status: '', remarksSabre: 'Alimentação ou Refeição: 782738223' },
  // { id: "5, nome: 'Hawa Ninharelhos Lame', pnr: 'CM1N1Y', status: 'Cancelado', remarksSabre: 'Agent: kemsilva - Date: 13/11/2020 15h00' },
  // { id: "6, nome: 'Loécio Peralta Faro', pnr: '3N2X1Q', status: '', remarksSabre: '' },
  // { id: "7, nome: 'João Faleiro Rosa', pnr: 'IW5G7U', status: 'Emitido', remarksSabre: 'Pax perdeu a conexão em Salvador. Voucher Hotel: 232928321' },
  // { id: "8, nome: 'Amarilda Faleiro Rosa', pnr: 'IW5G7U', status: 'Emitido', remarksSabre: 'Pax perdeu a conexão em Salvador. Voucher Hotel: 232928321' },
  // { id: "9, nome: 'Camila Faleiro Rosa', pnr: 'IW5G7U', status: 'Cancelado', remarksSabre: 'Pax perdeu a conexão em Salvador. Voucher Hotel: 232928321' },
  // { id: "10, nome: 'Yannick Patrício Abasto', pnr: 'XW6L7', status: 'Cancelado', remarksSabre: 'Voucher 12398999 emitido em 24NOV20' },
  // { id: "11, nome: 'Kimi Aldeia lago', pnr: 'W19T2Q', status: 'Emitido', remarksSabre: 'Transporte: 8273482723/724723823 (ida/volta)' },
  // { id: 12, nome: 'Kailany Santos Franqueir', pnr: 'JN7N2X', status: 'Emitido', remarksSabre: 'Alimentação ou Refeição: 782738223' },
  // { id: 13, nome: 'Hawa Ninharelhos Lame', pnr: 'CM1N1Y', status: 'Emitido', remarksSabre: 'Agent: kemsilva - Date: 13/11/2020 15h00' },
  // { id: 14, nome: 'Loécio Peralta Faro', pnr: '3N2X1Q', status: 'Emitido', remarksSabre: '' },
  // { id: 15, nome: 'João Faleiro Rosa', pnr: 'IW5G7U', status: 'Emitido', remarksSabre: 'Pax perdeu a conexão em Salvador. Voucher Hotel: 232928321' },
  // { id: 16, nome: 'Amarilda Faleiro Rosa', pnr: 'IW5G7U', status: 'Emitido', remarksSabre: 'Pax perdeu a conexão em Salvador. Voucher Hotel: 232928321' },
];
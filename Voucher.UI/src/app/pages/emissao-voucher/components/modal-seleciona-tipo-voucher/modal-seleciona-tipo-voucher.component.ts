import { Component, Inject, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { of, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { FoodService } from 'src/app/services/food.service';
import { TransportService } from 'src/app/services/transport.service';
import { VoucherIssuanceRestrictionService } from 'src/app/services/voucher-issuance-restriction.service';
import { FlightDetailSabre } from 'src/app/shared/model/flight-detail-sabre.model';
import { VoucherIssuanceRestriction, VoucherType } from 'src/app/shared/model/voucher-issuance-restriction.model';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { Passenger } from '../../listar-passageiros/listar-passageiros.component';

export class TipoVoucher {
  name: string;
  selected: boolean;
  color: ThemePalette;
  subTipos?: TipoVoucher[];
  fornecedor?: string;
  textoPadrao?: string;
  disabled?: boolean;
  diarias?: number;
  permission?: boolean;
  fornecedorId?: number;
}
@Component({
  selector: 'app-modal-seleciona-tipo-voucher',
  templateUrl: './modal-seleciona-tipo-voucher.component.html',
  styleUrls: ['./modal-seleciona-tipo-voucher.component.scss']
})
export class ModalSelecionaTipoVoucherComponent implements OnInit {
  tipoVoucher: TipoVoucher = {
    name: 'Todos',
    selected: false,
    color: 'primary',
    subTipos: [
      // { name: 'Alimentação Refeição', selected: false, color: 'primary', fornecedor: '', textoPadrao: 'Bebida Alcóolica não inclusa.', disabled: false },
      // { name: 'Alimentação Lanche', selected: false, color: 'primary', fornecedor: '', textoPadrao: 'Válido para o restaurante acordado.', disabled: false },
      // { name: 'Transporte', selected: false, color: 'primary', fornecedor: '', textoPadrao: 'Não é permitido animais' },
      // { name: 'Hotel', selected: false, color: 'primary', diarias: 0 }
    ]
  };

  motivoEmissao: string = '';
  voucherType = VoucherType;

  fornecedoresFood = [];
  fornecedoresSnacks = [];
  fornecedoresTransport = [];
  private subjectPesquisaSnacks: Subject<string> = new Subject<string>();
  private subjectPesquisaFood: Subject<string> = new Subject<string>();
  private subjectPesquisaTransport: Subject<string> = new Subject<string>();

  constructor(
    public modalRef: MatDialogRef<ModalSelecionaTipoVoucherComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private voucherRestriService: VoucherIssuanceRestrictionService,
    private foodService: FoodService,
    private transportService: TransportService,
    private notification: NotificationService

  ) {
    console.log('-------ModalSelecionaTipoVoucherComponent----', data);

    this.buscarAuthorizationStatus(data.form);

    this.subjectInit();
  }

  subjectInit() {
    this.subjectPesquisaSnacks.pipe(
      debounceTime(1000),
      distinctUntilChanged(),
      switchMap((termoString) => {
        if (termoString === '') {
          return of<any[]>([]);
        }
        return this.foodService.getFornecedorSnacks(termoString);
      }),
    ).subscribe(
      (data) => this.fornecedoresSnacks = data,
    );

    this.subjectPesquisaFood.pipe(
      debounceTime(1000),
      distinctUntilChanged(),
      switchMap((termoString) => {
        if (termoString === '') {
          return of<any[]>([]);
        }
        return this.foodService.getFornecedorFood(termoString);
      }),
    ).subscribe(
      (data) => this.fornecedoresFood = data,
    );

    this.subjectPesquisaTransport.pipe(
      debounceTime(1000),
      distinctUntilChanged(),
      switchMap((termoString) => {
        if (termoString === '') {
          return of<any[]>([]);
        }
        return this.transportService.getListFilter(termoString);
      }),
    ).subscribe(
      (data) => this.fornecedoresTransport = data,
    );
  }

  ngOnInit() {

  }

  emitirVouchers() {
    let vouchersSelecionados = []
    this.tipoVoucher.subTipos.forEach(v => {
      if (v.selected) {
        vouchersSelecionados.push(v);
      }
    })

    const invalidVoucher = vouchersSelecionados.find(v => !v.fornecedorId || v.fornecedor === '');
    if (invalidVoucher && invalidVoucher.name !== 'Accommodation') {
      return this.notification.error(`O voucher ${invalidVoucher.name} não possui um fornecedor válido!`)
    }

    const isAccomodation = vouchersSelecionados.find(v => v.name === 'Accommodation');
    if (this.motivoEmissao == '') {
      return this.notification.error(`É necessário inserir o motivo da emissão do(s) voucher(s).`)
    }
    if (isAccomodation && (isAccomodation.diarias == 0 || !isAccomodation.diarias)) {
      return this.notification.error(`Informe a quantidade de diárias.`)
    }
    if (isAccomodation && (!this.data.vagas || this.data.vagas.length === 0)) {
      return this.notification.error(`O voucher ${isAccomodation.name} não possui nenhum passageiro alocado.`)
    }

    vouchersSelecionados.forEach(x => x.reason = this.motivoEmissao);
    console.log('vouchersSelecionados', vouchersSelecionados);

    this.modalRef.close({ isDistribuirVagasHoteis: false, vouchersSelecionados, hoteis: this.data.vagas });
  }

  onNoClick(): void {
    this.modalRef.close();
  }

  teste(event) {
    console.log('TESTE---', event);
  }

  distribuirVagasHotel() {
    let vouchersSelecionados = []
    this.tipoVoucher.subTipos.forEach(v => {
      if (v.selected) {
        vouchersSelecionados.push(v);
      }
    })
    this.modalRef.close({ isDistribuirVagasHoteis: true, vouchersSelecionados });
  }

  clearFields(tipo: TipoVoucher) {
    tipo.fornecedor = '';
    /* REGRA NÃO PODEM SER SELECIONADOS JUNTOS, É LANCHE OU REFEIÇÃO */
    if (tipo.name === 'Snacks') {
      this.tipoVoucher.subTipos.find(x => x.name === 'Food').disabled = tipo.selected;
    }
    if (tipo.name === 'Food') {
      this.tipoVoucher.subTipos.find(x => x.name === 'Snacks').disabled = tipo.selected;
    }
  }

  buscarAuthorizationStatus(form: FlightDetailSabre) {
    console.log('form buscarAuthorizationStatus', form);
    this.voucherRestriService.getList(form.flight, form.departureDate, form.origin).subscribe(
      res => {
        console.log('voucherRestriService res', res);
        if (res.length === 0) {
          this.modalRef.close();
          this.notification.error('Não existem vouchers autorizados para esse voo.');
        }

        res.forEach((e: VoucherIssuanceRestriction) => {
          let model = new TipoVoucher();
          // { name: 'Alimentação Refeição', selected: false, color: 'primary', fornecedor: '', textoPadrao: 'Bebida Alcóolica não inclusa.', disabled: false },
          model.name = this.voucherType[e.restrictionType];
          model.selected = false;
          model.color = 'primary';
          model.fornecedor = '';
          model.textoPadrao = '';
          model.disabled = false;
          model.permission = e.authorized;

          this.tipoVoucher.subTipos.push(model);

        })

        if (this.data.vouchers && this.data.vouchers.length > 0) {
          this.tipoVoucher.subTipos = this.tipoVoucher.subTipos.map(item => {
            let item2 = this.data.vouchers.find(i2 => i2.name === item.name);
            return item2 ? { ...item, ...item2 } : item;
          });
        }

        console.log('tipoVoucher----', this.tipoVoucher);

      },
      err => {
        console.log('err ', err);
      }
    );
  }

  onKey(termo: string, voucher: any, tipo: 'food' | 'snack' | 'transport') {
    if (termo === '') {
      voucher.fornecedor = '';
      voucher.textoPadrao = '';
      voucher.fornecedorId = null;
    }
    if (termo.length >= 2)
      switch (tipo) {
        case 'snack':
          this.subjectPesquisaSnacks.next(termo);
          break;
        case 'food':
          this.subjectPesquisaFood.next(termo);
          break;
        case 'transport':
          this.subjectPesquisaTransport.next(termo);
          break;
      }
  }

  fornecedorChange(fornecedor: any, tipo: TipoVoucher) {
    tipo.fornecedor = fornecedor.name;
    tipo.textoPadrao = fornecedor.freeText;
    tipo.fornecedorId = fornecedor.id;
  }


}

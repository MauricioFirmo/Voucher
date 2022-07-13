import { Component, ElementRef, Inject, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Passenger } from '../../listar-passageiros/listar-passageiros.component';
import { TipoVoucher } from '../modal-seleciona-tipo-voucher/modal-seleciona-tipo-voucher.component';
import { VagasHotel } from 'src/app/shared/model/vagas-hotel.model';
import { MatTable, MatTableDataSource } from '@angular/material/table';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { AccomodationVacancyService } from 'src/app/services/accomodation-vacancy.service';
import { AccommodationVacancy } from 'src/app/shared/model/accommodation-vacancy.model';

export interface Distribuicaovagas {
  passageiros: Passenger[];
  vouchers: TipoVoucher[];
}

export interface DataVagaQuarto {
  passageiro: Passenger;
  numeroQuarto: number;
}

export class Group {
  level = 0;
  parent: Group;
  expanded = true;
  totalCounts = 0;
  get visible(): boolean {
    return !this.parent || (this.parent.visible && this.parent.expanded);
  }
}
@Component({
  selector: 'app-modal-distribuicao-vagas-hoteis',
  templateUrl: './modal-distribuicao-vagas-hoteis.component.html',
  styleUrls: ['./modal-distribuicao-vagas-hoteis.component.scss'],
})
export class ModalDistribuicaoVagasHoteisComponent implements OnInit {
  panelOpenState = false
  vagas: VagasHotel[] = [];
  passageiros: Passenger[] = [];

  quartosCompartihados: any = [];
  quartosSingle: any = [];

  dataSourcePassageiros = new MatTableDataSource<any | Group>([]);
  dataSourceQuartosCompartilhados = new MatTableDataSource<any | Group>([]);
  dataSourceQuartosSingle = new MatTableDataSource<any | Group>([]);

  columnsPassageiros = [{ field: 'nome' }];
  displayedColumnsPassageiros = this.columnsPassageiros.map(column => column.field);
  groupByColumnsPassageiros = ['pnr'];

  columnsCompartilhado = [{ field: 'quarto' }];
  displayedColumnsCompartilhado = this.columnsCompartilhado.map(column => column.field);
  groupByColumnsCompartilhado = ['quarto', 'pnr'];

  columnsSingle = [{ field: 'nome' }];
  displayedColumnsSingle = this.columnsSingle.map(column => column.field);
  groupByColumnsSingle = ['pnr'];

  @ViewChild('dataTableCompartilhados') dataTableCompartilhados: ElementRef<MatTable<any>>;
  @ViewChild('dataTablePassageiros') dataTablePassageiros: ElementRef;
  @ViewChild('hoteis') hoteisElement: ElementRef;

  qtdQuartosCompartilhados: number[] = [];
  constructor(
    public modalRef: MatDialogRef<ModalDistribuicaoVagasHoteisComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private notification: NotificationService,
    private accomodationVacancyService: AccomodationVacancyService
  ) {
    console.log('-------ModalDistribuicaoVagasHoteisComponent-----', data);
    // this.vagas = data.vagas.sort((a, b) => a.prioridade - b.prioridade);
    this.passageiros = data.passageiros;
  }
  ngOnInit() {
    this.listarHoteis();
  }

  updateQtdQuartos(qtd: number, hotel: VagasHotel) {
    hotel.qtdQuartosCompartilhados = qtd;
  }

  countVagasRestantes(hotel: VagasHotel): number {
    let numQuartosOcupados = 0;
    for (let i = 0; i < hotel.qtdQuartosCompartilhados; i++) {
      const qtdPaxQuarto = hotel.passageirosQuartosCompartilhados.filter(p => p.quarto === i + 1)
      if (qtdPaxQuarto.length === hotel.limitePaxQrtCompart) {
        numQuartosOcupados++;
      }
    }

    return numQuartosOcupados;
  }

  async addPassengerSingle(passageiro: Passenger, hotel: VagasHotel) {
    if (hotel.mapSingle.size === 0) {
      passageiro.quarto = 1;
      hotel.mapSingle.set(1, passageiro);
    } else {

      if (hotel.mapSingle.size < hotel.qtdQuartosSingle) {
        passageiro.quarto = hotel.mapSingle.size + 1;

        hotel.mapSingle.set(hotel.mapSingle.size + 1, passageiro);
      } else {
        return this.notification.error('Limite de Quartos Single Atingido!', 5, 'top');
      }
    }

    hotel.passageirosQuartosSingle = [];
    for await (const m of hotel.mapSingle.keys()) {
      hotel.passageirosQuartosSingle.push(hotel.mapSingle.get(m));
    }

    const passengerToRemove = this.passageiros.find(p => p.id === passageiro.id);
    const index = this.passageiros.indexOf(passengerToRemove);
    this.passageiros.splice(index, 1);
    this.passageiros = [...this.passageiros];

    setTimeout(() => {
      this.dataTablePassageiros['ngOnInit']();
    }, 100);
  }

  addPassengerCompartilhado(data: DataVagaQuarto, hotel: VagasHotel) {
    const quantidadeNoQuartoX = hotel.passageirosQuartosCompartilhados.filter(p => p.quarto === data.numeroQuarto);
    if (quantidadeNoQuartoX.length === hotel.limitePaxQrtCompart) { // Regra de limite de Pax por quarto;
      return this.notification.error(`Limite de Pax(${hotel.limitePaxQrtCompart}) no Quarto ${data.numeroQuarto} atingido!`, 5, 'top');
    }
    const passageiro = Object.assign(data.passageiro);
    passageiro.quarto = data.numeroQuarto;

    hotel.passageirosQuartosCompartilhados.push(passageiro);
    hotel.passageirosQuartosCompartilhados = [...hotel.passageirosQuartosCompartilhados];

    const index = this.passageiros.findIndex(p => p.id === passageiro.id);
    this.passageiros.splice(index, 1);
    this.passageiros = [...this.passageiros];
  }

  removePassenger(passageiro: Passenger, hotel: VagasHotel, type: string) {
    if (type === 'single') {
      let index = hotel.passageirosQuartosSingle.findIndex(p => p.id === passageiro.id);
      hotel.passageirosQuartosSingle.splice(index, 1);
      hotel.passageirosQuartosSingle = [...hotel.passageirosQuartosSingle];
      hotel.mapSingle.delete(passageiro.quarto);
    } else {
      // COMPARTILHADOS!
      let indexArray = hotel.passageirosQuartosCompartilhados.findIndex(p => p.id === passageiro.id);
      hotel.passageirosQuartosCompartilhados.splice(indexArray, 1);
      hotel.passageirosQuartosCompartilhados = [...hotel.passageirosQuartosCompartilhados];
    }
    delete passageiro.quarto;
    this.passageiros.unshift(passageiro);
    this.passageiros = [...this.passageiros];
  }

  salvar() {
    console.log('--------SALVAR------', this.vagas);

    const hoteisComPassageiros = this.vagas.filter(v => v.passageirosQuartosCompartilhados.length > 0 || v.passageirosQuartosSingle.length > 0)
    this.modalRef.close({ vouchers: this.data.vouchers, vagas: hoteisComPassageiros });
  }

  listarHoteis() {
    this.accomodationVacancyService.getListOrderbyProvider().subscribe(
      res => {
        res.forEach((a: AccommodationVacancy) => {
          let model = new VagasHotel();
          model.base = a.accommodationProvider.airportIataCode;
          model.id = a.accommodationProvider.id;
          model.nome = a.accommodationProvider.name;
          model.ativo = a.accommodationProvider.active;
          model.data = a.dateTime;
          model.vagasDisponiveis = a.vacancies;
          model.vagasRestantes = a.vacancies;
          model.limitePaxQrtCompart = a.accommodationProvider.maxPaxPerSharedRoom;
          model.prioridade = a.accommodationProvider.priority;
          model.qtdQuartosSingle = 0;
          model.qtdQuartosCompartilhados = 0;
          model.qtdQuartosCompartilhadosArray = [];
          model.mapSingle = new Map();
          model.passageirosQuartosSingle = [];
          model.passageirosQuartosCompartilhados = [];
          model.id = a.accommodationProviderId;

          this.vagas.push(model);
        });

      },
      err => {
        this.notification.error('Não foi possível encontrar as informações dos hotéis. Tente novamente ou entre em contato com o administrador do sistema.');
      }
    );
  }

}

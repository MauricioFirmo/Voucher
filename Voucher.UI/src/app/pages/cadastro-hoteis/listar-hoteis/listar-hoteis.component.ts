import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AccomodationService } from 'src/app/services/accomodation.service';
import { LoadingService } from 'src/app/services/loading.service';
import { ModalConfirmacaoComponent } from 'src/app/shared/components/modal-confirmacao/modal-confirmacao.component';
import { Accomodation } from 'src/app/shared/model/accomodation.model';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-listar-hoteis',
  templateUrl: './listar-hoteis.component.html',
  styleUrls: ['./listar-hoteis.component.scss']
})
export class ListarHoteisComponent implements OnInit {
  hoteisData: any[] = [];
  headerTabelaHoteis: string[] = ['select', 'airportIataCode', 'name', 'phone', 'email', 'address', 'active', 'acoes'];
  isLoadingResults = false;

  constructor(
    private route: Router,
    private accomodationService: AccomodationService,
    private loading: LoadingService,
    private notification: NotificationService,
    private modal: MatDialog,
  ) { }

  ngOnInit() {
    this.listarHoteis();
  }

  atualizarVagas(e: Accomodation) {
    console.log('update----', e);
    this.route.navigateByUrl(`cadastro-hoteis/vagas-hospedagem/${e.airportIataCode}/${e.name}/${e.id}`);
  }

  listarHoteis(): void {
    this.loading.showLoading(true);
    this.accomodationService.getList().subscribe(
      res => {
        this.hoteisData = res ? res : [];
        this.loading.showLoading(false);
      }, err => {
        this.notification.error('Erro ao buscar lista de Hoteis');
        this.loading.showLoading(false);
      }
    );
  }

  excluir(e: Accomodation) {
    this.openModalConfirmacao(e);
  }

  abrir(e: Accomodation) {
    console.log('abrir----', e);
    this.route.navigateByUrl(`/cadastro-hoteis/visualizar/${e.id}`);
  }

  editar(e: Accomodation) {
    console.log('editar----', e);
    this.route.navigateByUrl(`/cadastro-hoteis/editar/${e.id}`);
  }

  openModalConfirmacao(e: Accomodation): void {
    const dialogRef = this.modal.open(ModalConfirmacaoComponent, {
      width: '250px',
      data: { titulo: 'Confirmação', pergunta: 'Deseja mesmo excluir esse hotel?' }
    });
    dialogRef.afterClosed().subscribe(result => {

      if (result) {
        this.loading.showLoading(true);
        this.accomodationService.delete(e.id).subscribe(
          res => {
            this.notification.sucesso('Hotel excluído com sucesso!')
            this.listarHoteis();
          }, err => {
            this.loading.showLoading(false);
          }
        );
      }
    });
  }


}

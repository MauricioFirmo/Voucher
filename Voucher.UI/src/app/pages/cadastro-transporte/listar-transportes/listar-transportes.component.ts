import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LoadingService } from 'src/app/services/loading.service';
import { TransportService } from 'src/app/services/transport.service';
import { ModalConfirmacaoComponent } from 'src/app/shared/components/modal-confirmacao/modal-confirmacao.component';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-listar-transportes',
  templateUrl: './listar-transportes.component.html',
  styleUrls: ['./listar-transportes.component.scss']
})
export class ListarTransportesComponent implements OnInit {
  transporteData: any[] = [];
  headerTabelaTransporte: string[] = ['select', 'airportIataCode', 'name', 'phone', 'email', 'address', 'transportType', 'price', 'active', 'acoes'];
  isLoadingResults = false;

  constructor(
    private transportService: TransportService,
    private loading: LoadingService,
    private notification: NotificationService,
    private modal: MatDialog,
    private route: Router) { }

  ngOnInit() {
    this.listarFornecedores();
  }


  listarFornecedores(): void {
    this.loading.showLoading(true);
    this.transportService.getList().subscribe(
      res => {
        this.transporteData = res ? res : [];
        this.loading.showLoading(false);
      }, err => {
        this.notification.error('Erro ao buscar lista de fornecedores');
        this.loading.showLoading(false);
      }
    );
  }

  excluir(e) {
    this.openModalConfirmacao(e);
  }

  abrir(e) {
    console.log('abrir----', e);
    this.route.navigateByUrl(`/cadastro-transporte/visualizar/${e.id}`);
  }

  editar(e) {
    console.log('editar----', e);
    this.route.navigateByUrl(`/cadastro-transporte/editar/${e.id}`);
  }

  update(e) {
    console.log('update----', e);
  }

  openModalConfirmacao(e: any): void {
    const dialogRef = this.modal.open(ModalConfirmacaoComponent, {
      width: '250px',
      data: { titulo: 'Confirmação', pergunta: 'Deseja mesmo excluir esse fornecedor?' }
    });
    dialogRef.afterClosed().subscribe(result => {

      if (result) {
        this.loading.showLoading(true);
        this.transportService.delete(e.id).subscribe(
          res => {
            this.notification.sucesso('Fornecedor excluído com sucesso!')
            this.listarFornecedores();
          }, err => {
            this.loading.showLoading(false);
          }
        );
      }
    });
  }

}

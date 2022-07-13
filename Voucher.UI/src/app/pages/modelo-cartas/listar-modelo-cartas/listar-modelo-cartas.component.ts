import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EmailService } from 'src/app/services/email.service';
import { LoadingService } from 'src/app/services/loading.service';
import { ModalConfirmacaoComponent } from 'src/app/shared/components/modal-confirmacao/modal-confirmacao.component';
import { AccommodationEmail } from 'src/app/shared/model/email.model';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-listar-modelo-cartas',
  templateUrl: './listar-modelo-cartas.component.html',
  styleUrls: ['./listar-modelo-cartas.component.scss']
})
export class ListarModeloCartasComponent implements OnInit {
  modeloCartasData: AccommodationEmail[] = [];
  headerTabelaModeloCartas: string[] = ['select', 'id', 'language', 'acoes'];
  isLoadingResults = false;

  constructor(
    private route: Router,
    private emailService: EmailService,
    private loading: LoadingService,
    private notification: NotificationService,
    private modal: MatDialog
  ) { }

  ngOnInit() {
    this.listarEmails();
  }

  excluir(e: AccommodationEmail) {
    this.openModalConfirmacao(e);
  }

  abrir(e: AccommodationEmail) {
    this.route.navigateByUrl(`/modelo-cartas/visualizar/${e.id}`);
  }

  editar(e: AccommodationEmail) {
    this.route.navigateByUrl(`/modelo-cartas/editar/${e.id}`);
  }

  listarEmails() {
    this.loading.showLoading(true);
    this.emailService.getList().subscribe(
      res => {
        this.modeloCartasData = res ? res : [];;
        this.loading.showLoading(false);
      }, err => {
        this.loading.showLoading(false);
      }
    );
  }

  openModalConfirmacao(e: AccommodationEmail): void {
    const dialogRef = this.modal.open(ModalConfirmacaoComponent, {
      width: '250px',
      data: { titulo: 'Confirmação', pergunta: 'Deseja mesmo excluir esse modelo?' }
    });
    dialogRef.afterClosed().subscribe(result => {

      if (result) {
        this.loading.showLoading(true);
        this.emailService.delete(e.id).subscribe(
          res => {
            console.log('excluir res', res);
            this.notification.sucesso('Modelo excluído com sucesso!')
            this.listarEmails();
          }, err => {
            console.log('excluir err', err);
            this.loading.showLoading(false);
          }
        );
      }
    });
  }
}

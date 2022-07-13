import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { FoodService } from 'src/app/services/food.service';
import { LoadingService } from 'src/app/services/loading.service';
import { ModalConfirmacaoComponent } from 'src/app/shared/components/modal-confirmacao/modal-confirmacao.component';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-listar-alimentacao',
  templateUrl: './listar-alimentacao.component.html',
  styleUrls: ['./listar-alimentacao.component.scss']
})
export class ListarAlimentacaoComponent implements OnInit {
  fornecedoresData: any[] = [];
  headerTabelaFornecedor: string[] = ['select', 'airportIataCode', 'name', 'phone', 'email', 'address', 'active', 'mealType', 'price', 'acoes'];
  isLoadingResults = false;

  constructor(
    private foodService: FoodService,
    private loading: LoadingService,
    private notification: NotificationService,
    private modal: MatDialog,
    private route: Router
    ) { }

  ngOnInit() {
    this.listarFornecedores();
  }


  listarFornecedores(): void {
    this.loading.showLoading(true);
    this.foodService.getList().subscribe(
      res => {
        this.fornecedoresData = res ? res : [];
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
    this.route.navigateByUrl(`/cadastro-alimentacao/visualizar/${e.id}`);
  }

  editar(e) {
    console.log('editar----', e);
    this.route.navigateByUrl(`/cadastro-alimentacao/editar/${e.id}`);
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
        this.foodService.delete(e.id).subscribe(
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

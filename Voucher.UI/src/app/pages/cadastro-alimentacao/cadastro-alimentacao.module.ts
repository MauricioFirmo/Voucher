import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CadastroAlimentacaoRoutingModule } from './cadastro-alimentacao.routing.module';
import { CadastrarAlimentacaoComponent } from './cadastrar-alimentacao/cadastrar-alimentacao.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ListarAlimentacaoComponent } from './listar-alimentacao/listar-alimentacao.component';
import { DataTableAlimentacaoComponent } from './data-table-alimentacao/data-table-alimentacao.component';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatNativeDateModule } from '@angular/material/core';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { ModalConfirmacaoModule } from 'src/app/shared/components/modal-confirmacao/modal-confirmacao.module';
import { MatDialogModule } from '@angular/material/dialog';
import { BaseFieldModule } from 'src/app/shared/components/base-field/base-filed.module';
@NgModule({
  imports: [
    CommonModule,
    CadastroAlimentacaoRoutingModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatInputModule,
    MatSelectModule,
    MatTableModule,
    MatTooltipModule,
    MatProgressSpinnerModule,
    MatCheckboxModule,
    MatIconModule,
    MatPaginatorModule,
    MatSortModule,
    MatNativeDateModule,
    MatSnackBarModule,
    MatDialogModule,
    BaseFieldModule
  ],
  declarations: [
    CadastrarAlimentacaoComponent,
    ListarAlimentacaoComponent,
    DataTableAlimentacaoComponent
  ],
  providers: [NotificationService]
})
export class CadastroAlimentacaoModule { }
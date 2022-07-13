import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CadastroHoteisRoutingModule } from './cadastro-hoteis.routing.module';
import { CadastrarHotelComponent } from './cadastrar-hotel/cadastrar-hotel.component';
import { ListarHoteisComponent } from './listar-hoteis/listar-hoteis.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import {MatTooltipModule } from '@angular/material/tooltip';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { DataTableHoteisComponent } from './data-table-hoteis/data-table-hoteis.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { NgxMaskModule, IConfig } from 'ngx-mask'
import { VagasHospedagemComponent } from './vagas-hospedagem/vagas-hospedagem.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { ModalConfirmacaoModule } from 'src/app/shared/components/modal-confirmacao/modal-confirmacao.module';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { BaseFieldModule } from 'src/app/shared/components/base-field/base-filed.module';

export const options: Partial<IConfig> | (() => Partial<IConfig>) = null;
@NgModule({
  imports: [
    CommonModule,
    CadastroHoteisRoutingModule,

    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    FlexLayoutModule,

    MatTableModule,
    MatCheckboxModule,
    MatIconModule,
    MatTooltipModule,
    MatProgressSpinnerModule,
    MatPaginatorModule,
    MatSortModule,

    NgxMaskModule.forRoot(),
    MatSnackBarModule,
    BaseFieldModule,
  ],
  declarations: [
    CadastrarHotelComponent,
    ListarHoteisComponent,
    VagasHospedagemComponent,
    DataTableHoteisComponent
  ],
  providers: [NotificationService]
})
export class CadastroHoteisModule { }

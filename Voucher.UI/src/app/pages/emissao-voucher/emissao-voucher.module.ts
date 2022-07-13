import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmissaoVoucherRoutingModule } from './emissao-voucher.routing.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ListarPassageirosComponent } from './listar-passageiros/listar-passageiros.component';
import { MatDividerModule } from '@angular/material/divider';
import { MatDialogModule } from '@angular/material/dialog';
import { ModalSelecionaTipoVoucherComponent } from './components/modal-seleciona-tipo-voucher/modal-seleciona-tipo-voucher.component';
import { MatCardModule } from '@angular/material/card';
import { ModalDistribuicaoVagasHoteisComponent } from './components/modal-distribuicao-vagas-hoteis/modal-distribuicao-vagas-hoteis.component';
import { MatExpansionModule } from '@angular/material/expansion';
import {MatTreeModule} from '@angular/material/tree';
import { DataTableDistribuicaoVagasComponent } from './components/data-table-distribuicao-vagas/data-table-distribuicao-vagas.component';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { MatMenuModule } from '@angular/material/menu';
import { BaseFieldModule } from 'src/app/shared/components/base-field/base-filed.module';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    EmissaoVoucherRoutingModule,
    ReactiveFormsModule,

    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    MatDividerModule,
    MatDialogModule,
    MatCardModule,
    MatExpansionModule,
    MatTableModule,
    MatCheckboxModule,
    MatIconModule,
    MatTooltipModule,
    MatProgressSpinnerModule,
    MatPaginatorModule,
    MatSortModule,
    MatSnackBarModule,
    MatTreeModule,
    MatMenuModule,
    MatAutocompleteModule,

    FlexLayoutModule,
    BaseFieldModule
  ],
  declarations: [ListarPassageirosComponent, ModalSelecionaTipoVoucherComponent, ModalDistribuicaoVagasHoteisComponent, DataTableDistribuicaoVagasComponent],
  entryComponents: [ModalSelecionaTipoVoucherComponent, ModalDistribuicaoVagasHoteisComponent],
  providers: [NotificationService]
})
export class EmissaoVoucherModule { }

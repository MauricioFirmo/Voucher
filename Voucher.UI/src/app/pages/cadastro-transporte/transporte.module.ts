import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TransporteRoutingModule } from './transporte.routing.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
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
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { ListarTransportesComponent } from './listar-transportes/listar-transportes.component';
import { CadastrarTransporteComponent } from './cadastrar-transporte/cadastrar-transporte.component';
import { DataTableTransporteComponent } from './components/data-table-transporte/data-table-transporte.component';
import { NgxMaskModule, IConfig } from 'ngx-mask'
import { NotificationService } from 'src/app/shared/services/notification.service';
import { BaseFieldModule } from 'src/app/shared/components/base-field/base-filed.module';
export const options: Partial<IConfig> | (() => Partial<IConfig>) = null;

@NgModule({
  imports: [
    CommonModule,
    TransporteRoutingModule,

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
    MatSnackBarModule,
    BaseFieldModule,

    NgxMaskModule.forRoot(),
  ],
  declarations: [ListarTransportesComponent, CadastrarTransporteComponent, DataTableTransporteComponent],
  providers: [NotificationService]
})
export class TransporteModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListarModeloCartasComponent } from './listar-modelo-cartas/listar-modelo-cartas.component';
import { CadastrarModeloCartasComponent } from './cadastrar-modelo-cartas/cadastrar-modelo-cartas.component';
import { ModeloCartasRoutingModule } from './modelo-cartas.routing.module';
import { DataTableModule } from 'src/app/shared/components/data-table/data-table.module';
import { MatButtonModule } from '@angular/material/button';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
  imports: [
    CommonModule,
    ModeloCartasRoutingModule,
    DataTableModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule,
    FlexLayoutModule,
    MatSnackBarModule
  ],
  declarations: [ListarModeloCartasComponent, CadastrarModeloCartasComponent],
  providers: [NotificationService]
})
export class ModeloCartasModule { }

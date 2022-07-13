import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AutorizacaoVoucherComponent } from './autorizacao-voucher.component';
import { AutorizacaoVoucherRoutingModule } from './autorizacao-voucher.routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { BaseFieldModule } from 'src/app/shared/components/base-field/base-filed.module';
@NgModule({
  imports: [
    CommonModule,
    AutorizacaoVoucherRoutingModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCardModule,
    MatDividerModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatSelectModule,
    FlexLayoutModule,
    MatSnackBarModule,
    MatAutocompleteModule,
    BaseFieldModule
  ],
  providers: [
    MatDatepickerModule,
    NotificationService
  ],
  declarations: [AutorizacaoVoucherComponent],
})
export class AutorizacaoVoucherModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalConfirmacaoComponent } from './modal-confirmacao.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  imports: [
    CommonModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule
  ],
  entryComponents: [ModalConfirmacaoComponent],
  declarations: [ModalConfirmacaoComponent],
  exports: [ModalConfirmacaoComponent]
})
export class ModalConfirmacaoModule { }

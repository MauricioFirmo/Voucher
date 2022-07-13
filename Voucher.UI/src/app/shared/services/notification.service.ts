import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition } from '@angular/material/snack-bar';

@Injectable()
export class NotificationService {

  constructor(private snackBar: MatSnackBar) { }

  sucesso(txtMensagem, durationSeconds = 5, verticalPosition: MatSnackBarVerticalPosition = 'bottom', horizontalPosition: MatSnackBarHorizontalPosition = 'end'): void {
    if (txtMensagem !== '' || txtMensagem === null) {
      this.snackBar.open(txtMensagem, 'X', {
        duration: durationSeconds * 1000,
        panelClass: 'notification-success',
        horizontalPosition,
        verticalPosition
      });
    }
  }

  error(txtMensagem, durationSeconds = 5, verticalPosition: MatSnackBarVerticalPosition = 'bottom', horizontalPosition: MatSnackBarHorizontalPosition = 'end'): void {
    if (txtMensagem !== '' || txtMensagem === null) {
      this.snackBar.open(txtMensagem, 'X', {
        duration: durationSeconds * 1000,
        panelClass: 'notification-error',
        horizontalPosition,
        verticalPosition
      });
    }
  }
}
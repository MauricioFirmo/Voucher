import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AutorizacaoVoucherComponent } from './autorizacao-voucher.component';


const routes: Routes = [
  { path: '', component: AutorizacaoVoucherComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AutorizacaoVoucherRoutingModule { }
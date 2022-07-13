import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListarPassageirosComponent } from './listar-passageiros/listar-passageiros.component';


const routes: Routes = [
  { path: '', component: ListarPassageirosComponent },
  { path: 'novo', component: null },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmissaoVoucherRoutingModule { }
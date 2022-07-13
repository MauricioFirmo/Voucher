import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CadastrarTransporteComponent } from './cadastrar-transporte/cadastrar-transporte.component';
import { ListarTransportesComponent } from './listar-transportes/listar-transportes.component';


const routes: Routes = [
  { path: 'listar', component: ListarTransportesComponent },
  { path: 'novo', component: CadastrarTransporteComponent },
  { path: 'editar/:id', component: CadastrarTransporteComponent },
  { path: 'visualizar/:id', component: CadastrarTransporteComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TransporteRoutingModule { }
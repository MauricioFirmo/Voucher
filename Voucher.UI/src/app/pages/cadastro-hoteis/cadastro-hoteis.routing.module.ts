import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CadastrarHotelComponent } from './cadastrar-hotel/cadastrar-hotel.component';
import { ListarHoteisComponent } from './listar-hoteis/listar-hoteis.component';
import { VagasHospedagemComponent } from './vagas-hospedagem/vagas-hospedagem.component';


const routes: Routes = [
  { path: 'listar', component: ListarHoteisComponent },
  { path: 'novo', component: CadastrarHotelComponent },
  { path: 'vagas-hospedagem/:iataCode/:name/:id', component: VagasHospedagemComponent },
  { path: 'editar/:id', component: CadastrarHotelComponent },
  { path: 'visualizar/:id', component: CadastrarHotelComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CadastroHoteisRoutingModule
{}

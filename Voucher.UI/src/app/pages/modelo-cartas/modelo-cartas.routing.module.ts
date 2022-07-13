import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CadastrarModeloCartasComponent } from './cadastrar-modelo-cartas/cadastrar-modelo-cartas.component';
import { ListarModeloCartasComponent } from './listar-modelo-cartas/listar-modelo-cartas.component';


const routes: Routes = [
  { path: 'listar', component: ListarModeloCartasComponent },
  { path: 'novo', component: CadastrarModeloCartasComponent },
  { path: 'editar/:id', component: CadastrarModeloCartasComponent },
  { path: 'visualizar/:id', component: CadastrarModeloCartasComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ModeloCartasRoutingModule { }
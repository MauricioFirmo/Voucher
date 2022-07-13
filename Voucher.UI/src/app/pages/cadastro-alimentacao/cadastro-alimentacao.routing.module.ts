import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CadastrarAlimentacaoComponent } from './cadastrar-alimentacao/cadastrar-alimentacao.component';
import { ListarAlimentacaoComponent } from './listar-alimentacao/listar-alimentacao.component';

const routes: Routes = [
    { path: 'listar', component: ListarAlimentacaoComponent },
    { path: 'novo', component: CadastrarAlimentacaoComponent },
    { path: 'editar/:id', component: CadastrarAlimentacaoComponent },
    { path: 'visualizar/:id', component: CadastrarAlimentacaoComponent },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class CadastroAlimentacaoRoutingModule { }
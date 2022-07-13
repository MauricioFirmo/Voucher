import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router'
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: '/inicio', pathMatch: 'full' },
  { path: 'login', loadChildren: () => import('./pages/login/login.module').then(m => m.LoginModule) },
  { path: 'inicio', loadChildren: () => import('./pages/inicio/inicio.module').then(m => m.InicioModule), canActivate: [AuthGuard] },
  { path: 'autorizacao-voucher', loadChildren: () => import('./pages/autorizacao-voucher/autorizacao-voucher.module').then(m => m.AutorizacaoVoucherModule), canActivate: [AuthGuard] },
  { path: 'cadastro-alimentacao', loadChildren: () => import('./pages/cadastro-alimentacao/cadastro-alimentacao.module').then(m => m.CadastroAlimentacaoModule), canActivate: [AuthGuard] },
  { path: 'cadastro-hoteis', loadChildren: () => import('./pages/cadastro-hoteis/cadastro-hoteis.module').then(m => m.CadastroHoteisModule), canActivate: [AuthGuard] },
  { path: 'cadastro-transporte', loadChildren: () => import('./pages/cadastro-transporte/transporte.module').then(m => m.TransporteModule), canActivate: [AuthGuard] },
  { path: 'modelo-cartas', loadChildren: () => import('./pages/modelo-cartas/modelo-cartas.module').then(m => m.ModeloCartasModule), canActivate: [AuthGuard] },
  { path: 'emissao-voucher', loadChildren: () => import('./pages/emissao-voucher/emissao-voucher.module').then(m => m.EmissaoVoucherModule), canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }


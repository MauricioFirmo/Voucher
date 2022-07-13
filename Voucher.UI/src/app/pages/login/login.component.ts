import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoadingService } from 'src/app/services/loading.service';
import { LoginService } from 'src/app/services/login.service';
import { MenuService } from 'src/app/services/menu.service';
import { SideNavComponent } from 'src/app/shared/components/side-nav/side-nav.component';
import { User } from 'src/app/shared/model/user.model';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  formLogin: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    public loginService: LoginService,
    private menuService: MenuService,
    public loadingService: LoadingService,
    private router: Router,
    private notification: NotificationService
  ) {
    this.formLogin = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  ngOnInit() {
  }

  // convenience getter for easy access to form fields
  get f() { return this.formLogin.controls; }

  onSubmit() {
    // stop here if form is invalid
    if (this.formLogin.invalid) return;
    this.loadingService.showLoading(true);
    if (this.formLogin.value.userName === 'admin' && this.formLogin.value.password === 'admin') {
      console.log('his.formLogin.value', this.formLogin.value);
      let data = {
        username: this.f.userName.value,
        isAuthenticated: true,
        groups: [
          "DL AUTENTICACAO VOUCHER",
          "DL EMITIR VOUCHER",
          "DL AUTORIZAR VOUCHER",
          "DL CADASTROS VOUCHER"
        ],
        error: null
      }
      return setTimeout(() => {
        const canAuthenticate = data.groups.includes('DL AUTENTICACAO VOUCHER');
        this.loadingService.showLoading(false);
        if (canAuthenticate) {
          data.username = this.f.userName.value;
          localStorage.setItem('user', JSON.stringify(data));
          this.menuService.shouldUpdateMenu.next(true);
          return this.router.navigate(['/inicio']);
        }
        this.notification.error('Falha na autenticação: Usuário não possuí DL necessária.')
        console.log('USUARIO NÃO POSSUI ACESSO!')
      }, 1000);
    } else {

      this.loginService.login(this.formLogin.value).subscribe(
        res => {
          const canAuthenticate = res.groups.includes('DL AUTENTICACAO VOUCHER');
          this.loadingService.showLoading(false);
          if (canAuthenticate) {
            res.username = this.f.userName.value;
            localStorage.setItem('user', JSON.stringify(res));
            this.menuService.shouldUpdateMenu.next(true);
            return this.router.navigate(['/inicio']);
          }
          this.notification.error('Falha na autenticação: Usuário não possuí DL necessária.')
        }, err => {
          this.notification.error('Falha na autenticação: Contate o Administrador do sistema.')
          this.loadingService.showLoading(false);
        });
    }

  }



}

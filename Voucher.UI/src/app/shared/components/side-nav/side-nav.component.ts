import { Component, OnChanges, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { LoginService } from 'src/app/services/login.service';
import { MenuService } from 'src/app/services/menu.service';
import { AuthenticatedUser } from '../../model/authenticated-user.model';
import { Menu } from '../../model/menu.model';

export type DL_VOUCHER = 'DL PROXY ESP TERCEIROS' | 'DL AUTENTICACAO VOUCHER' | 'DL EMITIR VOUCHER' | 'DL AUTORIZAR VOUCHER' | 'DL CADASTROS VOUCHER';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit, OnDestroy {

  @ViewChild('sidenav') sidenav: MatSidenav;
  authenticatedUser: AuthenticatedUser;
  menu: Menu = new Menu();

  constructor(private menuService: MenuService, public loginService: LoginService) {
  }

  ngOnInit() {
    this.menuService.shouldUpdateMenu.subscribe(value => {
      this.getUserDls();
      if (value || JSON.parse(localStorage.getItem('user'))) {
        this.menu = this.menuService.getMenuList(this.authenticatedUser.groups);
      }
    });
  }

  getUserDls(): void {
    this.authenticatedUser = JSON.parse(localStorage.getItem('user'));
  }

  checkIfContainsDL(dl: DL_VOUCHER): boolean {
    if (!this.authenticatedUser) {
      return false;
    }
    return this.authenticatedUser.groups.includes(dl);
  }

  ngOnDestroy() {
    this.menuService.shouldUpdateMenu.unsubscribe();
  }

}

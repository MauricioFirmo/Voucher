import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { LoadingService } from 'src/app/services/loading.service';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Output() toggleAction: EventEmitter<boolean> = new EventEmitter();

  openSideNav: boolean = true;

  constructor(public loginService: LoginService, public loadingService: LoadingService) { }

  ngOnInit() {
  }

  toggleSideNav(): void {
    this.openSideNav = !this.openSideNav;
    this.toggleAction.emit(this.openSideNav);
  }

  logout(): void {
    this.loginService.logout();
  }

}
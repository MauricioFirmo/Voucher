import { Component, ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { SideNavComponent } from './shared/components/side-nav/side-nav.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'gol-voucher-ui';

  @ViewChild('sidenavComponent') sidenavComponent: ElementRef<SideNavComponent>;

  constructor(private router: Router,) {
  }

  navigate() {
    this.router.navigate(['/login']);
  }

  toggleSideNav(toggle) {
    this.sidenavComponent['sidenav'].toggle();
  }
}
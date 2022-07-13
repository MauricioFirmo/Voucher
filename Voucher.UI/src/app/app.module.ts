import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { FlexLayoutModule } from '@angular/flex-layout';

import { SidenavModule } from './shared/components/side-nav/sidenav.module';
import { HeaderModule } from './shared/components/header/header.module';

import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
import { InterceptorModule } from './helpers/http-interceptor.module';
import { LoginService } from './services/login.service';

registerLocaleData(localePt);
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FlexLayoutModule,
    SidenavModule,
    HeaderModule,
    HttpClientModule,
    InterceptorModule
  ],
  providers: [
    { provide: LOCALE_ID, useValue: "pt-BR" },
    LoginService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

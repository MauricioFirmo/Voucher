import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthenticatedUser } from '../shared/model/authenticated-user.model';
import { User } from '../shared/model/user.model';
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(
    private router: Router,
    private http: HttpClient,
  ) { }

  isAuthenticated() {
    return localStorage.getItem('user');
  }

  login(user: User): Observable<AuthenticatedUser> {
    return this.http.post<AuthenticatedUser>(environment.API_URL + 'AD/GetADProfile', user);
  }

  logout() {
    this.router.navigate(["/login"]);
    localStorage.clear();
  }



}

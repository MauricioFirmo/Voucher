import { HttpClient } from '@angular/common/http';
import { InjectableCompiler } from '@angular/compiler/src/injectable_compiler';
import { Component, Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { AccommodationEmail } from '../shared/model/email.model';

@Injectable({ providedIn: 'root' })

export class EmailService {

  constructor(private http: HttpClient) { }

  get(idEmail: number): Observable<AccommodationEmail> {
    return this.http.get<AccommodationEmail>(environment.API_URL + `Email/Get?idEmail=${idEmail}`);
  }

  getList(): Observable<AccommodationEmail[]> {
    return this.http.get<AccommodationEmail[]>(environment.API_URL + 'Email/List');
  }

  insert(emailForm: AccommodationEmail): Observable<AccommodationEmail> {
    return this.http.post<AccommodationEmail>(environment.API_URL + 'Email/Create', emailForm);
  }

  update(emailForm: AccommodationEmail): Observable<AccommodationEmail> {
    return this.http.put<AccommodationEmail>(environment.API_URL + 'Email/Update', emailForm);
  }

  delete(idEmail: number): Observable<AccommodationEmail> {
    return this.http.delete<AccommodationEmail>(environment.API_URL + `Email/Delete?idEmail=${idEmail}`);
  }


}


import { HttpClient } from '@angular/common/http';
import { InjectableCompiler } from '@angular/compiler/src/injectable_compiler';
import { Component, Inject } from '@angular/core';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { SpecialService } from '../shared/model/special-service.model';

@Injectable({ providedIn: 'root' })

export class SpecialServicesService {

  constructor(private http: HttpClient) { }

  get(id: number): Observable<SpecialService> {
    return this.http.get<SpecialService>(environment.API_URL + `SpecialService/Get?id=${id}`);
  }

  getList(): Observable<SpecialService[]> {
    return this.http.get<SpecialService[]>(environment.API_URL + 'SpecialService/GetList');
  }

  insert(specialServicesForm: SpecialService): Observable<SpecialService> {
    return this.http.post<SpecialService>(environment.API_URL + 'SpecialService/Create', specialServicesForm);
  }

  update(specialServicesForm: SpecialService): Observable<SpecialService> {
    return this.http.put<SpecialService>(environment.API_URL + 'SpecialService/Update', specialServicesForm);
  }

  delete(id: number): Observable<SpecialService> {
    return this.http.delete<SpecialService>(environment.API_URL + `SpecialService/Delete?id=${id}`);
  }


}


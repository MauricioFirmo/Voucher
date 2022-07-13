import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Transport } from '../shared/model/transport.model';


@Injectable({ providedIn: 'root' })

export class TransportService {

  constructor(private http: HttpClient) { }

  get(id: number): Observable<Transport> {
    return this.http.get<Transport>(environment.API_URL + `TransportProvider/Get?id=${id}`);
  }

  getList(): Observable<Transport[]> {
    return this.http.get<Transport[]>(environment.API_URL + 'TransportProvider/GetList');
  }

  insert(transportForm: Transport): Observable<Transport> {
    return this.http.post<Transport>(environment.API_URL + 'TransportProvider/Insert', transportForm);
  }

  update(transportForm: Transport): Observable<Transport> {
    return this.http.put<Transport>(environment.API_URL + 'TransportProvider/Update', transportForm);
  }

  delete(id: number): Observable<Transport> {
    return this.http.delete<Transport>(environment.API_URL + `TransportProvider/Delete?id=${id}`);
  }

  getListFilter(name: string): Observable<Transport[]> {
    return this.http.get<Transport[]>(environment.API_URL + 'TransportProvider/GetList').pipe(map(res => {
      const filtered = res.filter(f => f.name.toLowerCase().includes(name.toLowerCase()));
      return filtered;
    }));;
  }
}

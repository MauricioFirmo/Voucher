import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Airport } from '../shared/model/airport.model';
@Injectable({ providedIn: 'root' })

export class AirportService {

  constructor(private http: HttpClient) { }

  get(id: number): Observable<Airport> {
    return this.http.get<Airport>(environment.API_URL + `Airport/Get?id=${id}`);
  }

  getList(): Observable<Airport[]> {
    return this.http.get<Airport[]>(environment.API_URL + 'Airport/List');
  }

  insert(foodForm: Airport): Observable<Airport> {
    return this.http.post<Airport>(environment.API_URL + 'Airport/Insert', foodForm);
  }

  update(foodForm: Airport): Observable<Airport> {
    return this.http.put<Airport>(environment.API_URL + 'Airport/Update', foodForm);
  }

  getAirportData(termo: string): Observable<Airport[]> {
    return this.http.get<Airport[]>("./assets/json/airport-base.json").pipe(map(res => {
      const filtered = res.filter(e => e.iatacode.toLowerCase().includes(termo.toLowerCase()) || e.name.toLowerCase().includes(termo.toLowerCase()) || e.shortname.toLowerCase().includes(termo.toLowerCase()))
      return filtered;
    }));
  }

}

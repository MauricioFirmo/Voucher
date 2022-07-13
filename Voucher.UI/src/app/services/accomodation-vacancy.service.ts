import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AccommodationVacancy } from '../shared/model/accommodation-vacancy.model';

@Injectable({
  providedIn: 'root'
})
export class AccomodationVacancyService {

  constructor(private http: HttpClient) { }

  get(idAccProvider: number, dateTime: string): Observable<AccommodationVacancy> {
    return this.http.get<AccommodationVacancy>(environment.API_URL + `AccommodationVacancy/Get?idAccProvider=${idAccProvider}&DateTime=${dateTime}`);
  }

  getList(): Observable<AccommodationVacancy[]> {
    return this.http.get<AccommodationVacancy[]>(environment.API_URL + 'AccommodationVacancy/List');
  }

  getListByProvider(idAccProvider: number): Observable<AccommodationVacancy[]> {
    return this.http.get<AccommodationVacancy[]>(environment.API_URL + `AccommodationVacancy/GetListByProvider?idAccProvider=${idAccProvider}`);
  }

  getListOrderbyProvider(): Observable<AccommodationVacancy[]> {
    return this.http.get<AccommodationVacancy[]>(environment.API_URL + `AccommodationVacancy/GetListOrderbyProvider`);
  }

  insert(accommodationProviderId: number, dateTime: string, vacancies: number): Observable<AccommodationVacancy> {
    dateTime = dateTime.toString();
    return this.http.post<AccommodationVacancy>(environment.API_URL + `AccommodationVacancy/Create?accommodationProviderId=${accommodationProviderId}&DateTime=${dateTime}&Vacancies=${vacancies}`, {});
  }

  update(accommodationProviderId: number, dateTime: string, vacancies: number): Observable<AccommodationVacancy> {
    return this.http.put<AccommodationVacancy>(environment.API_URL + `AccommodationVacancy/Save?accommodationProviderId=${accommodationProviderId}&DateTime=${dateTime}&Vacancies=${vacancies}`, {});
  }

  delete(idAccProvider: number, dateTime: string): Observable<AccommodationVacancy> {
    return this.http.delete<AccommodationVacancy>(environment.API_URL + `AccommodationVacancy/Delete?idAccProvider=${idAccProvider}&?DateTime=${dateTime}`);
  }

}

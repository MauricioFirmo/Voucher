import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AccommodationVoucher } from '../shared/model/accommodation-voucher.model';

@Injectable({
  providedIn: 'root'
})
export class AccommodationVoucherService {

  constructor(private http: HttpClient) { }

  get(id: number): Observable<AccommodationVoucher> {
    return this.http.get<AccommodationVoucher>(environment.API_URL + `AccommodationVoucher/Get?id=${id}`);
  }

  getList(): Observable<AccommodationVoucher[]> {
    return this.http.get<AccommodationVoucher[]>(environment.API_URL + 'AccommodationVoucher/GetList');
  }

  insert(accomodationVoucherForm: AccommodationVoucher): Observable<AccommodationVoucher> {
    return this.http.post<AccommodationVoucher>(environment.API_URL + 'AccommodationVoucher/Insert', accomodationVoucherForm);
  }

  insertRange(accomodationVoucherForm: AccommodationVoucher): Observable<AccommodationVoucher> {
    return this.http.post<AccommodationVoucher>(environment.API_URL + 'AccommodationVoucher/InsertRange', accomodationVoucherForm);
  }

  update(accomodationVoucherForm: AccommodationVoucher): Observable<AccommodationVoucher> {
    return this.http.put<AccommodationVoucher>(environment.API_URL + 'AccommodationVoucher/Update', accomodationVoucherForm);
  }

  delete(id: number): Observable<AccommodationVoucher> {
    return this.http.delete<AccommodationVoucher>(environment.API_URL + `AccommodationVoucher/Delete?id=${id}`);
  }

}

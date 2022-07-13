import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TransportVoucher } from '../shared/model/transport-voucher.model';

@Injectable({
  providedIn: 'root'
})
export class TransportVoucherService {

  constructor(private http: HttpClient) { }

  get(id: number): Observable<TransportVoucher> {
    return this.http.get<TransportVoucher>(environment.API_URL + `TransportVoucher/Get?id=${id}`);
  }

  getList(): Observable<TransportVoucher[]> {
    return this.http.get<TransportVoucher[]>(environment.API_URL + 'TransportVoucher/GetList');
  }

  insert(transporVoucherForm: TransportVoucher): Observable<TransportVoucher> {
    return this.http.post<TransportVoucher>(environment.API_URL + 'TransportVoucher/Insert', transporVoucherForm);
  }

  insertRange(transporVoucherForm: TransportVoucher[]): Observable<TransportVoucher> {
    return this.http.post<TransportVoucher>(environment.API_URL + 'TransportVoucher/InsertRange', transporVoucherForm);
  }

  update(transporVoucherForm: TransportVoucher): Observable<TransportVoucher> {
    return this.http.put<TransportVoucher>(environment.API_URL + 'TransportVoucher/Update', transporVoucherForm);
  }

  delete(id: number): Observable<TransportVoucher> {
    return this.http.delete<TransportVoucher>(environment.API_URL + `TransportVoucher/Delete?id=${id}`);
  }

}

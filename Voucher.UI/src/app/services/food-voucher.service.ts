import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FoodVoucher } from '../shared/model/food-voucher.model';

@Injectable({
  providedIn: 'root'
})
export class FoodVoucherService {

  constructor(private http: HttpClient) { }

  get(id: number): Observable<FoodVoucher> {
    return this.http.get<FoodVoucher>(environment.API_URL + `FoodVoucher/Get?id=${id}`);
  }

  getList(): Observable<FoodVoucher[]> {
    return this.http.get<FoodVoucher[]>(environment.API_URL + 'FoodVoucher/GetList');
  }

  insert(foodVoucherForm: FoodVoucher): Observable<FoodVoucher> {
    return this.http.post<FoodVoucher>(environment.API_URL + 'FoodVoucher/Insert', foodVoucherForm);
  }

  insertRange(foodVoucherForm: FoodVoucher): Observable<FoodVoucher> {
    return this.http.post<FoodVoucher>(environment.API_URL + 'FoodVoucher/InsertRange', foodVoucherForm);
  }

  update(foodVoucherForm: FoodVoucher): Observable<FoodVoucher> {
    return this.http.put<FoodVoucher>(environment.API_URL + 'FoodVoucher/Update', foodVoucherForm);
  }

  delete(id: number): Observable<FoodVoucher> {
    return this.http.delete<FoodVoucher>(environment.API_URL + `FoodVoucher/Delete?id=${id}`);
  }

}

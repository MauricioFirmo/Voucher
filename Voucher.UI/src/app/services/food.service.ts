import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Food } from '../shared/model/food.model';


@Injectable({ providedIn: 'root' })

export class FoodService {

  constructor(private http: HttpClient) { }

  get(id: number): Observable<Food> {
    return this.http.get<Food>(environment.API_URL + `FoodProvider/Get?id=${id}`);
  }

  getList(): Observable<Food[]> {
    return this.http.get<Food[]>(environment.API_URL + 'FoodProvider/GetList');
  }

  insert(foodForm: Food): Observable<Food> {
    return this.http.post<Food>(environment.API_URL + 'FoodProvider/Insert', foodForm);
  }

  update(foodForm: Food): Observable<Food> {
    return this.http.put<Food>(environment.API_URL + 'FoodProvider/Update', foodForm);
  }

  delete(id: number): Observable<Food> {
    return this.http.delete<Food>(environment.API_URL + `FoodProvider/Delete?id=${id}`);
  }

  getFornecedorSnacks(name: string): Observable<Food[]> {
    return this.http.get<Food[]>(environment.API_URL + 'FoodProvider/GetList').pipe(map(res => {
      const filtered = res.filter(f => f.mealType === 1 && f.name.toLowerCase().includes(name.toLowerCase()));
      return filtered;
    }));
  }

  getFornecedorFood(name: string): Observable<Food[]> {
    return this.http.get<Food[]>(environment.API_URL + 'FoodProvider/GetList').pipe(map(res => {
      const filtered = res.filter(f => f.mealType === 0 && f.name.toLowerCase().includes(name.toLowerCase()));
      return filtered;
    }));
  }
}

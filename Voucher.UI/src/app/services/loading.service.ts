import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  private loading: boolean;

  public showLoading(v: boolean) {
    this.loading = v;
  }

  public get isLoading(): boolean {
    return this.loading;
  }


  constructor() { }

}

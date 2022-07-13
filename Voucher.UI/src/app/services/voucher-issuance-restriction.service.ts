import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { VoucherIssuanceRestriction } from '../shared/model/voucher-issuance-restriction.model';

@Injectable({ providedIn: 'root' })

export class VoucherIssuanceRestrictionService {

    constructor(private http: HttpClient) { }

    get(id: number): Observable<VoucherIssuanceRestriction> {
        return this.http.get<VoucherIssuanceRestriction>(environment.API_URL + `VoucherIssuanceRestriction/Get?id=${id}`);
    }

    getList(flight: number, date: string, departureAirport: string): Observable<VoucherIssuanceRestriction[]> {
        return this.http.get<VoucherIssuanceRestriction[]>(environment.API_URL + `VoucherIssuanceRestriction/GetList?Flight=${flight}&Date=${date}&DepartureAirport=${departureAirport}`);
    }

    insert(voucherIssuanceRestrictionList: VoucherIssuanceRestriction[]): Observable<VoucherIssuanceRestriction> {
        return this.http.post<VoucherIssuanceRestriction>(environment.API_URL + 'VoucherIssuanceRestriction/Create', voucherIssuanceRestrictionList);
    }

    update(voucherIssuanceRestrictionList: VoucherIssuanceRestriction[]): Observable<VoucherIssuanceRestriction[]> {
        return this.http.put<VoucherIssuanceRestriction[]>(environment.API_URL + 'VoucherIssuanceRestriction/UpdateRange', voucherIssuanceRestrictionList);
    }

}

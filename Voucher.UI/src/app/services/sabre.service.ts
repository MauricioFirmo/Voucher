import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Accomodation } from '../shared/model/accomodation.model';
import { FlightDetailSabreDTO } from '../shared/model/DTO/flight-detail-sabre-dto';
import { PassengerInfo, PassengerSabreDTO } from '../shared/model/DTO/passenger-sabre-dto';
import { FlightDetailSabre } from '../shared/model/flight-detail-sabre.model';
import { PassengerListSabreRequest } from '../shared/model/passenger-list-request-sabre.model';

@Injectable({
  providedIn: 'root'
})
export class SabreService {

  constructor(private http: HttpClient) { }

  getPassengerList(passengerListForm: PassengerListSabreRequest): Observable<PassengerInfo[]> {
    return this.http.post<PassengerInfo[]>(environment.API_URL + 'Sabre/getPassengerList', passengerListForm);
  }

  getFlightDetailSabre(flightDetailForm: FlightDetailSabre): Observable<FlightDetailSabreDTO> {
    return this.http.post<FlightDetailSabreDTO>(environment.API_URL + 'Sabre/GetFlightDetailSabre', flightDetailForm);
  }

  updateReserveSabre(accomodationForm: Accomodation): Observable<Accomodation> {
    return this.http.post<Accomodation>(environment.API_URL + 'Sabre/UpdateReserveSabre', accomodationForm);
  }

}

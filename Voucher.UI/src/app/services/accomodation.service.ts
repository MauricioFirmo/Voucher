import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Accomodation } from '../shared/model/accomodation.model';
import { Hotel } from '../shared/model/hotel.model';
import { VagasHotel } from '../shared/model/vagas-hotel.model';

@Injectable({
  providedIn: 'root'
})
export class AccomodationService {

  constructor(private http: HttpClient) { }


  getHoteis() {
    const hotelData: Hotel[] = [
      {
        id: 1,
        base: 'CGH',
        nome: 'IBIS Congonhas',
        telefone: '(11) 2222-3333',
        email: 'ibisbudget@ibis.com.br',
        endereco: 'R. Baronesa de Bela Vista 801 - Vila Congonhas',
        ativo: true,
        limitePaxQrtCompart: 2,
        prioridade: 1
      },
      {
        id: 2,
        base: 'SDU',
        nome: 'Hilton Santos Drumont',
        telefone: '(21) 8888-99999',
        email: 'hiltonbudget@hiilton.com.br',
        endereco: 'R. Joquin Lerna 301 - Centro',
        ativo: false,
        limitePaxQrtCompart: 3,
        prioridade: 2
      },
      {
        id: 4,
        base: 'GRU',
        nome: 'Plaza Congonhas',
        telefone: '(21) 5555-66666',
        email: 'plazahotel@plaza.com.br',
        endereco: 'R. E. Ribeiro 007 - Gávea',
        ativo: true,
        limitePaxQrtCompart: 4,
        prioridade: 10
      }
    ];
    return hotelData;
  }

  getVagas() {
    const vagasData: VagasHotel[] = [
      {
        base: 'CGH',
        id: 1,
        nome: 'IBIS Congonhas',
        ativo: true,
        data: '24NOV20',
        vagasDisponiveis: 10,
        vagasRestantes: 8,
        limitePaxQrtCompart: 2,
        prioridade: 10,
        qtdQuartosSingle: 2,
        qtdQuartosCompartilhados: 3,
        qtdQuartosCompartilhadosArray: [],
        mapSingle: new Map(),
        passageirosQuartosSingle: [],
        passageirosQuartosCompartilhados: [],
      },
      {
        id: 1,
        base: 'SDU',
        nome: 'Transamerica Flat',
        ativo: true,
        data: '22NOV20',
        vagasDisponiveis: 12,
        vagasRestantes: 12,
        limitePaxQrtCompart: 3,
        prioridade: 1,
        qtdQuartosSingle: 5,
        qtdQuartosCompartilhados: 3,
        qtdQuartosCompartilhadosArray: [],
        mapSingle: new Map(),
        passageirosQuartosSingle: [],
        passageirosQuartosCompartilhados: [],
      },
      {
        id: 1,
        base: 'GDU',
        nome: 'Hilton',
        ativo: true,
        data: '21NOV20',
        vagasDisponiveis: 20,
        vagasRestantes: 15,
        limitePaxQrtCompart: 4,
        prioridade: 20,
        qtdQuartosSingle: 1,
        qtdQuartosCompartilhados: 2,
        qtdQuartosCompartilhadosArray: [],
        mapSingle: new Map(),
        passageirosQuartosSingle: [],
        passageirosQuartosCompartilhados: [],
      },

    ];
    return vagasData;
  }

  get(id: number): Observable<Accomodation> {
    return this.http.get<Accomodation>(environment.API_URL + `AccommodationProvider/Get?id=${id}`);
  }

  getList(): Observable<Accomodation[]> {
    return this.http.get<Accomodation[]>(environment.API_URL + 'AccommodationProvider/GetList');
  }

  insert(accomodationForm: Accomodation): Observable<Accomodation> {
    return this.http.post<Accomodation>(environment.API_URL + 'AccommodationProvider/Insert', accomodationForm);
  }

  update(accomodationForm: Accomodation): Observable<Accomodation> {
    return this.http.put<Accomodation>(environment.API_URL + 'AccommodationProvider/Update', accomodationForm);
  }

  delete(id: number): Observable<Accomodation> {
    return this.http.delete<Accomodation>(environment.API_URL + `AccommodationProvider/Delete?id=${id}`);
  }

}

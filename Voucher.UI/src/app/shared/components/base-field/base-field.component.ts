import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { of, Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { AirportService } from 'src/app/services/airport.service';
import { Airport } from '../../model/airport.model';

@Component({
  selector: 'app-base-field',
  templateUrl: './base-field.component.html',
  styleUrls: ['./base-field.component.scss']
})
export class BaseFieldComponent implements OnInit {
  private subjectPesquisaBase: Subject<string> = new Subject<string>();
  airportsData: Airport[] = [];

  @Input() value: string = '';
  @Input() showValidation = false;
  @Input() isDisabled = false;
  @Output() airportSelected = new EventEmitter();

  constructor(private airportService: AirportService,) { }

  ngOnInit() {
    this.subjectPesquisaBase.pipe(
      debounceTime(1000),
      distinctUntilChanged(),
      switchMap((termoString) => {
        if (termoString === '') {
          return of<any[]>([]);
        }
        return this.airportService.getAirportData(termoString);
      }),
    ).subscribe(
      (data) => this.airportsData = data,
    );
  }

  onKey(termo: string, isObra?: boolean) {
    if (termo.length >= 2)
      this.subjectPesquisaBase.next(termo);
  }

  airportSelect(airport) {
    this.airportSelected.emit(airport);
  }

}

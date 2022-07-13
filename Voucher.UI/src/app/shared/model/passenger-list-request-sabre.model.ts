export class PassengerListSabreRequest {
    codeList: string[] = ["ON", "XON"];
    strAirline: string = 'G3';
    strFilght: string;
    departureDate: string;
    strOrigin: string;
    hasFilter: boolean = true;
    filterType: string = 'OR';
}
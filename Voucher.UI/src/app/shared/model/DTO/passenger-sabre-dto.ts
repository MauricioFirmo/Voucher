export class PassengerSabreDTO {
    arrivalTimeField: string;
    departureTimeField: string;
    estimated_ArrivalDateField: string;
    estimated_DepartureDateField: string;
    scheduled_ArrivalDateField: string;
    scheduled_DepartureDateField: string;
    aircraftTypeField: string;
    destinationField: string;
    originField: string;
    passengerInfo: PassengerInfo[]
}

export class PassengerInfo {
    destination: string;
    dtInsert: Date | string;
    flightId: number;
    flightdate: Date | string;
    id: number;
    idpassenger: string;
    origin: string;
    passengerName: string;
    pnr: string;
    remark: string;
    username: string;
    voucherId: number;
    voucherstatus: boolean;
}
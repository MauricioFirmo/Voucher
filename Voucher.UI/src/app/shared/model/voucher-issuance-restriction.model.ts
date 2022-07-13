export class VoucherIssuanceRestriction {
    id?: number;
    sabreId?: string;
    flightNumber?: number;
    std?: Date | string;
    sta?: Date | string;
    international?: boolean;
    departureAirport?: string;
    arrivalAirport?: string;
    restrictionType: number;
    username?: string;
    authorized: boolean;
    updatedate?: Date | string;
}

export enum VoucherType {
    Accommodation,
    Transport,
    Food,
    Snacks
}
export class FoodVoucher {
    id?: number;
    discriminator: string;
    createdBy: string;
    canceledBy: string;
    createdDate: Date;
    validUntil: Date;
    canceledDate: Date;
    printedDate: Date;
    serviceProviderId: number;
    freeText: string;
    flightId: number;
    isActive: boolean;
    pseudoCityCode: string;
    idPassenger: string;
    passengerName: string;
    status: number;
    reason: string;
}
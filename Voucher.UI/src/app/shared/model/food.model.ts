export class Food {
    id?: number;
    discriminator: string;
    airportIataCode: string;
    name: string;
    phone: string;
    email: string;
    address: string;
    active: true;
    priority: number;
    distance: number;
    freeText: string;
    createdBy: string;
    createdDate: Date;
    lastModifiedBy: string;
    lastModifiedDate: Date;
    price: number;
    mealType: number;
}
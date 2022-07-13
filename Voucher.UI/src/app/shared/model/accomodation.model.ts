import { AccommodationEmail } from "./email.model";

export class Accomodation {
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
    sapCode: string;
    mealPrice: number;
    createdDate: Date;
    maxPaxPerSharedRoom: number;
    accommodationEmailTemplate: AccommodationEmail;
    accommodationEmailTemplateId: number;
    accommodationProviderSpecialServices: [
        {
            accommodationProviderId: number;
            specialServiceId: number;
            specialService: {
                id: number;
                name: string;
                accommodationProviderSpecialServices: []
            }
        }
    ];
    specialServices: any;
    vacancies: [
        {
            accommodationProviderId: number;
            dateTime: Date;
            vacancies: number;
        }
    ]
}
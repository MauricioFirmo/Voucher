export class AccommodationVacancy {
    accommodationProvider: {
        sapCode: string;
        mealPrice: number;
        maxPaxPerSharedRoom: number;
        accommodationEmailTemplate: any;
        accommodationEmailTemplateId: number;
        accommodationProviderSpecialServices: any;
        id?: number;
        discriminator: any;
        airportIataCode: string;
        name: string;
        phone: string;
        email: string;
        address: string;
        active: boolean;
        priority: number;
        distance: number;
        freeText: string;
        createdBy: string;
        createdDate: Date;
        lastModifiedBy: string;
        lastModifiedDate: Date
    };
    accommodationProviderId?: number;
    dateTime: Date;
    vacancies: number;
}
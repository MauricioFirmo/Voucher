export class AccommodationProviderSpecialServices {
    accommodationProviderId: number = 0;
    specialServiceId: number = 0;
    specialService: SpecialService;
}

export class SpecialService {
    id: number = 0;
    name: string = '';
    accommodationProviderSpecialServices: any = null;
}
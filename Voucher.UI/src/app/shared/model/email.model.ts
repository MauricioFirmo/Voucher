export class AccommodationEmail {
    id: number;
    language: string;
    subject: string;
    body: string;
}

export enum Language {
    Portuguese,
    English,
    Spanish
}
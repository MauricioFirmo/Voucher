export class Hotel {
    id: number;
    base: string;
    nome: string;
    telefone: string;
    email: string;
    endereco: string;
    ativo: boolean;
    prioridade: number;
    limitePaxQrtCompart: number;
    codigoSap?: string;
    celular?: string;
    distanciaKm?: number;
    valorRefeicao?: number;
    possuiTranslado?: boolean;
    aceitaPet?: boolean;
    textoPadrao?: string;
    idiomaCartaPadrao?: string;
}
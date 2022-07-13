import { Passenger } from "src/app/pages/emissao-voucher/listar-passageiros/listar-passageiros.component";

export class VagasHotel {
    id: number;
    base: string;
    nome: string;
    ativo: boolean;
    data: Date | string;
    vagasDisponiveis: number;
    vagasRestantes: number;
    limitePaxQrtCompart: number;
    qtdQuartosSingle: number;
    qtdQuartosCompartilhados: number;
    qtdQuartosCompartilhadosArray: number[];
    prioridade: number;
    mapSingle: Map<number, Passenger>;
    passageirosQuartosSingle?: Passenger[];
    passageirosQuartosCompartilhados?: Passenger[];
}
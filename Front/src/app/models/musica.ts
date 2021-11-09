import { Artista } from "./artista";

export class Musica {

    Id?: number;
    nome!: string;
    genero!: string;
    lancamento!: Date;
    artista!: Artista;
}

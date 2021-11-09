import { Artista } from "./artista";
import { Musica } from "./musica";

export class Album {

    Id?: number;
    nome!: string;
    musicas!: Musica[];
    artista!: Artista;
    criadoEm!: Date;

}

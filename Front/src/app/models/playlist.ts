import { Musica } from "./musica";

export class Playlist {

    Id?: number;
    nome!: string;
    criadoEm?: Date;
    musicas!: Musica[];
}

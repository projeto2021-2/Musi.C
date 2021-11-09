import { Biblioteca } from "./biblioteca";
import { Musica } from "./musica";

export class Usuario {

    UserId!: number;
    Login!: string;
    Classe!: string;
    bibliotecas?: Biblioteca[];
    favoritas?: Musica[];
}

import { Album } from "./album";
import { Usuario } from "./usuario";

export class Artista {

    Id?: number;
    nome!: string;
    integrantes!: Usuario[];
    albuns?: Album[];
}

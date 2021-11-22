import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Musica } from '../models/musica';

@Injectable({
  providedIn: 'root'
})
export class MusicaService {

  baseURL = "https://localhost:5001/api/musica";

  constructor(private http: HttpClient) { }

  listar(): Observable<Musica[]>
  {
    return this.http.get<[]>(`${this.baseURL}`);
  }

  cadastrar(musica: Musica): Observable<Musica>
  {
    return this.http.post<Musica>(`${this.baseURL}`, musica);
  }

  listarPorId(id: number): Observable<Musica>
  {
    return this.http.get<Musica>(`${this.baseURL}/${id}`);
  }

  editar(musica: Musica, id: number): Observable<Musica>
  {
    return this.http.put<Musica>(`${this.baseURL}/${id}`, musica);
  }

  deletar(id: number): Observable<Musica>
  {
    return this.http.delete<Musica>(`${this.baseURL}/${id}`);
  }
}

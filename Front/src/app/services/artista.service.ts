import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Artista } from '../models/artista';

@Injectable({
  providedIn: 'root'
})
export class ArtistaService {

  baseURL = "https://localhost:5001/api/artista";

  constructor(private http: HttpClient) { }

  listar(): Observable<Artista[]>
  {
    return this.http.get<Artista[]>(`${this.baseURL}`);
  }

  cadastrar(artista: Artista): Observable<Artista>
  {
    return this.http.post<Artista>(`${this.baseURL}`, artista);
  }

  listarPorId(id: number): Observable<Artista>
  {
    return this.http.get<Artista>(`${this.baseURL}/${id}`);
  }

  editar(artista: Artista, id: number): Observable<Artista>
  {
    return this.http.put<Artista>(`${this.baseURL}/${id}`, artista);
  }

  deletar(id: number): Observable<Artista>
  {
    return this.http.delete<Artista>(`${this.baseURL}/${id}`);
  }
}

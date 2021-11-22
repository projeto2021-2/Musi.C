import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Biblioteca } from '../models/biblioteca';

@Injectable({
  providedIn: 'root'
})
export class BibliotecaService {

  baseURL = "https://localhost:5001/api/biblioteca";

  constructor(private http: HttpClient) { }

  listar(): Observable<Biblioteca[]>
  {
    return this.http.get<Biblioteca[]>(`${this.baseURL}`);
  }

  cadastrar(biblioteca: Biblioteca): Observable<Biblioteca>
  {
    return this.http.post<Biblioteca>(`${this.baseURL}`, biblioteca);
  }

  listarPorId(id: number): Observable<Biblioteca>
  {
    return this.http.get<Biblioteca>(`${this.baseURL}/${id}`);
  }

  editar(biblioteca: Biblioteca, id: number): Observable<Biblioteca>
  {
    return this.http.put<Biblioteca>(`${this.baseURL}/${id}`, biblioteca);
  }

  deletar(id: number): Observable<Biblioteca>
  {
    return this.http.delete<Biblioteca>(`${this.baseURL}/${id}`);
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../models/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  baseURL = "https://localhost:5001/api/usuario";

  constructor(private http: HttpClient) { }

  listar(): Observable<Usuario[]>
  {
    return this.http.get<Usuario[]>(`${this.baseURL}`);
  }

  cadastrar(usuario: Usuario): Observable<Usuario>
  {
    return this.http.post<Usuario>(`${this.baseURL}`, usuario);
  }

  listarPorId(id: number): Observable<Usuario>
  {
    return this.http.get<Usuario>(`${this.baseURL}/${id}`);
  }

  editar(usuario: Usuario, id: number): Observable<Usuario>
  {
    return this.http.put<Usuario>(`${this.baseURL}/${id}`, usuario);
  }

  deletar(id: number): Observable<Usuario>
  {
    return this.http.delete<Usuario>(`${this.baseURL}/${id}`);
  }
}

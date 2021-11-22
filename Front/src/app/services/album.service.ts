import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Album } from '../models/album';

@Injectable({
  providedIn: 'root'
})
export class AlbumService {

  baseURL = "https://localhost:5001/api/album";

  constructor(private http: HttpClient) { }

  listar(): Observable<Album[]>
  {
    return this.http.get<Album[]>(`${this.baseURL}`);
  }

  cadastrar(album: Album): Observable<Album>
  {
    return this.http.post<Album>(`${this.baseURL}`, album);
  }

  listarPorId(id: number): Observable<Album>
  {
    return this.http.get<Album>(`${this.baseURL}/${id}`);
  }

  editar(album: Album, id: number): Observable<Album>
  {
    return this.http.put<Album>(`${this.baseURL}/${id}`, album);
  }

  deletar(id: number): Observable<Album>
  {
    return this.http.delete<Album>(`${this.baseURL}/${id}`);
  }
}

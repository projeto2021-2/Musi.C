import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Playlist } from '../models/playlist';

@Injectable({
  providedIn: 'root'
})
export class PlaylistService {

  baseURL = "https://localhost:5001/api/playlist";

  constructor(private http: HttpClient) { }

  listar(): Observable<Playlist[]>
  {
    return this.http.get<Playlist[]>(`${this.baseURL}`);
  }

  cadastrar(playlist: Playlist): Observable<Playlist>
  {
    return this.http.post<Playlist>(`${this.baseURL}`, playlist);
  }

  listarPorId(id: number): Observable<Playlist>
  {
    return this.http.get<Playlist>(`${this.baseURL}/${id}`);
  }

  editar(playlist: Playlist, id: number): Observable<Playlist>
  {
    return this.http.put<Playlist>(`${this.baseURL}/${id}`, playlist);
  }

  deletar(id: number): Observable<Playlist>
  {
    return this.http.delete<Playlist>(`${this.baseURL}/${id}`);
  }
}

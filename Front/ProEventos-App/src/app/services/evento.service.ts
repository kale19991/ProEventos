import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Evento } from './../models/Evento';
import { Observable } from 'rxjs';
import { Result } from '../helps/response';

@Injectable(
  //{ providedIn: 'root'}
)
export class EventoService {
  private baseURL = 'https://localhost:5001/api/Evento';

  constructor(private http: HttpClient) { }

  getEventos(): Observable<Result<Evento[]>> {
    return this.http.get<Result<Evento[]>>(this.baseURL);
  }

  getEventoByTema(tema: string): Observable<Result<Evento[]>> {
    return this.http.get<Result<Evento[]>>(`${this.baseURL}/${tema}/tema`);
  }

  getEventoById(id: number): Observable<Result<Evento>> {
    return this.http.get<Result<Evento>>(`${this.baseURL}/${id}`);
  }
}

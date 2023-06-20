import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Evento } from '../models/Evento';
import { Result } from '../helpers/response';
import { EventoService } from '../services/evento.service';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos: Evento[] = [];
  public eventosFiltrado: Evento[] = [];
  public larguraImagem: number = 150;
  public margemImagem: number = 2;
  public mostraImagem: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrado = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.eventos.filter((evento: { tema: string; local: string }) =>
      evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      )
  }
  /**
   *
   */
  constructor(private eventoService: EventoService ) {

  }
  ngOnInit(): void {
    this.getEventos();
    this.eventosFiltrado = this.eventos;
  }

  public getEventos(): void {
    this.eventoService.getEventos().subscribe(
      response => {
        this.eventos = response.data
        this.eventosFiltrado = response.data;
      },
      error => console.log(error)
    );
  }

  public mostrarImg()
  {
    this.mostraImagem = !this.mostraImagem
  }

}

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos: any = [];
  /**
   *
   */
  constructor(private http: HttpClient ) {

  }
  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    // this.eventos =
    // [
    //   {
    //     Tema: 'Angular',
    //     Local: 'Belo Horizonte'
    //   },
    //   {
    //     Tema: '.NET 5',
    //     Local: 'São Paulo'
    //   },
    //   {
    //     Tema: 'Angular e Suas Novidades',
    //     Local: 'Rido de Janeiro'
    //   }
    // ]
    this.http.get('https://localhost:5001/api/evento').subscribe(
      response => this.eventos = response,
      error => console.log(error)
    );
  }

}

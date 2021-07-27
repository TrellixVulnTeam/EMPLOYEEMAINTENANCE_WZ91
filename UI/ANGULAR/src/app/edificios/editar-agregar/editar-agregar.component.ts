import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-editar-agregar',
  templateUrl: './editar-agregar.component.html',
  styleUrls: ['./editar-agregar.component.css']
})
export class EditarAgregarComponent implements OnInit {


 @Input() edificio: any;
 edificiosId: number = 0 ;
 edificioNum: string= "" ;
 edificioDireccion: string = "";
 tipoEdif: string = "";
 nivelCal: string = "";
 categor: string = "";

  constructor() { }

  ngOnInit(): void {
    this.edificiosId = this.edificio.edificiosId;
    this.edificioNum = this.edificio.edificioNum;
    this.edificioDireccion = this.edificio.edificioDireccion;
    this.tipoEdif = this.edificio.tipoEdif;
    this.nivelCal = this.edificio.nivelCal;
    this.categor = this.edificio.categor;
  }

}

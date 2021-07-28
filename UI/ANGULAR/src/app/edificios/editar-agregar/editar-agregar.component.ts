import { Component, OnInit, Input } from '@angular/core';
import { ManagmentService } from 'src/app/services/managment.service';

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


  constructor(private managmentService: ManagmentService) { }

  ngOnInit(): void {
    this.edificiosId = this.edificio.edificiosId;
    this.edificioNum = this.edificio.edificioNum;
    this.edificioDireccion = this.edificio.edificioDireccion;
    this.tipoEdif = this.edificio.tipoEdif;
    this.nivelCal = this.edificio.nivelCal;
    this.categor = this.edificio.categor;
  }

  agregarEdificio(){
    var edificio = {
      edificiosId : this.edificiosId,
      edificioNum : this.edificioNum,
      edificioDireccion : this.edificioDireccion,
      tipoEdif : this.tipoEdif,
      nivelCal : this.nivelCal,
      categor : this.categor
    }

    this.managmentService.añadirEdificio(edificio)
        .subscribe( res => {
          console.log(res)
        })
  }

  actualizarEdificio(){
    var edificio = {
      edificiosId : this.edificiosId,
      edificioNum : this.edificioNum,
      edificioDireccion : this.edificioDireccion,
      tipoEdif : this.tipoEdif,
      nivelCal : this.nivelCal,
      categor : this.categor
    }

    this.managmentService.actualizarEdificio(edificio)
        .subscribe( res => {
          console.log(res)
        })
  }

}

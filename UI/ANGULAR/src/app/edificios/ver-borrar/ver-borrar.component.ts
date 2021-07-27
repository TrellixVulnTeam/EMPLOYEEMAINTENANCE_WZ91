import { Component, OnInit } from '@angular/core';
import { ManagmentService } from 'src/app/services/managment.service';

@Component({
  selector: 'app-ver-borrar',
  templateUrl: './ver-borrar.component.html',
  styleUrls: ['./ver-borrar.component.css']
})
export class VerBorrarComponent implements OnInit {

  edificios: any = [];
  edificio: any;
  tituloModal: string = "";
  modalActivo: boolean= false;

  constructor(private managementService: ManagmentService) { }

  ngOnInit(): void {
    this.asignarDatosEdificios();
  }

  asignarDatosEdificios(){
      this.managementService.obtenerEdificios()
          .subscribe(edificios => this.edificios = edificios)
  }

  abrirModalAgregar(){
    this.edificio = {
      edificiosId : 0,
      edificioNum : "",
      edificioDireccion : "",
      tipoEdif: "",
      nivelCal: 0,
      categor: 0
    }
    this.tituloModal = "Agregar Edificio";
    this.modalActivo= true;
  }
  cerrarModalAgregar(){
    this.modalActivo = false;
    this.asignarDatosEdificios();
  }

  abrirModalEditar(edificio: any){
    this.edificio= edificio;
    this.tituloModal = "Editar Edificio"
    this.modalActivo = true;
  }
}
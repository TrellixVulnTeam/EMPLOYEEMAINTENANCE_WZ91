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
  verDetalleEdificio: boolean = true;
  detalleEdificio: any = [];

  constructor(private managementService: ManagmentService) { }

  ngOnInit(): void {
    this.asignarDatosEdificios();
  }

  asignarDatosEdificios(){
      this.managementService.obtenerEdificios()
          .subscribe(edificios => this.edificios = edificios)
  }

  verEdificio(id: any){
    this.managementService.verEdificio(id)
        .subscribe( edificio => {
          this.detalleEdificio.push(edificio)
        })
    this.verDetalleEdificio = true;
    this.detalleEdificio=[];
    this.tituloModal ="Detalles de Edificio"
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
    this.verDetalleEdificio = false;
  }

  abrirModalEditar(edificio: any){
    this.edificio= edificio;
    this.tituloModal = "Editar Edificio"
    this.modalActivo = true;
  }

  eliminarEdificio(id: any){
      if(confirm("Are you sure you want to delete this record ?")){
        this.managementService.eliminarEdificio(id)
            .subscribe( res => console.log("Edificio elmininado"))
        setTimeout(() => {
          this.asignarDatosEdificios();
        }, 500); 
      }
  }
}
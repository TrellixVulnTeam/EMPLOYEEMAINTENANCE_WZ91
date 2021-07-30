import { Component, OnInit } from '@angular/core';
import { ManagmentAsigService } from '../../services/managment-asig.service';

@Component({
  selector: 'app-ver-borrar-asign',
  templateUrl: './ver-borrar-asign.component.html',
  styleUrls: ['./ver-borrar-asign.component.css']
})
export class VerBorrarAsignComponent implements OnInit {

  asignaciones        : any = [];
  asignacion          : any;
  tituloModal         : string = "";
  modalActivo         : boolean= false;
  verDetalleAsignacion: boolean = true;
  detalleAsignacion   : any = [];
  parametroBusqueda   : string = "";
  lastSearch          : string = "";

  constructor(private managementService: ManagmentAsigService) { }

  ngOnInit(): void {
    this.asignarDatosAsignaciones();
  }

  asignarDatosAsignaciones(){
      this.managementService.obtenerAsignaciones()
                            .subscribe(asignaciones => this.asignaciones = asignaciones)
  }

  verAsignacion(id: any){
    this.managementService.verAsignacion(id)
                          .subscribe( asign => {
          this.detalleAsignacion.push(asign) 
          console.log(asign)
        })
    this.verDetalleAsignacion = true;
    this.detalleAsignacion    =[];
    this.tituloModal          ="Detalles de Asignaciones"
    
  }

  abrirModalAgregar(){
    this.asignacion = {
      asignacionesId  : 0,
      AsigNum         : "",
      AsigFechIni     : "",
      AsigNumDias     : "",
      EdificioNum_fk  : 0,
      TrabajadorNum_fk: 0
    }
    this.tituloModal = "Agregar Asignación";
    this.modalActivo = true;
  }

  cerrarModalAgregar(){
    this.modalActivo          = false;
    this.verDetalleAsignacion = false;
  }

  abrirModalEditar(asignacion: any){

    this.asignacion  = asignacion;
    this.tituloModal = "Editar Asignación"
    this.modalActivo = true;
    
  }

  eliminarAsignaciones(id: any){
    console.log(id)
      if(confirm("Are you sure you want to delete this record ?")){
        this.managementService.eliminarAsignaciones(id)
                              .subscribe( res => console.log("Asignación eliminado"))
        setTimeout(() => {
          this.asignarDatosAsignaciones();
        }, 500); 
      }
  }


  buscar(parametroBusqueda: any){
    if(parametroBusqueda === this.lastSearch) return ;
    this.lastSearch = parametroBusqueda
    this.managementService.buscarAsignacion()
                          .subscribe( asignaciones => {
          console.log(parametroBusqueda)
          console.log(asignaciones)
          this.asignaciones = asignaciones.filter( (asignacion:any) =>      
          asignacion.AsigNum
           .trim()
           .toLowerCase()
           .includes(parametroBusqueda
           .toLowerCase())
          )
        })
  }

}
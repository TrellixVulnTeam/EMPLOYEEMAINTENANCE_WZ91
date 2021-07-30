import { Component, Input, OnInit } from '@angular/core';
import { ManagmentAsigService } from '../../services/managment-asig.service';

@Component({
  selector: 'app-editar-agregar-asign',
  templateUrl: './editar-agregar-asign.component.html',
  styleUrls: ['./editar-agregar-asign.component.css']
})
export class EditarAgregarAsignComponent implements OnInit {

  @Input() asignacion: any;
  Asignacionid    : number = 0 ;
  AsigNum         : string = "" ;
  AsigFechIni     : string = "";
  AsigNumDias     : string = "";
  EdificioNum_fk  : number = 0;
  TrabajadorNum_fk: number = 0;
 
  // feedbackAlert: boolean = false;
 
   constructor(private managmentService: ManagmentAsigService) { }
 
   ngOnInit(): void {
     this.Asignacionid     = this.asignacion.asignacionid;
     this.AsigNum          = this.asignacion.asigNum;
     this.AsigFechIni      = this.asignacion.asigFechIni;
     this.AsigNumDias      = this.asignacion.asigNumDias;
     this.EdificioNum_fk   = this.asignacion.edificioNum_fk;
     this.TrabajadorNum_fk = this.asignacion.trabajadorNum_fk;
   }
 
   agregarAsignaciones(){
     var asignaciones = {
      Asignacionid     : this.Asignacionid,
      AsigNum          : this.AsigNum,
      AsigFechIni      : this.AsigFechIni,
      AsigNumDias      : this.AsigNumDias,
      EdificioNum_fk   : this.EdificioNum_fk,
      TrabajadorNum_fk : this.TrabajadorNum_fk
     }
 
     this.managmentService.añadirAsignaciones(asignaciones)
                          .subscribe( res => {
           console.log(res)
         })
   }
 
   actualizarAsignaciones(){
    var asignaciones = {
      Asignacionid     : this.Asignacionid,
      AsigNum          : this.AsigNum,
      AsigFechIni      : this.AsigFechIni,
      AsigNumDias      : this.AsigNumDias,
      EdificioNum_fk   : this.EdificioNum_fk,
      TrabajadorNum_fk : this.TrabajadorNum_fk
    }

    this.managmentService.actualizarAsignaciones(asignaciones)
        .subscribe( res => {
          console.log(res)
        })
   }

 }



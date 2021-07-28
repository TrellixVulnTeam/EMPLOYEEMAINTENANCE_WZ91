import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-editar-agregar',
  templateUrl: './editar-agregar.component.html',
  styleUrls: ['./editar-agregar.component.css']
})
export class EditarAgregarComponent implements OnInit {

  @Input() asignaciones: any;
  Asignacionid: number = 0 ;
  AsigNum: string= "" ;
  AsigFechIni: string = "";
  AsigNumDias: string = "";
  EdificioNum_fk: number = 0;
  TrabajadorNum_fk: number = 0;
 
  feedbackAlert: boolean = false;
 
   constructor(private managmentService: ManagmentService) { }
 
   ngOnInit(): void {
     this.Asignacionid = this.asignaciones.Asignacionid;
     this.AsigNum = this.asignaciones.AsigNum;
     this.AsigFechIni = this.asignaciones.AsigFechIni;
     this.AsigNumDias = this.asignaciones.AsigNumDias;
     this.EdificioNum_fk = this.asignaciones.EdificioNum_fk;
     this.TrabajadorNum_fk = this.asignaciones.TrabajadorNum_fk;
   }
 
   agregarEdificio(){
     var asignaciones = {
      Asignacionid : this.Asignacionid,
      AsigNum : this.AsigNum,
      AsigFechIni : this.AsigFechIni,
      AsigNumDias : this.AsigNumDias,
      EdificioNum_fk : this.EdificioNum_fk,
      TrabajadorNum_fk : this.TrabajadorNum_fk
     }
 
     this.managmentService.añadirEdificio(edificio)
         .subscribe( res => {
           console.log(res)
         })
   }
 
   actualizarEdificio(){
   }
 
 }



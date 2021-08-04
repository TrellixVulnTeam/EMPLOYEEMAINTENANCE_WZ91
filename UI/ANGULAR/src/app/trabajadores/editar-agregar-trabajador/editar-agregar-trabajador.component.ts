import { Component, Input, OnInit } from '@angular/core';
import { Trabajadores } from 'src/app/interfaces/trabajador.interface';
import { TrabajadoresService } from 'src/app/services/trabajadores.service';
import { VerBorrarTrabajadorComponent } from '../ver-borrar-trabajador/ver-borrar-trabajador.component';
@Component({
  selector: 'app-editar-agregar-trabajador',
  templateUrl: './editar-agregar-trabajador.component.html',
  styleUrls: ['./editar-agregar-trabajador.component.css']
})
export class EditarAgregarTrabajadorComponent implements OnInit {

  constructor( private service: TrabajadoresService, private modal: VerBorrarTrabajadorComponent ) { }

  @Input() 
  emp!:Trabajadores;
  @Input() list! : Trabajadores[];
  trabajador! : Trabajadores;

  /*trabajadorid: string=''
  trabajadorNum: string=''
  trabajadorNomb: string=''
  trabajadorTarif: string=''
  oficio: string=''
  trabajadorSuper:string=''*/

  
  activarBoton:Boolean = true;

  ngOnInit(): void {
   /* this.trabajadorid=  this.emp.trabajadorid;
    this.trabajadorNum=  this.emp.trabajadorNum;
    this.trabajadorNomb=  this.emp.trabajadorNomb;
    this.trabajadorTarif=  this.emp.trabajadorTarif;
    this.oficio=  this.emp.oficio;
    this.trabajadorSuper=  this.emp.trabajadorSuper;*/
    this.trabajador = this.emp;
    this.trabajador.trabajadorSuper ="Seleccione Supervisor"
  }
 /* validarInputs(){
    if(this.trabajador.trabajadorNomb==''){
      this.activarBoton=false;
    }
    else{
      this.activarBoton=true;

    }

  }*/

  agregarTrabajador(){
    console.log()

   this.service.addEmp(this.trabajador).subscribe(res=>{
  console.log(res.toString());    });
  setTimeout(() => {
    this.modal.refreshEmpList();

  }, 500);




  }

  

  actualizarTrabajador(){

   /*console.log(this.trabajadorid);   
    let val = {
      trabajadorid: this.trabajadorid.toString(),
      trabajadorNum: this.trabajadorNum.toString(),
      trabajadorNomb: this.trabajadorNomb.toString(),
      trabajadorTarif: this.trabajadorTarif.toString(),
      oficio: this.oficio.toString(),
      trabajadorSuper: this.trabajadorSuper.toString()
  }*/
    this.trabajador.trabajadorTarif = this.trabajador.trabajadorTarif.toString();
    console.log(this.trabajador);
   this.service.updateEmp(this.trabajador).subscribe(res=>{
  console.log(res);    });
  setTimeout(() => {
    this.modal.refreshEmpList();

  }, 500);


  }
}

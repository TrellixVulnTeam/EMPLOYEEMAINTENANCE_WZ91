import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators  } from "@angular/forms";
import { ToastrService } from 'ngx-toastr';
import { ListAsignaciones } from '../interfaces/interfaces-asignaciones';

@Component({
  selector: 'app-asignaciones',
  templateUrl: './asignaciones.component.html',
  styleUrls: ['./asignaciones.component.css']
})
export class AsignacionesComponent implements OnInit {

  ListAsignaciones: ListAsignaciones[]=[];

  form: FormGroup;

  constructor(private fb    : FormBuilder,
              private toastr: ToastrService)
               { 
                this.form = this.fb.group({
                  AsigNum: ['', [Validators.required,Validators.maxLength(20),Validators.minLength(5)]],
                  AsigFechIni: ['', [Validators.required, Validators.maxLength(16), Validators.minLength(16)]],
                  AsigNumDias: ['',[Validators.required, Validators.maxLength(5), Validators.minLength(5)]],
                  EdificioNum_fk:['', [Validators.required, Validators.maxLength(3), Validators.minLength(3)]],
                  TrabajadorNum_fk:['', [Validators.required, Validators.maxLength(3), Validators.minLength(3)]]
                })
              }

  ngOnInit(): void {
  }

  addAsign(){
    console.log(this.form);

    const asign: any = {
      AsigNum: this.form.get('AsigNum')?.value,
      AsigFechIni: this.form.get('AsigFechIni')?.value,
      AsigNumDias: this.form.get('AsigNumDias')?.value,
      EdificioNum_fk: this.form.get('EdificioNum_fk')?.value,
      TrabajadorNum_fk: this.form.get('TrabajadorNum_fk')?.value,

    }
    this.ListAsignaciones.push(asign);
    this.toastr.success('Registrada con exito!', 'Asignacion registrada!');
    this.form.reset();
  }
  deleteAsign(index: number){
    this.ListAsignaciones.splice(index, 1);
    this.toastr.error('La asignacion fue eliminada con exito!', 'Asigancion eliminada!');
  }
  editAsign(){
    
  }
}

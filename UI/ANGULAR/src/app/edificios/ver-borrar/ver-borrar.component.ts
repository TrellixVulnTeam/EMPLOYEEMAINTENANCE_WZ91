import { Component, OnInit } from '@angular/core';
import { ManagmentService } from 'src/app/services/managment.service';

@Component({
  selector: 'app-ver-borrar',
  templateUrl: './ver-borrar.component.html',
  styleUrls: ['./ver-borrar.component.css']
})
export class VerBorrarComponent implements OnInit {

  edificios: any = [];

  constructor(private managementService: ManagmentService) { }

  ngOnInit(): void {
    this.asignarDatosEdificios();
  }

  asignarDatosEdificios(){
      this.managementService.obtenerEdificios()
          .subscribe(edificios =>{
            console.log(edificios)
             this.edificios = edificios
          })
  }
}
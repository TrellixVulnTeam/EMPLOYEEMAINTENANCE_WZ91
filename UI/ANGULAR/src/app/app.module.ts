import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TrabajadoresComponent } from './trabajadores/trabajadores.component';
import { EdificiosComponent } from './edificios/edificios.component';
import { AsignacionesComponent } from './asignaciones/asignaciones.component';
import { ManagmentService } from './services/managment.service';
import { VerBorrarComponent } from './edificios/ver-borrar/ver-borrar.component';
import { EditarAgregarComponent } from './edificios/editar-agregar/editar-agregar.component';

import { AppRoutingModule } from './app-routing.module';
import { TrabajadoresService } from './services/trabajadores.service';
import { EditarAgregarTrabajadorComponent } from './trabajadores/editar-agregar-trabajador/editar-agregar-trabajador.component';
import { VerBorrarTrabajadorComponent } from './trabajadores/ver-borrar-trabajador/ver-borrar-trabajador.component';
import { BarraBuscarComponent } from './barra-buscar/barra-buscar.component';


@NgModule({
  declarations: [
    AppComponent,
    TrabajadoresComponent,
    EdificiosComponent,
    AsignacionesComponent,
    VerBorrarComponent,
    EditarAgregarComponent,
    EditarAgregarTrabajadorComponent,
    VerBorrarTrabajadorComponent, 
    BarraBuscarComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ManagmentService, TrabajadoresService],
  bootstrap: [AppComponent]
})
export class AppModule { }

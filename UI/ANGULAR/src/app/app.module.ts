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
import { BarraBuscarComponent } from './barra-buscar/barra-buscar.component';


@NgModule({
  declarations: [
    AppComponent,
    TrabajadoresComponent,
    EdificiosComponent,
    AsignacionesComponent,
    VerBorrarComponent,
    EditarAgregarComponent,
    BarraBuscarComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ManagmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }

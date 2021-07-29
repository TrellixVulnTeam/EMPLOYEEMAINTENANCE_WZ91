import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
//imports edificios
import { AppComponent } from './app.component';
import { TrabajadoresComponent } from './trabajadores/trabajadores.component';
import { EdificiosComponent } from './edificios/edificios.component';
import { ManagmentService } from './services/managment.service';
import { VerBorrarComponent } from './edificios/ver-borrar/ver-borrar.component';
import { EditarAgregarComponent } from './edificios/editar-agregar/editar-agregar.component';

//imports asignaciones
import { ManagmentAsigService } from './services/managment-asig.service';
import { AsignacionesComponent } from './asignaciones/asignaciones.component';



import { BarraBuscarComponent } from './barra-buscar/barra-buscar.component';
import { EditarAgregarAsignComponent } from './asignaciones/editar-agregar-asign/editar-agregar-asign.component';
import { VerBorrarAsignComponent } from './asignaciones/ver-borrar-asign/ver-borrar-asign.component';




@NgModule({
  declarations: [
    AppComponent,
    TrabajadoresComponent,
    EdificiosComponent,
    VerBorrarComponent,
    EditarAgregarComponent,
    AsignacionesComponent,
    BarraBuscarComponent,
    EditarAgregarAsignComponent,
    VerBorrarAsignComponent

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot()
   
    
  ],
  providers: [
    ManagmentService,
    ManagmentAsigService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

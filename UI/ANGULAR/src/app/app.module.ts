import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from './app.component';
import { TrabajadoresComponent } from './trabajadores/trabajadores.component';
import { EdificiosComponent } from './edificios/edificios.component';
import { ManagmentService } from './services/managment.service';
import { VerBorrarComponent } from './edificios/ver-borrar/ver-borrar.component';
import { EditarAgregarComponent } from './edificios/editar-agregar/editar-agregar.component';

import { AppRoutingModule } from './app-routing.module';
<<<<<<< HEAD
import { ManagmentAsigService } from './services/managment-asig.service';
import { AsignacionesComponent } from './asignaciones/asignaciones.component';
import { FooterComponent } from './shared/footer/footer.component';
import { SharedModule } from './shared/shared.module';

=======
import { BarraBuscarComponent } from './barra-buscar/barra-buscar.component';
>>>>>>> 4e37bf3c12899539f1a6b37f1aebbf8f8d18e9ec


@NgModule({
  declarations: [
    AppComponent,
    TrabajadoresComponent,
    EdificiosComponent,
    VerBorrarComponent,
    EditarAgregarComponent,
<<<<<<< HEAD
    AsignacionesComponent,
    FooterComponent
=======
    BarraBuscarComponent,

>>>>>>> 4e37bf3c12899539f1a6b37f1aebbf8f8d18e9ec
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    SharedModule,
    ReactiveFormsModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(),
    
  ],
  providers: [
    ManagmentService,
    ManagmentAsigService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

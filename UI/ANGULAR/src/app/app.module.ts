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
import { ManagmentAsigService } from './services/managment-asig.service';
import { AsignacionesComponent } from './asignaciones/asignaciones.component';
import { FooterComponent } from './shared/footer/footer.component';
import { SharedModule } from './shared/shared.module';



@NgModule({
  declarations: [
    AppComponent,
    TrabajadoresComponent,
    EdificiosComponent,
    VerBorrarComponent,
    EditarAgregarComponent,
    AsignacionesComponent,
    FooterComponent
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

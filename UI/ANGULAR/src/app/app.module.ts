import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TrabajadoresComponent } from './trabajadores/trabajadores.component';
import { EdificiosComponent } from './edificios/edificios.component';
import { AsignacionesComponent } from './asignaciones/asignaciones.component';
import { ManagmentService } from './services/managment.service';

@NgModule({
  declarations: [
    AppComponent,
    TrabajadoresComponent,
    EdificiosComponent,
    AsignacionesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ManagmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }

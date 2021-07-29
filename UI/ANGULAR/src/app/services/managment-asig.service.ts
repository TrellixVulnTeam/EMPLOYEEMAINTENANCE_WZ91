import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ManagmentAsigService {
  
  readonly BaseApiUrl = "https://localhost:44347/api"
  constructor(private http: HttpClient) { }

  obtenerAsignaciones(): Observable<any[]>{
    return this.http.get<any>(`${this.BaseApiUrl}/Asignaciones`);
  }

  añadirAsignaciones(Asignaciones: any){
    return this.http.post(`${this.BaseApiUrl}/Asignaciones`, Asignaciones)
  }

  actualizarAsignaciones(Asignaciones: any){
    return this.http.put(`${this.BaseApiUrl}/Asignaciones/${Asignaciones.AsignacionesId}`, Asignaciones)
  }

  eliminarAsignaciones(id: any){
    return this.http.delete(`${this.BaseApiUrl}/Asignaciones/${id}`);
  }

  verAsignaciones(id: any){
      return this.http.get(`${this.BaseApiUrl}/Asignaciones/${id}`)
  }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { Observable } from "rxjs";
import { Trabajadores } from '../interfaces/trabajador.interface';
@Injectable({
  providedIn: 'root'
})
export class TrabajadoresService {

  readonly APIurl ="https://localhost:44347"
  busqueda:string = ""

  constructor(private http:HttpClient) { }

  getEmplist(): Observable<Trabajadores[]>{

    return this.http.get<Trabajadores[]>(this.APIurl+'/api/Trabajador');
  }
  getEmplistclean(): Observable<Trabajadores[]>{

    return this.http.get<Trabajadores[]>(this.APIurl+'/api/Trabajador/getclean');
  }
  addEmp(val:Trabajadores){

    return this.http.post(this.APIurl+'/api/Trabajador',val);
  }
  updateEmp(val:Trabajadores){

    return this.http.put(this.APIurl+'/api/Trabajador/'+val.trabajadorid,val);
  }

  deleteEmp(val:Trabajadores){

    return this.http.delete(this.APIurl+'/api/Trabajador/'+val);
  }

  getbyId(val:Trabajadores){

    return this.http.get<Trabajadores>(this.APIurl+'/api/Trabajador/'+val);
  }

  buscartrabajador(){
    return this.http.get<Trabajadores[]>(`${this.APIurl}/api/Trabajador`);
  }
}

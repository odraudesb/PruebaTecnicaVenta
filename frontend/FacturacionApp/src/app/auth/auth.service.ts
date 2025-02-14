
import { environment } from '../../enviroments/environment';

import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Usuario } from '../interfaces/Usuario';
import { Observable } from 'rxjs';
import { ResponseAcceso } from '../interfaces/ResponseAcceso';

@Injectable({
     providedIn: 'root'
})
export class AuthService {

     private http = inject(HttpClient);
     private baseUrl: string =`${environment.apiUrl}`;
    

     constructor() { }
  
        lista(): Observable<Usuario[]> {
          return this.http.get<Usuario[]>(`${this.baseUrl}Usuario`);
          }

          registrarse(objeto: Usuario): Observable<Usuario> {  
               console.log(objeto);
               return this.http.post<Usuario>(`${this.baseUrl}Usuario`, objeto, {
                   withCredentials: true
               });  
           }

     login(usuario: string, password: string, objeto2: Usuario): Observable<any> {
       
      return this.http.post<Usuario>(`${this.baseUrl}/Usuario/login`, objeto2);
    }

     validarToken(token: string): Observable<ResponseAcceso> {
          return this.http.get<ResponseAcceso>(`${this.baseUrl}Usuario/ValidarToken?token=${token}`)
     }
     updateUsuario(usuario: Usuario): Observable<Usuario> {
     return this.http.put<Usuario>(`${this.baseUrl}Usuario/${usuario.usuarioid}`, usuario);
     }

     deleteUsuario(id: number): Observable<void> {
          return this.http.delete<void>(`${this.baseUrl}Usuario/${id}`);
        }
}

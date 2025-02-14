import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../auth/auth.service';
import { Router } from '@angular/router';
import { Usuario } from '../../interfaces/Usuario';

import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-registro',
  standalone: true,
  imports: [MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule, ReactiveFormsModule],
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.css'
})
export class RegistroComponent {

  private accesoService = inject(AuthService);
  private router = inject(Router);
  public formBuild = inject(FormBuilder);

  public formRegistro: FormGroup = this.formBuild.group({
     usuarioNombre: ['', Validators.required], 
     passHash: ['', Validators.required] 
   });

  registrarse() {
    if (this.formRegistro.invalid) return;

    const objeto: Usuario = {
      usuarioid: 0, 
      usuarioNombre: this.formRegistro.value.usuarioNombre, 
      passHash: this.formRegistro.value.passHash, 
      fechaCreacion: new Date() ,
    };

    this.accesoService.registrarse(objeto).subscribe({
     next: (data) => {
       if (data && data.usuarioid > 0) { 
         this.router.navigate(['']);
       } else {
         alert("No se pudo registrar");
       }
     },
     error: (error) => {
       console.error(error.message);
     }
   });
  }

  volver() {
    this.router.navigate(['']);
  }
}

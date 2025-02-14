import { Component } from '@angular/core';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Usuario } from '../../interfaces/Usuario';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  usuario: string = '';
  password: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  onSubmit() {
    const usuarioObj: Usuario = {
      usuarioNombre: this.usuario,
      passHash: this.password,
      usuarioid: 0,
      fechaCreacion: new Date()
    };
    
    this.authService.login(this.usuario, this.password, usuarioObj).subscribe({
      next: (response: { token: string; }) => {
        localStorage.setItem('token', response.token);
        this.router.navigate(['/dashboard']);
      },
      error: () => alert('Credenciales incorrectas'),
    });
  }
  
    registrarse() {
    this.router.navigate(['registro']);
  }
}

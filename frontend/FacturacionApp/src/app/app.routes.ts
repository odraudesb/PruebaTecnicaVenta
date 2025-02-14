import { Routes } from '@angular/router';
import { LoginComponent } from '../app/auth/login/login.component';
import { HomeComponent } from '../app/pages/home/home.component';
import { RegistroComponent } from '../app/pages/registro/registro.component';
export const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'registro', component: RegistroComponent },
  { path: 'login', component: LoginComponent },
  { path: 'home', loadComponent: () => import('../app/pages/home/home.component').then(m => m.HomeComponent) }
];

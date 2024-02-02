import { Routes } from '@angular/router';
import { HomeComponent } from '../components/page/home/home.component';
import { LoginComponent } from '../components/page/login/login.component';

export const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'login', component: LoginComponent, title:"Đăng nhập" },
];

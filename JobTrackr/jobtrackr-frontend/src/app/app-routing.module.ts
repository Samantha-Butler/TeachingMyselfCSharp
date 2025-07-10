import { importProvidersFrom } from '@angular/core';
import { provideRouter, RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { ApplicationsComponent } from './applications/applications.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'applications', component: ApplicationsComponent },
];

export const appRoutingProviders = [
  importProvidersFrom(RouterModule.forRoot(routes)),
];

import { Routes } from '@angular/router';
import { ChoresPageComponent } from './chores-page/chores-page.component';
import { HomePageComponent } from './home-page/home-page.component';

export const routes: Routes = [
  { path: 'chores', component: ChoresPageComponent }, 
  { path: 'home', component: HomePageComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
];

import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { MenubarModule } from 'primeng/menubar';
import { MenuBarHeader } from './header/header.component';
import { RouterModule } from '@angular/router'

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    MenubarModule,
    MenuBarHeader,
    RouterModule
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ChoreDashboard.UI';

  items: MenuItem[] = [
    {
      label: 'Home',
      icon: 'fa fa-home',
      routerLink: ['/']
    },
    {
      label: 'Chores',
      icon: 'fa fa-broom',
      routerLink: ['/chores']
    }
  ];
}

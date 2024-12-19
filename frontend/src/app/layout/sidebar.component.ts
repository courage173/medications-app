import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-layout-sidebar',
  imports: [CommonModule],
  templateUrl: './sidebar.component.html',
})
export class SidebarComponent {
  visible: boolean = true;
  routes = [
    {
      title: 'Medications',
      icon: 'pi pi-home',
      routerLink: '/',
    },
    {
      title: 'Therapeutic Classes',
      icon: 'pi pi-info',
      routerLink: '/therapeutic-classes',
    },
    {
      title: 'Active Ingredients',
      icon: 'pi pi-envelope',
      routerLink: '/active-ingredients',
    },
    {
      title: 'Pharmaceutical Forms',
      icon: 'pi pi-envelope',
      routerLink: '/pharmaceutical-forms',
    },
    {
      title: 'ATC Codes',
      icon: 'pi pi-envelope',
      routerLink: '/atc-codes',
    },
  ];

  //current active route
  activeRoute: string = '';

  constructor() {
    console.log(window.location.pathname);
    this.activeRoute = window.location.pathname;
  }
}

import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { SidebarModule } from 'primeng/sidebar';
import { SidebarComponent } from './layout/sidebar.component';

@Component({
  selector: 'app-root',
  imports: [CommonModule, RouterOutlet, SidebarModule, SidebarComponent],
  standalone: true,
  templateUrl: './app.component.html',
  providers: [],
})
export class AppComponent {
  title = 'frontend';
}

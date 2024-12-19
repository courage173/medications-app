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
})
export class AppComponent {
  title = 'frontend';
}

// {
//   "name": "Oraldene 0.1% Gargle/Mouthwash",
//   "competentAuthorityStatus": "Authorised",
//   "internalStatus": "Active",
//   "unit": "ml(s)",
//   "pharmaceuticalFormId": 1,
//   "atcCodeId": 1,
//   "therapeuticClassId": 1,
//   "classificationId": 2,
//   "activeIngredients": [
//     {
//       "activeIngredientId": 1,
//       "dosage": "0.1 percent weight/volume"
//     }
//   ]
// }

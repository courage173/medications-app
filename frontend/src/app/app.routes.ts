import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./features/medications/medication.component').then(
        (m) => m.MedicationComponent
      ),
  },
];

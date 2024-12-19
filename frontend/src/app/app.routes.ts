import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./features/medications/medication.component').then(
        (m) => m.MedicationComponent
      ),
  },
  {
    path: 'therapeutic-classes',
    loadComponent: () =>
      import('./features/therapeuticClass/therapeutic-class.component').then(
        (m) => m.TherapeuticClassComponent
      ),
  },
];

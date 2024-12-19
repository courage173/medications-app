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

  {
    path: 'active-ingredients',
    loadComponent: () =>
      import('./features/activeIngredients/active-ingredients.component').then(
        (m) => m.ActiveIngredientsComponent
      ),
  },
  {
    path: 'pharmaceutical-forms',
    loadComponent: () =>
      import(
        './features/pharmaceuticalForms/pharmaceutical-forms.component'
      ).then((m) => m.PharmaceuticalFormsComponent),
  },
  {
    path: 'atc-codes',
    loadComponent: () =>
      import('./features/atcCodes/atc-codes.component').then(
        (m) => m.AtcCodesComponent
      ),
  },
];

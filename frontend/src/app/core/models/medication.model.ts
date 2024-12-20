export interface ActiveIngredient {
  id: number;
  name: string;
  dosage: string;
}

export enum Classification {
  OTC = 'OTC',
  NARCOTIC = 'POM',
}

export interface Medication {
  id: number;
  name: string;
  competentAuthorityStatus: string;
  internalStatus: string;
  unit: string;
  pharmaceuticalFormId: number;
  pharmaceuticalFormName: string;
  atcCodeId: number;
  atcCodeName: string;
  therapeuticClassId: number;
  therapeuticClassName: string;
  classificationName: Classification;
  activeIngredients: ActiveIngredient[];
  createdAt: string;
  updatedAt: string;
}

export interface MedicationData {
  medications: Medication[];
  total: number;
  currentPage: number;
}

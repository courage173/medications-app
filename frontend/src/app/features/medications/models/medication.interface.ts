export interface Medication {
  id: number;
  name: string;
  pharmaceuticalForm: string;
  activeIngredients: string;
  classification: string;
  atcCode: string;
  manufacturer: string;
  price: number;
  description: string;
  createdAt: Date;
  updatedAt: Date;
}

export interface Car {
  vin: string;
  year: number;
  brand: string;
  color: string;
}

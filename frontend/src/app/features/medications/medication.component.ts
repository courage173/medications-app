import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { PrimeNG } from 'primeng/config';
import { TableComponent } from '../../shared/table/table.component';
import { MedicationService } from '../../core/services/medication-service';
import { Medication } from '../../core/models/medication.model';
import { Dialog } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { MultiSelectModule } from 'primeng/multiselect';
import {
  FormArray,
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Select } from 'primeng/select';

@Component({
  selector: 'app-medication',
  templateUrl: './medication.component.html',
  imports: [
    CommonModule,
    TableComponent,
    Dialog,
    ButtonModule,

    MultiSelectModule,
    FormsModule,
    ReactiveFormsModule,
    Select,
  ],
  providers: [MedicationService],
})
export class MedicationComponent implements OnInit {
  medications: Medication[] = [];
  visible: boolean = false;
  formGroup!: FormGroup;
  visibled = false;

  headers: string[] = [
    'Name',
    'Competent Authority Status',
    'Internal Status',
    'Unit',
    'Pharmaceutical Form',
    'ATC Code',
    'Therapeutic Class',
    'Classification',
    'Active Ingredients',
  ];

  columns = [
    {
      field: 'name',
    },
    {
      field: 'competentAuthorityStatus',
    },
    {
      field: 'internalStatus',
    },
    {
      field: 'unit',
    },
    {
      field: 'pharmaceuticalFormName',
    },
    {
      field: 'atcCodeName',
    },
    {
      field: 'therapeuticClassName',
    },
    {
      field: 'classificationName',
    },
    {
      field: 'activeIngredients',
    },
  ];

  loading: boolean = false;

  fields = [
    {
      field: 'name',
      header: 'Name',
      type: 'input',
      placeholder: 'Enter Name',
    },
    {
      field: 'unit',
      header: 'Unit',
      type: 'input',
      placeholder: 'Enter Unit',
    },
    {
      field: 'competentAuthorityStatus',
      header: 'Competent Authority Status',
      type: 'select',
      placeholder: 'Select Competent Authority Status',
      options: [
        { name: 'Authorised', code: 'Authorised' },
        { name: 'Withdrawn', code: 'Withdrawn' },
        { name: 'Suspended', code: 'Suspended' },
      ],
    },
    {
      field: 'internalStatus',
      header: 'Internal Status',
      type: 'select',
      placeholder: 'Select Internal Status',
      options: [
        { name: 'Active', code: 'Active' },
        { name: 'Inactive', code: 'Inactive' },
      ],
    },

    {
      field: 'pharmaceuticalFormName',
      header: 'Pharmaceutical Form',
      type: 'select',
      placeholder: 'Select Pharmaceutical Form',
      options: [
        { name: 'Tablet', code: 'Tablet' },
        { name: 'Capsule', code: 'Capsule' },
        { name: 'Injection', code: 'Injection' },
        { name: 'Syrup', code: 'Syrup' },
        { name: 'Cream', code: 'Cream' },
      ],
    },
    {
      field: 'atcCodeName',
      header: 'ATC Code',
      type: 'select',
      placeholder: 'Select ATC Code',
      options: [
        { name: 'A', code: 'A' },
        { name: 'B', code: 'B' },
        { name: 'C', code: 'C' },
        { name: 'D', code: 'D' },
        { name: 'E', code: 'E' },
      ],
    },
    {
      field: 'therapeuticClassName',
      header: 'Therapeutic Class',
      type: 'select',
      placeholder: 'Select Therapeutic Class',

      options: [
        { name: 'A', code: 'A' },
        { name: 'B', code: 'B' },
        { name: 'C', code: 'C' },
        { name: 'D', code: 'D' },
        { name: 'E', code: 'E' },
      ],
    },
    {
      field: 'classificationName',
      header: 'Classification',
      type: 'select',
      placeholder: 'Select Classification',
      options: [
        { name: 'A', code: 'A' },
        { name: 'B', code: 'B' },
        { name: 'C', code: 'C' },
        { name: 'D', code: 'D' },
        { name: 'E', code: 'E' },
      ],
    },
    {
      field: 'activeIngredients',
      header: 'Active Ingredients',
      type: 'multiselect',
      placeholder: 'Select Active Ingredients',
      options: [
        { name: 'New York', id: 'NY', dosage: '' },
        { name: 'Rome', id: 'RM', dosage: '' },
        { name: 'London', id: 'LDN', dosage: '' },
        { name: 'Istanbul', id: 'IST', dosage: '' },
        { name: 'Paris', id: 'PRS', dosage: '' },
      ],
    },
  ];

  constructor(
    private primengConfig: PrimeNG,
    private medicationService: MedicationService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    // Initialization logic here
    this.primengConfig.ripple.set(true);

    this.formGroup = this.fb.group({
      name: ['', Validators.required],
      competentAuthorityStatus: ['', Validators.required],
      internalStatus: ['', Validators.required],
      unit: ['', Validators.required],
      pharmaceuticalFormName: ['', Validators.required],
      atcCodeName: ['', Validators.required],
      therapeuticClassName: ['', Validators.required],
      classificationName: ['', Validators.required],
      // activeIngredients: [[], Validators.required],
      activeIngredients: this.fb.array([]), // Define as a FormArray for multiselect
    });

    this.medicationService.getMedications().subscribe((data: Medication[]) => {
      this.medications = data;
    });
  }

  get activeIngredients(): FormArray {
    return this.formGroup.get('activeIngredients') as FormArray;
  }

  addActiveIngredient(ingredient: { name: string; id: number }): void {
    const ingredientGroup = this.fb.group({
      name: [ingredient.name, Validators.required],
      id: [ingredient.id, Validators.required],
      dosage: ['', Validators.required], // Add dosage control here
    });
    this.activeIngredients.push(ingredientGroup);
  }

  onActiveIngredientsChange(selectedIngredients: any[]): void {
    while (this.activeIngredients.length) {
      this.activeIngredients.removeAt(0);
    }
    selectedIngredients.forEach((ingredient) => {
      this.addActiveIngredient(ingredient);
    });
  }

  removeActiveIngredient(index: number): void {
    this.activeIngredients.removeAt(index);
  }

  showDialog = () => {
    this.visibled = true;
  };

  editMedication = (data: Medication) => {
    const originalData = this.medications.find((m) => m.id === data.id);

    data.activeIngredients =
      originalData?.activeIngredients.map((ingredient) => {
        return {
          name: ingredient.name,
          id: ingredient.id,
          dosage: ingredient.dosage,
        };
      }) || [];
    this.formGroup.patchValue(data);
    this.visibled = true;
  };

  onSubmit(): void {
    console.log(this.formGroup.value);
    if (this.formGroup.valid) {
      // Handle form submission
      console.log(this.formGroup.value);
    }
  }

  getMedicationData() {
    return this.medications.map((medication: Medication) => {
      let activeIngredients = '';
      medication.activeIngredients.forEach((activeIngredient) => {
        if (activeIngredients !== '') {
          activeIngredients += ' | ';
        }
        activeIngredients += `${activeIngredient.name} ${activeIngredient.dosage}`;
      });
      return {
        ...medication,
        activeIngredients,
      };
    });
  }
}

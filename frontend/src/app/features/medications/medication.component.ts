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
import { ActiveIngredientService } from '../../core/services/active-ingredients-service';
import { PharmaceuticalFormService } from '../../core/services/pharmaceutical-form-service';
import { AtcCodeService } from '../../core/services/act-code-service';
import { TherapeuticClassService } from '../../core/services/therapeutic-class-service';
import { forkJoin } from 'rxjs';
import { ActiveIngredient } from '../../core/models/active-ingredients.model';
import { PharmaceuticalForm } from '../../core/models/pharmaceutical-form.model';
import { AtcCode } from '../../core/models/atc-codes.model';
import { TherapeuticClass } from '../../core/models/therapeutic-class.model';
import { mapDataToSubmit, mapEditData } from '../../shared/utils/medication';

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
  providers: [
    MedicationService,
    ActiveIngredientService,
    PharmaceuticalFormService,
    AtcCodeService,
    TherapeuticClassService,
  ],
})
export class MedicationComponent implements OnInit {
  medications: Medication[] = [];
  visible: boolean = false;
  formGroup!: FormGroup;
  itemToUpdate: Medication | null = null;

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
      options: [] as PharmaceuticalForm[],
    },
    {
      field: 'atcCodeName',
      header: 'ATC Code',
      type: 'select',
      placeholder: 'Select ATC Code',
      options: [] as AtcCode[],
    },
    {
      field: 'therapeuticClassName',
      header: 'Therapeutic Class',
      type: 'select',
      placeholder: 'Select Therapeutic Class',

      options: [] as TherapeuticClass[],
    },
    {
      field: 'classificationName',
      header: 'Classification',
      type: 'select',
      placeholder: 'Select Classification',
      options: [
        { name: 'POM', code: 'POM' },
        { name: 'OTC', code: 'OTC' },
      ],
    },
    {
      field: 'activeIngredients',
      header: 'Active Ingredients',
      type: 'multiselect',
      placeholder: 'Select Active Ingredients',
      options: [] as ActiveIngredient[],
    },
  ];

  constructor(
    private primengConfig: PrimeNG,
    private medicationService: MedicationService,
    private fb: FormBuilder,
    private activeIngredientService: ActiveIngredientService,
    private pharmaceuticalFormService: PharmaceuticalFormService,
    private atcCodeService: AtcCodeService,
    private therapeuticClassService: TherapeuticClassService
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
    this.loading = true;
    forkJoin({
      medications: this.medicationService.getMedications(),
      activeIngredients: this.activeIngredientService.getActiveIngredients(),
      pharmaceuticalForms:
        this.pharmaceuticalFormService.getPharmaceuticalForms(),
      atcCodes: this.atcCodeService.getAtcCodes(),
      therapeuticClasses: this.therapeuticClassService.getTherapeuticClasss(),
    }).subscribe({
      next: ({
        medications,
        activeIngredients,
        pharmaceuticalForms,
        atcCodes,
        therapeuticClasses,
      }) => {
        this.medications = medications;
        this.fields.find(
          (field) => field.field === 'activeIngredients'
        )!.options = activeIngredients;
        this.fields.find(
          (field) => field.field === 'pharmaceuticalFormName'
        )!.options = pharmaceuticalForms.map((pharmaceuticalForm) => {
          return {
            id: pharmaceuticalForm.id,
            name: pharmaceuticalForm.form,
          };
        });
        this.fields.find((field) => field.field === 'atcCodeName')!.options =
          atcCodes?.map((atcCode) => {
            return {
              id: atcCode.id,
              name: atcCode.code,
              code: atcCode.code,
            };
          });
        this.fields.find(
          (field) => field.field === 'therapeuticClassName'
        )!.options = therapeuticClasses;
        this.loading = false;
      },
      error: (error) => {
        console.error('Error fetching data', error);
        this.loading = false;
      },
    });
  }

  get activeIngredients(): FormArray {
    return this.formGroup.get('activeIngredients') as FormArray;
  }

  addActiveIngredient(ingredient: { name: string; id: number }): void {
    const ingredientGroup = this.fb.group({
      name: [ingredient.name, Validators.required],
      id: [ingredient.id, Validators.required],
      dosage: ['', Validators.required],
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
    this.visible = true;
  };

  hideDialog = () => {
    this.formGroup.reset();
    this.itemToUpdate = null;
    this.visible = false;
  };

  editMedication = (data: Medication) => {
    const originalData = this.medications.find((m) => m.id === data.id);

    data.activeIngredients = originalData?.activeIngredients || [];
    this.formGroup.patchValue(mapEditData(data));
    this.activeIngredients.patchValue(data.activeIngredients);
    this.visible = true;
  };

  refetchMedications = () => {
    this.medicationService.getMedications().subscribe((data: Medication[]) => {
      this.medications = data;
    });
  };

  onSubmit(): void {
    if (this.formGroup.valid) {
      if (this.itemToUpdate) {
        this.updateMedication(
          this.itemToUpdate.id,
          mapDataToSubmit(this.formGroup.value)
        );
      } else {
        this.addMedication(mapDataToSubmit(this.formGroup.value));
        this.medicationService
          .getMedications()
          .subscribe((data: Medication[]) => {
            this.medications = data;
          });
      }

      this.refetchMedications();
    }
  }

  addMedication(data: Medication): void {
    this.medicationService.addMedication(data).subscribe((medication) => {
      this.medications = [...this.medications, medication];
      this.visible = false;
    });
  }

  updateMedication(id: number, data: Medication): void {
    this.medicationService
      .updateMedication(id, data)
      .subscribe((medication) => {
        const index = this.medications.findIndex((m) => m.id === id);
        this.medications[index] = medication;
        this.visible = false;
      });
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

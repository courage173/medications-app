import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { TableComponent } from '../../shared/table/table.component';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { PharmaceuticalFormService } from '../../core/services/pharmaceutical-form-service';
import { PharmaceuticalForm } from '../../core/models/pharmaceutical-form.model';
import { Dialog } from 'primeng/dialog';

@Component({
  selector: 'app-pharmaceutical-forms',
  templateUrl: './pharmaceutical-forms.component.html',
  imports: [
    CommonModule,
    TableComponent,
    ButtonModule,
    FormsModule,
    ReactiveFormsModule,
    Dialog,
  ],
  providers: [PharmaceuticalFormService],
})
export class PharmaceuticalFormsComponent implements OnInit {
  pharmaceuticalForms: PharmaceuticalForm[] = [];
  visible: boolean = false;
  formGroup!: FormGroup;
  loading = false;
  itemToUpdate: PharmaceuticalForm | null = null;

  headers: string[] = ['Form'];

  columns = [
    {
      field: 'form',
    },
  ];

  constructor(
    private pharmaceuticalFormService: PharmaceuticalFormService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.formGroup = this.fb.group({
      form: ['', Validators.required],
    });

    this.pharmaceuticalFormService.getPharmaceuticalForms().subscribe({
      next: (pharmaceuticalForms) => {
        this.pharmaceuticalForms = pharmaceuticalForms;
      },
      error: (error) => {
        console.error(error);
      },
    });
  }

  onSubmit() {
    if (this.formGroup.valid) {
      // Handle form submission
      if (this.itemToUpdate) {
        this.updateTherapeuticClass(
          this.itemToUpdate.id,
          this.formGroup.value.form
        );
      } else {
        this.addTherapeuticClass();
      }
    }
  }

  onEdit = (data: PharmaceuticalForm) => {
    this.itemToUpdate = data;
    this.formGroup.patchValue(data);
    this.visible = true;
  };

  showDialog = () => {
    this.visible = true;
  };

  hideDialog = () => {
    this.formGroup.reset();
    this.itemToUpdate = null;
    this.visible = false;
  };

  addTherapeuticClass = () => {
    this.pharmaceuticalFormService
      .addPharmaceuticalForm(this.formGroup.value.form)
      .subscribe({
        next: (pharmaceuticalForms) => {
          this.pharmaceuticalForms = [
            ...this.pharmaceuticalForms,
            pharmaceuticalForms,
          ];
          this.visible = false;
        },
        error: (error) => {
          console.error(error);
        },
      });
  };

  deleteTherapeuticClass(id: number) {
    this.pharmaceuticalFormService.deletePharmaceuticalForm(id).subscribe({
      next: () => {
        this.pharmaceuticalForms = this.pharmaceuticalForms.filter(
          (pharmaceuticalForm) => pharmaceuticalForm.id !== id
        );
      },
      error: (error) => {
        console.error(error);
      },
    });
  }

  updateTherapeuticClass = (id: number, form: string) => {
    this.pharmaceuticalFormService
      .updatePharmaceuticalForm(id, form)
      .subscribe({
        next: (PharmaceuticalForm) => {
          this.pharmaceuticalForms = this.pharmaceuticalForms.map(
            (pharmaceuticalForm) =>
              pharmaceuticalForm.id === id
                ? { ...pharmaceuticalForm, form }
                : pharmaceuticalForm
          );

          this.visible = false;
        },
        error: (error) => {
          console.error(error);
        },
      });
  };
}

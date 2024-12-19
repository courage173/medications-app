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
import { ActiveIngredientService } from '../../core/services/active-ingredients-service';
import { ActiveIngredient } from '../../core/models/active-ingredients.model';
import { Dialog } from 'primeng/dialog';

@Component({
  selector: 'app-active-ingredients',
  templateUrl: './active-ingredients.component.html',
  imports: [
    CommonModule,
    TableComponent,
    ButtonModule,
    FormsModule,
    ReactiveFormsModule,
    Dialog,
  ],
  providers: [ActiveIngredientService],
})
export class ActiveIngredientsComponent implements OnInit {
  activeIngredients: ActiveIngredient[] = [];
  visible: boolean = false;
  formGroup!: FormGroup;
  loading = false;
  itemToUpdate: ActiveIngredient | null = null;

  headers: string[] = ['Name'];

  columns = [
    {
      field: 'name',
    },
  ];

  constructor(
    private activeIngredientService: ActiveIngredientService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.formGroup = this.fb.group({
      name: ['', Validators.required],
    });

    this.activeIngredientService.getActiveIngredients().subscribe({
      next: (activeIngredients) => {
        this.activeIngredients = activeIngredients;
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
        this.updateActiveIngredient(
          this.itemToUpdate.id,
          this.formGroup.value.name
        );
      } else {
        this.addActiveIngredient();
      }
    }
  }

  onEdit = (data: ActiveIngredient) => {
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

  addActiveIngredient = () => {
    this.activeIngredientService
      .addActiveIngredient(this.formGroup.value.name)
      .subscribe({
        next: (activeIngredients) => {
          this.activeIngredients = [
            ...this.activeIngredients,
            activeIngredients,
          ];
          this.visible = false;
        },
        error: (error) => {
          console.error(error);
        },
      });
  };

  deleteActiveIngredient = (data: ActiveIngredient) => {
    this.activeIngredientService.deleteActiveIngredient(data.id).subscribe({
      next: () => {
        this.activeIngredients = this.activeIngredients.filter(
          (activeIngredient) => activeIngredient.id !== data.id
        );
      },
      error: (error) => {
        console.error(error);
      },
    });
  };

  updateActiveIngredient = (id: number, name: string) => {
    this.activeIngredientService.updateActiveIngredient(id, name).subscribe({
      next: (ActiveIngredient) => {
        this.activeIngredients = this.activeIngredients.map(
          (activeIngredient) =>
            activeIngredient.id === id
              ? { ...activeIngredient, name }
              : activeIngredient
        );

        this.visible = false;
      },
      error: (error) => {
        console.error(error);
      },
    });
  };
}

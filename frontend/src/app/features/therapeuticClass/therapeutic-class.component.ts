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
import { TherapeuticClassService } from '../../core/services/therapeutic-class-service';
import { TherapeuticClass } from '../../core/models/therapeutic-class.model';
import { Dialog } from 'primeng/dialog';

@Component({
  selector: 'app-therapeutic-class',
  templateUrl: './therapeutic-class.component.html',
  imports: [
    CommonModule,
    TableComponent,
    ButtonModule,
    FormsModule,
    ReactiveFormsModule,
    Dialog,
  ],
  providers: [TherapeuticClassService],
})
export class TherapeuticClassComponent implements OnInit {
  therapeuticClasses: TherapeuticClass[] = [];
  visible: boolean = false;
  formGroup!: FormGroup;
  loading = false;
  itemToUpdate: TherapeuticClass | null = null;

  headers: string[] = ['Name'];

  columns = [
    {
      field: 'name',
    },
  ];

  constructor(
    private therapeuticClassService: TherapeuticClassService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.formGroup = this.fb.group({
      name: ['', Validators.required],
    });

    this.therapeuticClassService.getTherapeuticClasss().subscribe({
      next: (therapeuticClasses) => {
        this.therapeuticClasses = therapeuticClasses;
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
          this.formGroup.value.name
        );
      } else {
        this.addTherapeuticClass();
      }
    }
  }

  onEdit = (data: TherapeuticClass) => {
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
    this.therapeuticClassService
      .addTherapeuticClass(this.formGroup.value.name)
      .subscribe({
        next: (therapeuticClass) => {
          this.therapeuticClasses = [
            ...this.therapeuticClasses,
            therapeuticClass,
          ];
          this.visible = false;
        },
        error: (error) => {
          console.error(error);
        },
      });
  };

  deleteTherapeuticClass(id: number) {
    this.therapeuticClassService.deleteTherapeuticClass(id).subscribe({
      next: () => {
        this.therapeuticClasses = this.therapeuticClasses.filter(
          (therapeuticClass) => therapeuticClass.id !== id
        );
      },
      error: (error) => {
        console.error(error);
      },
    });
  }

  updateTherapeuticClass = (id: number, name: string) => {
    this.therapeuticClassService.updateTherapeuticClass(id, name).subscribe({
      next: (therapeuticClass) => {
        this.therapeuticClasses = this.therapeuticClasses.map(
          (therapeuticClass) =>
            therapeuticClass.id === id
              ? { ...therapeuticClass, name }
              : therapeuticClass
        );

        this.visible = false;
      },
      error: (error) => {
        console.error(error);
      },
    });
  };
}

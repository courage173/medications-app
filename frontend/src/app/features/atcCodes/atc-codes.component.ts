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
import { AtcCodeService } from '../../core/services/act-code-service';
import { AtcCode } from '../../core/models/atc-codes.model';
import { Dialog } from 'primeng/dialog';
import { Toast } from 'primeng/toast';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-atc-codes',
  templateUrl: './atc-codes.component.html',
  imports: [
    CommonModule,
    TableComponent,
    ButtonModule,
    FormsModule,
    ReactiveFormsModule,
    Dialog,
    Toast,
  ],
  providers: [AtcCodeService, MessageService],
})
export class AtcCodesComponent implements OnInit {
  atcCodes: AtcCode[] = [];
  visible: boolean = false;
  formGroup!: FormGroup;
  loading = false;
  itemToUpdate: AtcCode | null = null;

  headers: string[] = ['Code'];

  columns = [
    {
      field: 'code',
    },
  ];

  constructor(
    private atcCodeService: AtcCodeService,
    private fb: FormBuilder,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.formGroup = this.fb.group({
      code: ['', Validators.required],
    });

    this.atcCodeService.getAtcCodes().subscribe({
      next: (atcCodes) => {
        this.atcCodes = atcCodes;
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
        this.updateATCCode(this.itemToUpdate.id, this.formGroup.value.code);
      } else {
        this.addATCCode();
      }
    }
  }

  onEdit = (data: AtcCode) => {
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

  showError(message: string) {
    this.messageService.add({
      severity: 'error',
      summary: 'Error',
      detail: message,
    });
  }

  showSuccess(message: string) {
    this.messageService.add({
      severity: 'success',
      summary: 'Success',
      detail: message,
    });
  }

  addATCCode = () => {
    this.atcCodeService.addAtcCode(this.formGroup.value.code).subscribe({
      next: (atcCode) => {
        this.atcCodes = [...this.atcCodes, atcCode];
        this.visible = false;
        this.showSuccess('ATC code added successfully');
      },
      error: (error) => {
        this.showError(error.error || 'Error adding ATC code');
      },
    });
  };

  deleteATCCode = (data: AtcCode) => {
    this.atcCodeService.deleteAtcCode(data.id).subscribe({
      next: () => {
        this.atcCodes = this.atcCodes.filter(
          (atcCode) => atcCode.id !== data.id
        );
        this.showSuccess('ATC code deleted successfully');
      },
      error: (error) => {
        this.showError(error.error || 'Error deleting ATC code');
      },
    });
  };

  updateATCCode = (id: number, code: string) => {
    this.atcCodeService.updateAtcCode(id, code).subscribe({
      next: (atcCode) => {
        this.atcCodes = this.atcCodes.map((atcCode) =>
          atcCode.id === id ? { ...atcCode, code } : atcCode
        );

        this.visible = false;
        this.showSuccess('ATC code updated successfully');
      },
      error: (error) => {
        this.showError(error.error || 'Error updating ATC code');
      },
    });
  };
}

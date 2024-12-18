import { Component, Input } from '@angular/core';
import { TableModule } from 'primeng/table';
import { PrimeNG } from 'primeng/config';
import { InputTextModule } from 'primeng/inputtext';
import { IconField } from 'primeng/iconfield';
import { InputIcon } from 'primeng/inputicon';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { Popover } from 'primeng/popover';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  imports: [
    CommonModule,
    TableModule,
    InputTextModule,
    IconField,
    InputIcon,
    ButtonModule,
    Popover,
  ],
})
export class TableComponent {
  @Input() headers: string[] = [];
  @Input() columns: { field: string }[] = [];
  @Input() data: any[] = [];
  @Input() loading: boolean = false;
  @Input() totalRecords: number = 0;
  @Input() itemsPerPage = 15;
  @Input() title: string = '';
  @Input() addNew: () => void = () => {};
  @Input() edit: (id: number) => void = () => {};
  @Input() delete: (id: number) => void = () => {};

  constructor(private primengConfig: PrimeNG) {}

  ngOnInit(): void {
    this.primengConfig.ripple.set(true);
  }
}

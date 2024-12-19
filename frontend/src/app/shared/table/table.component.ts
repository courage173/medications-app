import { Component, Input, ViewChild } from '@angular/core';
import { TableModule } from 'primeng/table';
import { PrimeNG } from 'primeng/config';
import { InputTextModule } from 'primeng/inputtext';
import { IconField } from 'primeng/iconfield';
import { InputIcon } from 'primeng/inputicon';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { Popover } from 'primeng/popover';
import { ClickOutsideDirective } from '../../click-outside.directive';

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
    ClickOutsideDirective,
  ],
})
export class TableComponent {
  selectedItem: any;

  @Input() headers: string[] = [];
  @Input() columns: { field: string }[] = [];
  @Input() data: any[] = [];
  @Input() loading: boolean = false;
  @Input() totalRecords: number = 0;
  @Input() itemsPerPage = 15;
  @Input() title: string = '';
  @Input() addNew: () => void = () => {};
  @Input() edit: (data: any) => void = () => {};
  @Input() delete: (data: any) => void = () => {};

  constructor(private primengConfig: PrimeNG) {}
  @ViewChild('op') op!: Popover;

  handleAction(event: MouseEvent, item: any) {
    if (this.selectedItem?.id === item.id) {
      this.selectedItem = null;
    } else {
      this.selectedItem = item;
    }
  }
  ngOnInit(): void {
    this.primengConfig.ripple.set(true);
  }

  onOutsideClick(): void {
    this.selectedItem = null;
  }
}

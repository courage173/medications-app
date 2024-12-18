import { CommonModule } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { TableModule } from 'primeng/table';
import { Car } from './models/medication.interface';
import { Table } from 'primeng/table';
import { PrimeNG } from 'primeng/config';
import { InputTextModule } from 'primeng/inputtext';
import { IconField } from 'primeng/iconfield';
import { InputIcon } from 'primeng/inputicon';
import { TableComponent } from '../../shared/table/table.component';

@Component({
  selector: 'app-medication',
  templateUrl: './medication.component.html',
  imports: [TableComponent],
})
export class MedicationComponent implements OnInit {
  cars: Car[] = [
    {
      vin: 'A123BC',
      year: 2015,
      brand: 'Toyota',
      color: 'Red',
    },
    {
      vin: 'D456EF',
      year: 2018,
      brand: 'Honda',
      color: 'Blue',
    },
    {
      vin: 'G789HI',
      year: 2020,
      brand: 'Ford',
      color: 'Black',
    },
    {
      vin: 'J012KL',
      year: 2019,
      brand: 'Chevrolet',
      color: 'White',
    },
  ];

  loading: boolean = false;
  columns = [
    { field: 'vin' },
    { field: 'year' },
    { field: 'brand' },
    { field: 'color' },
  ];

  constructor(private primengConfig: PrimeNG) {}

  ngOnInit(): void {
    // Initialization logic here
    this.primengConfig.ripple.set(true);
  }
}

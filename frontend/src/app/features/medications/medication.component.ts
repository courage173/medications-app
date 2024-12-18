import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
import { Car } from './models/medication.interface';

@Component({
  selector: 'app-medication',
  templateUrl: './medication.component.html',
  imports: [CommonModule, TableModule],
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

  constructor() {}

  ngOnInit(): void {
    // Initialization logic here
  }
}

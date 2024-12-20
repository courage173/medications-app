import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MedicationComponent } from './medication.component';

import { of } from 'rxjs';
import { MedicationService } from '../../core/services/medication-service';
import { Medication } from '../../core/models/medication.model';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('MedicationComponent', () => {
  let component: MedicationComponent;
  let fixture: ComponentFixture<MedicationComponent>;
  let medicationService: jasmine.SpyObj<MedicationService>;

  beforeEach(async () => {
    const medicationServiceSpy = jasmine.createSpyObj('MedicationService', [
      'getMedications',
      'deleteMedication',
      'addMedication',
      'updateMedication',
    ]);

    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, MedicationComponent],
      providers: [
        { provide: MedicationService, useValue: medicationServiceSpy },
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(MedicationComponent);
    component = fixture.componentInstance;
    medicationService = TestBed.inject(
      MedicationService
    ) as jasmine.SpyObj<MedicationService>;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should fetch medications on initialization', () => {
    const mockMedications = {
      currentPage: 1,
      total: 2,
      medications: [
        {
          id: 1,
          name: 'Test Medication',
          competentAuthorityStatus: 'Authorised',
          internalStatus: 'Active',
          unit: 'ml(s)',
          pharmaceuticalFormId: 1,
          pharmaceuticalFormName: 'SOLUTION FOR INJECTION',
          atcCodeId: 1,
          atcCodeName: 'A01AA01',
          therapeuticClassId: 1,
          therapeuticClassName: 'CLASS',
          classificationName: 'POM',
          createdAt: '2023-01-01T00:00:00',
          updatedAt: '2023-01-01T00:00:00',
          activeIngredients: [{ id: 1, name: 'Ingredient', dosage: '10%' }],
        },
      ] as Medication[],
    };

    medicationService.getMedications.and.returnValue(of(mockMedications));
    component.refetchMedications();
    medicationService.getMedications.and.returnValue(of(mockMedications));
    fixture.detectChanges();

    expect(medicationService.getMedications).toHaveBeenCalled();
    expect(component.medicationData.medications.length).toBe(1);
    expect(component.medicationData.total).toBe(2);
  });

  it('should handle adding a medication', () => {
    const newMedication = {
      id: 2,
      name: 'New Medication',
      competentAuthorityStatus: 'Authorised',
      internalStatus: 'Active',
      unit: 'ml(s)',
      pharmaceuticalFormId: 1,
      pharmaceuticalFormName: 'SOLUTION FOR INJECTION',
      atcCodeId: 1,
      atcCodeName: 'A02AA01',
      therapeuticClassId: 1,
      therapeuticClassName: 'CLASS',
      classificationName: 'POM',
      createdAt: '2023-01-01T00:00:00',
      updatedAt: '2023-01-01T00:00:00',
      activeIngredients: [],
    } as Medication;

    medicationService.addMedication.and.returnValue(of(newMedication));

    component.addMedication(newMedication);

    expect(medicationService.addMedication).toHaveBeenCalledWith(newMedication);
    expect(component.medicationData.medications).toContain(newMedication);
  });

  it('should handle deleting a medication', () => {
    const medicationToDelete = { id: 1 } as Medication;
    medicationService.deleteMedication.and.returnValue(of({} as Medication));

    component.medicationData.medications = [medicationToDelete];
    component.onDelete(medicationToDelete);

    expect(medicationService.deleteMedication).toHaveBeenCalledWith(1);
    expect(component.medicationData.medications).not.toContain(
      medicationToDelete
    );
  });

  it('should handle updating a medication', () => {
    const updatedMedication = {
      id: 1,
      name: 'Updated Medication',
      competentAuthorityStatus: 'Withdrawn',
      internalStatus: 'Inactive',
      unit: 'mg',
      pharmaceuticalFormId: 2,
      pharmaceuticalFormName: 'TABLET',
      atcCodeId: 2,
      atcCodeName: 'A02AA02',
      therapeuticClassId: 2,
      therapeuticClassName: 'NEW CLASS',
      classificationName: 'OTC',
      createdAt: '2023-01-01T00:00:00',
      updatedAt: '2023-01-01T00:00:00',
      activeIngredients: [],
    } as Medication;

    medicationService.updateMedication.and.returnValue(of(updatedMedication));

    component.medicationData.medications = [
      {
        id: 1,
        name: 'Old Medication',
        competentAuthorityStatus: 'Authorised',
        internalStatus: 'Active',
        unit: 'ml(s)',
        pharmaceuticalFormId: 1,
        pharmaceuticalFormName: 'SOLUTION FOR INJECTION',
        atcCodeId: 1,
        atcCodeName: 'A01AA01',
        therapeuticClassId: 1,
        therapeuticClassName: 'CLASS',
        classificationName: 'POM',
        createdAt: '2023-01-01T00:00:00',
        updatedAt: '2023-01-01T00:00:00',
        activeIngredients: [],
      } as Medication,
    ];

    component.updateMedication(1, updatedMedication);

    expect(medicationService.updateMedication).toHaveBeenCalledWith(
      1,
      updatedMedication
    );
    expect(
      component.medicationData.medications.find((m) => m.id === 1)
    ).toEqual(updatedMedication);
  });

  it('should show and hide the dialog correctly', () => {
    component.showDialog();
    expect(component.visible).toBeTrue();

    component.hideDialog();
    expect(component.visible).toBeFalse();
    expect(component.formGroup.value).toEqual({
      name: '',
      competentAuthorityStatus: '',
      internalStatus: '',
      unit: '',
      pharmaceuticalFormName: '',
      atcCodeName: '',
      therapeuticClassName: '',
      classificationName: '',
      activeIngredients: [],
    });
  });
});

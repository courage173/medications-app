import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Medication, MedicationData } from '../models/medication.model';
import { StateService } from './state.service';
import { catchError, tap } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class MedicationService {
  private apiUrl = environment.baseUrl + '/medications';

  constructor(private http: HttpClient, private stateService: StateService) {}

  getMedications({
    pageNumber = 1,
    itemsPerPage = 10,
    searchValue = '',
    sortBy = '',
    ascending = true,
  }: {
    pageNumber?: number;
    itemsPerPage?: number;
    searchValue?: string;
    sortBy?: string;
    ascending?: boolean;
  }): Observable<MedicationData> {
    return this.http
      .get<MedicationData>(
        `${this.apiUrl}/?pageNumber=${pageNumber}&pageSize=${itemsPerPage}&searchTerm=${searchValue}&sortBy=${sortBy}&ascending=${ascending}`
      )
      .pipe(
        tap(() => this.stateService.setLoading(false)),
        catchError((error) => {
          this.stateService.setLoading(false);
          this.stateService.setError(error.message);
          return throwError(() => new Error(error.message));
        })
      );
  }

  getMedicationById(id: number): Observable<Medication> {
    return this.http.get<Medication>(`${this.apiUrl}/${id}`).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }

  addMedication(medication: Medication): Observable<Medication> {
    return this.http.post<Medication>(this.apiUrl, medication).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }

  updateMedication(id: number, medication: Medication): Observable<Medication> {
    return this.http.put<Medication>(`${this.apiUrl}/${id}`, medication).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }

  deleteMedication(id: number): Observable<Medication> {
    return this.http.delete<Medication>(`${this.apiUrl}/${id}`).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }
}

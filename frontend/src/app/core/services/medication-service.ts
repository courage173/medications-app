import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Medication } from '../models/medication.model';
import { StateService } from './state.service';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class MedicationService {
  private apiUrl = 'http://localhost:5283/api/medications';
  constructor(private http: HttpClient, private stateService: StateService) {}

  getMedications(pageNumber = 1): Observable<Medication[]> {
    return this.http
      .get<Medication[]>(`${this.apiUrl}/?pageNumber=${pageNumber}&pageSize=15`)
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

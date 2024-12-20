import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { PharmaceuticalForm } from '../models/pharmaceutical-form.model';
import { StateService } from './state.service';
import { catchError, tap } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class PharmaceuticalFormService {
  private apiUrl = environment.baseUrl + '/pharmaceuticalForm';

  constructor(private http: HttpClient, private stateService: StateService) {}

  getPharmaceuticalForms(page = 1): Observable<PharmaceuticalForm[]> {
    return this.http
      .get<PharmaceuticalForm[]>(
        `${this.apiUrl}?pageNumber=${page}&pageSize=100`
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

  getPharmaceuticalFormById(id: number): Observable<PharmaceuticalForm> {
    return this.http.get<PharmaceuticalForm>(`${this.apiUrl}/${id}`).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }

  addPharmaceuticalForm(form: string): Observable<PharmaceuticalForm> {
    return this.http.post<PharmaceuticalForm>(this.apiUrl, { form }).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }

  updatePharmaceuticalForm(
    id: number,
    form: string
  ): Observable<PharmaceuticalForm> {
    return this.http
      .put<PharmaceuticalForm>(`${this.apiUrl}/${id}`, { form })
      .pipe(
        tap(() => this.stateService.setLoading(false)),
        catchError((error) => {
          this.stateService.setLoading(false);
          this.stateService.setError(error.message);
          return throwError(() => new Error(error.message));
        })
      );
  }

  deletePharmaceuticalForm(id: number): Observable<PharmaceuticalForm> {
    return this.http.delete<PharmaceuticalForm>(`${this.apiUrl}/${id}`).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }
}

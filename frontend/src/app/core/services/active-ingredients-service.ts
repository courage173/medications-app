import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { ActiveIngredient } from '../models/active-ingredients.model';
import { StateService } from './state.service';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ActiveIngredientService {
  private apiUrl = 'http://localhost:5283/api/activeIngredient';

  constructor(private http: HttpClient, private stateService: StateService) {}

  getActiveIngredients(page = 1): Observable<ActiveIngredient[]> {
    return this.http
      .get<ActiveIngredient[]>(`${this.apiUrl}/?pageNumber=${page}&pageSize=15`)
      .pipe(
        tap(() => this.stateService.setLoading(false)),
        catchError((error) => {
          this.stateService.setLoading(false);
          this.stateService.setError(error.message);
          return throwError(() => new Error(error.message));
        })
      );
  }

  getActiveIngredientById(id: number): Observable<ActiveIngredient> {
    return this.http.get<ActiveIngredient>(`${this.apiUrl}/${id}`).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }

  addActiveIngredient(name: string): Observable<ActiveIngredient> {
    return this.http.post<ActiveIngredient>(this.apiUrl, { name }).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }

  updateActiveIngredient(
    id: number,
    name: string
  ): Observable<ActiveIngredient> {
    return this.http
      .put<ActiveIngredient>(`${this.apiUrl}/${id}`, { name })
      .pipe(
        tap(() => this.stateService.setLoading(false)),
        catchError((error) => {
          this.stateService.setLoading(false);
          this.stateService.setError(error.message);
          return throwError(() => new Error(error.message));
        })
      );
  }

  deleteActiveIngredient(id: number): Observable<ActiveIngredient> {
    return this.http.delete<ActiveIngredient>(`${this.apiUrl}/${id}`).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }
}

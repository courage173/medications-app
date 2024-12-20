import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { TherapeuticClass } from '../models/therapeutic-class.model';
import { StateService } from './state.service';
import { catchError, tap } from 'rxjs/operators';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TherapeuticClassService {
  private apiUrl = environment.baseUrl + '/therapeuticClass';

  constructor(private http: HttpClient, private stateService: StateService) {}

  getTherapeuticClasss(page = 1): Observable<TherapeuticClass[]> {
    return this.http
      .get<TherapeuticClass[]>(
        `${this.apiUrl}/?pageNumber=${page}&pageSize=100`
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

  getTherapeuticClassById(id: number): Observable<TherapeuticClass> {
    return this.http.get<TherapeuticClass>(`${this.apiUrl}/${id}`).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }

  addTherapeuticClass(name: string): Observable<TherapeuticClass> {
    return this.http.post<TherapeuticClass>(this.apiUrl, { name }).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }

  updateTherapeuticClass(
    id: number,
    name: string
  ): Observable<TherapeuticClass> {
    return this.http
      .put<TherapeuticClass>(`${this.apiUrl}/${id}`, { name })
      .pipe(
        tap(() => this.stateService.setLoading(false)),
        catchError((error) => {
          this.stateService.setLoading(false);
          this.stateService.setError(error.message);
          return throwError(() => new Error(error.message));
        })
      );
  }

  deleteTherapeuticClass(id: number): Observable<TherapeuticClass> {
    return this.http.delete<TherapeuticClass>(`${this.apiUrl}/${id}`).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }
}

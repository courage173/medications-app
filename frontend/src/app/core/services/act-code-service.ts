import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { AtcCode } from '../models/atc-codes.model';
import { StateService } from './state.service';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AtcCodeService {
  private apiUrl = 'http://localhost:5283/api/atcCodes?';

  constructor(private http: HttpClient, private stateService: StateService) {}

  getAtcCodes(page = 1): Observable<AtcCode[]> {
    return this.http
      .get<AtcCode[]>(`${this.apiUrl}/pageNumber=${page}&pageSize=15`)
      .pipe(
        tap(() => this.stateService.setLoading(false)),
        catchError((error) => {
          this.stateService.setLoading(false);
          this.stateService.setError(error.message);
          return throwError(() => new Error(error.message));
        })
      );
  }

  getAtcCodeById(id: number): Observable<AtcCode> {
    return this.http.get<AtcCode>(`${this.apiUrl}/${id}`).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }

  addAtcCode(code: string): Observable<AtcCode> {
    return this.http.post<AtcCode>(this.apiUrl, { code }).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }

  updateAtcCode(id: number, code: string): Observable<AtcCode> {
    return this.http.put<AtcCode>(`${this.apiUrl}/${id}`, { code }).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }

  deleteAtcCode(id: number): Observable<AtcCode> {
    return this.http.delete<AtcCode>(`${this.apiUrl}/${id}`).pipe(
      tap(() => this.stateService.setLoading(false)),
      catchError((error) => {
        this.stateService.setLoading(false);
        this.stateService.setError(error.message);
        return throwError(() => new Error(error.message));
      })
    );
  }
}

import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { PersonAddress } from '../model/person-address.model';

@Injectable({
  providedIn: 'root'
})
export class PersonAddressService {
  private apiUrl = 'http://localhost:5267/api/PersonAddress'; // URL da sua API

  constructor(private http: HttpClient) { }

  // Obter todos os endereços
  getAddresses(): Observable<PersonAddress[]> {
    return this.http.get<PersonAddress[]>(this.apiUrl).pipe(
      catchError(this.handleError)
    );
  }

  // Obter um endereço pelo ID
  getAddress(id: string): Observable<PersonAddress> {
    const encodedId = encodeURIComponent(id);
    return this.http.get<PersonAddress>(`${this.apiUrl}/${encodedId}`).pipe(
      catchError(this.handleError)
    );
  }

  // Criar um novo endereço
  createAddress(address: PersonAddress): Observable<PersonAddress> {
    return this.http.post<PersonAddress>(this.apiUrl, address).pipe(
      catchError(this.handleError)
    );
  }

  // Atualizar um endereço existente
  updateAddress(id: string, address: PersonAddress): Observable<void> {
    const encodedId = encodeURIComponent(id);
    return this.http.put<void>(`${this.apiUrl}/${encodedId}`, address).pipe(
      catchError(this.handleError)
    );
  }

  // Excluir um endereço
  deleteAddress(id: string): Observable<void> {
    const encodedId = encodeURIComponent(id);
    return this.http.delete<void>(`${this.apiUrl}/${encodedId}`).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 400) {
      return throwError(error.error);
    }
    return throwError('An unknown error occurred.');
  }
}

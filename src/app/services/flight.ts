import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Flight {
  private apiUrl = "https://localhost:7169/api/Flight";

  constructor(private http: HttpClient) {}

  getFlights():Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  getFlightById(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }
}

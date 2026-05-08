import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class Booking {
  private apiUrl = "https://localhost:7169/api/Booking";

  constructor(private http: HttpClient) {
  }

  getBookings() {
    return this.http.get<any[]>(this.apiUrl);
  }

  getBookingById(id: number) {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }
}

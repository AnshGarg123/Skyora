import { ChangeDetectorRef, Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Booking } from '../../services/booking';

@Component({
  selector: 'app-booking-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './booking-list.html',
  styleUrl: './booking-list.css',
})
export class BookingList implements OnInit{
  bookings: any[] = [];

  constructor(private bookingService: Booking, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.bookingService.getBookings().subscribe({
      next: (data) => {
        this.bookings = data;
        console.log('Bookings fetched successfully:', this.bookings);
        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('Error fetching bookings:', error);
      }
    });
  }
}

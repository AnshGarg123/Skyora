import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Flight } from '../../../services/flight';

@Component({
  selector: 'app-flight-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './flight-list.html',
  styleUrl: './flight-list.css',
})
export class FlightList implements OnInit{
  flights: any[] = [];
  
  constructor(private flightService: Flight, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.flightService.getFlights().subscribe({
      next: (data) => {
        this.flights = data;
        console.log('Flights fetched successfully:', this.flights);
        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('Error fetching flights:', error);
      }
    });
  }
}

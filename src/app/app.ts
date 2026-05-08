import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CreateBooking } from "./features/bookings/create-booking/create-booking";
import { FlightList } from "./features/flights/flight-list/flight-list";
import { Navbar } from "./features/navbar/navbar";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, FlightList, Navbar],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('SkyOra-Frontend');
}

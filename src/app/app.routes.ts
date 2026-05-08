import { Routes } from '@angular/router';
import { FlightList } from './features/flights/flight-list/flight-list';
import { UserList } from './features/user-list/user-list';
import { BookingList } from './features/booking-list/booking-list';

export const routes: Routes = [
    { path: '', redirectTo: '/users', pathMatch: 'full' },
    { path: 'users', component: UserList },
    { path: 'flights', component: FlightList },
    { path: 'bookings', component: BookingList }
    // { path: 'passengers', component: PassengerListComponent }
];

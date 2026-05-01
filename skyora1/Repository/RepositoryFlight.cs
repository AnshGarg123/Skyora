using Microsoft.EntityFrameworkCore;
using skyora1.DAL;
using skyora1.Models;

namespace skyora1.Repository
{
    public class RepositoryFlight : IFlights
    {
        private readonly AppDbContext _context;

        public RepositoryFlight(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddFlightAsync(Flight flight)
        {
            await _context.flights.AddAsync(flight);
            await _context.SaveChangesAsync();
            return flight.FlightId;
        }

        public async Task<int> DeleteFlightAsync(int id)
        {
            var data = await _context.flights.Where(x => x.FlightId == id).FirstOrDefaultAsync();

            if (data != null)
            {
                _context.flights.Remove(data);
                await _context.SaveChangesAsync();
                return data.FlightId;

            }
            else
            {
                throw new KeyNotFoundException($"Flight with ID {id} not found.");
            }
        }

        public async Task<IEnumerable<Flight>> GetAllFlightsAsync()
        {
            var allFlights = await _context.flights.ToListAsync();
            return allFlights;
        }

        public async Task<Flight> GetFlightByIdAsync(int id)
        {
            var flight = _context.flights.Where(f => f.FlightId == id).FirstOrDefaultAsync();
            if (flight == null)
            {
                throw new KeyNotFoundException($"Flight with ID {id} not found.");
            }
            return await flight;
        }

        public async Task<int> EditFlightAsync(int id, Flight flight)
        {
            var data = await _context.flights.Where(x => x.FlightId == id).FirstOrDefaultAsync();

            if(data != null)
            {
                data.FlightNo = flight.FlightNo;
                data.Source = flight.Source;
                data.Destination = flight.Destination;
                data.DepartureTime = flight.DepartureTime;
                data.FlightId = flight.FlightId;
                data.TotalBusinessSeats = flight.TotalBusinessSeats;
                data.TotalEconomySeats = flight.TotalEconomySeats;
                data.AvailableBusinessSeats = flight.AvailableBusinessSeats;
                data.AvailableEconomySeats = flight.AvailableEconomySeats;
                data.BusinessPrice = flight.BusinessPrice;
                data.EconomyPrice = flight.EconomyPrice;

                await _context.SaveChangesAsync();
                return data.FlightId;
            }
            else
            {
                throw new KeyNotFoundException($"Flight with ID {id} not found.");
            }
        }
    }
}

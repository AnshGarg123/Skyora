using Microsoft.EntityFrameworkCore;
using skyora1.DAL;
using skyora1.Models;

namespace skyora1.Repository
{
    public class IBookingRepository : IBooking
    {
        private readonly AppDbContext appDbContext;
        public IBookingRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            
        }
        public async Task<int> AddBooking(Booking booking)
        {

            await appDbContext.bookings.AddAsync(booking);
            await appDbContext.SaveChangesAsync();
            return booking.BookingId;

        }

        public async Task<int> DeleteBooking(int id)
        {
            var bookingelement=await appDbContext.bookings.FirstOrDefaultAsync(x=>x.BookingId==id);
            if (bookingelement != null)
            {
                appDbContext.bookings.Remove(bookingelement);
                appDbContext.SaveChanges();
                return id;

            }
            else
                return 404;
        }



        public async Task<List<Booking>> GetBookingAsync()
        {
            return await appDbContext.bookings
                .Include(b => b.User)
                .Include(b => b.Flight)
                .Include(b => b.Passengers)
                .ToListAsync();
        }


        public async Task<Booking> GetBookingById(int id)
        {
            return await appDbContext.bookings
                .Include(b => b.User)
                .Include(b => b.Flight)
                .Include(b => b.Passengers)
                .FirstOrDefaultAsync(x => x.BookingId == id);
        }
    }
}

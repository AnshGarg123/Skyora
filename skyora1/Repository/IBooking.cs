using skyora1.Models;

namespace skyora1.Repository
{
    public interface IBooking
    {
        Task<List<Booking>> GetBookingAsync();
        Task<Booking> GetBookingById(int id);
        Task<int> DeleteBooking(int  id);
        Task<int> AddBooking(Booking booking);
    }
}

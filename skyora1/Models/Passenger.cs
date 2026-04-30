using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skyora1.Models
{
    public class Passenger
    {

        [Key]
        public int PassengerId { get; set; }
        [ForeignKey(nameof(PassengerId))]
        public int BookingId { get; set; }

        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
    }
}

using System;
using System.Collections.Generic;

namespace BookingApi.Models
{
    public partial class Booking
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int UserId { get; set; }
        public int HairdresserId { get; set; }
        public int TreatmentId { get; set; }

        public virtual Hairdresser Hairdresser { get; set; }
        public virtual Treatment Treatment { get; set; }
        public virtual User User { get; set; }
    }
}

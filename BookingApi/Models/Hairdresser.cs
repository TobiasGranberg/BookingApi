using System;
using System.Collections.Generic;

namespace BookingApi.Models
{
    public partial class Hairdresser
    {
        public Hairdresser()
        {
            Booking = new HashSet<Booking>();
            HairdresserTreatment = new HashSet<HairdresserTreatment>();
        }

        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public byte[] Image { get; set; }
        public string Password { get; set; }
        public bool IsModerator { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<HairdresserTreatment> HairdresserTreatment { get; set; }
    }
}

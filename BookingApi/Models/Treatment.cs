using System;
using System.Collections.Generic;

namespace BookingApi.Models
{
    public partial class Treatment
    {
        public Treatment()
        {
            Booking = new HashSet<Booking>();
            HairdresserTreatment = new HashSet<HairdresserTreatment>();
        }

        public int Id { get; set; }
        public double Price { get; set; }
        public int TimeLength { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<HairdresserTreatment> HairdresserTreatment { get; set; }
    }
}

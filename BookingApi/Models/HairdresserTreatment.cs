using System;
using System.Collections.Generic;

namespace BookingApi.Models
{
    public partial class HairdresserTreatment
    {
        public int Id { get; set; }
        public int HairdresserId { get; set; }
        public int TreatmentId { get; set; }

        public virtual Hairdresser Hairdresser { get; set; }
        public virtual Treatment Treatment { get; set; }
    }
}

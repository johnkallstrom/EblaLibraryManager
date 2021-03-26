using System;
using System.Collections.Generic;

#nullable disable

namespace EblaLibraryManager.Data.Models
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int ReservationStatusId { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
        public virtual ReservationStatus ReservationStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace EblaLibraryManager.Data.Models
{
    public partial class Book
    {
        public Book()
        {
            Lendings = new HashSet<Lending>();
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public int TotalPages { get; set; }
        public DateTime? Borrowed { get; set; }
        public DateTime? DueDate { get; set; }
        public int AvailabilityStatusId { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }

        public virtual Author Author { get; set; }
        public virtual AvailabilityStatus AvailabilityStatus { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Lending> Lendings { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}

using EblaLibraryManager.Data.Identity;
using System;

#nullable disable

namespace EblaLibraryManager.Data.Models
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Status { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public virtual Book Book { get; set; }
    }
}

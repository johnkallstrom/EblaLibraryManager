using System;

#nullable disable

namespace EblaLibraryManager.Data.Models
{
    public partial class Lending
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime? Returned { get; set; }
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}

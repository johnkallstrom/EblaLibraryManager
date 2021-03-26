using System;
using System.Collections.Generic;

#nullable disable

namespace EblaLibraryManager.Data.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Born { get; set; }
        public DateTime? Death { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace EblaLibraryManager.Data.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
}

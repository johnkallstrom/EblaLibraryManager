﻿using EblaLibraryManager.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EblaLibraryManager.Core.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
    }
}
using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Data.Interfaces
{
    public interface IApplicationsRepository
    {
        Application GetByApiKey(string apiKey);
    }
}

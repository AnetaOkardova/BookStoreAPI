using BookStoreAPI.Data.Interfaces;
using BookStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreAPI.Data
{
    public class ApplicationsRepository : IApplicationsRepository
    {
        private readonly BookStoreDbContext _dbContext;

        public ApplicationsRepository(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Application GetByApiKey(string apiKey)
        {
            return _dbContext.Applications.FirstOrDefault(x=> x.Key == apiKey);
        }
    }
}

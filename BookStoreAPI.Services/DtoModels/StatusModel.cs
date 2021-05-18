using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Services.DtoModels
{
    public class StatusModel
    {
        public StatusModel()
        {
            IsSuccessfull = true;
        }
        public string Message { get; set; }
        public bool IsSuccessfull { get; set; }
    }
}

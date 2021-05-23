using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookStoreAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Phone { get; set; }

        public DateTime DateCreated { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal FullPrice { get; set; }
        [Required]
        public List<BookOrder> Books { get; set; }
        //[Required]
        //public List<int> BookIds { get; set; }
    }
}

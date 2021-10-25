using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SevenJuat_API_Test.Models
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        
        [Required]
        public string AccountName { get; set; }
        
        public decimal Balance { get; set; }
        public List<Payment> Payments { get; set; }

    }
}

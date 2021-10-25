using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SevenJuat_API_Test.Models
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; }
        public DateTime Date { get; set; }

        [Required]
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public Guid AccountId { get; set; }

    }
}

using System;

namespace WebTest.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int? StudentId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public decimal? Points { get; set; }
        public string TransactionDescription { get; set; }
        public virtual Student Student { get; set; }
    }
}

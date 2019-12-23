
using System.Collections.Generic;

namespace WebTest.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public int? GradeId { get; set; }
        public string StudentName { get; set; }
        public string YiddishName { get; set; }
        public string Message { get; set; }
        public decimal? TotalPoints { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual List<Transaction> Transactions { get; set; }
    }
}

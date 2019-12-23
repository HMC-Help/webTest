using System.Collections.Generic;

namespace WebTest.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Teacher { get; set; }
        public decimal? GradePointTotal { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}

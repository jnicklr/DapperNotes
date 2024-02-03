using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNotes.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal EnrollmentValue { get; set; }
        public int StudentClass { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}

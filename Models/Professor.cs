using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperNotes.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal ValuePerHour { get; set; }
        public string AcademicDegree { get; set; }
    }
}

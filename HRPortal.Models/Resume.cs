using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class Resume
    {
        public Resume()
        {
            EducationHistory = new List<Education> {new Education(), new Education(), new Education()};
            EmploymentHistory = new List<Employment> {new Employment(), new Employment(), new Employment()};
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public List<Employment> EmploymentHistory { get; set; }
        //public Employment AddedEmploymentHistory { get; set; }
        public List<Education> EducationHistory { get; set; }
        //public Education AddedEducationHistory { get; set; }

        [DataType(DataType.Currency)]
        public decimal DesiredSalary { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfApplication { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class Resume : IValidatableObject
    {
        public Resume()
        {
            EducationHistory = new List<Education> {new Education(), new Education(), new Education()};
            EmploymentHistory = new List<Employment> {new Employment(), new Employment(), new Employment()};
        }

        public int ID { get; set; }

       // [Required(ErrorMessage = "Enter a name.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public List<Employment> EmploymentHistory { get; set; }
        public List<Education> EducationHistory { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal DesiredSalary { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfApplication { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(FirstName))
            {
                errors.Add(new ValidationResult("First Name", new[] { "FirstName" }));
            }

            if (string.IsNullOrEmpty(LastName))
            {
                errors.Add(new ValidationResult("Last Name", new[] { "LastName" }));
            }

            if (string.IsNullOrEmpty(Email))
            {
                errors.Add(new ValidationResult("Email", new[] { "Email" }));
            }

            if (string.IsNullOrEmpty(LastName))
            {
                errors.Add(new ValidationResult("Phone Number", new[] { "PhoneNumber" }));
            }

            if (string.IsNullOrEmpty(LastName))
            {
                errors.Add(new ValidationResult("Postion", new[] { "Position" }));
            }

            if (DesiredSalary == 0)
            {
                errors.Add(new ValidationResult("Desired Salary", new[] { "DesiredSalary" }));
            }

            return errors;
        }
    }
}

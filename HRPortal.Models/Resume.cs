﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class Resume
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public List<Employment> EmploymentHistory { get; set; }
        public List<Education> EducationHistory { get; set; }
        public Decimal DesiredSalary { get; set; }
        public DateTime DateOfApplication { get; set; }

    }
}

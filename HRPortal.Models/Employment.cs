using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class Employment
    {
        public string CompanyName { get; set; }
        [DataType(DataType.MultilineText)]
        public string JobDescription { get; set; }
        public string Position { get; set; }

        public int YearsOfEmployment { get; set; }
    }
}

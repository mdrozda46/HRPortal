using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class Education
    {
        public string Name { get; set; }
        public string Type { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HRPortal.Data;
using HRPortal.Models;

namespace HRPortal.UI
{
    public class PolicyToViewVM
    {
        public string categorySelected { get; set; }

        public List<SelectListItem> Categories { get; set; }
        public List<Policy> Policies { get; set; }

        public PolicyToViewVM()
        {
            var repo = new PolicyRepository();
            Categories = new List<SelectListItem>();
            Policies = new List<Policy>();

            var cats = repo.GetAllCategories();

            foreach (var c in cats)
            {
                var s = new SelectListItem();
                s.Text = c;
                s.Value = c ;

                Categories.Add(s);
            }

        }
    }

}

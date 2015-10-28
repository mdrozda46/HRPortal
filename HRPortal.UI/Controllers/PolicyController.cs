using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Data;

namespace HRPortal.UI.Controllers
{
    public class PolicyController : Controller
    {
        // GET: Policy
        public ActionResult Index()
        {
            var repo = new PolicyRepository();
            var categories = repo.GetAllCategories();
            var policies = repo.GetAllPolicies();
            return View();
        }
    }
}
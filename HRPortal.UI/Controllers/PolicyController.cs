using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Data;
using HRPortal.Models;

namespace HRPortal.UI.Controllers
{
    public class PolicyController : Controller
    {
        // GET: Policy
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewPolicies()
        {
            var PolicyToViewVM = new PolicyToViewVM();
            return View(PolicyToViewVM);
        }

        [HttpPost]
        public ActionResult ViewPolicies(PolicyToViewVM PVM)
        {
            var repo = new PolicyRepository();
            var policies = repo.GetAllPolicies();
            
            PVM.Policies = policies.Where(p => p.Category == PVM.categorySelected).ToList();
            return View(PVM);

        }

        public ActionResult ViewPolicy(int ID)
        {
            var repo = new PolicyRepository();
            var policy = repo.GetByID(ID);
            return View(policy);
        }

        public ActionResult ManagePolicies()
        {
            var PolicyToViewVM = new PolicyToViewVM();
            return View(PolicyToViewVM);
        }

        [HttpPost]
        public ActionResult ManagePolicies(PolicyToViewVM PVM)
        {
            var repo = new PolicyRepository();
            var policies = repo.GetAllPolicies();

            PVM.Policies = policies.Where(p => p.Category == PVM.categorySelected).ToList();
            return View(PVM);

        }

        public ActionResult DeletePolicy(int ID)
        {
            var repo = new PolicyRepository();
            repo.DeletePolicy(ID);
            return View("DeletePolicy");
        }

        public ActionResult AddPolicy()
        {
            var policyVM = new PolicyToViewVM();
            return View(policyVM);
        }

        [HttpPost]
        public ActionResult AddPolicy(string Name, string CategorySelected, string Description)
        {
            var repo = new PolicyRepository();
            var newPolicy = new Policy();

            newPolicy.Name = Name;
            newPolicy.Category = CategorySelected;
            newPolicy.Description = Description;

            repo.AddPolicy(newPolicy);

            return View("AddSuccess");
        }
    }
}
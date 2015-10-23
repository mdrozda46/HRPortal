using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Data;
using HRPortal.Models;

namespace HRPortal.UI.Controllers
{
    public class ApplyController : Controller
    {
        // GET: Apply
        public ActionResult Index()
        {
            return View(new Resume());
        }

        [HttpPost]
        public ActionResult AddResume(Resume resume)
        {

            
            var repo = Factory.CreateResumeRepository();

            resume.DateOfApplication = DateTime.Now;
            var resumes = repo.GetAll();
            resume.ID = resumes.Max(r => r.ID) + 1;
            repo.Add(resume);

            return View("Result");
        }

        public ActionResult AddEducation(Resume resume)
        {
            return View();
        }
    }
}
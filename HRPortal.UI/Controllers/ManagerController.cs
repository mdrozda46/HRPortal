using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRPortal.Data;
using HRPortal.Models;

namespace HRPortal.UI.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            var repo = Factory.CreateResumeRepository();
            var resumes = repo.GetAll();

            return View(resumes);
        }

        public ActionResult ViewResume(int ID)
        {
            var repo = Factory.CreateResumeRepository();
            var resume = repo.GetById(ID);

            return View(resume);
        }

        [HttpPost]
        public ActionResult DeleteResume(Resume resume)
        {
            var repo = Factory.CreateResumeRepository();
            repo.Delete(resume.ID);
            var resumes = repo.GetAll();

            return View("Index", resumes);
        }
    }
}
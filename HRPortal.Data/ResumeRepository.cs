using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data
{
    public class ResumeRepository : IResumeRepository
    {
        private static List<Resume> _resumes = new List<Resume>();

        public ResumeRepository()
        {
            if (!_resumes.Any())
            {
                List<Education> victorEducation = new List<Education>
                {
                    new Education() {Name = "Cleveland State University", Type = "Bachelor of Science", Description = "Computer Science"},
                    new Education() {Name = "Cleveland State University", Type = "Master of Science ", Description = "Mathematics"}
                };

                List<Education> randallEducation = new List<Education>
                {
                    new Education() {Name = "Ohio State University", Type = "Bachelor of Science", Description = "Computer Science"},

                };

                List<Employment> victorEmployment = new List<Employment>
                {
                    new Employment() {CompanyName = "Software Guild", Position = "Lead Instructor", JobDescription = "Taught apprentices", YearsOfEmployment = 1},
                    new Employment() {CompanyName = "DataBank IMX", Position = "Director of Development and Database Services", JobDescription = "Team development and database services", YearsOfEmployment = 2}
                };

                List<Employment> randallEmployment = new List<Employment>
                {
                    new Employment() {CompanyName = "Software Guild", Position = "TA", JobDescription = "Taught apprentices", YearsOfEmployment = 1},
                    new Employment() {CompanyName = "Cleveland Clinic", Position = "Senior Developer", JobDescription = "Web services architect", YearsOfEmployment = 2}
                };
                _resumes.AddRange(new List<Resume>()
                {
                    new Resume {ID = 1, FirstName = "Victor", LastName = "Pudelski", Email ="vpudelski@swguild.com", PhoneNumber = "876-5309", Position = "Lead Instructor", EmploymentHistory = victorEmployment, EducationHistory = victorEducation, DesiredSalary = 90000, DateOfApplication = (DateTime.Parse("10/23/2015"))},
                    new Resume {ID = 1, FirstName = "Randall", LastName = "Clapper", Email ="rclapper@swguild.com", PhoneNumber = "867-5309", Position = "TA", EmploymentHistory = randallEmployment, EducationHistory = randallEducation, DesiredSalary = 100000, DateOfApplication = (DateTime.Parse("10/23/2015"))}
                });
            }
        }

        public List<Resume> GetAll()
        {
            return _resumes;
        }

        public void Add(Resume newResume)
        {
            // ternary operator is saying:
            // if there are any resumes return the max contact id and add 1 to set our new resume id
            // else set to 1
            newResume.ID = (_resumes.Any()) ? _resumes.Max(r => r.ID) + 1 : 1;

            _resumes.Add(newResume);
        }

        public void Delete(int id)
        {
            _resumes.RemoveAll(r => r.ID == id);
        }

        public void Edit(Resume resume)
        {
            Delete(resume.ID);
            _resumes.Add(resume);
        }

        public Resume GetById(int id)
        {
            return _resumes.FirstOrDefault(r => r.ID == id);
        }
    }
}

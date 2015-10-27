using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data
{
    public class PolicyRepository
    {
        private const string _filePath = @"C:\_repos\HRPortal\HRPortal.UI\DataFiles\Policies\";

        private List<Policy> _policies = new List<Policy>();
        private List<string> _categories = new List<string>();

        public PolicyRepository()
        {
            _policies.Clear();
            _categories.Clear();

            _categories = Directory.GetDirectories(_filePath).ToList();
            string category = "";

            foreach (var folder in _categories)
            {
                Policy newPolicy = new Policy();

                var files = Directory.GetFiles(_filePath + folder);
                category = folder;

                foreach (var file in files)
                {
                    var reader = File.ReadAllLines(file);
                    newPolicy.CategoryID = category;
                    newPolicy.Name = file;

                    for (int i = 0; i < reader.Length; i++)
                    {
                        newPolicy.Description = newPolicy.Description + "\n" + reader[i];
                    }

                    _policies.Add(newPolicy);
                }

            }
        }
    
    public List<Policy> GetAllPolicies()
    {
        return _policies;
    }

        public List<string> GetAllCategories()
        {
            return _categories;
        } 

    public void AddPolicy(Policy newPolicy)
    {

        _policies.Add(newPolicy);
            AddCategory(newPolicy.CategoryID);

        WritePolicyToFile(newPolicy);
    }

        public void AddCategory(string newCategory)
        {
            if (!(_categories.Contains(newCategory)))
            {
                Directory.CreateDirectory(_filePath + newCategory);
                _categories.Add(newCategory);
            }
        }

    public void DeletePolicy(Policy policy)
    {
        _policies.RemoveAll(r => r.Name == policy.Name);

        string policyFilePath = _filePath + policy.CategoryID  + "\\" + policy.Name + ".txt";

        if (File.Exists(policyFilePath))
        {
            File.Delete(policyFilePath);
        }
    }

   //public Resume GetById(int id)
   // {
   //     return _resumes.FirstOrDefault(r => r.ID == id);
   // }

    private void WritePolicyToFile(Policy newPolicy)
    {
        //string resumeFilePath = _filePath + "Resume" + resume.ID + ".txt";

        //if (File.Exists(resumeFilePath))
        //{
        //    File.Delete(resumeFilePath);
        //}

        //using (var writer = File.CreateText(resumeFilePath))
        //{

        //    writer.WriteLine("{0}", resume.ID);
        //    writer.WriteLine("{0}", resume.FirstName);
        //    writer.WriteLine("{0}", resume.LastName);
        //    writer.WriteLine("{0}", resume.PhoneNumber);
        //    writer.WriteLine("{0}", resume.Email);
        //    writer.WriteLine("{0}", resume.DateOfApplication);
        //    writer.WriteLine("{0}", resume.Position);
        //    writer.WriteLine("{0}", resume.DesiredSalary);

        //    // Remove blank entries from list before writing to file
        //    resume.EmploymentHistory.RemoveAll(r => r.CompanyName == null);

        //    // Note the number of employment entries in the text file
        //    writer.WriteLine("{0}", resume.EmploymentHistory.Count);

        //    foreach (var employer in resume.EmploymentHistory)
        //    {
        //        writer.WriteLine("{0}", employer.CompanyName);
        //        writer.WriteLine("{0}", employer.Position);
        //        writer.WriteLine("{0}", employer.YearsOfEmployment);
        //        writer.WriteLine("{0}", employer.JobDescription);
        //    }

        //    // Remove blank entries from list before writing to file
        //    resume.EducationHistory.RemoveAll(r => r.Name == null);

        //    // Note the number of education entries in the text file
        //    writer.WriteLine("{0}", resume.EducationHistory.Count);

        //    foreach (var education in resume.EducationHistory)
        //    {
        //        writer.WriteLine("{0}", education.Name);
        //        writer.WriteLine("{0}", education.Type);
        //        writer.WriteLine("{0}", education.Description);
        //    }
       // }
    }
}
}

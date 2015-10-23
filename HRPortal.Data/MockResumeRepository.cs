using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data
{
    public class MockResumeRepository : IResumeRepository
    {
        private static List<Resume> _resumes = new List<Resume>();

        public MockResumeRepository()
        {
            if (!_resumes.Any())
            {
                _resumes.AddRange(new List<Resume>()
                {
                    new Resume {ContactID = 1, Name = "Victor Pudelski", PhoneNumber = "876-5309"},
                    new Resume {ContactID = 2, Name = "Randall Clapper", PhoneNumber = "555-5555"}
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

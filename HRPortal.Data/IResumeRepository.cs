using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data
{
    public interface IResumeRepository
    {
        List<Resume> GetAll();
        void Add(Resume newResume);
        void Delete(int id);
        void Edit(Resume resume);
        Resume GetById(int id);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
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

            var categoryDirectories = Directory.GetDirectories(_filePath).ToList();

            foreach (var folder in categoryDirectories)
            {
                var files = Directory.GetFiles(folder);

                foreach (var file in files)
                {
                    Policy newPolicy = new Policy();
                    var reader = File.ReadAllLines(file);
                    newPolicy.Category = reader[0];

                    if (!(_categories.Contains(newPolicy.Category)))
                    {
                        _categories.Add(newPolicy.Category);
                    }

                    newPolicy.Name = reader[1];

                    for (int i = 2; i < reader.Length; i++)
                    {
                        newPolicy.Description = newPolicy.Description + reader[i] + "\n";
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

            AddCategory(newPolicy.Category);

            WritePolicyToFile(newPolicy);
        }

        public void AddCategory(string newCategory)
        {
            if (!(_categories.Contains(newCategory)))
            {
                Directory.CreateDirectory((_filePath + newCategory).Replace(" ", String.Empty));
                _categories.Add(newCategory);
            }
        }

        public void DeletePolicy(Policy policy)
        {
            _policies.RemoveAll(r => r.Name == policy.Name);

            string policyFilePath = (_filePath + policy.Category + "\\" + policy.Name + ".txt").Replace(" ", String.Empty);

            if (File.Exists(policyFilePath))
            {
                File.Delete(policyFilePath);
            }
        }

        public Policy GetByName(string name)
         {
             return _policies.FirstOrDefault(r => r.Name == name);
         }

        private void WritePolicyToFile(Policy newPolicy)
        {
            string policyFilePath = (_filePath + newPolicy.Category + "\\" + newPolicy.Name + ".txt").Replace(" ", String.Empty);

            if (File.Exists(policyFilePath))
             {
                File.Delete(policyFilePath);
            }

            using (var writer = File.CreateText(policyFilePath))
            {

                writer.WriteLine("{0}", newPolicy.Category);
                writer.WriteLine("{0}", newPolicy.Name);
                writer.WriteLine("{0}", newPolicy.Description);

            }
        }
    }
}

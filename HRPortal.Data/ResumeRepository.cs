using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data
{
    public class ResumeRepository : IResumeRepository
    {
        private const string _filePath = @"C:\_repos\HRPortal\HRPortal.UI\DataFiles\Resumes\";
        private static List<Resume> _resumes = new List<Resume>();

        public ResumeRepository()
        {
            _resumes.Clear();

            var files = Directory.GetFiles(_filePath);

            foreach (var file in files)
            {
                Resume newResume = new Resume();
                newResume.EmploymentHistory = new List<Employment>();
                newResume.EducationHistory = new List<Education>();

                var reader = File.ReadAllLines(file);

                newResume.ID = int.Parse(reader[0]);
                newResume.FirstName = reader[1];
                newResume.LastName = reader[2];
                newResume.PhoneNumber = reader[3];
                newResume.Email = reader[4];
                newResume.DateOfApplication = DateTime.Parse(reader[5]);
                newResume.Position = reader[6];
                newResume.DesiredSalary = decimal.Parse(reader[7]);

                int lineCount = 9;


                // Line 8 in the text file contain the number of employment entries
                for (int i = 0; i < int.Parse(reader[8]); i++)
                {
                    Employment employment = new Employment();

                    employment.CompanyName = reader[lineCount++];
                    employment.Position = reader[lineCount++];
                    employment.YearsOfEmployment = int.Parse(reader[lineCount++]);
                    employment.JobDescription = reader[lineCount++];

                    newResume.EmploymentHistory.Add(employment);

                }

                int numOfEdu = int.Parse(reader[lineCount]);
                lineCount++;

                for (int i = 0; i < numOfEdu ; i++)
                {
                    Education education = new Education();

                    education.Name = reader[lineCount++];
                    education.Type = reader[lineCount++];
                    education.Description = reader[lineCount++];

                    newResume.EducationHistory.Add(education);

                }

                _resumes.Add(newResume);
                
            }
        }

        public List<Resume> GetAll()
        {
            return _resumes;
        }

        public void Add(Resume newResume)
        {

            newResume.ID = (_resumes.Any()) ? _resumes.Max(r => r.ID) + 1 : 1;

            _resumes.Add(newResume);
            WriteToFile(newResume);
        }

        public void Delete(int id)
        {
            _resumes.RemoveAll(r => r.ID == id);

            string resumeFilePath = _filePath + "Resume" + id + ".txt";

            if (File.Exists(resumeFilePath))
            {
                File.Delete(resumeFilePath);
            }
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

        private void WriteToFile(Resume resume)
        {
            string resumeFilePath = _filePath + "Resume" + resume.ID + ".txt";

            if (File.Exists(resumeFilePath))
            {
                File.Delete(resumeFilePath);
            }

            using (var writer = File.CreateText(resumeFilePath))
            {

                writer.WriteLine("{0}", resume.ID);
                writer.WriteLine("{0}", resume.FirstName);
                writer.WriteLine("{0}", resume.LastName);
                writer.WriteLine("{0}", resume.PhoneNumber);
                writer.WriteLine("{0}", resume.Email);
                writer.WriteLine("{0}", resume.DateOfApplication);
                writer.WriteLine("{0}", resume.Position);
                writer.WriteLine("{0}", resume.DesiredSalary);

                // Remove blank entries from list before writing to file
                resume.EmploymentHistory.RemoveAll(r => r.CompanyName == null);

                // Note the number of employment entries in the text file
                writer.WriteLine("{0}", resume.EmploymentHistory.Count);

                foreach (var employer in resume.EmploymentHistory)
                {
                    writer.WriteLine("{0}", employer.CompanyName);
                    writer.WriteLine("{0}", employer.Position);
                    writer.WriteLine("{0}", employer.YearsOfEmployment);
                    writer.WriteLine("{0}", employer.JobDescription);
                }

                // Remove blank entries from list before writing to file
                resume.EducationHistory.RemoveAll(r => r.Name == null);

                // Note the number of education entries in the text file
                writer.WriteLine("{0}", resume.EducationHistory.Count);

                foreach (var education in resume.EducationHistory)
                {
                    writer.WriteLine("{0}", education.Name);
                    writer.WriteLine("{0}", education.Type);
                    writer.WriteLine("{0}", education.Description);
                }
            }
        }

        private void LoadMockData()
        {
            if (!_resumes.Any())
            {
                List<Education> victorEducation = new List<Education>
                {
                    new Education()
                    {
                        Name = "Cleveland State University",
                        Type = "Bachelor of Science",
                        Description = "Computer Science"
                    },
                    new Education()
                    {
                        Name = "Cleveland State University",
                        Type = "Master of Science ",
                        Description = "Mathematics"
                    }
                };

                List<Education> randallEducation = new List<Education>
                {
                    new Education()
                    {
                        Name = "Ohio State University",
                        Type = "Bachelor of Science",
                        Description = "Computer Science"
                    },

                };

                List<Employment> victorEmployment = new List<Employment>
                {
                    new Employment()
                    {
                        CompanyName = "Software Guild",
                        Position = "Lead Instructor",
                        JobDescription = "Taught apprentices",
                        YearsOfEmployment = 1
                    },
                    new Employment()
                    {
                        CompanyName = "DataBank IMX",
                        Position = "Director of Development and Database Services",
                        JobDescription = "Team development and database services",
                        YearsOfEmployment = 2
                    }
                };

                List<Employment> randallEmployment = new List<Employment>
                {
                    new Employment()
                    {
                        CompanyName = "Software Guild",
                        Position = "TA",
                        JobDescription = "Taught apprentices",
                        YearsOfEmployment = 1
                    },
                    new Employment()
                    {
                        CompanyName = "Cleveland Clinic",
                        Position = "Senior Developer",
                        JobDescription = "Web services architect",
                        YearsOfEmployment = 2
                    }
                };
                _resumes.AddRange(new List<Resume>()
                {
                    new Resume
                    {
                        ID = 1,
                        FirstName = "Victor",
                        LastName = "Pudelski",
                        Email = "vpudelski@swguild.com",
                        PhoneNumber = "876-5309",
                        Position = "Lead Instructor",
                        EmploymentHistory = victorEmployment,
                        EducationHistory = victorEducation,
                        DesiredSalary = 90000,
                        DateOfApplication = (DateTime.Parse("10/23/2015"))
                    },
                    new Resume
                    {
                        ID = 2,
                        FirstName = "Randall",
                        LastName = "Clapper",
                        Email = "rclapper@swguild.com",
                        PhoneNumber = "867-5309",
                        Position = "TA",
                        EmploymentHistory = randallEmployment,
                        EducationHistory = randallEducation,
                        DesiredSalary = 100000,
                        DateOfApplication = (DateTime.Parse("10/23/2015"))
                    }
                });

                WriteToFile(_resumes[0]);
                WriteToFile(_resumes[1]);
            }

        }
    }
}

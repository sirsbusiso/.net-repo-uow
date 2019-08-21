using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUDWITHUOWPT1.ViewModels;
using CRUDWITHUOWPT1.Models;
using CRUDWITHUOWPT1.Repository;
using CRUDWITHUOWPT1.UnitOfWork;
using CRUDSEPARATIONOFCONCENTP1.ViewModels;
using CRUDSEPARATIONOFCONCENTP1.Entity;
using CRUDWITHUOWPT1.UnitOfWork;
using System.Security.Cryptography;
using System.Text;

namespace CRUDSEPARATIONOFCONCENTP1.BusinessLogic
{
    public class StudentBusinessLogic
    {
        public List<AllStudentViewModel> GetAllByCondition()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Repository<Student>().GetAll().Where(c => c.IsActive == true).Select(s => new AllStudentViewModel
                {
                    Name = s.Name,
                    Surname = s.Surname,
                    CourseName = s.Course.CourseName,
                    StudentNumber = s.StudentNumber,
                    IsActive = true,
                    StudentId = s.StudentId

                }).OrderBy(s => s.Surname).ToList();
            }
        }

        public void RemoveStudent(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var delete = uow.Repository<Student>().GetById(id);
                uow.Repository<Student>().Delete(delete);
                uow.SaveChanges();
            }
        }


        public void AddStudent(CreateStudentViewModel model)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var student = new Student
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    CourseId = model.CourseId,
                    IsActive = true,
                    IsDeleted = false,
                    StudentNumber = StudentNumber(),
                    DateCreated = model.DateCreated
                };
                uow.Repository<Student>().Insert(student);
                uow.SaveChanges();
            }

        }

        public List<AllStudentViewModel> SearchByName(string name)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Repository<Student>().GetAll().Where(s => s.Name.Contains(name) || s.Surname.Contains(name) || s.StudentNumber.Contains(name) || s.Course.CourseName.Contains(name)).Select(s => new AllStudentViewModel
                {
                    StudentId = s.StudentId,
                    CourseName = s.Course.CourseName,
                    Name = s.Name,
                    Surname = s.Surname,
                    IsActive = s.IsActive,
                    StudentNumber = s.StudentNumber

                }).ToList();
            }
        }

        private string StudentNumber()
        {
            int year = DateTime.Now.Year;
            string yearlast = year.ToString().Substring(2, 2);

            int maxsize = 6;
            char[] chars = new char[6];
            string a = "1234567890";
            chars = a.ToCharArray();
            int size = maxsize;
            byte[] data = new byte[1];

            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxsize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);

            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data) { result.Append(chars[b % (chars.Length)]); }
            string final = yearlast + result;

            return final.ToString();
        }

        public void GetById(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var student = uow.Repository<Student>().GetById(id);
            }

        }

        public void UpdateStudent(int id, GetByIdViewModel model)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var update = uow.Repository<Student>().GetById(id);
                if(update != null)
                {
                    update.Name = model.Name;
                    update.Surname = model.Surname;
                    update.CourseId = model.CourseId;
                    uow.Repository<Student>().Update(update);
                    uow.SaveChanges();
                }

             
            }
        }
    }
}
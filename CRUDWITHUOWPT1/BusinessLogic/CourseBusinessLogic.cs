
using CRUDSEPARATIONOFCONCENTP1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUDWITHUOWPT1.UnitOfWork;
using CRUDSEPARATIONOFCONCENTP1.Entity;

namespace CRUDSEPARATIONOFCONCENTP1.BusinessLogic
{
    public class CourseBusinessLogic
    {
        //List all the records from the database
        public List<AllCoursesViewModel> GetAllCourses()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Repository<Course>().GetAll().Where(c => c.IsActive == true).Select(c => new AllCoursesViewModel
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName,
                    DateCreated = c.DateCreated
                }).OrderBy(c => c.CourseName).ToList();
            }
        }

        //Add new record onto the database
        public void AddCourse(CreateCourseViewModel model)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var course = new Course
                {
                    CourseName = model.CourseName,
                    IsActive = true,
                    DateCreated = model.DateCreated,
                    IsDeleted = false
                };
                uow.Repository<Course>().Insert(course);
               
                uow.SaveChanges();
                
            }
        }

        //Gets and return the view of the record matching the specified id
        public GetCourseByIdViewModel GetById(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var course = uow.Repository<Course>().GetById(id);
                return new GetCourseByIdViewModel
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    DateCreated = course.DateCreated
                };
            }
        }

        //Update the record that matches the specified id
        public void UpdateCourse(int id, GetCourseByIdViewModel model)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var getCourse = uow.Repository<Course>().GetById(id);
                getCourse.CourseName = model.CourseName;
                uow.Repository<Course>().Update(getCourse);
                uow.SaveChanges();
            }
        }
        
        //Remove the record from the database that matches the id
        public void DeleteCourse(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var delete = uow.Repository<Course>().GetById(id);
                uow.Repository<Course>().Delete(delete);
                uow.SaveChanges();
            }
        }

        //Returns the list of a record(s) that matches the parameter
        public List<AllCoursesViewModel> SearchCourse(string name)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                return uow.Repository<Course>().GetAll().Where(c => c.CourseName.Contains(name)).Select(c => new AllCoursesViewModel
                {
                    CourseName = c.CourseName,
                    DateCreated = c.DateCreated
                }).ToList();
            }
        }

    }


}



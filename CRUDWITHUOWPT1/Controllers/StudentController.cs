using CRUDSEPARATIONOFCONCENTP1.BusinessLogic;
using CRUDSEPARATIONOFCONCENTP1.ViewModels;
using CRUDWITHUOWPT1.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDWITHUOWPT1.Controllers
{

    public class StudentController : Controller
    {
        StudentBusinessLogic student = new StudentBusinessLogic();
        CourseBusinessLogic course = new CourseBusinessLogic();
        // GET: Calls the method from business logic to return all the records
        // Pass the stirng variable to search method from the business logic to return record(s) base on it.
        public ActionResult Index(string name, int? page, string SortOrder)
        {
            ViewBag.CourseName = SortOrder == "CourseName" ? "Course_Descending" : "CourseName";
            ViewBag.StudentName = SortOrder == "StudentName" ? "Student_Descending" : "StudentName";
            ViewBag.StudentSurname = SortOrder == "StudentSurname" ? "Surname_Descending" : "StudentSurname";
            ViewBag.StudentNumber = SortOrder == "StudentNumber" ? "Number_Descending" : "StudentNumber";

            var studentget = from i in student.GetAllByCondition()
                             select i;
            var studentsearched = from s in student.SearchByName(name)
                                  select s;

            if (name == null)
            {

                int pagesize = 5;
                int pagenumber = (page ?? 1);

                switch (SortOrder)
                {
                    case "Course_Descending":
                        studentget = studentget.OrderByDescending(x => x.CourseName).ToList();
                        break;
                    case "CourseName":
                        studentget = studentget.OrderBy(x => x.CourseName).ToList();
                        break;
                    case "Student_Descending":
                        studentget = studentget.OrderByDescending(x => x.Name).ToList();
                        break;
                    case "StudentName":
                        studentget = studentget.OrderBy(x => x.Name).ToList();
                        break;
                    case "Surname_Descending":
                        studentget = studentget.OrderByDescending(x => x.Surname).ToList();
                        break;
                    case "StudentSurname":
                        studentget = studentget.OrderBy(x => x.Surname).ToList();
                        break;
                    case "Number_Descending":
                        studentget = studentget.OrderByDescending(x => x.StudentNumber).ToList();
                        break;
                    case "StudentNumber":
                        studentget = studentget.OrderBy(x => x.StudentNumber).ToList();
                        break;
                    default:
                        studentget = studentget.OrderBy(x => x.Name).ToList();
                        break;
                }
                return View(studentget.ToPagedList(pagenumber, pagesize));
            }

            else if (name != null)
            {
                int pagesize = 5;
                int pagenumber = (page ?? 1);

                switch (SortOrder)
                {
                    case "Course_Descending":
                        studentsearched = studentsearched.OrderByDescending(x => x.CourseName).ToList();
                        break;
                    case "CourseName":
                        studentsearched = studentsearched.OrderBy(x => x.CourseName).ToList();
                        break;
                    case "Student_Descending":
                        studentsearched = studentsearched.OrderByDescending(x => x.Name).ToList();
                        break;
                    case "StudentName":
                        studentsearched = studentsearched.OrderBy(x => x.Name).ToList();
                        break;
                    case "Surname_Descending":
                        studentsearched = studentsearched.OrderByDescending(x => x.Surname).ToList();
                        break;
                    case "StudentSurname":
                        studentsearched = studentsearched.OrderBy(x => x.Surname).ToList();
                        break;
                    case "Number_Descending":
                        studentsearched = studentsearched.OrderByDescending(x => x.StudentNumber).ToList();
                        break;
                    case "StudentNumber":
                        studentsearched = studentsearched.OrderBy(x => x.StudentNumber).ToList();
                        break;
                    default:
                        studentsearched = studentsearched.OrderBy(x => x.Name).ToList();
                        break;
                }
                return View(studentsearched.ToPagedList(pagenumber,pagesize));
            }
            return RedirectToAction("Index");
        }

        // GET: Student/Details/5
        // Call the getby id method from business logic to return the record matching the id
        //public ActionResult Details(int id)
        //{
        //    if (id != 0)
        //    {
        //        GetByIdViewModel model = student.GetByStudentId(id);
        //        return PartialView("_Details",model);
        //    }
        //    return RedirectToAction("Index");
        //}

        // GET: Student/Create
        // Returns the create view 
        public ActionResult Create()
        {
            var course = new CourseBusinessLogic();
            ViewBag.StudentCourseId = new SelectList(course.GetAllCourses(), "CourseId", "CourseName", "Please Select");

            return View();
        }

        // POST: Student/Create
        // Calls the method from the business logic to add onto database
        [HttpPost]
        public ActionResult Create(CourseStudentViewModel model)
        {
            model.Student.DateCreated = DateTime.Now;
            
            if (ModelState.IsValid)
            {
                student.AddStudent(model.Student);
                return RedirectToAction("Index");
            }
            ViewBag.StudentCourseId = new SelectList(course.GetAllCourses(), "CourseId", "CourseName", "Please Select");
            return View(model);
        }

      
        // GET: Student/Edit/5
        //returns the view for the update
        //public ActionResult Edit(int id)
        //{
        //    if (id != 0)
        //    {
        //        GetByIdViewModel model = student.GetByStudentId(id);
        //        var course = new CourseBusinessLogic();
        //        ViewBag.CourseId = new SelectList(course.GetAllCourses(), "CourseId", "CourseName");
        //        return PartialView("_Update", model);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }

        //}

        // POST: Student/Edit/5
        // Calls the method from the business logic to update a record based on the id
        //[HttpPost]
        //public ActionResult Edit(int id, GetByIdViewModel model)
        //{
        //    if (id == 0)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    //Calling the get method from the student business logic
        //    else
        //    {
        //        student.GetByStudentId(id);
        //        student.UpdateStudent(id, model);
        //        var course = new CourseBusinessLogic();
        //        ViewBag.CourseId = new SelectList(course.GetAllCourses(), "CourseId", "CourseName");
        //        return RedirectToAction("Index");

        //    }

        //}
        // Calls the deelete method from the business logic to remove the record based on the specified record
        public ActionResult Delete(int id)
        {
            if (id != 0)
            {
                student.GetById(id);

                student.RemoveStudent(id);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }
    }
}

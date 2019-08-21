using CRUDSEPARATIONOFCONCENTP1.BusinessLogic;
using CRUDSEPARATIONOFCONCENTP1.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDWITHUOWPT1.Controllers
{
    public class CourseController : Controller
    {

        CourseBusinessLogic course = new CourseBusinessLogic();
        // GET: Call the method that returns all courses
        // Search: returns all courses matching specified search term
        public ActionResult Index(string name, int? page, string SortOrder)
        {
            ViewBag.SortByCourseName = SortOrder == "CourseName" ? "Course_Descending" : "CourseName";
            ViewBag.SortByDate = SortOrder == "Date" ? "Date_Descending" : "Date";


            if (name == null)
            {
                var getcourse = from i in course.GetAllCourses()
                                select i;
                switch (SortOrder)
                {
                    case "Course_Descending":
                        getcourse = getcourse.OrderByDescending(x => x.CourseName).ToList();
                        break;
                    case "CourseName":
                        getcourse = getcourse.OrderBy(x => x.CourseName).ToList();
                        break;
                    case "Date_Descending":
                        getcourse = getcourse.OrderByDescending(x => x.DateCreated).ToList();
                        break;
                    case "Date":
                        getcourse = getcourse.OrderBy(x => x.DateCreated).ToList();
                        break;
                    default:
                        getcourse = getcourse.OrderBy(x => x.CourseName).ToList();
                        break;

                }

                int pagesize = 5;
                int pagenumber = (page ?? 1);

                return View(getcourse.ToPagedList(pagenumber, pagesize));
            }
            else
            {
                var getcoursebysearch = from i in course.SearchCourse(name)
                                        select i;
                switch (SortOrder)
                {
                    case "Course_Descending":
                        getcoursebysearch = getcoursebysearch.OrderByDescending(x => x.CourseName).ToList();
                        break;
                    case "CourseName":
                        getcoursebysearch = getcoursebysearch.OrderBy(x => x.CourseName).ToList();
                        break;
                    case "Date_Descending":
                        getcoursebysearch = getcoursebysearch.OrderByDescending(x => x.DateCreated).ToList();
                        break;
                    case "Date":
                        getcoursebysearch = getcoursebysearch.OrderBy(x => x.DateCreated).ToList();
                        break;
                    default:
                        getcoursebysearch = getcoursebysearch.OrderBy(x => x.CourseName).ToList();
                        break;
                }

                int pagesize = 5;
                int pagenumber = (page ?? 1);

                return View(getcoursebysearch.ToPagedList(pagenumber, pagesize));
            }
        }

        [HttpPost]
        public JsonResult SearchJson(string name)
        {
            var get = course.SearchCourse(name);

            return Json(get, JsonRequestBehavior.AllowGet);
        }


        // GET: Course/Details/5
        //// Calls the method from business logic that returns details for each record from the database based on the record id
        //public ActionResult Details(int id)
        //{
        //    if (id != 0)
        //    {
        //        GetCourseByIdViewModel model = course.GetById(id);

        //        return PartialView("_Details", model);
        //    }
        //    return RedirectToAction("Index");
        //}

        // GET: Course/Create
        // return the create view
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // Call the method from business logic that adds a record onto database
        [HttpPost]
        public ActionResult Create(CreateCourseViewModel model)
        {
            model.DateCreated = DateTime.Now;
            if (ModelState.IsValid)
            {
                course.AddCourse(model);
                return RedirectToAction("Create","Student");
            }
            return View(model);
        }

        // GET: Course/Edit/5
        // Call the method from business logic to return the record based on the id
        //public ActionResult Edit(int id)
        //{
        //    GetCourseByIdViewModel model = course.GetById(id);
        //    return PartialView("_Update",model);
        //}

        //// POST: Course/Edit/5
        //// Call the update method from business logic and post the view 
        //[HttpPost]
        //public ActionResult Edit(int id, GetCourseByIdViewModel model)
        //{
        //    if (id != 0)
        //    {
        //        course.UpdateCourse(id, model);
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}

        // Call the delete method from business logic to remove the record based on the record id
        public ActionResult Delete(int id)
        {
            if (id != 0)
            {
                course.GetById(id);
                course.DeleteCourse(id);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}

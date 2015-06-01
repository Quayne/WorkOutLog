using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;
using WorkoutLog.Data;

namespace WorkoutLog.MVC.Controllers
{
    [Authorize]
    public class WorkoutLogController : Controller
    {
        //protected static string _email;

        
        // GET: /WorkoutLog/
        [HttpGet]
        public ActionResult Index()
        {
            var email = User.Identity.Name;

            //get user
            var personProvider = new PersonsProvider();
            Persons person = personProvider.GetByKey(email);

            if (person == null)
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "Authentication");
            }

            ViewBag.Person = person;

            
            var provider = new ExerciseProvider();
            var items = provider.GetAllByKey(person.EmailAddress);
            return View(items);
        }

        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            var bpProvider = new BodyPartsProvider();
            ViewBag.BodyParts = bpProvider.GetAll();

            var etProvider = new ExerciseTypeProvider();
            ViewBag.ExerciseTypes = etProvider.GetAll();

            IExercise item;
            if (id > 0)
            {
                var provider = new ExerciseProvider();

                item = provider.GetByID(id);
                return View(item);
            }

            return View();
        }


        /// <summary>
        /// TODO: 
        /// Insert exercise where emailAddress equal logged in user email address
        /// </summary>
        /// <param name="exercise"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(Exercise exercise)
        {
            var provider = new ExerciseProvider();

            bool isSuccess;
            if (exercise.ID > 0)
                isSuccess = provider.Update(exercise);
            else
                isSuccess = provider.Insert(exercise);

            if (isSuccess)
                return RedirectToAction("Index");

            return View("Add");
        }

        /// <summary>
        /// Delete exercise by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var provider = new ExerciseProvider();
            provider.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

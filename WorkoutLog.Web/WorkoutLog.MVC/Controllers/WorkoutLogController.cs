using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;
using WorkoutLog.Data;

namespace WorkoutLog.MVC.Controllers
{
    public class WorkoutLogController : Controller
    {
        //
        // GET: /WorkoutLog/
        [HttpGet]
        public ActionResult Index()
        {
            var provider = new ExerciseSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);
            var items = provider.GetAll();
            return View(items);
        }

        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            var bpProvider = new BodyPartSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);
            ViewBag.BodyParts = bpProvider.GetAll();

            var etProvider = new ExerciseTypeSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);
            ViewBag.ExerciseTypes = etProvider.GetAll();

            IExercise item;// = new Exercise();
            if (id > 0)
            {
                var provider = new ExerciseSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);

                item = provider.GetById(id);
                return View(item);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Add(Exercise exercise)
        {            
            var provider = new ExerciseSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);

            bool isSuccess;
            if (exercise.ID > 0)
                isSuccess = provider.Update(exercise);
            else
                isSuccess = provider.Insert(exercise);

            if (isSuccess)
                return RedirectToAction("Index");

            return View("Add");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {            
            var provider = new ExerciseSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);
            provider.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

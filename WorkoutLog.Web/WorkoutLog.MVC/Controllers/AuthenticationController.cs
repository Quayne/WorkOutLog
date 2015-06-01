using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkoutLog.Data;
using WorkoutLog.Core.Model;
using System.Web.Security;

namespace WorkoutLog.MVC.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Persons person)
        {
            if (Authenticate(person))
            {
                FormsAuthentication.SetAuthCookie(person.EmailAddress, createPersistentCookie: true);
                FormsAuthentication.RedirectFromLoginPage(person.EmailAddress, false);
                
                //return View();
            }

            ViewBag.Summary = "Your login attempt was not successful. Please try again.";
            return View("Login");
        }

        [HttpGet]
        public void LogOff(Persons person)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();            
        }

        /// <summary>
        /// Validate login
        /// </summary>
        /// <param name="person"></param>
        /// <returns>True if username and password correspond</returns>
        private bool Authenticate(Persons person)
        {
            bool isSuccess = false;
            var provider = new PersonsProvider();

            if (person.EmailAddress != null && person.UserPassword.Length >= 3)
                if (provider.ValidateUser(person.EmailAddress, person.UserPassword))
                    isSuccess = true;

            return isSuccess;
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Call the PersonsProvider to insert a user if all fields are valid, then redirect to the login page.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(Persons person)
        {
            if (ValidateRegistration(person))
            {
                var provider = new PersonsProvider();
                provider.Insert(person);
                Response.Redirect("Login");
            }
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns>True if username is entered, emailaddress is entered and don't already exist in the database, password length is not less than 3,
        /// confirmation password matches initial password, false otherwise</returns>
        private bool ValidateRegistration(Persons person)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(person.UserName))
            {
                //usernameMsg.Text = "You must enter a username";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(person.EmailAddress))            {
                //emailMsg.Text = "You must enter a valid email address.";
                isValid = false;
            }
            else if (UserExists(person.EmailAddress.Trim()))
            {
                //Show email already exist
               // emailMsg.Text = "This email address already exist.";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(person.UserPassword) || person.UserPassword.Length < 3)
            {
                //passwordMsg.Text = "Password must be at least 3 characters long";
                isValid = false;
            }
            else if (person.ConfirmPassword.CompareTo(person.UserPassword) != 0)
            {
                //confirmPasswordMsg.Text = "Your passwords must correspond with each other.";                
                isValid = false;
            }

            return isValid;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool UserExists(string email)
        {
            var provider = new PersonsProvider();

            if (provider.GetByKey(email) != null)
            {
                return true;
            }

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;
using WorkoutLog.Data;


namespace WorkoutLog.Web
{
    public partial class Registration : System.Web.UI.Page, IPersons
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitRegistrationEvent(object sender, EventArgs e)
        {
            if (ValidateRegistration())
            {
                //Insert member
                var provider = new PersonsProvider();

                var person = new Persons();

                person.EmailAddress = EmailAddress;
                person.UserName = UserName;
                person.UserPassword = UserPassword;

                if (provider.Insert(person))
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private bool ValidateRegistration()
        {
            bool isValid = true;

            if (usernameTextBox.Text.ToString().Trim() == "")
            {
                usernameMsg.Text = "You must enter a username";
                isValid = false;
            }

            if (emailTextBox.Text.ToString().Trim() == "")
            {
                emailMsg.Text = "You must enter a valid email address.";
                isValid = false;
            }
            else if (UserExists(emailTextBox.Text.ToString().Trim()))
            {                
                emailMsg.Text = "This email address already exist.";
                isValid = false;
            }

            if (passwordTextBox.Text.Length < 3)
            {

                passwordMsg.Text = "Password must be at least 3 characters long";
                isValid = false;
            }
            else if (confirmPasswordTextBox.Text.CompareTo(passwordTextBox.Text) != 0)
            {
                confirmPasswordMsg.Text = "Your passwords must correspond with each other.";
                isValid = false;
            }

            return isValid;
        }


        private bool UserExists(string email)
        {
            var provider = new PersonsProvider();

            if (provider.GetByKey(email) != null)
            {
                return true;
            }

            return false;
        }


        public string EmailAddress
        {
            get
            {
                return emailTextBox.Text.ToString();
            }
            set
            {
                emailTextBox.Text = value.ToString();
            }
        }

        public string UserName
        {
            get
            {
                return usernameTextBox.Text.ToString();
            }
            set
            {
                usernameTextBox.Text = value.ToString();
            }
        }

        public string UserPassword
        {
            get
            {
                return passwordTextBox.Text.ToString();
            }
            set
            {
                passwordTextBox.Text = value.ToString();
            }
        }


        public string ConfirmPassword
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
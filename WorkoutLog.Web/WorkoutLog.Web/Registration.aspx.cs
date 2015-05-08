using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Data;


namespace WorkoutLog.Web
{
    public partial class Registration : System.Web.UI.Page, IPersons
    {
        private string _userName;
        private string _email;
        private string _password;
        private string _confirmpassword;   


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitRegistrationEvent(object sender, EventArgs e)
        {
            if (ValidateRegistration())
            {
                //Insert member
                var provider = new PersonSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);

                if (provider.Insert(this))
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
                //Show email already exist
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

        //public bool IsValidEmail(string strIn)
        //{
        //    bool invalid = false;
        //    if (String.IsNullOrEmpty(strIn))
        //        return false;

        //    // Use IdnMapping class to convert Unicode domain names. 
        //    try
        //    {
        //        strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
        //    }
        //    catch (RegexMatchTimeoutException)
        //    {
        //        return false;
        //    }

        //    if (invalid)
        //        return false;

        //    // Return true if strIn is in valid e-mail format. 
        //    try
        //    {
        //        return Regex.IsMatch(strIn,
        //              @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        //              @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
        //              RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        //    }
        //    catch (RegexMatchTimeoutException)
        //    {
        //        return false;
        //    }
        //}

        //private string DomainMapper(Match match)
        //{
        //    // IdnMapping class with default property values.
        //    IdnMapping idn = new IdnMapping();

        //    string domainName = match.Groups[2].Value;
        //    try
        //    {
        //        domainName = idn.GetAscii(domainName);
        //    }
        //    catch (ArgumentException)
        //    {
        //        invalid = true;
        //    }
        //    return match.Groups[1].Value + domainName;
        //}

        private bool UserExists(string email)
        {
            var provider = new PersonSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);

            if (provider.GetById(email) != null) 
            { 
                return true; 
            }

            return false;
        }

        //protected void CreateUserWizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
        //{
            
        //    if (e.CurrentStepIndex == 0)
        //    {
        //        if (SearchAccount.Text.Trim() == "" || UserExists(SearchAccount.Text))
        //        {
        //            SearchAccountMessage.Text = "That account already exists. Please select an different account name.";
        //            e.Cancel = true;
        //        }
        //        else
        //        {
        //            TextBox userName =
        //              (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName");
        //            userName.Text = SearchAccount.Text;
        //            SearchAccountMessage.Text = "";
        //            e.Cancel = false;

        //            //TODO: insert user
        //            //TODO: Redirect to login page
        //        }
        //    }
        //}

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
    }
}
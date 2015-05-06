using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkoutLog.Core;
using WorkoutLog.Data;

namespace WorkoutLog.Web
{
    public partial class Login : System.Web.UI.Page
    {           
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            lgSignIn.Authenticate += lgSignIn_Authenticate;
        }

        void lgSignIn_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //reference to the ExerciseSQLProvider class
            var provider = new PersonSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);
     
            //TODO: call member provider
            //var provider = new MemberProvider(Server.MapPath(Variables.MembersXmlFilePath));


            bool isSuccess = provider.ValidatePerson(lgSignIn.UserName, lgSignIn.Password);

            //bool isSuccess = provider.ValidateUser(lgSignIn.UserName, lgSignIn.Password);
            e.Authenticated = isSuccess;
        }
    }
}
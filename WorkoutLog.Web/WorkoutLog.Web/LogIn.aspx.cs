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
            bool isSuccess = false;

            if (Variables.UseXmlDataSource)
            {                
                var provider = new MemberXMLProvider(Server.MapPath(Variables.MembersXmlFilePath));

                isSuccess = provider.ValidateUser(lgSignIn.UserName, lgSignIn.Password);
            }
            else
            {
                //reference to the ExerciseSQLProvider class
                var provider = new PersonSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);

                isSuccess = provider.ValidatePerson(lgSignIn.UserName, lgSignIn.Password);
            }     
     
            e.Authenticated = isSuccess;
        }
    }
}
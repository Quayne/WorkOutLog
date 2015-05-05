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
    public partial class LogIn : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            lgSignIn.Authenticate += lgSignIn_Authenticate;
        }

        void lgSignIn_Authenticate(object sender, AuthenticateEventArgs e)
        {            
            //TODO: call member provider
            var provider = new MemberProvider(Server.MapPath(Variables.MembersXmlFilePath));
            bool isSuccess = provider.ValidateUser(lgSignIn.UserName, lgSignIn.Password);
            e.Authenticated = isSuccess;
        }

       protected void SubmitCredentials(object sender, EventArgs e)
       {
           
       }
    }
}
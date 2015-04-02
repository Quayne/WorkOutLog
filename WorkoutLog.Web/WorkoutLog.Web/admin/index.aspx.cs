using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkoutLog.Data;

namespace WorkoutLog.Web
{
    public partial class WorkoutTable : System.Web.UI.Page
    {

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            var provider = new ExerciseSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);
            var items = provider.GetAll();
            Repeater1.DataSource = items;
            Repeater1.DataBind();
        }

        /// <summary>
        /// Get the selected ID and pass it as an argument to the ExerciseSQLProvider to delete the selected record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">ExerciseID</param>
        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            int temp;
            int.TryParse(e.CommandArgument as string, out temp);

            var provider = new ExerciseSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);
            provider.Delete(temp);
        }
        
    }
}
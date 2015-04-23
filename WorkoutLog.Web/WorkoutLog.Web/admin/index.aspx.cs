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
    public partial class WorkoutTable : System.Web.UI.Page
    {
        /// <summary>
        /// Override the OnPreRender method to set _________ after any event occur
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            ////reference to the ExerciseSQLProvider class
            //var provider = new ExerciseSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);

            ////get all the records from the database
            //var items = provider.GetAll();

            var provider = new ExerciseXMLProvider(Server.MapPath(Variables.ExerciseXmlFilePath));
            var items = provider.ExerciseList;

            //Sets the data source that provides data for populating the repeater
            Repeater1.DataSource = items;

            //Binding data to the repeater
            Repeater1.DataBind();
        }

        /// <summary>
        /// Get the selected ID and pass it as an argument to the ExerciseSQLProvider to delete the selected record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">ExerciseID</param>
        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            //TODO: Remove exercise from XML

            int temp; //hold the ID passed in the query string

            //validate the input for integer value
            int.TryParse(e.CommandArgument as string, out temp);

            //reference to the ExerciseSQLProvider class
            var provider = new ExerciseSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);

            //pass the Exercise ID that should be deleted
            provider.Delete(temp);
        }
        
    }
}
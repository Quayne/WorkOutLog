using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkoutLog.Core;
using WorkoutLog.Core.Model;
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
            var items = provider.GetAll();

            //Sets the data source that provides data for populating the repeater
            Repeater1.DataSource = items;

            //Binding data to the repeater
            Repeater1.DataBind();
        }

        /// <summary>
        /// TODO: Need to determine if you want to delete from the database or the XML file
        /// Get the selected ID and pass it as an argument to the ExerciseSQLProvider to delete the selected record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            //TODO: Remove exercise from XML

            int tempId; //hold the ID passed in the query string

            //validate the input for integer value
            int.TryParse(e.CommandArgument as string, out tempId);

            //reference to the ExerciseSQLProvider class
            //var provider = new ExerciseSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);

            var provider = new ExerciseXMLProvider(Server.MapPath(Variables.ExerciseXmlFilePath));                 

            //pass the Exercise ID that should be deleted
            provider.Delete(tempId);
        }
        
   
    }
}
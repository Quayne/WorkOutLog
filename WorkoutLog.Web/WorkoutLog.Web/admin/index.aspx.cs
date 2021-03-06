﻿using System;
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

            var loginUser = HttpContext.Current.User.Identity.Name;
            var person = new PersonsProvider();
            Persons name = person.GetByKey(loginUser);

            LoginName.Text = name.UserName;

           
                var provider = new ExerciseProvider();

                //TODO: get all the records from the exercise.xml file based on the user that is logged in
                var items = provider.GetAllByKey(loginUser);

                //Sets the data source that provides data for populating the repeater
                Repeater1.DataSource = items;

                //Binding data to the repeater
                Repeater1.DataBind();            
        }

        /// <summary>
        /// Get the selected ID and pass it as an argument to the Provider to delete the selected record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {

            int tempId; //to hold the ID passed in the query string

            int.TryParse(e.CommandArgument as string, out tempId);


                var provider = new ExerciseProvider();

                //pass the ExerciseID to the ExerciseXMLProvider that should be deleted from the Exercise.xml file
                provider.Delete(tempId);         
        }

    }
}
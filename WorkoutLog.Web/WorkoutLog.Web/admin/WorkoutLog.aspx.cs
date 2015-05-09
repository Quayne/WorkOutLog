﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;
using WorkoutLog.Data;
using WorkoutLog.Core;

namespace WorkoutLog.Web
{
    public partial class Workout1 : System.Web.UI.Page, IExercise
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            LoadBodyPartsList(); 
            LoadExerciseTypeList();

            //TODO: Populate controls with existing data to be edited
            if (Variables.UseXmlDataSource)
            {
                if (!IsPostBack && ID > 0)
                {
                    var provider = new ExerciseXMLProvider(Server.MapPath(Variables.ExerciseXmlFilePath));

                    //Get record by ID
                    var item = provider.GetByID(ID);

                    // set IExercise Properties
                    BodyParts = item.BodyParts;
                    ExerciseName = item.ExerciseName;
                    ExerciseSets = item.ExerciseSets;
                    Reps = item.Reps;
                    Weights = item.Weights;
                }
            }
            else
            {
                //if not post back, get excercise by id
                if (!IsPostBack && ID > 0)
                {
                    //Create instance of ExerciseSQLProvider
                    var provider = new ExerciseSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);

                    //Get record by ID
                    var item = provider.GetById(ID);

                    // set IExercise Properties
                    BodyPartID = item.BodyPartID;
                    ExerciseTypeID = item.ExerciseTypeID;
                    ExerciseSets = item.ExerciseSets;
                    Reps = item.Reps;
                    Weights = item.Weights;
                }
            }
             
        }

        /// <summary>
        /// Load the Body Parts Dropdown list
        /// </summary>
        private void LoadBodyPartsList()
        {
            if (Variables.UseXmlDataSource)
            {
                ////TODO: Load the Body Parts Dropdown list from the exercise.xml file
                var provider = new BodyPartXMLProvider(Server.MapPath(Variables.BodyPartXmlFilePath));

                //get all the records from the database
                var items = provider.GetAll();

                //Sets the data source that provides data for populating the ddlBodyParts control
                ddlBodyParts.DataSource = items;

                //Binding data to the ddlBodyParts control
                ddlBodyParts.DataBind();
            }
            else
            {
                //Create instance of ExerciseSQLProvider
                var provider = new BodyPartSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);

                //get all the records from the database
                var items = provider.GetAll();

                //Sets the data source that provides data for populating the ddlBodyParts control
                ddlBodyParts.DataSource = items;

                //Binding data to the ddlBodyParts control
                ddlBodyParts.DataBind();
            }
            
        }

        /// <summary>
        /// Load the Exercise type Dropdown list
        /// </summary>
        private void LoadExerciseTypeList()
        {
            if (Variables.UseXmlDataSource)
            {
                //TODO: Load the Exercise type Dropdown list from the exercise.xml file
                var provider = new ExerciseTypeXMLProvider(Server.MapPath(Variables.ExerciseTypeXmlFilePath));

                //get all the records from the database
                var items = provider.GetAll();

                //Sets the data source that provides data for populating the ddlExerciseName control
                ddlExerciseName.DataSource = items;

                //Binding data to the ddlExerciseName control
                ddlExerciseName.DataBind();
            }
            else
            {
                //Create instance of ExerciseSQLProvider
                var provider = new ExerciseTypeSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);

                //get all the records from the database
                var items = provider.GetAll();

                //Sets the data source that provides data for populating the ddlExerciseName control
                ddlExerciseName.DataSource = items;

                //Binding data to the ddlExerciseName control
                ddlExerciseName.DataBind();
            }            
        }

        /// <summary>
        /// Determine whether to do a insert or a update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var loginUser = HttpContext.Current.User.Identity.Name;
            

            if (Variables.UseXmlDataSource)
            {
                SaveXML();
            }
            else
            {
                SaveToDatabase();
            }                       
        }

        /// <summary>
        /// Determine whether to do a insert or a update
        /// </summary>
        private void SaveToDatabase()
        {
            //Create instance of ExerciseSQLProvider
            var provider = new ExerciseSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);

            //if query string have ID, do update instead of insert
            if (Request.QueryString["id"] != null)
            {
                if (provider.Update(this))
                    Response.Redirect("~/admin/index.aspx");
            }
            else if (provider.Insert(this))
            {
                Response.Redirect("~/admin/index.aspx");
            } 
        }

        /// <summary>
        /// Determine whether to do a insert or a update
        /// </summary>
        private void SaveXML()
        {
            var provider = new ExerciseXMLProvider(Server.MapPath(Variables.ExerciseXmlFilePath));

            if (Request.QueryString["id"] != null)
            {
                int updateID;
                int.TryParse(Request.QueryString["id"], out updateID);
                provider.Update(this);
            }
            else
            {
                provider.Insert(this);                
            }            
            Response.Redirect("~/admin/index.aspx");
        }

   
        public new int ID
        {
            get
            {
                int tempInt;
                if (!int.TryParse(Request.QueryString["ID"], out tempInt)) { }
                return tempInt;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int ExerciseSets
        {
            get
            {
                int sets;
                int.TryParse(txtSets.Text, out sets);
                return sets;
            }
            set
            {
                txtSets.Text = value.ToString();
            }
        }

        public double Weights
        {
            get
            {
                double weights;
                double.TryParse(txtWeights.Text, out weights);
                return weights;
            }
            set
            {
                txtWeights.Text = value.ToString();
            }
        }

        public int Reps
        {
            get
            {
                int reps;
                int.TryParse(txtReps.Text, out reps);
                return reps;
            }
            set
            {
                txtReps.Text = value.ToString();
            }
        }

        public string EmailAddress
        {
            get
            {
                var loginUser = HttpContext.Current.User.Identity.Name;
                return loginUser;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int BodyPartID
        {
            get
            {
                int bodyPartID;
                int.TryParse(ddlBodyParts.SelectedValue, out bodyPartID);
                return bodyPartID;
            }
            set
            {
                ddlBodyParts.Text = value.ToString();
            }
        }

        public int ExerciseTypeID
        {
            get
            {
                int exerciseTypeID;
                int.TryParse(ddlExerciseName.SelectedValue, out exerciseTypeID);
                return exerciseTypeID;
            }
            set
            {

                ddlExerciseName.Text = value.ToString();
            }
        }

        public double TotalWeights
        {
            get { throw new NotImplementedException(); }
        }

        public string ExerciseName
        {
            get
            {
                return ddlExerciseName.SelectedValue;
            }
            set
            {
                ddlExerciseName.DataTextField = value.ToString();                
            }
        }

        public string BodyParts
        {
            get
            {
                return ddlBodyParts.SelectedValue;
            }
            set
            {
                ddlBodyParts.DataTextField = value.ToString();                
            }
        }

        public DateTime CurrentDate
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
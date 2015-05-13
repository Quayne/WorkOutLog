using System;
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
        
                 if (!IsPostBack && ID > 0)
                {
                    var provider = new ExerciseProvider();

                    //Get record by ID
                    var item = provider.GetByID(ID);

                    // set IExercise Properties
                    BodyPartID = item.BodyPartID;
                    ExerciseTypeID = item.ExerciseTypeID;
                    ExerciseSets = item.ExerciseSets;
                    Reps = item.Reps;
                    Weights = item.Weights;
                    
                }            
        }

        /// <summary>
        /// Load the Body Parts Dropdown list
        /// </summary>
        private void LoadBodyPartsList()
        {
            var provider = new BodyPartsProvider();

            //get all the records from the database
            var items = provider.GetAll();

            //Sets the data source that provides data for populating the ddlBodyParts control
            ddlBodyParts.DataSource = items;

            //Binding data to the ddlBodyParts control
            ddlBodyParts.DataBind();
            
        }

        /// <summary>
        /// Load the Exercise type Dropdown list
        /// </summary>
        private void LoadExerciseTypeList()
        {
           
                //TODO: Load the Exercise type Dropdown list from the exercise.xml file
                var provider = new ExerciseTypeProvider();

                //get all the records from the database
                var items = provider.GetAll();

                //Sets the data source that provides data for populating the ddlExerciseName control
                ddlExerciseName.DataSource = items;

                //Binding data to the ddlExerciseName control
                ddlExerciseName.DataBind();                  
        }

        /// <summary>
        /// Determine whether to do a insert or a update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var loginUser = HttpContext.Current.User.Identity.Name;

            var provider = new ExerciseProvider();

            var exercise = new Exercise();

            exercise.ID = ID;
            exercise.BodyPartID = BodyPartID;
            exercise.CurrentDate = CurrentDate;
            exercise.EmailAddress = EmailAddress;
            exercise.ExerciseSets = ExerciseSets;
            exercise.ExerciseTypeID = ExerciseTypeID;
            exercise.Reps = Reps;
            exercise.Weights = Weights;
            exercise.BodyParts = BodyParts;
            exercise.ExerciseName = ExerciseName;

            if (Request.QueryString["id"] != null)
            {
                int updateID;
                int.TryParse(Request.QueryString["id"], out updateID);
                provider.Update(exercise);
            }
            else
            {
                provider.Insert(exercise);
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
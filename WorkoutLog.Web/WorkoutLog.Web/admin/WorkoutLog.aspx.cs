using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;
using WorkoutLog.Data;

namespace WorkoutLog.Web
{
    public partial class Workout1 : System.Web.UI.Page, IExercise
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            LoadBodyPartsList();
            LoadExerciseTypeList();

            // if not post back, get excercise by id
            if (!IsPostBack && ID > 0)
            {
                // set IExercise Properties
                var provider = new ExerciseSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);
                var item = provider.GetById(ID);
                BodyPartID = item.BodyPartID;
                ExerciseTypeID = item.ExerciseTypeID;
                ExerciseSets = item.ExerciseSets;
                Reps = item.Reps;
                Weights = item.Weights;
            }            
        }

        private void LoadBodyPartsList()
        {
            var provider = new BodyPartSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);
            var items = provider.GetAll();

            ddlBodyParts.DataSource = items;
            ddlBodyParts.DataBind();
        }

        private void LoadExerciseTypeList()
        {
            var provider = new ExerciseTypeSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);
            var items = provider.GetAll();

            ddlExerciseName.DataSource = items;
            ddlExerciseName.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var provider = new ExerciseSQLProvider(System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString);

            //if query string have ID, do update instead of insert
            if (Request.QueryString["id"] != null)
            {
                if(provider.Update(this))
                    Response.Redirect("~/admin/index.aspx");
            }
            else if (provider.Insert(this))
            {
                Response.Redirect("~/admin/index.aspx");
            }              
        }


        public new int ID //need explanation
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
                return "bigs@gmail.com";
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
                int.TryParse(ddlExerciseName.SelectedValue, out exerciseTypeID); //not sure if the selected value should be int or not
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
                throw new NotImplementedException();
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
                throw new NotImplementedException();
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
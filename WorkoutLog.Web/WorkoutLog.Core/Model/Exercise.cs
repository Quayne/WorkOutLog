using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutLog.Core.Interfaces;

namespace WorkoutLog.Core.Model
{
    [Serializable]
    public class Exercise : IExercise
    {
        private string _email;
        private DateTime _currentDate = DateTime.Now;


        public int ID
        {
            get;
            set;
        }
                
        public DateTime CurrentDate
        {
            get
            {
                if (_currentDate <= DateTime.MinValue)
                    _currentDate = DateTime.Now;
                return _currentDate;
            }
            set { _currentDate = value; }
        }

        [Range(1, 1000, ErrorMessage = "Please Enter a valid input for SETS. Input must be an integer between and 0 and 1000.")]
        public int ExerciseSets
        {
            get;
            set;
        }

        public double Weights
        {
            get;
            set;
        }

        public int Reps
        {
            get;
            set;
        }


        public string EmailAddress
        {
            get;
            set;
        }

        public int BodyPartID
        {
            get;
            set;
        }

        public int ExerciseTypeID
        {
            get;
            set;
        }

        public double TotalWeights
        {
            get { return Reps * Weights; }
        }

        public string ExerciseName
        {
            get;
            set;
        }

        public string BodyParts
        {
            get;
            set;
        }
    }
}

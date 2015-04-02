using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutLog.Core.Interfaces;

namespace WorkoutLog.Core.Model
{
    public class ExerciseType : IExerciseType
    {
        public int ID
        {
            get;
            set;
        }

        public string ExerciseName
        {
            get;
            set;
        }
    }
}

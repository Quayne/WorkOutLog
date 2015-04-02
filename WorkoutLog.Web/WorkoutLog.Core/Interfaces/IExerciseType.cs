using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutLog.Core.Interfaces
{
    public interface IExerciseType
    {
        int ID { get; set; }

        string ExerciseName { get; set; }
    }
}

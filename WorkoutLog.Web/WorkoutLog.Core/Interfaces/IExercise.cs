using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutLog.Core.Interfaces
{
    public interface IExercise
    {
        int ID { get; set; }

        DateTime CurrentDate { get; set; }

        [Required(ErrorMessage = "Please Enter a valid input for SETS. Input must be an integer greater than 0.")]
        [Range(1, 1000, ErrorMessage = "Please Enter a valid input for SETS. Input must be an integer between and 0 and 1000.")]
        int ExerciseSets { get; set; }

        [Required(ErrorMessage = "Please Enter a valid input for WEIGHTS. Input must be an integer greater than 0.")]
        [Range(1, 1000, ErrorMessage = "Please Enter a valid input for WEIGHTS. Input must be an integer between and 0 and 1000.")]
        double Weights { get; set; }

        [DisplayName("Reps count")]
        [Required(ErrorMessage = "Please Enter a valid input for REPS. Input must be an integer greater than 0.")]
        [Range(1, 1000, ErrorMessage = "Please Enter a valid input for REPS. Input must be an integer between and 0 and 1000.")]
        int Reps { get; set; }
        
        string EmailAddress { get; set; }

        int BodyPartID { get; set; }

        int ExerciseTypeID { get; set; }

        double TotalWeights { get; }

        [Required(ErrorMessage = "You must select a exercise type.")]
        string ExerciseName { get; set; }

        [Required(ErrorMessage = "You must select a body Part.")]
        string BodyParts { get; set; }

    }

}

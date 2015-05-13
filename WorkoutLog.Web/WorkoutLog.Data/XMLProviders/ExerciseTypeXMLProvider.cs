using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WorkoutLog.Core.Helpers;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;

namespace WorkoutLog.Data.XMLProviders
{
    internal class ExerciseTypeXMLProvider : BaseXMLProvider<ExerciseType>
    {

        public ExerciseTypeXMLProvider(string xmlFilePath) : base(xmlFilePath) { }

        public override ExerciseType GetByID(int id)
        {
            var exercise = new ExerciseType();
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].ID == id)
                {
                    exercise.ID = Items[i].ID;
                    exercise.ExerciseName = Items[i].ExerciseName;
                }
            }
            return exercise;
        }

        public override List<ExerciseType> GetAll()
        {
            return Items;
        }
 
    }
}

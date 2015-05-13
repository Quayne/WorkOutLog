using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutLog.Core.Helpers;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;
using WorkoutLog.Data.SQLProviders;

namespace WorkoutLog.Data.XMLProviders
{
    internal class ExerciseXMLProvider : BaseXMLProvider<Exercise>, IProvider<Exercise>
    {
        /// <summary>
        /// Initialize the XML File Path.
        /// Check if the file exist.
        /// Instantiate a new exercise list if the file path does not exist; otherwise, read the entire file then store it in the exercise list.
        /// </summary>
        /// <param name="xmlFilePath"></param>
        public ExerciseXMLProvider(string xmlFilePath) : base(xmlFilePath) { }
        

        public override Exercise GetByID(int id)
        {
            var exercise = new Exercise();
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].ID == id)
                {
                    exercise.ID = Items[i].ID;
                    exercise.BodyPartID = Items[i].BodyPartID;
                    exercise.BodyParts = Items[i].BodyParts;
                    exercise.CurrentDate = Items[i].CurrentDate;
                    exercise.EmailAddress = Items[i].EmailAddress;
                    exercise.ExerciseName = Items[i].ExerciseName;
                    exercise.ExerciseSets = Items[i].ExerciseSets;
                    exercise.ExerciseTypeID = Items[i].ExerciseTypeID;
                    exercise.Reps = Items[i].Reps;
                    exercise.Weights = Items[i].Weights;
                }
            }
            return exercise;
        }

        /// <summary>
        /// Get all exercise for the user that is logged in
        /// </summary>
        /// <param name="email"></param>
        /// <returns>exercise</returns>
        public override List<Exercise> GetAllByKey(string email)
        {
            var exercise = new List<Exercise>();
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].EmailAddress == email)
                {
                    exercise.Add(Items[i]);                    
                }
            }
            return exercise;
        }

        public void Save()
        {
            SerializationHelper.Serialize<List<Exercise>>(_xmlFilePath, Items);
        }


        /// <summary>
        /// find the index with the ID has  and delete it
        /// </summary>
        /// <param name="id"></param>
        public override bool Delete(int id)
        {            
            Exercise exerciseTemp = null;
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].ID == id)
                {
                    exerciseTemp = Items[i];
                }
                
            }
            if (exerciseTemp != null)
            {
                Items.Remove(exerciseTemp);
                Save();
                return true;
            }
            else {
                return false;
            }        
        }

        /// <summary>
        /// Find the ID of the exercise that has been passed in and update it.
        /// </summary>
        /// <param name="exercise"></param>
        public override bool Update(Exercise exercise)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].ID == exercise.ID)
                {
                    Items[i].ID = exercise.ID;
                    Items[i].BodyPartID = exercise.BodyPartID;
                    Items[i].EmailAddress = exercise.EmailAddress;
                    Items[i].ExerciseName = exercise.ExerciseName;
                    Items[i].BodyParts = exercise.BodyParts;
                    Items[i].ExerciseSets = exercise.ExerciseSets;
                    Items[i].ExerciseTypeID = exercise.ExerciseTypeID;
                    Items[i].Reps = exercise.Reps;
                    Items[i].Weights = exercise.Weights;
                    Items[i].CurrentDate = exercise.CurrentDate;
                    break;
                }
            }
            Save();
            return true;
        }

        /// <summary>
        /// Insert a new exercise
        /// </summary>
        /// <param name="exercise"></param>
        public override bool Insert(Exercise exercise)
        {
            int newId = IncrementHighestId();

            Items.Add(new Exercise
            {
                ID = newId,
                BodyPartID = exercise.BodyPartID,
                EmailAddress = exercise.EmailAddress,
                ExerciseName = exercise.ExerciseName,
                BodyParts = exercise.BodyParts,
                ExerciseSets = exercise.ExerciseSets,
                ExerciseTypeID = exercise.ExerciseTypeID,
                Reps = exercise.Reps,
                Weights = exercise.Weights,
                CurrentDate = DateTime.Now
            });
            Save();
            return true;
        }

        /// <summary>
        /// Check for the ID with the highest value then add 1
        /// </summary>
        /// <returns>The highest ID + 1</returns>
        private int IncrementHighestId()
        {
            int highestID = (Items.Count() == 0) ? 0 : Items[0].ID;

            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].ID > highestID)
                    highestID = Items[i].ID;
            }
            return highestID + 1;
        }
    }
}

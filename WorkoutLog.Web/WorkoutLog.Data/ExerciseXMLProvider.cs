﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutLog.Core.Helpers;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;

namespace WorkoutLog.Data
{
    public class ExerciseXMLProvider
    {
        private List<Exercise> _exerciseList;
        private readonly string _xmlFilePath;

        public ExerciseXMLProvider(string xmlFilePath)
        {
            this._xmlFilePath = xmlFilePath;

            if (!File.Exists(_xmlFilePath))
            {
                _exerciseList = new List<Exercise>();
            }
            else
            {
                var xmlContent = System.IO.File.ReadAllText(_xmlFilePath);
                _exerciseList = SerializationHelper.Deserialize<List<Exercise>>(xmlContent);
            }
        }

        public List<Exercise> GetAll()
        {
            return ExerciseList;
        }

        private List<Exercise> ExerciseList
        {
            get
            {
                if (_exerciseList == null)
                    _exerciseList = new List<Exercise>();

                return _exerciseList;

                //return _exerciseList ?? (_exerciseList =  new List<Exercise>());
            }
        }

        public void Save()
        {
            SerializationHelper.Serialize<List<Exercise>>(_xmlFilePath, _exerciseList);
        }


        /// <summary>
        /// find the index with the ID has  and delete it
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {            
            Exercise exerciseTemp = null;
            for (int i = 0; i < ExerciseList.Count; i++)
            {
                if (ExerciseList[i].ID == id)
                {
                    exerciseTemp = ExerciseList[i];
                }
                
            }
            if (exerciseTemp != null)
                ExerciseList.Remove(exerciseTemp);

            Save();
        }

        /// <summary>
        /// Find the ID of the exercise that has been passed in and update it.
        /// </summary>
        /// <param name="exercise"></param>
        public void Update(IExercise exercise)
        {
            for (int i = 0; i < ExerciseList.Count; i++)
            {
                if (ExerciseList[i].ID == exercise.ID)
                {
                    ExerciseList[i].ID = exercise.ID;
                    ExerciseList[i].BodyPartID = exercise.BodyPartID;
                    ExerciseList[i].EmailAddress = exercise.EmailAddress;
                    ExerciseList[i].ExerciseName = exercise.ExerciseName;
                    ExerciseList[i].BodyParts = exercise.BodyParts;
                    ExerciseList[i].ExerciseSets = exercise.ExerciseSets;
                    ExerciseList[i].ExerciseTypeID = exercise.ExerciseTypeID;
                    ExerciseList[i].Reps = exercise.Reps;
                    ExerciseList[i].Weights = exercise.Weights;
                    ExerciseList[i].CurrentDate = exercise.CurrentDate;
                }
            }
            Save();
        }

        /// <summary>
        /// Insert a new exercise
        /// </summary>
        /// <param name="exercise"></param>
        public void Insert(IExercise exercise)
        {
            int newId = IncrementHighestId();
           
            ExerciseList.Add(new Exercise
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
        }

        /// <summary>
        /// Check for the ID with the highest value then add 1
        /// </summary>
        /// <returns>The highest ID + 1</returns>
        private int IncrementHighestId()
        {
            int highestID = (ExerciseList.Count() == 0) ? 0 : ExerciseList[0].ID;

            for (int i = 0; i < ExerciseList.Count; i++)
            {
                if (ExerciseList[i].ID > highestID)
                    highestID = ExerciseList[i].ID;
            }
            return highestID + 1;
        }
    }
}

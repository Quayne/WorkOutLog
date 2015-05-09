using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WorkoutLog.Core.Helpers;
using WorkoutLog.Core.Model;

namespace WorkoutLog.Data
{
    public class ExerciseTypeXMLProvider
    {
        private List<ExerciseType> _exerciseTypeList;
        private readonly string _xmlFilePath;
        //private static string _exerciseName;

        public ExerciseTypeXMLProvider(string xmlFilePath)
        {
            _xmlFilePath = xmlFilePath;

            if (!File.Exists(_xmlFilePath))
            {
                _exerciseTypeList = new List<ExerciseType>();
                SerializationHelper.Serialize<List<ExerciseType>>(_xmlFilePath, _exerciseTypeList);
            }
            else
            {
                var xmlContent = System.IO.File.ReadAllText(_xmlFilePath);
                _exerciseTypeList = SerializationHelper.Deserialize<List<ExerciseType>>(xmlContent);
            }
        }

        public ExerciseType GetById(int id)
        {
            var exercise = new ExerciseType();
            for (int i = 0; i < ExerciseTypeList.Count; i++)
            {
                if (ExerciseTypeList[i].ID == id)
                {
                    exercise.ID = ExerciseTypeList[i].ID;
                    exercise.ExerciseName = ExerciseTypeList[i].ExerciseName;
                }
            }
            return exercise;
        }

        public List<ExerciseType> GetAll()
        {
            return ExerciseTypeList;
        }

        private List<ExerciseType> ExerciseTypeList
        {
            get
            {
                if (_exerciseTypeList == null)
                    _exerciseTypeList = new List<ExerciseType>();

                return _exerciseTypeList;

            }
        }
    }
}

using System;
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

        public List<Exercise> ExerciseList
        {
            get
            {
                return _exerciseList;
            }
        }

        public void Save()
        {
            SerializationHelper.Serialize<List<Exercise>>(_xmlFilePath, _exerciseList);
        }

        public void Delete(int id)
        {
            SerializationHelper.Deserialize<List<Exercise>>(id.ToString());
        }

        
    }
}

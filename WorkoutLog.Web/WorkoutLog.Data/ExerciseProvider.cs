using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkoutLog.Core;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;
using WorkoutLog.Data.SQLProviders;
using WorkoutLog.Data.XMLProviders;

namespace WorkoutLog.Data
{
    public class ExerciseProvider : IProvider<Exercise>
    {
        private IProvider<Exercise> _provider;
        public ExerciseProvider()
        {
            if (Variables.UseXmlDataSource)
                _provider = new ExerciseXMLProvider(Variables.ExerciseXmlFilePath);
            else
                _provider = new ExerciseSQLProvider(Variables.ConnectionString);

        }
        
        public bool Insert(Exercise item)
        {
            return _provider.Insert(item);
        }

        public bool Delete(int Id)
        {
            return _provider.Delete(Id);
        }

        public bool Delete(string key)
        {            
            throw new NotImplementedException();
        }

        public bool Update(Exercise item)
        {
            return _provider.Update(item);
        }

        public List<Exercise> GetAll()
        {
            return _provider.GetAll();            
        }

        public List<Exercise> GetAllById(int id)
        {
            return _provider.GetAll();
        }

        public bool ValidateUser(string user, string password)
        {
            throw new NotImplementedException();
        }

        public List<Exercise> GetAllByKey(string key)
        {
            //var exerciseList = _provider.GetAllByKey(key).OrderByDescending(x => x.CurrentDate);
            return _provider.GetAllByKey(key).OrderByDescending(x => x.CurrentDate).ToList();
        }

        public Exercise GetByID(int Id)
        {
            return _provider.GetByID(Id);
        }


        public Persons GetByKey(string key)
        {
            throw new NotImplementedException();
        }
    }
}

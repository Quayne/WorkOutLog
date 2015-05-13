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
    public class ExerciseTypeProvider : IProvider<ExerciseType>
    {

        private IProvider<ExerciseType> _provider;
        public ExerciseTypeProvider()
        {
            if (Variables.UseXmlDataSource)
                _provider = new ExerciseTypeXMLProvider(Variables.ExerciseTypeXmlFilePath);
            else
                _provider = new ExerciseTypeSQLProvider(Variables.ConnectionString);

        }





        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string key)
        {
            throw new NotImplementedException();
        }

        public List<ExerciseType> GetAll()
        {
            return _provider.GetAll();
        }

        public bool ValidateUser(string user, string password)
        {
            throw new NotImplementedException();
        }

        public ExerciseType GetByID(int Id)
        {
            return _provider.GetByID(Id);
        }

        public Persons GetByKey(string key)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ExerciseType item)
        {
            throw new NotImplementedException();
        }

        public bool Update(ExerciseType item)
        {
            throw new NotImplementedException();
        }

        public List<ExerciseType> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ExerciseType> GetAllByKey(string key)
        {
            throw new NotImplementedException();
        }
    }
}

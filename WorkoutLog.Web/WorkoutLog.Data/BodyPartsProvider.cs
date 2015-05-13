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
    public class BodyPartsProvider : IProvider<BodyParts>
    {

        private IProvider<BodyParts> _provider;
        public BodyPartsProvider()
        {
            if (Variables.UseXmlDataSource)
                _provider = new BodyPartXMLProvider(Variables.BodyPartXmlFilePath);
            else
                _provider = new BodyPartSQLProvider(Variables.ConnectionString);

        }

        public bool Insert(BodyParts item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string key)
        {
            throw new NotImplementedException();
        }

        public List<BodyParts> GetAll()
        {
            return _provider.GetAll();
        }  

        public bool ValidateUser(string user, string password)
        {
            throw new NotImplementedException();
        }

        public BodyParts GetByID(int Id)
        {
            return _provider.GetByID(Id);
        }        

        public bool Update(BodyParts item)
        {
            throw new NotImplementedException();
        }

        List<BodyParts> IProvider<BodyParts>.GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        List<BodyParts> IProvider<BodyParts>.GetAllByKey(string key)
        {
            throw new NotImplementedException();
        }

        public Persons GetByKey(string key)
        {
            throw new NotImplementedException();
        }
    }
}

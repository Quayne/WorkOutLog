using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkoutLog.Core;
using WorkoutLog.Core.Helpers;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;
using WorkoutLog.Data.SQLProviders;
using WorkoutLog.Data.XMLProviders;

namespace WorkoutLog.Data
{
     public class PersonsProvider : IProvider<Persons>
    {
        private IProvider<Persons> _provider;
        public PersonsProvider()
        {
            if (Variables.UseXmlDataSource)
                _provider = new PersonsXMLProvider(Variables.MembersXmlFilePath);
            else
                _provider = new PersonSQLProvider(Variables.ConnectionString);

        }


        public bool Insert(Persons item)
        {
            var hashedPassword = PasswordHasher.Hash(item.UserPassword);
            item.UserPassword = hashedPassword.Hash;

            return _provider.Insert(item);
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string key)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(string user, string password)
        {
            var encryptedPassword = PasswordHasher.Hash(password);            

            return _provider.ValidateUser(user, encryptedPassword.Hash);           
        }

        public List<Persons> GetAllByKey(string key)
        {
            return _provider.GetAllByKey(key);
        }
         
        public bool Update(Persons item)
        {
            throw new NotImplementedException();
        }

        public List<Persons> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Persons> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

         public Persons GetByID(int Id)
        {
            throw new NotImplementedException();
        }

        public Persons GetByKey(string key)
        {
            return _provider.GetByKey(key);
        }
    }
}

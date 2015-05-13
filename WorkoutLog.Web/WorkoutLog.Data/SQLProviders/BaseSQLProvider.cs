using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;

namespace WorkoutLog.Data.SQLProviders
{
    public abstract class BaseSQLProvider<T> : IProvider<T>
    {
        protected readonly string _connString;

        public BaseSQLProvider(string connString)
        {
            _connString = connString;
        }



        public virtual bool Insert(T item)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(string key)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(T item)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual bool ValidateUser(string user, string password)
        {
            throw new NotImplementedException();
        }

        public virtual List<T> GetAllByKey(string key)
        {
            throw new NotImplementedException();
        }

        public virtual T GetByID(int Id)
        {
            throw new NotImplementedException();
        }


        public virtual Persons GetByKey(string key)
        {
            throw new NotImplementedException();
        }
    }
}

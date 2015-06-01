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
    public abstract class BaseXMLProvider<T> : IProvider<T>
    {
        protected readonly string _xmlFilePath;
        private List<T> _items;

        public BaseXMLProvider(string xmlFilePath)
        {
            _xmlFilePath = System.Web.HttpContext.Current.Server.MapPath(xmlFilePath);

            
            if (!File.Exists(_xmlFilePath))
            {
                _items = new List<T>();
            }
            else
            {
                var xmlContent = System.IO.File.ReadAllText(_xmlFilePath);
                _items = SerializationHelper.Deserialize<List<T>>(xmlContent);
            }
        }

        /// <summary>
        /// If list equal null, then instantiate new exercise list.
        /// Returns list.
        /// </summary>
        protected List<T> Items
        {
            get
            {
                if (_items == null)
                    _items = new List<T>();

                return _items;
            }
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

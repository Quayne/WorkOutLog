using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutLog.Data
{
    public abstract class BaseSQLProvider<T>
    {
        protected readonly string _connString;

        public BaseSQLProvider(string connString)
        {
            _connString = connString;
        }

        public abstract bool Insert(T item);
        public abstract bool Delete(int ID);
        public abstract bool Update(T item);

        public abstract List<T> GetAll();
    }
}

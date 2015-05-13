using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkoutLog.Core.Model;

namespace WorkoutLog.Core.Interfaces
{
    public interface IProvider<T>
    {
        bool Insert(T item);
        bool Delete(int Id);
        bool Delete(string key);
        bool Update(T item);
        List<T> GetAll();
        List<T> GetAllById(int id);
        bool ValidateUser(string user, string password);
        List<T> GetAllByKey(string key);
        T GetByID(int Id);
        Persons GetByKey(string key);
    }
}

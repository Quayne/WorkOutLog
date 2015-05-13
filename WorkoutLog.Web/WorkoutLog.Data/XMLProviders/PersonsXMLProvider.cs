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
    internal class PersonsXMLProvider : BaseXMLProvider<Persons>
    {
        

        public PersonsXMLProvider(string xmlFilePath) : base(xmlFilePath) { }
       

        public override bool ValidateUser(string email, string password)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].EmailAddress.Equals(email) && Items[i].UserPassword.Equals(password))
                {
                    return true;
                }                        
            }
            return false;
        }


        /// <summary>
        /// Get user by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override Persons GetByKey(string key)
        {
            var person = new Persons();

            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].EmailAddress == key)
                {
                    person.EmailAddress = Items[i].EmailAddress;
                    person.UserName = Items[i].UserName;
                    return person;
                }
            }

            return person;

            //TODO: Read up on LINQ https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b
            //var query = from n in Items
            //            where n.UserName.Equals(key, StringComparison.OrdinalIgnoreCase)
            //            select n;

            //return query.FirstOrDefault();

        }

    }
}

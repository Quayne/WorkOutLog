using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutLog.Core.Interfaces;

namespace WorkoutLog.Core.Model
{
    public class Persons : IPersons
    {
        public string EmailAddress
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string UserPassword
        {
            get;
            set;
        }
    }
}

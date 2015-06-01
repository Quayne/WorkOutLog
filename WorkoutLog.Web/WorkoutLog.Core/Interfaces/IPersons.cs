using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutLog.Core.Interfaces
{
    public interface IPersons
    {
        string EmailAddress { get; set; }

        string UserName { get; set; }

        string UserPassword { get; set; }

        string ConfirmPassword { get; set; }
    }
}

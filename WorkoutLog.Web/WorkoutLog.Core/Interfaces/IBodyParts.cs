using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutLog.Core.Interfaces
{
    public interface IBodyParts
    {
        int ID { get; set; }

        string BodyPartName { get; set; }
    }
}

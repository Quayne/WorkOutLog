using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutLog.Core.Interfaces;

namespace WorkoutLog.Core.Model
{
    public class BodyParts : IBodyParts
    {
        public int ID
        {
            get;
            set;
        }

        public string BodyPartName
        {
            get;            
            set;            
        }
    }
}

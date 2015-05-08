using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutLog.Core
{
    public static class Variables
    {
        public static string ExerciseXmlFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["ExerciseXmlFilePath"];
            }
        }
        

        public static string MembersXmlFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["MembersXmlFilePath"];
            }
        }

        public static bool UseXmlDataSource
        {
            get
            {
                var toReturn = false;
                bool.TryParse(ConfigurationManager.AppSettings["UseXmlDataSource"], out toReturn);
                return toReturn;
            }
        }
    }


}

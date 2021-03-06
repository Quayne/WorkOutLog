﻿using System;
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

        public static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["ExerciseConnString"].ConnectionString;
            }
        }
        

        public static string MembersXmlFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["MembersXmlFilePath"];
            }
        }

        public static string ExerciseTypeXmlFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["ExerciseTypeXmlFilePath"];
            }
        }

        public static string BodyPartXmlFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["BodyPartXmlFilePath"];
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WorkoutLog.Core.Helpers;
using WorkoutLog.Core.Model;

namespace WorkoutLog.Data
{
    public class BodyPartXMLProvider
    {
        private List<BodyParts> _bodyPartList;
        private readonly string _xmlFilePath;
        //private static string _exerciseName;

        public BodyPartXMLProvider(string xmlFilePath)
        {
            _xmlFilePath = xmlFilePath;

            if (!File.Exists(_xmlFilePath))
            {
                _bodyPartList = new List<BodyParts>();
                SerializationHelper.Serialize<List<BodyParts>>(_xmlFilePath, _bodyPartList);
            }
            else
            {
                var xmlContent = System.IO.File.ReadAllText(_xmlFilePath);
                _bodyPartList = SerializationHelper.Deserialize<List<BodyParts>>(xmlContent);
            }
        }

        public BodyParts GetByID(int id)
        {
            var bodyPart = new BodyParts();
            for (int i = 0; i < BodyPartList.Count; i++)
            {
                if (BodyPartList[i].ID == id)
                {
                    bodyPart.ID = BodyPartList[i].ID;
                    bodyPart.BodyPartName = BodyPartList[i].BodyPartName;
                }
            }
            return bodyPart;
        }


        public List<BodyParts> GetAll()
        {
            return BodyPartList;
        }

        private List<BodyParts> BodyPartList
        {
            get
            {
                if (_bodyPartList == null)
                    _bodyPartList = new List<BodyParts>();

                return _bodyPartList;

            }
        }
    }
}

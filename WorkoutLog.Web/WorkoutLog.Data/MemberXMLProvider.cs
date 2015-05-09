using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WorkoutLog.Core.Helpers;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;

namespace WorkoutLog.Data
{
    public class MemberXMLProvider 
    {
        private List<Persons> _memberList;
        private readonly string _xmlFilePath;

        public MemberXMLProvider(string xmlFilePath)
        {
            _xmlFilePath = xmlFilePath;

            if (!File.Exists(_xmlFilePath))
            {
                _memberList = new List<Persons>();
                SerializationHelper.Serialize<List<Persons>>(_xmlFilePath, _memberList);
            }
            else
            {
                var xmlContent = System.IO.File.ReadAllText(_xmlFilePath);
                _memberList = SerializationHelper.Deserialize<List<Persons>>(xmlContent);
            }
        }


        public bool ValidateUser(string email, string password)
        {
            for (int i = 0; i < MemberList.Count; i++)
            {
                if (MemberList[i].EmailAddress.Equals(email) && MemberList[i].UserPassword.Equals(password))
                {
                    return true;
                }                        
            }
            return false;
        }

        private List<Persons> MemberList
        {
            get
            {
                if (_memberList == null)
                    _memberList = new List<Persons>();

                return _memberList;

            }
        }
    }
}

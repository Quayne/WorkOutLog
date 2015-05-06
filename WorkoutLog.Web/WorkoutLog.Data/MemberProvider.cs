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
    public class MemberProvider 
    {
        private List<Persons> _memberList;
        private readonly string _xmlFilePath;
        private static string _userName;

        public MemberProvider(string xmlFilePath)
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


        public bool ValidateUser(string userName, string password)
        {
            for (int i = 0; i < MemberList.Count; i++)
            {
                if (MemberList[i].UserName.Equals(userName) && MemberList[i].UserPassword.Equals(password))
                {
                   // SetUsername(MemberList[i].UserName);
                    return true;
                }                        
            }
            return false;
        }

        private void SetUsername(string name)
        {
            _userName = name;
        }

        public string GetUsername()
        {
            return _userName;
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

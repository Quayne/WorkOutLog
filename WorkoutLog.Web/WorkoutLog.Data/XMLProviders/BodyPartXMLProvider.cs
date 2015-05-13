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
    internal class BodyPartXMLProvider : BaseXMLProvider<BodyParts>
    {
        
        public BodyPartXMLProvider(string xmlFilePath) : base(xmlFilePath) { }

        public override BodyParts GetByID(int id)
        {
            var bodyPart = new BodyParts();
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].ID == id)
                {
                    bodyPart.ID = Items[i].ID;
                    bodyPart.BodyPartName = Items[i].BodyPartName;
                }
            }
            return bodyPart;
        }


        public override List<BodyParts> GetAll()
        {
            return Items;
        }
    }
}

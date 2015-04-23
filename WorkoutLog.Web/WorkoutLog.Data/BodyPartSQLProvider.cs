using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;

namespace WorkoutLog.Data
{
    public class BodyPartSQLProvider : BaseSQLProvider<IBodyParts>
    {
        public BodyPartSQLProvider(string connString) : base(connString) { }

        /// <summary>
        /// Get bodyParts by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>bodyParts</returns>
        public IBodyParts GetById(int Id)
        {
            var bodyParts = new BodyParts();

            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                const string selectQuery = "SELECT * FROM BodyParts WHERE BodyPartsID = @ID";

                SqlCommand command = new SqlCommand(selectQuery, conn);

                command.Parameters.Add("@ID", Id);
                command.ExecuteNonQuery();

                using (var dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();

                        bodyParts.BodyPartName = dr["BodyPartName"].ToString();

                        bodyParts.ID = validateInteger(dr["BodyPartsID"].ToString());
                    }                  
                }
            }            
            return bodyParts;
        }

        public override bool Insert(IBodyParts item)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID)
        {
            string cmd = "DELETE FROM BodyParts WHERE BodyPartsID = @ID";
            //TODO: 
            return false;
        }

        public override bool Update(IBodyParts item)
        {
            throw new NotImplementedException();
        }

        public override List<IBodyParts> GetAll()
        {
            var toReturn = new List<IBodyParts>();
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                const string selectQuery = "SELECT * FROM BodyParts";

                SqlCommand command = new SqlCommand(selectQuery, conn);

                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {                                               
                        var bodyParts = new BodyParts();
                        bodyParts.BodyPartName = dr["BodyPartName"].ToString();

                        bodyParts.ID = validateInteger(dr["BodyPartsID"].ToString());
                                                
                        toReturn.Add(bodyParts);
                    }
                }

            }
            return toReturn;
        }

        private int validateInteger(string input)
        {
            int temp;

            if (int.TryParse(input, out temp))
            {
                return temp;
            }
            return 0;
        }

        
    }
}

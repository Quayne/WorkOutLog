﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;

namespace WorkoutLog.Data.SQLProviders
{
    internal class BodyPartSQLProvider : BaseSQLProvider<BodyParts>
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
                const string selectQuery = "SELECT * FROM BodyParts WHERE ID = @ID";

                SqlCommand command = new SqlCommand(selectQuery, conn);

                command.Parameters.AddWithValue("@ID", Id);
                command.ExecuteNonQuery();

                using (var dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();

                        bodyParts.BodyPartName = dr["BodyParts"].ToString();

                        bodyParts.ID = validateInteger(dr["BodyPartsID"].ToString());
                    }                  
                }
            }            
            return bodyParts;
        }

        public override bool Insert(BodyParts item)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID)
        {
           // string cmd = "DELETE FROM BodyParts WHERE BodyPartsID = @ID";
            //TODO: 
            return false;
        }

        public override bool Update(BodyParts item)
        {
            throw new NotImplementedException();
        }

        public override List<BodyParts> GetAll()
        {
            var toReturn = new List<BodyParts>();
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
                        bodyParts.BodyPartName = dr["BodyParts"].ToString();

                        bodyParts.ID = validateInteger(dr["ID"].ToString());
                                                
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

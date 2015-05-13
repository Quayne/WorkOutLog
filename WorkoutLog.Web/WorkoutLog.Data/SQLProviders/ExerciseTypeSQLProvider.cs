using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutLog.Core.Interfaces;
using WorkoutLog.Core.Model;

namespace WorkoutLog.Data.SQLProviders
{
    internal class ExerciseTypeSQLProvider : BaseSQLProvider<ExerciseType>
    {
        public ExerciseTypeSQLProvider(string connString) : base(connString) { }

        public ExerciseType GetById(int Id)
        {
            var exerciseType = new ExerciseType();
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                const string selectQuery = "SELECT * FROM ExerciseType WHERE ID = @ID";

                SqlCommand command = new SqlCommand(selectQuery, conn);
                command.Parameters.AddWithValue("@ID", Id);
                command.ExecuteNonQuery();

                using (var dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        exerciseType.ExerciseName = dr["ExerciseName"].ToString();

                        int tempInt;
                        if (int.TryParse(dr["ID"].ToString(), out tempInt))
                        {
                            exerciseType.ID = tempInt;
                        }
                    }
                }
            }
            return exerciseType;
        }


        public override bool Insert(ExerciseType item)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public override bool Update(ExerciseType item)
        {
            throw new NotImplementedException();
        }

        public override List<ExerciseType> GetAll()
        {
            var toReturn = new List<ExerciseType>();
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                const string selectQuery = "SELECT * FROM ExerciseType";

                SqlCommand command = new SqlCommand(selectQuery, conn);

                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int tempInt;
                        var exerciseType = new ExerciseType();
                        exerciseType.ExerciseName = dr["ExerciseName"].ToString();

                        if (int.TryParse(dr["ID"].ToString(), out tempInt))
                        {
                            exerciseType.ID = tempInt;
                        }

                        toReturn.Add(exerciseType);
                    }
                }

            }
            return toReturn;
        }

        
    }
}

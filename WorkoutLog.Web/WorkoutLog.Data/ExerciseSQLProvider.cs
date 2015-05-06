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
    public class ExerciseSQLProvider : BaseSQLProvider<IExercise>
    {
        public ExerciseSQLProvider(string connString) : base(connString) { }

        /// <summary>
        /// Get exercise by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>record with the specified Id</returns>
        public IExercise GetById(int Id)
        {
            var exercise = new Exercise();
            string selectQuery = "SELECT * FROM Exercise WHERE ID = @ID";

            using (var conn = new SqlConnection(_connString)) //Set connection string
            {
                conn.Open();//Open connection
                
                //Set SQL command and pass in the SQL statement and the connection string to use
                SqlCommand command = new SqlCommand(selectQuery, conn);

                //Add new command parameter
                command.Parameters.Add(new SqlParameter("@ID", Id));

                command.ExecuteNonQuery(); //Executes the SQL statement against the connection

                using (var dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        int tempInt;
                        float tempFloat;
                        
                        exercise.EmailAddress = dr["EmailAddress"].ToString();

                        if (int.TryParse(dr["ID"].ToString(), out tempInt))
                        {
                            exercise.ID = tempInt;
                        }
                        if (int.TryParse(dr["BodyPartID"].ToString(), out tempInt))
                        {
                            exercise.BodyPartID = tempInt;
                        }
                        if (int.TryParse(dr["ExerciseTypeID"].ToString(), out tempInt))
                        {
                            exercise.ExerciseTypeID = tempInt;
                        }
                        if (int.TryParse(dr["Reps"].ToString(), out tempInt))
                        {
                            exercise.Reps = tempInt;
                        }
                        if (int.TryParse(dr["ExerciseSets"].ToString(), out tempInt))
                        {
                            exercise.ExerciseSets = tempInt;
                        }
                        if (float.TryParse(dr["Weights"].ToString(), out tempFloat))
                        {
                            exercise.Weights = tempFloat;
                        }
                        
                    }                    
                }                
            }
            return exercise;
        }

        /// <summary>
        /// Inserts Exercise records
        /// </summary>
        /// <param name="exercise"></param>
        /// <returns>true if the number of rows affected is greater than 0, false otherwise</returns>
        public override bool Insert(IExercise exercise)
        {
            const string cmd = "INSERT INTO Exercise VALUES (@CurrentDate,@ExerciseSets,@Reps,@Weights,@EmailAddress,@BodyPartID,@ExerciseTypeID);";
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    SqlCommand sql = new SqlCommand(cmd, conn);
                    sql.Parameters.Add(new SqlParameter("@CurrentDate", exercise.CurrentDate));
                    sql.Parameters.Add(new SqlParameter("@ExerciseSets", exercise.ExerciseSets));
                    sql.Parameters.Add(new SqlParameter("@Reps", exercise.Reps));
                    sql.Parameters.Add(new SqlParameter("@Weights", exercise.Weights));
                    sql.Parameters.Add(new SqlParameter("@EmailAddress", "quayne@gmail.com"));
                    sql.Parameters.Add(new SqlParameter("@BodyPartID", exercise.BodyPartID));
                    sql.Parameters.Add(new SqlParameter("@ExerciseTypeID", exercise.ExerciseTypeID));                                     

                    //return true if the number of rows affected is greater than 0
                    return sql.ExecuteNonQuery() > 0;
                }
            }
            catch(Exception ex)
            {
                //log the exception
                //return false
                throw ex;
            }           
        }

        /// <summary>
        /// Update record by ID
        /// </summary>
        /// <param name="exercise"></param>
        /// <returns>true if numberOfRowsAffected = 1, false otherwise</returns>
        public override bool Update(IExercise exercise)
        {
            var isUpdated = false;
            using (var conn = new SqlConnection(_connString))
            {
                string selectQuery = "UPDATE Exercise SET CurrentDate =@currentDate, ExerciseSets =@sets, Reps =@reps, Weights =@weights, BodyPartID =@bodyPartID, ExerciseTypeID =@exerciseTypeID, EmailAddress=@emailAddress WHERE ID = @ID";

                conn.Open();               

                    SqlCommand sql = new SqlCommand(selectQuery, conn);
                    sql.Parameters.Add(new SqlParameter("@ID", exercise.ID));
                    sql.Parameters.Add(new SqlParameter("@currentDate", exercise.CurrentDate));
                    sql.Parameters.Add(new SqlParameter("@sets", exercise.ExerciseSets));
                    sql.Parameters.Add(new SqlParameter("@reps", exercise.Reps));
                    sql.Parameters.Add(new SqlParameter("@weights", exercise.Weights));
                    sql.Parameters.Add(new SqlParameter("@bodyPartID", exercise.BodyPartID));
                    sql.Parameters.Add(new SqlParameter("@exerciseTypeID", exercise.ExerciseTypeID));
                    sql.Parameters.Add(new SqlParameter("@emailAddress", "quayne@gmail.com"));

                    var numberOfRowsAffected = sql.ExecuteNonQuery();

                    isUpdated = (numberOfRowsAffected == 1) ? true : false;              
            }
            return isUpdated;
        }

        /// <summary>
        /// Delete record by ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>false if number of rows affected = 0, true otherwise</returns>
        public override bool Delete(int ID)
        {
            using (var conn = new SqlConnection(_connString))
            {
                string cmd = "DELETE FROM Exercise WHERE ID = @ID";

                conn.Open();

                SqlCommand command = new SqlCommand(cmd, conn);
                command.Parameters.Add(new SqlParameter("@ID", ID));

                if (command.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                return true;
            }            
        }

        /// <summary>
        /// Get all Exercise record
        /// </summary>
        /// <returns>all Exercise record</returns>
        public override List<IExercise> GetAll()
        {
            var toReturn = new List<IExercise>();
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                var selectQuery = "SELECT [Exercise].ID,[ExerciseSets],[Reps],[Weights],[BodyParts],[ExerciseName],[EmailAddress],[CurrentDate] FROM Exercise JOIN BodyParts ON Exercise.BodyPartID = BodyParts.ID JOIN ExerciseType ON Exercise.ExerciseTypeID = ExerciseType.ID WHERE EmailAddress LIKE @email";

                SqlCommand command = new SqlCommand(selectQuery, conn);

                //TODO: get the email address that is logged in
                command.Parameters.AddWithValue("@email", "quayne@gmail.com");

                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int tempInt;
                        float tempFloat;
                        var exercise = new Exercise();
                        exercise.EmailAddress = dr["EmailAddress"].ToString();

                        if (int.TryParse(dr["ID"].ToString(), out tempInt))
                        {
                            exercise.ID = tempInt;
                        }
                        if (int.TryParse(dr["Reps"].ToString(), out tempInt))
                        {
                            exercise.Reps = tempInt;
                        }
                        if (int.TryParse(dr["ExerciseSets"].ToString(), out tempInt))
                        {
                            exercise.ExerciseSets = tempInt;
                        }
                        if (float.TryParse(dr["Weights"].ToString(), out tempFloat))
                        {
                            exercise.Weights = tempFloat;
                        }
                        exercise.ExerciseName = dr["ExerciseName"].ToString();
                        exercise.BodyParts = dr["BodyParts"].ToString();

                        toReturn.Add(exercise);
                    }
                }

            }
            return toReturn;
        }
        
    }
}

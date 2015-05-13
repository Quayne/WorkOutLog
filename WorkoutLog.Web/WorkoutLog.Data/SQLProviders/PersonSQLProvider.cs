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
    internal class PersonSQLProvider : BaseSQLProvider<Persons>
    {
        public PersonSQLProvider(string connString) : base(connString) { }

        public override Persons GetByKey(string email)
        {
            Persons person = null;
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                const string selectQuery = "SELECT * FROM Persons WHERE EmailAddress = @Email";

                SqlCommand command = new SqlCommand(selectQuery, conn);
                command.Parameters.AddWithValue("@Email", email);
                //command.ExecuteNonQuery();

                using (var dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        person = new Persons();
                        person.EmailAddress = dr["EmailAddress"].ToString();
                        person.UserName = dr["UserName"].ToString();
                        person.UserPassword = dr["UserPassword"].ToString();
                    }
                }
            }
            return person;
        }

        public override bool ValidateUser(string email, string password)
        {
            var isUser = false;

            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                const string selectQuery = "SELECT * FROM Persons WHERE EmailAddress LIKE @email AND UserPassword LIKE @password";

                SqlCommand command = new SqlCommand(selectQuery, conn);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);


                using (var dr = command.ExecuteReader())
                {
                    
                    if (dr.Read())
                    {
                        var userEmail = dr["EmailAddress"].ToString();
                        var userpassword = dr["UserPassword"].ToString();

                        if (userEmail.ToLower() == email.ToLower() && userpassword.Equals(password))
                        {
                            isUser = true;
                        }
                    }
                }               
            }
            return isUser;
        }


        public override bool Insert(Persons person)
        {
            const string cmd = "INSERT INTO Persons VALUES (@email,@username,@password);";
            try
            {
                using (var conn = new SqlConnection(_connString))
                {
                    conn.Open();
                    SqlCommand sql = new SqlCommand(cmd, conn);
                    sql.Parameters.Add(new SqlParameter("@email", person.EmailAddress));
                    sql.Parameters.Add(new SqlParameter("@password", person.UserPassword));
                    sql.Parameters.Add(new SqlParameter("@username", person.UserName));                

                    //return true if the number of rows affected is greater than 0
                    return sql.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                //log the exception
                //return false
                throw ex;
            }  
        }

        public override bool Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public override bool Update(Persons item)
        {
            throw new NotImplementedException();
        }

        public override List<Persons> GetAll()
        {
            throw new NotImplementedException();
        }

        
    }
}

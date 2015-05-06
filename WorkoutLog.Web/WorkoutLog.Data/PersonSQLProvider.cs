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
    public class PersonSQLProvider : BaseSQLProvider<IPersons>
    {
        public PersonSQLProvider(string connString) : base(connString) { }

        public IPersons GetById(string email)
        {
            var person = new Persons();
            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                const string selectQuery = "SELECT * FROM Persons WHERE EmailAddress = @Email";

                SqlCommand command = new SqlCommand(selectQuery, conn);
                //command.Parameters.Add("@Email", email);
                //command.ExecuteNonQuery();

                using (var dr = command.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        person.EmailAddress = dr["EmailAddress"].ToString();
                        person.UserName = dr["UserName"].ToString();
                        person.UserPassword = dr["UserPassword"].ToString();
                    }
                }
            }
            return person;
        }

        public bool ValidatePerson(string name, string password)
        {
            var isUser = false;

            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();
                const string selectQuery = "SELECT * FROM Persons WHERE UserName LIKE @username AND UserPassword LIKE @password";

                SqlCommand command = new SqlCommand(selectQuery, conn);
                command.Parameters.AddWithValue("@username", name);
                command.Parameters.AddWithValue("@password", password);


                using (var dr = command.ExecuteReader())
                {
                    
                    if (dr.Read())
                    {
                        var userName = dr["UserName"].ToString();
                        var userpassword = dr["UserPassword"].ToString();

                        if (userName.ToLower() == name.ToLower() && password.Equals(password))
                        {
                            isUser = true;
                        }
                    }
                }               
            }
            return isUser;
        }


        public override bool Insert(IPersons item)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public override bool Update(IPersons item)
        {
            throw new NotImplementedException();
        }

        public override List<IPersons> GetAll()
        {
            throw new NotImplementedException();
        }

        
    }
}

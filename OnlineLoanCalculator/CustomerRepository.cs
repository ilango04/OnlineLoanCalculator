using System;
using System.Data;
using System.Data.SqlClient;                         //Data providers for SqlClient
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLoanCalculator
{
    public class CustomerRepository
    {
        public int rows = 0;
        public bool ToAdminLogin(long id,string password)
        {
            string connectionString = @"Data Source=LAPTOP-S25DNCVE\SQLEXPRESS;Database=Project;Integrated Security=SSPI";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("select * from admin", sqlConnection);
            sqlConnection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (((Convert.ToInt64(reader.GetValue(0)))==id) && (reader.GetString(1).Equals(password)))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool ToCustomerLogin(long id, string password)
        {
            string connectionString = @"Data Source=LAPTOP-S25DNCVE\SQLEXPRESS;Database=Project;Integrated Security=SSPI";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("select * from customer", sqlConnection);
            sqlConnection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (((Convert.ToInt64(reader.GetValue(0))) == id) && (reader.GetString(10).Equals(password)))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public void InsertDetails(Customer customer)
        {
            string connectionString = @"Data Source=LAPTOP-S25DNCVE\SQLEXPRESS;Database=Project;Integrated Security=SSPI";
            //string connectionString = ConfigurationManager.ConnectionStrings["Connectivity"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            connection.Open();
            command = new SqlCommand("sp_insertCustomerDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                command.Parameters.Add(new SqlParameter("@name", customer.name));
                command.Parameters.Add(new SqlParameter("@dateOfBirth", customer.dateOfBirth));
                command.Parameters.Add(new SqlParameter("@emailID", customer.emailID));
                command.Parameters.Add(new SqlParameter("@type", customer.employmentType));
                command.Parameters.Add(new SqlParameter("@salary", customer.monthlySalary));
                command.Parameters.Add(new SqlParameter("@company", customer.company));
                command.Parameters.Add(new SqlParameter("@address", customer.address));
                command.Parameters.Add(new SqlParameter("@pincode", customer.pincode));
                command.Parameters.Add(new SqlParameter("@mobileNumber", customer.mobileNumber));
                command.Parameters.Add(new SqlParameter("@password", customer.password));
                adapter.InsertCommand = command;
                rows = adapter.InsertCommand.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Exception Occur");
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }
    }
}

using OnlineLoanCalculator_EL;
using System;
using System.Data;
using System.Data.SqlClient;                         //Data providers for SqlClient
using System.Web.UI.WebControls;

namespace OnlineLoanCalculator_DAL
{
    public class CustomerRepository
    {
        public int rows = 0;
        public bool ToAdminLogin(long id,string password)
        {
            SqlConnection connection = DatabaseConnection.GetDatabaseConnection();
            SqlCommand command = new SqlCommand("select * from admin", connection);
            connection.Open();
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
            SqlConnection sqlConnection = DatabaseConnection.GetDatabaseConnection();
            SqlCommand command = new SqlCommand("select * from customer", sqlConnection);
            sqlConnection.Open();
            try
            {
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
            }
            catch
            {
                Console.WriteLine("Exception Occur");
            }
            finally
            {
                command.Dispose();
                sqlConnection.Close();
            }
            return false;
        }
        public bool InsertDetails(Customer customer)
        {
            SqlConnection connection = DatabaseConnection.GetDatabaseConnection();
            SqlCommand command = new SqlCommand("sp_insertCustomerDetails", connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            connection.Open();
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
                if (rows >= 0)
                    return true;
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
            return false;
        }
        public bool DisplayDetails(GridView GridViewId)
        {
            SqlConnection sqlConnection = DatabaseConnection.GetDatabaseConnection();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_DisplayCustomers", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    GridViewId.DataSource = dataTable;
                    GridViewId.DataBind();
                    return true;
                }
            }
            catch
            {
                Console.WriteLine("Exception Occur");
            }
            finally
            {
                sqlConnection.Close();
            }
            return false;
        }
        public bool AddCustomerDetails(Customer customer)
        {
            SqlConnection sqlConnection = DatabaseConnection.GetDatabaseConnection();
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("sp_InsertCustomerDetails", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@name", customer.name);
                    sqlCommand.Parameters.AddWithValue("@dateOfBirth", customer.dateOfBirth);
                    sqlCommand.Parameters.AddWithValue("@emailId", customer.emailID);
                    sqlCommand.Parameters.AddWithValue("@type", customer.employmentType);
                    sqlCommand.Parameters.AddWithValue("@salary", customer.monthlySalary);
                    sqlCommand.Parameters.AddWithValue("@company", customer.company);
                    sqlCommand.Parameters.AddWithValue("@address", customer.address);
                    sqlCommand.Parameters.AddWithValue("@pincode", customer.pincode);
                    sqlCommand.Parameters.AddWithValue("@mobileNumber", customer.mobileNumber);
                    sqlCommand.Parameters.AddWithValue("@password", customer.password);
                    sqlConnection.Open();
                    int rows = sqlCommand.ExecuteNonQuery();
                    if (rows > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                Console.WriteLine("Exception Occur");
            }
            finally
            { 
                sqlConnection.Close();
            }
            return false;
        }
        public bool DeleteCustomerDetails(int customerId)
        {
            SqlConnection connection = DatabaseConnection.GetDatabaseConnection();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_DeleteCustomers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", customerId);
                    command.Connection = connection;
                    connection.Open();
                    int rows =command.ExecuteNonQuery();
                    if (rows >= 0)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                Console.WriteLine("Exception Occurs");
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public bool UpdateCustomerDetails(Customer customer,int customerId)
        {
            SqlConnection connection = DatabaseConnection.GetDatabaseConnection();
            try
            {
                using (SqlCommand command = new SqlCommand("sp_UpdateCustomers"))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", customerId);
                    command.Parameters.AddWithValue("@Name", customer.name);
                    command.Parameters.AddWithValue("@DateOfBirth", customer.dateOfBirth);
                    command.Parameters.AddWithValue("@EmailId", customer.emailID);
                    command.Parameters.AddWithValue("@type", customer.employmentType);
                    command.Parameters.AddWithValue("@salary", customer.monthlySalary);
                    command.Parameters.AddWithValue("@company", customer.company);
                    command.Parameters.AddWithValue("@address", customer.address);
                    command.Parameters.AddWithValue("@pincode", customer.pincode);
                    command.Parameters.AddWithValue("@mobilenumber", customer.mobileNumber);
                    command.Parameters.AddWithValue("@password", customer.password);
                    command.Connection = connection;
                    connection.Open();
                    int rows=command.ExecuteNonQuery();
                    if (rows >= 0)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                Console.WriteLine("Exception Occurs");
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}

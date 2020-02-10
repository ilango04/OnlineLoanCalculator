using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace OnlineLoanCalculator
{
    public partial class Home : System.Web.UI.Page
    {
        CustomerRepository customerRepository = new CustomerRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCustomerDetails();
            }
        }
        public void BindCustomerDetails()
        {           
            customerRepository.DisplayDetails(GridViewId);
        }
        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int customerId = Convert.ToInt32(GridViewId.DataKeys[e.RowIndex].Values[0]);
            string connectionString = @"Data Source=LAPTOP-S25DNCVE\SQLEXPRESS;Database=Project;Integrated Security=SSPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_DeleteCustomers"))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", customerId);
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            BindCustomerDetails();
        }
        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewId.EditIndex = e.NewEditIndex;
            BindCustomerDetails();
        }
        protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewId.EditIndex = -1;
            BindCustomerDetails();
        }
        protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string name = (GridViewId.Rows[e.RowIndex].FindControl("txtName") as TextBox).Text;
            string dateofbirth = (GridViewId.Rows[e.RowIndex].FindControl("txtBirth") as TextBox).Text;
            string emailId = (GridViewId.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text;
            string employmentType = (GridViewId.Rows[e.RowIndex].FindControl("txtType") as TextBox).Text;
            string salary = (GridViewId.Rows[e.RowIndex].FindControl("txtSalary") as TextBox).Text;
            string company = (GridViewId.Rows[e.RowIndex].FindControl("txtCompany") as TextBox).Text;
            string address = (GridViewId.Rows[e.RowIndex].FindControl("txtAddress") as TextBox).Text;
            string pincode = (GridViewId.Rows[e.RowIndex].FindControl("txtPincode") as TextBox).Text;
            string mobilenumber = (GridViewId.Rows[e.RowIndex].FindControl("txtNumber") as TextBox).Text;
            string password = (GridViewId.Rows[e.RowIndex].FindControl("txtPassword") as TextBox).Text;
            int id = Convert.ToInt32(GridViewId.DataKeys[e.RowIndex].Values[0]); ;
            Customer customer = new Customer(name,Convert.ToDateTime(dateofbirth), emailId, employmentType,int.Parse(salary), company, address,long.Parse(pincode),long.Parse(mobilenumber), password);
            string connectionString = @"Data Source=LAPTOP-S25DNCVE\SQLEXPRESS;Database=Project;Integrated Security=SSPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_UpdateCustomers"))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@Name", customer.name);
                    command.Parameters.AddWithValue("@DateOfBirth", customer.dateOfBirth);
                    command.Parameters.AddWithValue("@EmailId", customer.emailID);
                    command.Parameters.AddWithValue("@type", customer.employmentType);
                    command.Parameters.AddWithValue("@salary", customer.monthlySalary);
                    command.Parameters.AddWithValue("@company", customer.company);
                    command.Parameters.AddWithValue("@address", customer.address);
                    command.Parameters.AddWithValue("@pincode", customer.pincode);
                    command.Parameters.AddWithValue("@mobilenumber",customer.mobileNumber);
                    command.Parameters.AddWithValue("@password", customer.password);
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            GridViewId.EditIndex = -1;
            BindCustomerDetails();
        }
        protected void InsertClick(object sender, EventArgs e)
        {
            string name = (GridViewId.FooterRow.FindControl("nameId") as TextBox).Text;
            string dateofbirth = (GridViewId.FooterRow.FindControl("birthId") as TextBox).Text;
            string emailId = (GridViewId.FooterRow.FindControl("emailId") as TextBox).Text;
            string employmentType = (GridViewId.FooterRow.FindControl("typeId") as TextBox).Text;
            string salary = (GridViewId.FooterRow.FindControl("salaryId") as TextBox).Text;
            string company = (GridViewId.FooterRow.FindControl("companyId") as TextBox).Text;
            string address = (GridViewId.FooterRow.FindControl("addressId") as TextBox).Text;
            string pincode = (GridViewId.FooterRow.FindControl("pincodeId") as TextBox).Text;
            string mobilenumber = (GridViewId.FooterRow.FindControl("mobileId") as TextBox).Text;
            string password = (GridViewId.FooterRow.FindControl("PasswordId") as TextBox).Text;
            Customer customer = new Customer(name, Convert.ToDateTime(dateofbirth), emailId, employmentType, int.Parse(salary), company, address, long.Parse(pincode), long.Parse(mobilenumber), password);
            customerRepository.AddCustomer(customer);
            GridViewId.EditIndex = -1;
            BindCustomerDetails();
        }
    }
}
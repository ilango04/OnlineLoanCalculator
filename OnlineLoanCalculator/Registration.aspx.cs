using System;
using System.Data.SqlClient;                         //Data providers for SqlClient
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLoanCalculator
{
    public partial class Registration : System.Web.UI.Page
    {
        public string customerName;
        public DateTime dateOfBirth;
        public string emailID;
        public string employmentType;
        public long salary;
        public string company;
        public string address;
        public long pincode;
        public long mobileNumber;
        public string password;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Button_Load(object sender, EventArgs e)
        {
            customerName = txtName.Text;
            dateOfBirth = Convert.ToDateTime(txtDate.Text);
            emailID = txtEmail.Text;
            employmentType = txtType.Text;
            salary = long.Parse(txtSalary.Text);
            company = txtCompany.Text;
            address = txtAddress.Text;
            pincode = long.Parse(txtPincode.Text);
            mobileNumber = long.Parse(txtNumber.Text);
            password = txtPassword.Text;
            Customer customer = new Customer(customerName, dateOfBirth, emailID, employmentType, salary, company, address, pincode, mobileNumber, password);
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.InsertDetails(customer);
            if(customerRepository.rows>=0)
                Response.Write("<script>alert('Registration successfully your userid is')</script>");
            else
                Response.Write("<script>alert('Data inserted successfully'+)</script>");

            //Response.Redirect("Login.aspx.cs");
        }
    }
}
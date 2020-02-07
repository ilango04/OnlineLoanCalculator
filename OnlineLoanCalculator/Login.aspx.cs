using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLoanCalculator
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button_Click(object sender, EventArgs e)
        {
            long id = long.Parse(txtID.Text);
            string password = txtPassword.Text;
            CustomerRepository customerRepository = new CustomerRepository();
            if (customerRepository.ToAdminLogin(id, password) == true)
                Response.Write("<script>alert('Login successfully for Admin')</script>");
            else if (customerRepository.ToCustomerLogin(id, password) == true)
                Response.Write("<script>alert('Login successfully for Customer')</script>");
            else
                Response.Write("<script>alert('Login Failed')</script>");
        }
    }
}
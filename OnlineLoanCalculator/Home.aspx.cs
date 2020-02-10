using System;
using OnlineLoanCalculator_EL;
using OnlineLoanCalculator_BL;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace OnlineLoanCalculator
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCustomerDetails();
            }
        }
        public void BindCustomerDetails()
        {
            new CustomerBL().DisplayCustomerDetails(GridViewId);
        }
        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int customerId = Convert.ToInt32(GridViewId.DataKeys[e.RowIndex].Values[0]);
            if(new CustomerBL().DeleteCustomer(customerId)==true)
                Response.Write("<script>alert('Successfully Deleted')</script>");
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
            if(new CustomerBL().UpdateCustomer(customer,id)==true)
                Response.Write("<script>alert('Successfully Updated')</script>");
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
            if(new CustomerBL().AddCustomer(customer)==true)
                Response.Write("<script>alert('Successfully Added')</script>");
            GridViewId.EditIndex = -1;
            BindCustomerDetails();
        }
    }
}
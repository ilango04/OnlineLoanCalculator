using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineLoanCalculator
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        public void BindGrid()
        {
            string connectionString = @"Data Source=LAPTOP-S25DNCVE\SQLEXPRESS;Database=Project;Integrated Security=SSPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select id,name,current_company,monthly_salary from customer"))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        cmd.Connection = connection;
                        adapter.SelectCommand = cmd;
                        using (DataTable data = new DataTable())
                        {
                            adapter.Fill(data);
                            GridView1.DataSource = data;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        protected void RowEditing(object sender, GridViewEditEventArgs e)
        {
           
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }
        protected void RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string name = (row.Cells[2].Controls[0] as TextBox).Text;
            string company = (row.Cells[3].Controls[0] as TextBox).Text;
            int salary = Convert.ToInt32((row.Cells[3].Controls[0] as TextBox).Text);
            string connectionString = @"Data Source=LAPTOP-S25DNCVE\SQLEXPRESS;Database=Project;Integrated Security=SSPI";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("UPDATE customer SET name = @Name, current_company=@company,monthly_salary=@salary WHERE id = @CustomerId"))
                {
                    command.Parameters.AddWithValue("@CustomerId",customerId);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@company", company);
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        protected void RowCancelingEdit(object sender, EventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        protected void RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int customerId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string connectionString = @"Data Source=LAPTOP-S25DNCVE\SQLEXPRESS;Database=Project;Integrated Security=SSPI";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Customer WHERE id = @CustomerId"))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }
        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }
    }
}
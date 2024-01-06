using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3.MasterPages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string id = txtbox_ID.Text;
            string pword = txtbox_password.Text;

            string connectionString = "Data Source=BUNGA\\SQLEXPRESS01;Initial Catalog=Dotnet;Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT Password FROM login WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader["Password"].ToString();
                        if (pword.Equals(storedPassword))
                        {
                            // Login successful, redirect to another page
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            lblStatus.Text = "Incorrect password";
                        }
                    }
                    else
                    {
                        lblStatus.Text = "User not found";
                    }
                }
            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtbox_ID.Text = string.Empty;
            txtbox_password.Text = string.Empty;
        }
    }
}
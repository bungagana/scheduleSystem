using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Lab3.MasterPages
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void submitFormContact(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            string Name = txtName.Text;
            string Messeges = txtmesseges.Text;

            string connectionString = "Data Source=BUNGA\\SQLEXPRESS01;Initial Catalog=Dotnet;Integrated Security=True;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO contactUs (ID, Name, Messeges) VALUES (@id, @name, @messeges)", con);
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@messeges", Messeges);

                    cmd.ExecuteNonQuery();
                    Response.Write("Succesfull insert data in the table");
                 

                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
                finally
                {
                    con.Close();
                }

            }
            string script = "if (confirm('Are you sure you want to submit this form?')) { " +
                               "document.getElementById('" + contactButton.ClientID + "').click(); }";

            ScriptManager.RegisterStartupScript(this, GetType(), "submitConfirmation", script, true);
        }
        protected void cancelForm(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtmesseges.Text = string.Empty;
        }
    }
}
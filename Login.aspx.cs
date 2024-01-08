using System;
using System.Data.SqlClient;

namespace Lab3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
     
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string crewId = txtUsername.Text.Trim(); 
                string password = txtPassword.Text;


                using (SqlConnection connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE CrewID = @CrewID AND Password = @Password", connection))
                    {
                        command.Parameters.AddWithValue("@CrewID", crewId);
                        command.Parameters.AddWithValue("@Password", HashingFunction(password));

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
   
                            Session["CrewID"] = reader["CrewID"].ToString();
                            Session["FullName"] = reader["FullName"].ToString();
                            Session["Email"] = reader["Email"].ToString();
                            Session["Username"] = reader["Username"].ToString();
                            Session["Department"] = reader["Department"].ToString();
                            Session["UserRole"] = reader["UserRole"].ToString();

       
                            Response.Redirect("Home.aspx", false);
                        }
                        else
                        {
                            lblMessage.Text = "Invalid CrewID or password.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error during login: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
            }
        }

        private string HashingFunction(string password)
        {
  
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}

using System;
using System.Data.SqlClient;

namespace Lab3
{
    public partial class Regis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDepartments();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }

        protected void ddlDepartment_DataBound(object sender, EventArgs e)
        {
            ddlDepartment.Items.Add(new System.Web.UI.WebControls.ListItem("Department1", "Department1"));
            ddlDepartment.Items.Add(new System.Web.UI.WebControls.ListItem("Department2", "Department2"));
        }

        private void PopulateDepartments()
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT DepartmentName FROM Departments";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            ddlDepartment.Items.Clear();

                            while (reader.Read())
                            {
                                string departmentName = reader["DepartmentName"].ToString();
                                ddlDepartment.Items.Add(new System.Web.UI.WebControls.ListItem(departmentName, departmentName));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading departments: " + ex.Message;
                lblMessage.Visible = true;
            }
        }

        private void RegisterUser()
        {
            try
            {
                string crewId = txtCrewId.Text.Trim();
                string fullName = txtFullName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;
                string confirmPassword = txtConfirmPassword.Text;
                string department = ddlDepartment.SelectedValue;
                string userRole = ddlUserRole.SelectedValue;

                if (password != confirmPassword)
                {
                    lblMessage.Text = "Password and Confirm Password do not match.";
                    lblMessage.Visible = true;
                    return;
                }
                string hashedPassword = HashingFunction(password);

                using (SqlConnection connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    using (SqlCommand checkUserCommand = new SqlCommand("SELECT COUNT(*) FROM Users WHERE CrewId = @CrewId", connection))
                    {
                        checkUserCommand.Parameters.AddWithValue("@CrewId", crewId);

                        int existingUsersCount = (int)checkUserCommand.ExecuteScalar();
                        if (existingUsersCount > 0)
                        {
                            lblMessage.Text = "User with the same Crew ID already exists.";
                            lblMessage.Visible = true;
                            return;
                        }
                    }

                    using (SqlCommand insertUserCommand = new SqlCommand(
                        "INSERT INTO Users (CrewId, FullName, Email, Username, Password, Department, UserRole) " +
                        "VALUES (@CrewId, @FullName, @Email, @Username, @Password, @Department, @UserRole)", connection))
                    {
                        insertUserCommand.Parameters.AddWithValue("@CrewId", crewId);
                        insertUserCommand.Parameters.AddWithValue("@FullName", fullName);
                        insertUserCommand.Parameters.AddWithValue("@Email", email);
                        insertUserCommand.Parameters.AddWithValue("@Username", username);
                        insertUserCommand.Parameters.AddWithValue("@Password", hashedPassword);
                        insertUserCommand.Parameters.AddWithValue("@Department", department);
                        insertUserCommand.Parameters.AddWithValue("@UserRole", userRole);

                        int rowsAffected = insertUserCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Registration successful.";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            lblMessage.Visible = true;
                            Response.Redirect("Login.aspx", false);
                        }
                        else
                        {
                            lblMessage.Text = "Registration failed. Please try again.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error during registration: " + ex.Message;
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

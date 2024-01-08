using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Lab3
{
    public partial class Profile : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is logged in
                if (Session["CrewID"] != null)
                {
                    // Retrieve user information and display it
                    txtCrewId.Text = Session["CrewID"].ToString();
                    txtFullName.Text = Session["FullName"].ToString();
                    txtEmail.Text = Session["Email"].ToString();
                    txtUsername.Text = Session["Username"].ToString();
                    txtDepartment.Text = Session["Department"].ToString();
                    txtUserRole.Text = Session["UserRole"].ToString();

                    // Set the initial visibility of buttons
                    btnEdit.Visible = true;
                    btnSave.Visible = false;

                    // Set the initial state of textboxes
                    SetTextBoxesReadOnly(true);
                }
                else
                {
                    // Redirect to the login page if the user is not logged in
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // Enable editing
            SetTextBoxesReadOnly(false);

            // Toggle button visibility
            btnEdit.Visible = false;
            btnSave.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Save changes to the database
            UpdateUserProfile();

            // Update session variables with the edited values
            Session["FullName"] = txtFullName.Text;
            Session["Email"] = txtEmail.Text;
            Session["Username"] = txtUsername.Text;
            Session["Department"] = txtDepartment.Text;
            Session["UserRole"] = txtUserRole.Text;

            // Disable editing
            SetTextBoxesReadOnly(true);

            // Toggle button visibility
            btnEdit.Visible = true;
            btnSave.Visible = false;
        }

        private void SetTextBoxesReadOnly(bool readOnly)
        {
            // Set the ReadOnly property of textboxes
            txtFullName.ReadOnly = readOnly;
            txtEmail.ReadOnly = readOnly;
            txtUsername.ReadOnly = readOnly;
            txtDepartment.ReadOnly = readOnly;
            txtUserRole.ReadOnly = readOnly;
        }

        private void UpdateUserProfile()
        {
            // Perform the database update
            using (SqlConnection connection = DbConnection.GetConnection())
            {
                string updateQuery = "UPDATE Users SET FullName=@FullName, Email=@Email, Username=@Username, Department=@Department, UserRole=@UserRole WHERE CrewID=@CrewID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                    cmd.Parameters.AddWithValue("@UserRole", txtUserRole.Text);
                    cmd.Parameters.AddWithValue("@CrewID", Session["CrewID"].ToString());

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

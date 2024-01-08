using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Lab3
{
    public partial class AddDepart : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSaveDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                string departmentId = txtDepartmentId.Text;
                string departmentName = txtDepartmentName.Text;
                string departmentDescription = txtDepartmentDescription.Text;

                using (SqlConnection connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string query = "INSERT INTO Departments (departmentId, departmentName, departmentDesc) " +
                                   "VALUES (@DepartmentId, @DepartmentName, @DepartmentDesc)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@DepartmentId", departmentId);
                        command.Parameters.AddWithValue("@DepartmentName", departmentName);
                        command.Parameters.AddWithValue("@DepartmentDesc", departmentDescription);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Redirect("Department.aspx");
                        }
                        else
                        {
                            throw new Exception("Failed to insert data into the Departments table.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


    }
}

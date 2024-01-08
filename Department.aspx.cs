using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class Department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Departments", connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataTable.Load(reader);

                    GridViewDepartments.DataSource = dataTable;
                    GridViewDepartments.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAddDepartment_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddDepart.aspx");
        }


        protected void GridViewDepartments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int departmentId = Convert.ToInt32(GridViewDepartments.DataKeys[e.RowIndex].Values["DepartmentId"]);

                using (SqlConnection connection = DbConnection.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Departments WHERE DepartmentId = @DepartmentId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DepartmentId", departmentId);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            BindGridView(); 
                        }
                        else
                        {
                            throw new Exception("Failed to delete data from the Departments table.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
             
            }
        }
    }
}

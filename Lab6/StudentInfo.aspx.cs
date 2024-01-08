using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Lab3
{
    public partial class StudentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }

        }
        private void BindGrid()
        {

            SqlConnection con = new SqlConnection
            ("Data Source =.\\SQLEXPRESS01; Initial Catalog = Dotnet;   Integrated Security = True; Pooling = False");

            try
            {
                con.Open();

                SqlCommand cmmd = new SqlCommand("SELECT * FROM student", con);
                SqlDataAdapter sda = new SqlDataAdapter();
                DataTable dt = new DataTable();

                sda.SelectCommand = cmmd;
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();



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
     
        protected void GridView1_RowDataBound(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = GridView1.SelectedRow.Cells[0].Text;
            string ID = GridView1.SelectedRow.Cells[1].Text;
            string course = GridView1.SelectedRow.Cells[2].Text;

            Session["studentid"] = ID;
            Session["studentname"] = name;
            Session["course"] = course;

            Response.Redirect("Update.aspx");
        }

        protected void ButtonAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNew.aspx");
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Get the student_id of the row being deleted
                string studentId = GridView1.DataKeys[e.RowIndex].Value.ToString();

                // Your delete logic here
                DeleteStudent(studentId);

                // Rebind the GridView after deletion
                BindGrid();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Response.Write(ex.ToString());
            }
        }


        // Method to delete a student by ID
        private void DeleteStudent(string studentId)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Data Source =.\\SQLEXPRESS01; Initial Catalog = Dotnet; Integrated Security = True; Pooling = False"].ToString()))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM student WHERE student_id=@StudentId", con);
                    cmd.Parameters.AddWithValue("@StudentId", studentId);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // Optionally, you can set a message or log that deletion was successful
                    }
                    else
                    {
                        // Optionally, you can set a message or log that deletion failed
                    }
                }
                catch (Exception ex)
                {
                    // Handle any SQL exceptions
                    Response.Write(ex.ToString());
                }
            }
        }


    }
}

    

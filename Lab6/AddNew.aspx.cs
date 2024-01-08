using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class AddNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            string ID = txtbox_ID.Text;
            string name = txtbox_name.Text;
            string course = ddl_Course.SelectedItem.Text;

            SqlConnection con = new SqlConnection
            ("Data Source =.\\SQLEXPRESS01; Initial Catalog = Dotnet;   Integrated Security = True; Pooling = False");

            try
            {
                con.Open();

                SqlCommand cmmd = new SqlCommand("SELECT * FROM student WHERE student_id='" + ID + "'", con);
                SqlDataReader reader = cmmd.ExecuteReader();

                if (reader.Read())
                {
                    lblStatus.Text = "Student ID already exists! Please type different Student ID";
                    reader.Close();
                    return;
                }

                reader.Close();
                SqlDataAdapter cmd = new SqlDataAdapter();// Create a object of SqlDataAdapter class
                cmd.InsertCommand = new SqlCommand("INSERT INTO student VALUES (@name, @student_id,@course) ", con); //Pass the connection object to cmd

                cmd.InsertCommand.Parameters.Add("@name", SqlDbType.Text).Value = name;
                cmd.InsertCommand.Parameters.Add("@student_id", SqlDbType.Text).Value = ID;
                cmd.InsertCommand.Parameters.Add("@course", SqlDbType.Text).Value = course;

                cmd.InsertCommand.ExecuteNonQuery();  //to execute the SQL command

                lblStatus.Text = "New student info added successfully";
                txtbox_ID.Text = "";
                txtbox_name.Text = "";
                ddl_Course.Text = "";

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

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            txtbox_name.Text = "";
            txtbox_ID.Text = "";
            ddl_Course.Text = "";
        }
    }
}

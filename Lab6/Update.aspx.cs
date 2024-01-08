using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



namespace Lab3
{
    public partial class Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                txtbox_ID.Text = Session["studentid"].ToString();
                txtbox_name.Text = Session["studentname"].ToString();
                ddl_Course.Items.FindByText(Session["course"].ToString()).Selected = true;
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Update_DB("update");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            txtbox_ID.Text = Session["studentid"].ToString();
            txtbox_name.Text = Session["studentname"].ToString();
            ddl_Course.SelectedItem.Selected = false;
            ddl_Course.Items.FindByText(Session["course"].ToString()).Selected = true;
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            Update_DB("delete");
        }

        protected void Update_DB(String strAction)
        {
            string ID = txtbox_ID.Text.Trim();
            string name = txtbox_name.Text;
            //DateTime now = DateTime.Now;
            string course = ddl_Course.SelectedItem.Text;

             SqlConnection con = new SqlConnection
 ("Data Source =.\\SQLEXPRESS01; Initial Catalog = Dotnet;   Integrated Security = True; Pooling = False");

            //SqlCommand com = new SqlCommand();
            try
            {
                con.Open();

                SqlCommand cmd;

                if (strAction == "update")
                {
                    cmd = new SqlCommand("UPDATE student SET name='" + name + "', course='" + course + "' WHERE student_id='" + ID + "'", con);

                    int result = cmd.ExecuteNonQuery();  //to execute the SQL command

                    if (result > 0)
                        lblStatus.Text = "Student info updated successfully";
                }
                else if (strAction == "delete")
                {
                    cmd = new SqlCommand("DELETE FROM student WHERE student_id='" + ID + "'", con);

                    int result = cmd.ExecuteNonQuery();  //to execute the SQL command

                    if (result > 0)
                        lblStatus.Text = "Student info deleted successfully";
                    txtbox_ID.Text = "";
                    txtbox_name.Text = "";
                    txtbox_ID.Enabled = false;
                    txtbox_name.Enabled = false;
                    ddl_Course.Enabled = false;
                    ButtonSave.Enabled = false;
                    ButtonDelete.Enabled = false;
                    ButtonCancel.Enabled = false;

                }

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

        protected void txtbox_name_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "";
        }
    }
}

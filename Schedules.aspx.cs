using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class Schedules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewSchedules.RowDataBound += GridViewSchedules_RowDataBound;
                BindGridView();
            }
        }

        protected void GridViewSchedules_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int no = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = no.ToString();
            }
        }

        protected void GridViewSchedules_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string crewID = GridViewSchedules.DataKeys[e.RowIndex]["crewID"].ToString();

  
            DeleteScheduleByCrewID(crewID);

      
            BindGridView();
        }

        private void DeleteScheduleByCrewID(string crewID)
        {
            try
            {
                using (SqlConnection connection = DbConnection.GetConnection())
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM Dataschedules WHERE crewID = @CrewID";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CrewID", crewID);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            
                lblErrorMessageDetails.Text = "Error deleting schedule: " + ex.Message;
                lblErrorMessageDetails.Visible = true;
            }
        }

        private void BindGridView()
        {
            try
            {
                using (SqlConnection con = DbConnection.GetConnection())
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Dataschedules", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            GridViewSchedules.DataSource = dt;
                            GridViewSchedules.DataBind();
                        }
                        else
                        {
  
                            dt.Rows.Add(dt.NewRow());
                            GridViewSchedules.DataSource = dt;
                            GridViewSchedules.DataBind();
                            int columncount = GridViewSchedules.Rows[0].Cells.Count;
                            GridViewSchedules.Rows[0].Cells.Clear();
                            GridViewSchedules.Rows[0].Cells.Add(new TableCell());
                            GridViewSchedules.Rows[0].Cells[0].ColumnSpan = columncount;
                            GridViewSchedules.Rows[0].Cells[0].Text = "No schedules found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
             
                lblErrorMessageDetails.Text = ex.Message;
                lblErrorMessageDetails.Visible = true;
            }
        }

        protected void btnAddSchedule_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateSchedule.aspx");
        }

        protected void GridViewSchedules_RowEditing(object sender, GridViewEditEventArgs e)
        {
  
            string crewID = GridViewSchedules.DataKeys[e.NewEditIndex].Values["crewID"].ToString();

            Response.Redirect($"UpdateSchedule.aspx?editMode=true&editCrewID={crewID}");
            BindGridView();
        }
    }
}

using System;
using System.Data.SqlClient;

namespace Lab3
{
    public partial class UpdateSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string crewID = Request.QueryString["editCrewID"];
                txtCrewID.Enabled = false;
                PopulateScheduleDetails(crewID);
                PopulateDepartments();
            }
        }

        private void PopulateDepartments()
        {
    
            using (SqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();

                string query = "SELECT DepartmentName FROM Departments"; 

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ddlJobRoles.Items.Clear(); //

                        while (reader.Read())
                        {
                            string departmentName = reader["DepartmentName"].ToString();
                            ddlJobRoles.Items.Add(new System.Web.UI.WebControls.ListItem(departmentName, departmentName));
                        }
                    }
                }
            }
        }

        private void PopulateScheduleDetails(string crewID)
        {
            try
            {
                using (SqlConnection con = DbConnection.GetConnection())
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Dataschedules WHERE CrewID = @CrewID", con))
                    {
                        cmd.Parameters.AddWithValue("@CrewID", crewID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                              
                                lblCrewID.Text = reader["CrewID"].ToString();
                                txtFullName.Text = reader["FullName"].ToString();
                                txtCrewID.Text = reader["CrewID"].ToString();
                                ddlJobRoles.SelectedValue = reader["JobRoles"].ToString();
                                txtDutyTime.Text = reader["DutyTime"].ToString();
                                txtStartTime.Attributes["value"] = reader["StartTime"].ToString();

                                txtEndTime.Attributes["value"] = reader["EndTime"].ToString();

                           
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
        }


        protected void btnUpdateSchedule_Click(object sender, EventArgs e)
        {
            try
            {
            
                string crewID = Request.QueryString["editCrewID"];

          
                using (SqlConnection con = DbConnection.GetConnection())
                {
                    con.Open();

                
                    using (SqlCommand cmd = new SqlCommand("UPDATE Dataschedules SET FullName = @FullName, JobRoles = @JobRoles, DutyTime = @DutyTime, StartTime = @StartTime, EndTime = @EndTime WHERE CrewID = @CrewID", con))
                    {
                        cmd.Parameters.AddWithValue("@CrewID", crewID);
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                        cmd.Parameters.AddWithValue("@JobRoles", ddlJobRoles.SelectedValue);
                        cmd.Parameters.AddWithValue("@DutyTime", txtDutyTime.Text);
                        cmd.Parameters.AddWithValue("@StartTime", txtStartTime.Value);
                        cmd.Parameters.AddWithValue("@EndTime", txtEndTime.Value);


                        cmd.ExecuteNonQuery();
                    }
                }

   
                Response.Redirect("Schedules.aspx");
            }
            catch (Exception ex)
            {
         
            }
        }

    }
}

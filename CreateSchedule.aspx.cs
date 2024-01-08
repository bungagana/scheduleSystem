using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class CreateSchedule : System.Web.UI.Page
    {
        protected HtmlInputControl txtStartTime;
        protected HtmlInputControl txtEndTime;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDepartments();
                PopulateCrewIDs();
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
                        while (reader.Read())
                        {
                            string departmentName = reader["DepartmentName"].ToString();
                            ddlJobRoles.Items.Add(new ListItem(departmentName, departmentName));
                        }
                    }
                }
            }
        }

        private void PopulateCrewIDs()
        {
            using (SqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();

                string query = "SELECT CrewID FROM Users"; 

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string crewID = reader["CrewID"].ToString();
                            ddlCrewID.Items.Add(new ListItem(crewID, crewID));
                        }
                    }
                }
            }
        }

        protected void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = txtFullName.Text;
                string crewID = ddlCrewID.SelectedValue;
                string jobRoles = ddlJobRoles.SelectedValue;
                string dutyTime = txtDutyTime.Text;
                string startTime = txtStartTime.Value; 
                string endTime = txtEndTime.Value;     


                if (TryParseTime(startTime, out TimeSpan startTimeSpan) && TryParseTime(endTime, out TimeSpan endTimeSpan))
                {
                    using (SqlConnection connection = DbConnection.GetConnection())
                    {
                        connection.Open();

                        string query = "INSERT INTO Dataschedules (fullName, crewID, jobRoles, dutyTime, startTime, endTime) " +
                                       "VALUES (@FullName, @CrewID, @JobRoles, @DutyTime, @StartTime, @EndTime)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@FullName", fullName);
                            command.Parameters.AddWithValue("@CrewID", crewID);
                            command.Parameters.AddWithValue("@JobRoles", jobRoles);
                            command.Parameters.AddWithValue("@DutyTime", dutyTime);
                            command.Parameters.AddWithValue("@StartTime", startTimeSpan.ToString("hh\\:mm"));
                            command.Parameters.AddWithValue("@EndTime", endTimeSpan.ToString("hh\\:mm"));

                            command.ExecuteNonQuery();
                        }
                    }

                    Response.Redirect("Schedules.aspx");
                }
                else
                {
                    pnlMessage.Visible = true;
                    lblErrorMessage.Text = "Invalid time format for StartTime or EndTime.";
                }
            }
            catch (SqlException ex)
            {
                pnlMessage.Visible = true;
                lblErrorMessage.Text = $"Error creating schedule: The Crew ID has already been used.";
            }
            catch (Exception ex)
            {
                pnlMessage.Visible = true;
                lblErrorMessage.Text = $"An error occurred: {ex.Message}";
            }
        }

        private bool TryParseTime(string timeString, out TimeSpan result)
        {
            return TimeSpan.TryParse(timeString, out result);
        }
    }
}

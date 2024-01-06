using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.HtmlControls;

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
                // Populate job roles in the DropDownList from the database
                PopulateDepartments();
            }
        }

        private void PopulateDepartments()
        {
            // Use DbConnection class to get the SqlConnection
            using (SqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();

                string query = "SELECT DepartmentName FROM Departments"; // Adjust the query based on your actual table structure

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string departmentName = reader["DepartmentName"].ToString();
                            ddlJobRoles.Items.Add(new System.Web.UI.WebControls.ListItem(departmentName, departmentName));
                        }
                    }
                }
            }
        }

        protected void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                // Get values from the input controls
                string fullName = txtFullName.Text;
                string crewID = txtCrewID.Text;
                string jobRoles = ddlJobRoles.SelectedValue;
                string dutyTime = txtDutyTime.Text;
                string startTime = txtStartTime.Value; // Access value property
                string endTime = txtEndTime.Value;     // Access value property

                // Ensure startTime and endTime are valid time formats
                if (TryParseTime(startTime, out TimeSpan startTimeSpan) && TryParseTime(endTime, out TimeSpan endTimeSpan))
                {
                    // Insert data into the database using DbConnection class
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
                    // Handle invalid time formats
                    pnlMessage.Visible = true;
                    lblErrorMessage.Text = "Invalid time format for StartTime or EndTime.";
                }
            }
            catch (SqlException ex)
            {
                // Display error message or log the exception
                pnlMessage.Visible = true;
                lblErrorMessage.Text = $"Error creating schedule: The Crew ID has already been used.";
            }

            catch (Exception ex)
            {
                // Handle other exceptions
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

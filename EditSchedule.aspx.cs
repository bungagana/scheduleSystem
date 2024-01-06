using System;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class EditSchedule : System.Web.UI.Page
    {
        protected HtmlInputControl txtStartTime;
        protected HtmlInputControl txtEndTime;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["editMode"] != null && Request.QueryString["editCrewID"] != null)
                {
                    string crewID = Request.QueryString["editCrewID"];
                    Console.WriteLine($"DEBUG: Page_Load - Editing CrewID: {crewID}");
                    LoadScheduleDataForEditing(crewID);
                }
                else
                {
                    Console.WriteLine("DEBUG: Page_Load - Not in edit mode.");
                }

            }
        }



        private void LoadScheduleDataForEditing(string crewID)
        {
            SqlCommand cmd = null;

            try
            {
                using (SqlConnection con = DbConnection.GetConnection())
                {
                    con.Open();

                    cmd = new SqlCommand("SELECT * FROM Dataschedules WHERE crewID = @CrewID", con);
                    cmd.Parameters.AddWithValue("@CrewID", crewID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            txtFullName.Text = reader["FullName"].ToString();
                            txtCrewID.Text = reader["crewID"].ToString();
                            ddlJobRoles.SelectedValue = reader["JobRoles"].ToString();
                            txtDutyTime.Text = reader["DutyTime"].ToString();
                            txtStartTime.Value = reader["StartTime"].ToString();
                            txtEndTime.Value = reader["EndTime"].ToString();

                            Console.WriteLine($"DEBUG: Loaded data for CrewID: {txtCrewID.Text}");
                        }
                        else
                        {
                            Console.WriteLine($"DEBUG: No data found for CrewID: {crewID}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: LoadScheduleDataForEditing - {ex.Message}");
                lblErrorMessage.Text = $"Error loading schedule data: {ex.Message}";
                lblErrorMessage.Visible = true;
            }
            finally
            {
                cmd?.Dispose();
            }
        }


        protected void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            UpdateSchedule();
        }

        private void UpdateSchedule()
        {
            try
            {
                using (SqlConnection con = DbConnection.GetConnection())
                {
                    con.Open();

                    string query = "UPDATE Dataschedules SET fullName = @FullName, jobRoles = @JobRoles, dutyTime = @DutyTime, " +
                                   "startTime = @StartTime, endTime = @EndTime WHERE crewID = @CrewID";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                        cmd.Parameters.AddWithValue("@JobRoles", ddlJobRoles.SelectedValue);
                        cmd.Parameters.AddWithValue("@DutyTime", txtDutyTime.Text);
                        cmd.Parameters.AddWithValue("@StartTime", txtStartTime.Value);
                        cmd.Parameters.AddWithValue("@EndTime", txtEndTime.Value);
                        cmd.Parameters.AddWithValue("@CrewID", txtCrewID.Text); // Gunakan kembali crewID sebagai parameter WHERE

                        Console.WriteLine($"DEBUG: Query: {query}");
                        Console.WriteLine($"DEBUG: crewID: {txtCrewID.Text}");

                        int rowsAffected = cmd.ExecuteNonQuery();

                        Console.WriteLine($"DEBUG: Rows Affected: {rowsAffected}");

                        if (rowsAffected > 0)
                        {
                            // Schedule successfully updated
                            lblErrorMessage.Text = "Schedule updated successfully.";
                            lblErrorMessage.Visible = true;
                        }
                        else
                        {
                            // Update failed
                            lblErrorMessage.Text = "Failed to update schedule.";
                            lblErrorMessage.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = $"Error updating schedule: {ex.Message}";
                lblErrorMessage.Visible = true;
            }
        }


        private void LoadDepartmentOptions()
        {
            try
            {
                using (SqlConnection con = DbConnection.GetConnection())
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT departmentName FROM departments", con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string departmentName = reader["departmentName"].ToString();
                                ddlJobRoles.Items.Add(new ListItem(departmentName, departmentName));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it, show an error message)
                Console.WriteLine($"Error loading department options: {ex.Message}");
            }
        }
    }
}

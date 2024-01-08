using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Lab3
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboardSummary();
                BindChart();
            }
        }

        private void BindChart()
        {
            Chart1.DataSource = GetDataFromDatabase();
            Chart1.Series["Series1"].XValueMember = "Label";
            Chart1.Series["Series1"].YValueMembers = "Value";
            Chart1.DataBind();
        }

        private void LoadDashboardSummary()
        {
            int departmentCount = GetDepartmentCount();
            int userCount = GetUserCount();
            int dayScheduleCount = GetScheduleCount("Day");
            int nightScheduleCount = GetScheduleCount("Night");

            litDepartments.Text = departmentCount.ToString();
            litUsers.Text = userCount.ToString();
            litDaySchedules.Text = dayScheduleCount.ToString();
            litNightSchedules.Text = nightScheduleCount.ToString();
        }

        private DataTable GetDataFromDatabase()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT 'Schedules (Day)' AS Label, COUNT(*) AS Value FROM Dataschedules WHERE scheduleTypeComputed = 'Day' UNION ALL SELECT 'Schedules (Night)' AS Label, COUNT(*) AS Value FROM Dataschedules WHERE scheduleTypeComputed = 'Night'", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        private int GetDepartmentCount()
        {
      
            using (SqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Departments", connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        private int GetUserCount()
        {
            using (SqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Users", connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

       private int GetScheduleCount(string scheduleType)
{
    using (SqlConnection connection = DbConnection.GetConnection())
    {
        connection.Open();

        using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Dataschedules WHERE scheduleTypeComputed = @ScheduleType", connection))
        {
            command.Parameters.AddWithValue("@ScheduleType", scheduleType);
            return (int)command.ExecuteScalar();
        }
    }
}

    }
}

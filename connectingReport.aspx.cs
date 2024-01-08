using System;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;


namespace Lab3
{
    public partial class connectingReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport();
            }
        }

        private void LoadReport()
        {
            DataTable dt = GetDataFromDatabase();

            ReportDataSource rds = new ReportDataSource("member", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report.rdlc");

            ReportViewer1.LocalReport.Refresh();
        }

        private DataTable GetDataFromDatabase()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=projectDotnet;Integrated Security=True";
            string query = "SELECT * FROM Users";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }


    }
}

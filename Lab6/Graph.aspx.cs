using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using System.Data;

namespace Lab3
{
    public partial class Graph : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindChart();
            }
        }

        protected void BindChart()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS01;Initial Catalog=Dotnet;Integrated Security=True;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT programee, num FROM classSumm", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    Chart2.DataSource = dt;
                    Chart2.Series["Series1"].XValueMember = "programee";
                    Chart2.Series["Series1"].YValueMembers = "num";
                    Chart2.DataBind();
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
        }


        

        protected void Chart1_Load1(object sender, EventArgs e)
        {

        }
    }
}
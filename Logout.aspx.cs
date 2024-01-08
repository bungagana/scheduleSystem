using System;

namespace Lab3
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}

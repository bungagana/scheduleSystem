using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Lab3.MasterPages
{
    public partial class MasterPages : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Mendapatkan nama halaman yang sedang dilihat
            string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);

            // Menentukan elemen menu yang sesuai dengan halaman yang sedang dilihat
            foreach (Control control in menu.Controls)
            {
                if (control is HtmlGenericControl li)
                {
                    // Menghapus kelas CSS 'active' dari semua elemen menu
                    li.Attributes["class"] = li.Attributes["class"].Replace("active", "");

                    // Menambahkan kelas CSS 'active' ke elemen menu yang sesuai dengan halaman yang sedang dilihat
                    if (li.InnerHtml.Contains($"href=\"{currentPage}\""))
                    {
                        li.Attributes["class"] += " active";
                    }
                }
            }
        }


    }
}
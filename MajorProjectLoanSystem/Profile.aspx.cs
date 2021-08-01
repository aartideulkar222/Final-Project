using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajorProjectLoanSystem
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }

            if (Session["USER_ID"] != null)
            {

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void submit6_Click(object sender, EventArgs e)
        {

        }
    }
}
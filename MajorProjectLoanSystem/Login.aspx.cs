using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using MajorProjectLoanSystem.Models;

namespace MajorProjectLoanSystem
{
    public partial class LoginSignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }

            if (Session["USER_ID"] != null)
            {
                Session.Remove("USER_ID");
                Session.RemoveAll();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //GET Request
                var responseTask = client.GetAsync("LoginDetails");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<LoginDetailsClass[]>();
                    readTask.Wait();

                    var logindetails = readTask.Result;

                    foreach (var logindetail in logindetails)
                    {
                        if (txtEmailId.Text == logindetail.Mail && txtPassword.Text == logindetail.Pass)
                        {
                            Session["USER_ID"] = logindetail.ID;
                            Response.Redirect("LoanHomePage.aspx");
                        }
                    }

                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "errorAlert()", true);
                }
            }
        }
    }
}
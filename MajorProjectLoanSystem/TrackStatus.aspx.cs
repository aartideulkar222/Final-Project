using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.IO;
using MajorProjectLoanSystem.Models;

namespace MajorProjectLoanSystem
{
    public partial class TrackStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                
            }

            if (Session["USER_ID"] != null)
            {
                StatusPersonal_Get_Id();
                StatusHome_Get_Id();
                StatusEducation_Get_Id();
                StatusGold_Get_Id();
            }
            else
            {
                //Response.Redirect("http://document.somee.com/Login.aspx");
            }
        }

        public void StatusPersonal_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("StatusPersonal/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StatusPersonalClass>();
                    readTask.Wait();
                    
                    var ladp = readTask.Result;

                    Label1.Text = ladp.Personal_Applied;
                    Label2.Text = ladp.Personal_Status;
                    Label3.Text = ladp.Personal_Correction;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void StatusHome_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("StatusHome/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StatusHomeClass>();
                    readTask.Wait();

                    var ladp = readTask.Result;

                    Label4.Text = ladp.Home_Applied;
                    Label5.Text = ladp.Home_Status;
                    Label6.Text = ladp.Home_Correction;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void StatusEducation_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("StatusEducation/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StatusEducationClass>();
                    readTask.Wait();

                    var ladp = readTask.Result;

                    Label7.Text = ladp.Education_Applied;
                    Label8.Text = ladp.Education_Status;
                    Label9.Text = ladp.Education_Correction;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }

        public void StatusGold_Get_Id()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                var responseTask = client.GetAsync("StatusGold/" + Convert.ToInt32(Session["USER_ID"]));
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StatusGoldClass>();
                    readTask.Wait();

                    var ladp = readTask.Result;

                    Label10.Text = ladp.Gold_Applied;
                    Label11.Text = ladp.Gold_Status;
                    Label12.Text = ladp.Gold_Correction;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                }
            }
        }
    }
}
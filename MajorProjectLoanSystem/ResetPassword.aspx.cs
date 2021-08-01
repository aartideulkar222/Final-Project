using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Net.Http;
using MajorProjectLoanSystem.Models;

namespace MajorProjectLoanSystem
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

            string myGUID;
            
            using (var client = new HttpClient())
            {
                    client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                    myGUID = Request.QueryString["Uid"];

                    if (myGUID != null)
                    {
                        //GET Request from ForgotPassword Table
                        var rT = client.GetAsync("ForgotPassword?Uid=" + myGUID);
                        rT.Wait();

                        var r = rT.Result;
                        int c = 0;
                        int id = 0;
                        if (r.IsSuccessStatusCode)
                        {
                            var readT = r.Content.ReadAsAsync<ForgotPasswordClass>();
                            readT.Wait();

                            var ld = readT.Result;

                            if (ld.U_ID == myGUID)
                            {
                                c = 1;
                                id = ld.P_ID;
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                            }

                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "errorAlert()", true);
                        }

                        if (c == 1)
                        {
                            //GET Request from LoginDetails Table
                            var lrT = client.GetAsync("LoginDetails");
                            lrT.Wait();

                            var lr = lrT.Result;

                            if (lr.IsSuccessStatusCode)
                            {
                                var lreadT = lr.Content.ReadAsAsync<LoginDetailsClass[]>();
                                lreadT.Wait();

                                var lld = lreadT.Result;

                                foreach (var ll in lld)
                                {
                                    if (ll.ID == id)
                                    {
                                        //HTTP PUT request in LoginDetails Table
                                        var logindetails = new LoginDetailsClass() { Mail = ll.Mail, Pan = ll.Pan, First_Name = ll.First_Name, Last_Name = ll.Last_Name, Contact = ll.Contact, Pass = txtNewPassword.Text };

                                        var putTask = client.PutAsJsonAsync<LoginDetailsClass>("LoginDetails?id=" + id, logindetails);
                                        putTask.Wait();

                                        var result = putTask.Result;

                                        if (result.IsSuccessStatusCode)
                                        {
                                            //HTTP DELETE request in LoginDetails Table
                                            var deleteTask = client.DeleteAsync("ForgotPassword?Uid=" + myGUID);
                                            deleteTask.Wait();

                                            var deleteResult = deleteTask.Result;
                                            if (deleteResult.IsSuccessStatusCode)
                                            {

                                                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "successAlert()", true);
                                            }
                                        }
                                        else
                                        {
                                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "errorAlert()", true);
                                        }
                                        break;
                                    }
                                }


                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "errorAlert()", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "oopsAlert()", true);
                    }
                }
        }
    }
}
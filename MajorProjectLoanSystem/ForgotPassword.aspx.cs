using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Mail;
using System.Net;
using System.Net.Http;
using MajorProjectLoanSystem.Models;

namespace MajorProjectLoanSystem
{
    public partial class ForgotPassword : System.Web.UI.Page
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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");
                String myGUID = Guid.NewGuid().ToString();
                //GET Request from LoginDetails Table
                var responseT = client.GetAsync("LoginDetails");
                responseT.Wait();

                var res = responseT.Result;
                int c = 0;
                int id = 0;
                if (res.IsSuccessStatusCode)
                {
                    var readT = res.Content.ReadAsAsync<LoginDetailsClass[]>();
                    readT.Wait();

                    var ld = readT.Result;

                    foreach (var l in ld)
                    {
                        if (l.Mail == txtEmailId.Text)
                        {
                            c = 1;
                            id = l.ID;
                            break;
                        }
                    }
                }

                if (c == 1)
                {
                    //HTTP POST Request in ForgotPassword Table
                    DateTime now = DateTime.Now;
                    var forgotpassword = new ForgotPasswordClass() { P_ID = id, U_ID = myGUID, RequestDateTime = now.Date };

                    var postTask = client.PostAsJsonAsync<ForgotPasswordClass>("forgotpassword", forgotpassword);
                    postTask.Wait();

                    var result = postTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<LoginDetailsClass>();
                        readTask.Wait();

                        var insertedStudent = readTask.Result;
                        //send email
                        try
                        {
                            String ToEmailAddress = txtEmailId.Text;
                            String Username = txtEmailId.Text;
                            String EmailBody = "Hi " + Username + ",<br/><br/> Click the link below to reset your password <br/><br/> https://localhost:44337/ResetPassword.aspx?Uid=" + myGUID;
                            MailMessage PassRecMail = new MailMessage("rahulgada07@gmail.com", ToEmailAddress);
                            PassRecMail.Body = EmailBody;
                            PassRecMail.IsBodyHtml = true;
                            PassRecMail.Subject = "Reset Password";
                            PassRecMail.Priority = MailPriority.High;
                            SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 587);
                            SMTP.DeliveryMethod = SmtpDeliveryMethod.Network;
                            SMTP.EnableSsl = true;
                            SMTP.UseDefaultCredentials = false;
                            SMTP.EnableSsl = true;
                            SMTP.Credentials = new NetworkCredential()
                            {
                                UserName = "trustyloanngp@gmail.com",
                                Password = "Asdf@123"
                            };
                            
                            SMTP.Send(PassRecMail);

                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "successAlert()", true);
                        }
                        catch (Exception)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "errorAlert()", true);
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
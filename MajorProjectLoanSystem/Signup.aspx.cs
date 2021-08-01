using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using MajorProjectLoanSystem.Models;
using SRVTextToImage;
using System.Drawing;
using System.Drawing.Imaging;

namespace MajorProjectLoanSystem
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //PAN Validation
            char[] lName = txtLastName.Text.ToCharArray();
            char[] panArray = txtPan.Text.ToCharArray();
            bool isPanValid;

            if (panArray[3] == 'C' || panArray[3] == 'H' || panArray[3] == 'F' || panArray[3] == 'A' || panArray[3] == 'T' || panArray[3] == 'B' || panArray[3] == 'L' || panArray[3] == 'J' || panArray[3] == 'G' || panArray[3] == 'P')
            {
                
                if (panArray[4] == lName[0])
                {
                    isPanValid = true;
                }
                else
                {
                    isPanValid = false;
                }

            }
            else
            {
                isPanValid = false;
            }

            //Captcha Validation 
            bool isCaptchaValid = false;
            if (Session["CaptchaText"] != null && Session["CaptchaText"].ToString() == txtCaptchaText.Text)
            {
                isCaptchaValid = true;
            }

            //Registeration
            if (isCaptchaValid)
            {
                if(isPanValid)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                        //GET Request
                        var rT = client.GetAsync("LoginDetails");
                        rT.Wait();

                        var r = rT.Result;
                        int c = 0;
                        if (r.IsSuccessStatusCode)
                        {
                            var readT = r.Content.ReadAsAsync<LoginDetailsClass[]>();
                            readT.Wait();

                            var ld = readT.Result;

                            foreach (var l in ld)
                            {
                                if (l.Mail == txtEmailId.Text)
                                {
                                    c = 1;
                                    break;
                                }
                            }
                        }

                        if (c == 0)
                        {
                            //HTTP POST
                            var logindetails = new LoginDetailsClass() { Mail = txtEmailId.Text, Pan = txtPan.Text, First_Name = txtFirstName.Text, Last_Name = txtLastName.Text, Contact = long.Parse(txtContact.Text), Pass = txtPassword.Text };

                            var postTask = client.PostAsJsonAsync<LoginDetailsClass>("LoginDetails", logindetails);
                            postTask.Wait();

                            var result = postTask.Result;

                            if (result.IsSuccessStatusCode)
                            {

                                var readTask = result.Content.ReadAsAsync<LoginDetailsClass>();
                                readTask.Wait();

                                var insertedStudent = readTask.Result;
                                txtEmailId.Text = "";
                                txtPan.Text = "";
                                txtPassword.Text = "";
                                txtConfirmPassword.Text = "";
                                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "successAlert()", true);
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "errorAlert()", true);
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "infoAlert()", true);
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "panAlert()", true);
                }
                
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "captchaAlert()", true);
            }

            
        }
    }
}
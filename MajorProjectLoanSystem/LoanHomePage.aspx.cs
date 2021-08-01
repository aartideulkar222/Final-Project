using System;
using System.Web.UI;
using System.Net.Mail;
using System.Net;
using System.Net.Http;
using MajorProjectLoanSystem.Models;

namespace MajorProjectLoanSystem
{
    public partial class LoanHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Loan_Details_Method();
            }

            if(Session["USER_ID"] != null)
            {

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void Loan_Details_Method()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");
                var responseTask = client.GetAsync("LoanDetails");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<LoanDetailsClass[]>();
                    readTask.Wait();

                    var loandetails = readTask.Result;

                    foreach (var LoanDetailsClass in loandetails)
                    {
                        lblPersonal1.Text = LoanDetailsClass.Personal_Interest_Rate;
                        lblPersonal2.Text = LoanDetailsClass.Personal_Loan_Tenure;
                        lblPersonal3.Text = LoanDetailsClass.Personal_Loan_Amount;
                        lblPersonal4.Text = LoanDetailsClass.Personal_Processing_Fees;
                        lblEducation1.Text = LoanDetailsClass.Education_Interest_Rate;
                        lblEducation2.Text = LoanDetailsClass.Education_Loan_Type;
                        lblEducation3.Text = LoanDetailsClass.Education_Loan_Amount;
                        lblEducation4.Text = LoanDetailsClass.Education_Concession;
                        lblHome1.Text = LoanDetailsClass.Home_InterestRate_1;
                        lblHome2.Text = LoanDetailsClass.Home_InterestRate_2;
                        lblHome3.Text = LoanDetailsClass.Home_InterestRate_3;
                        lblHome4.Text = LoanDetailsClass.Home_Processing_Fees;
                        lblGold1.Text = LoanDetailsClass.Gold_Min_Loan;
                        lblGold2.Text = LoanDetailsClass.Gold_Max_Loan;
                        lblGold3.Text = LoanDetailsClass.Gold_Margin;
                        lblGold4.Text = LoanDetailsClass.Gold_Processing_Fees;
                        lblClient.Text = LoanDetailsClass.Clients;
                        lblLoanApproved.Text = LoanDetailsClass.Loan_Approved;
                        lblHoursSupport.Text = LoanDetailsClass.Hours_Support;
                        lblHardWorkers.Text = LoanDetailsClass.Hard_Workers;
                        lblTrustyContactLocation.Text = LoanDetailsClass.Trusty_City;
                        lblTrustyContactMail.Text = LoanDetailsClass.Trusty_Mail;
                        lblTrustyContactPhone.Text = LoanDetailsClass.Trusty_Phone;
                        lblTrustyCity.Text = LoanDetailsClass.Trusty_City;
                        lblTrustyState.Text = LoanDetailsClass.Trusty_State;
                        lblTrustyCountry.Text = LoanDetailsClass.Trusty_Country;
                        lblTrustyPhone.Text = LoanDetailsClass.Trusty_Phone;
                        lblTrustyMail.Text = LoanDetailsClass.Trusty_Mail;

                        Session["Personal_Rate"] = LoanDetailsClass.Personal_Interest_Rate;
                        Session["Home_Rate1"] = LoanDetailsClass.Home_InterestRate_1;
                        Session["Home_Rate2"] = LoanDetailsClass.Home_InterestRate_2;
                        Session["Home_Rate3"] = LoanDetailsClass.Home_InterestRate_3;
                        Session["Education_Rate"] = LoanDetailsClass.Education_Interest_Rate;
                        Session["Gold_Rate"] = LoanDetailsClass.Personal_Interest_Rate;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //send email
            try
            {
                String ToEmailAddress = "trustyloanngp@gmail.com";
                String Username = name.Text;
                String EmailBody = "Hi LoanTrusty," + "<br/><br/>This is " + Username + "<br/><br/>My Email : " + email.Text + "<br/><br/>Message : " + message.Text + "<br/><br/>Thanks.";
                MailMessage PassRecMail = new MailMessage("rahulgada07@gmail.com", ToEmailAddress);
                PassRecMail.Body = EmailBody;
                PassRecMail.IsBodyHtml = true;
                PassRecMail.Subject = subject.Text;
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

    }
}
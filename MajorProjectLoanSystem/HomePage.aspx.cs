using System;
using System.Web.UI;
using System.Net.Mail;
using System.Net;
using System.Net.Http;
using MajorProjectLoanSystem.Models;

namespace MajorProjectLoanSystem
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            Session.Remove("USER_ID");
            Session.RemoveAll();

            if (!Page.IsPostBack)
            {
                Loan_Details_Method ();
            }
        }

        public void Loan_Details_Method()
        {
            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri("http://trustyloanapi.somee.com/api/");

                //GET Request
                var responseTask = client.GetAsync("LoanDetails/1");
                responseTask.Wait();
                    
                var result = responseTask.Result;
                
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<LoanDetailsClass>();
                    readTask.Wait();

                    var loandetails = readTask.Result;

                        lblPersonal1.Text = loandetails.Personal_Interest_Rate;
                        lblPersonal2.Text = loandetails.Personal_Loan_Tenure;
                        lblPersonal3.Text = loandetails.Personal_Loan_Amount;
                        lblPersonal4.Text = loandetails.Personal_Processing_Fees;
                        lblEducation1.Text = loandetails.Education_Interest_Rate;
                        lblEducation2.Text = loandetails.Education_Loan_Type;
                        lblEducation3.Text = loandetails.Education_Loan_Amount;
                        lblEducation4.Text = loandetails.Education_Concession;
                        lblHome1.Text = loandetails.Home_InterestRate_1;
                        lblHome2.Text = loandetails.Home_InterestRate_2;
                        lblHome3.Text = loandetails.Home_InterestRate_3;
                        lblHome4.Text = loandetails.Home_Processing_Fees;
                        lblGold1.Text = loandetails.Gold_Min_Loan;
                        lblGold2.Text = loandetails.Gold_Max_Loan;
                        lblGold3.Text = loandetails.Gold_Margin;
                        lblGold4.Text = loandetails.Gold_Processing_Fees;
                        lblClient.Text = loandetails.Clients;
                        lblLoanApproved.Text = loandetails.Loan_Approved;
                        lblHoursSupport.Text = loandetails.Hours_Support;
                        lblHardWorkers.Text = loandetails.Hard_Workers;
                        lblTrustyContactLocation.Text = loandetails.Trusty_City;
                        lblTrustyContactMail.Text = loandetails.Trusty_Mail;
                        lblTrustyContactPhone.Text = loandetails.Trusty_Phone;
                        lblTrustyCity.Text = loandetails.Trusty_City;
                        lblTrustyState.Text = loandetails.Trusty_State;
                        lblTrustyCountry.Text = loandetails.Trusty_Country;
                        lblTrustyPhone.Text = loandetails.Trusty_Phone;
                        lblTrustyMail.Text = loandetails.Trusty_Mail;

                    Session["Personal_Rate"] = loandetails.Personal_Interest_Rate;
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
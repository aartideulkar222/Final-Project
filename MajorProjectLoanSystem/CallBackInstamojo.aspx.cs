using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstamojoAPI;
using System.IO;
using System.Net;

namespace MajorProjectLoanSystem
{
    public partial class CallBackInstamojo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Insta_client_id = "test_rBoXQIrDJ5gyNu0AL4OMuEDXqdVPxb3hHd4";
            string Insta_client_secret = "test_NTnwuLRyMMHjjJ7p1EYH51bHdXepVlyXWS7prQIWf2Bglzy5Jmjr1oaasf1M1QF42DpprHaMLHz0eBKZpaujUjCwfn0wE7DSk9J5GTWRdTT4lLW7FaSv4YSTnIk";
            string Insta_Endpoint = InstamojoConstants.INSTAMOJO_API_ENDPOINT;
            string Insta_Auth_Endpoint = InstamojoConstants.INSTAMOJO_AUTH_ENDPOINT;

            Instamojo objClass = InstamojoImplementation.getApi(Insta_client_id, Insta_client_secret, Insta_Endpoint, Insta_Auth_Endpoint);
            DetailsofPayment(objClass);
        }

        private void DetailsofPayment(Instamojo objClass)
        {
            PaymentOrderDetailsResponse paymentOrderDetailsResponse = objClass.getPaymentOrderDetailsByTransactionId(Session["transID"].ToString());
            TxnId.Text = paymentOrderDetailsResponse.transaction_id;
            txtName.Text = paymentOrderDetailsResponse.name;
            txtAmount.Text = Convert.ToString(paymentOrderDetailsResponse.amount);
            h1Message.Text = paymentOrderDetailsResponse.status;
            date.Text = paymentOrderDetailsResponse.created_at;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("payment.aspx");
        }
    }
}
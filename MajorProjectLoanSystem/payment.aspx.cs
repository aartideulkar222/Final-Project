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
	public partial class payment : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["USER_ID"] != null)
			{
				txtOrder.Text = GenerateID();
			}
			else
			{
				Response.Redirect("Login.aspx");
			}
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			string Insta_client_id = "test_rBoXQIrDJ5gyNu0AL4OMuEDXqdVPxb3hHd4";
			string Insta_client_secret = "test_NTnwuLRyMMHjjJ7p1EYH51bHdXepVlyXWS7prQIWf2Bglzy5Jmjr1oaasf1M1QF42DpprHaMLHz0eBKZpaujUjCwfn0wE7DSk9J5GTWRdTT4lLW7FaSv4YSTnIk";
			string Insta_Endpoint = InstamojoConstants.INSTAMOJO_API_ENDPOINT;
			string Insta_Auth_Endpoint = InstamojoConstants.INSTAMOJO_AUTH_ENDPOINT;

			Instamojo objClass = InstamojoImplementation.getApi(Insta_client_id, Insta_client_secret, Insta_Endpoint, Insta_Auth_Endpoint);
			CreatePaymentOrder(objClass);
		}

		private void CreatePaymentOrder(Instamojo objClass)
		{
			PaymentOrder objPaymentRequest = new PaymentOrder();
			//Required POST parameters
			objPaymentRequest.name = txtName.Text;
			objPaymentRequest.email = txtEmail.Text;
			objPaymentRequest.phone = txtMobileNumber.Text;
			objPaymentRequest.description = "Test description";
			objPaymentRequest.amount = Convert.ToInt32(txtAmount.Text);
			objPaymentRequest.currency = "INR";

			string randomName = Path.GetRandomFileName();
			randomName = randomName.Replace(".", string.Empty);
			objPaymentRequest.transaction_id = "test" + randomName;

			Session["transID"] = objPaymentRequest.transaction_id;

			objPaymentRequest.redirect_url = "https://localhost:44337/CallBackInstamojo.aspx";
			//Extra POST parameters 

			if (objPaymentRequest.validate())
			{
				if (objPaymentRequest.emailInvalid)
				{
					Response.Write("Email is not valid");
				}
				if (objPaymentRequest.nameInvalid)
				{
					Response.Write("Name is not valid");
				}
				if (objPaymentRequest.phoneInvalid)
				{
					Response.Write("Phone is not valid");
				}
				if (objPaymentRequest.amountInvalid)
				{
					Response.Write("Amount is not valid");
				}
				if (objPaymentRequest.currencyInvalid)
				{
					Response.Write("Currency is not valid");
				}
				if (objPaymentRequest.transactionIdInvalid)
				{
					Response.Write("Transaction Id is not valid");
				}
				if (objPaymentRequest.redirectUrlInvalid)
				{
					Response.Write("Redirect Url Id is not valid");
				}
				if (objPaymentRequest.webhookUrlInvalid)
				{
					Response.Write("Webhook URL is not valid");
				}

			}
			else
			{
				try
				{
					CreatePaymentOrderResponse objPaymentResponse = objClass.createNewPaymentRequest(objPaymentRequest);
					Response.Redirect(objPaymentResponse.payment_options.payment_url);
				}
				catch (ArgumentNullException ex)
				{
					Response.Write(ex.Message);
				}
				catch (WebException ex)
				{
					Response.Write(ex.Message);
				}
				catch (IOException ex)
				{
					Response.Write(ex.Message);
				}
				catch (InvalidPaymentOrderException ex)
				{
					if (!ex.IsWebhookValid())
					{
						Response.Write("Webhook is invalid");
					}

					if (!ex.IsCurrencyValid())
					{
						Response.Write("Currency is Invalid");
					}

					if (!ex.IsTransactionIDValid())
					{
						Response.Write("Transaction ID is Inavlid");
					}
				}
				catch (ConnectionException ex)
				{
					Response.Write(ex.Message);
				}
				catch (BaseException ex)
				{
					Response.Write(ex.Message);
				}
				catch (Exception ex)
				{
					Response.Write("Error:" + ex.Message);
				}
			}
		}

		//Order ID Generator
		public string GenerateID()
		{
			string format = "Mddyyyyhhmmss";
			string datename = String.Format("{0}", DateTime.Now.ToString(format));

			Random ran = new Random();

			string PersID = "LT" + ran.Next(100, 999) + datename;

			return PersID;
		}
	}
}
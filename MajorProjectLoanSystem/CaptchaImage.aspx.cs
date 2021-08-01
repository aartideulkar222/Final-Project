using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SRVTextToImage;
using System.Drawing;
using System.Drawing.Imaging;

namespace MajorProjectLoanSystem
{
    public partial class CaptchaImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Captcha_Generating_Method();
        }

        public void Captcha_Generating_Method()
        {
            CaptchaRandomImage CI = new CaptchaRandomImage();
            // GetRandomString Function return random text of your provided characters size
            string captchaText = CI.GetRandomString(4);

            //GenearteImage  function return image of the provided text of provided size
            //CI.GenerateImage(captchaText, 200, 50);
            //there is a overload function available for set color of the image
            Session["CaptchaText"] = captchaText;
            CI.GenerateImage(captchaText, 200, 50, Color.Blue, Color.AliceBlue);

            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";
            CI.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);
            CI.Dispose();
        }
    }
}
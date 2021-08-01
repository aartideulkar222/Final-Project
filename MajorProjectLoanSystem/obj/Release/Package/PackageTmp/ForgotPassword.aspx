<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="MajorProjectLoanSystem.ForgotPassword" %>

<!DOCTYPE html>

<html lang="en" dir="ltr">
<head>
    <meta charset="utf-8">
    <!-- Main Stylesheet File -->
    <link href="css/style7.css" rel="stylesheet">
    <link href="css/style5.css" rel="stylesheet">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js" type="text/javascript"></script>
    <script>
        function successAlert() {

            swal({
                title: "Great Job!",
                text: "Check your email to reset your password!",
                type: "success"
            }).then(function () {
                window.location = "Login.aspx";
            });
        }

        function oopsAlert() {
            swal(

                'Oops...!',
                "Account using this Email ID does not Exist",
                'warning'


            )
        }

        function errorAlert() {
            swal(

                'Oops...!',
                'Something went wrong!',
                'error'

            )
        }
    </script>
</head>
<body>
    <!--==========================
      Forgot Password  Section
    ============================-->
    <div class="wrapper">
        <div class="logo float-left">
            <a href="http://document.somee.com/HomePage.aspx"><img src="img/logo.png" alt="" class="img-fluid"></a>
        </div>
        <div class="title-text">
            <div class="title login">
                Forgot Password
            </div>
        </div>
        <div class="form-container">
            <div class="form-inner">
                <form class="login" runat="server">
                    <div class="field">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Mail ID" ControlToValidate="txtEmailId" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                        <asp:TextBox ID="txtEmailId" placeholder="Enter Email Address" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Mail ID" ControlToValidate="txtEmailId" Font-Size="Small" ForeColor="Red" SetFocusOnError="True">Please Enter Mail ID</asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <br />
                    <div class="field btn">
                        <div class="btn-layer">
                        </div>
                        
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        
                    </div>
                </form>
            </div>
        </div>
    </div>

    <script>
        const loginText = document.querySelector(".title-text .login");
        const loginForm = document.querySelector("form.login");
        const loginBtn = document.querySelector("label.login");
        const signupBtn = document.querySelector("label.signup");
        const signupLink = document.querySelector("form .signup-link a");
        signupBtn.onclick = (() => {
            loginForm.style.marginLeft = "-50%";
            loginText.style.marginLeft = "-50%";
        });
        loginBtn.onclick = (() => {
            loginForm.style.marginLeft = "0%";
            loginText.style.marginLeft = "0%";
        });
        signupLink.onclick = (() => {
            signupBtn.click();
            return false;
        });
    </script>

</body>
</html>




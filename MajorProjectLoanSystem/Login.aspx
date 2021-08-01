<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MajorProjectLoanSystem.LoginSignup" %>

<!DOCTYPE html>

<html lang="en" dir="ltr">
<head>
    <meta charset="utf-8">
    <!-- Main Stylesheet File -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js" type="text/javascript"></script>
    <script>
        function oopsAlert() {
            swal(

                'Oops...!',
                'Invalid Username or Password',
                'warning'

            )
        }

        function errorAlert() {
            swal(

                'Oops...!',
                'Please Try again Later',
                'warning'

            )
        }
    </script>
    <link href="css/style7.css" rel="stylesheet">
</head>
<body>
    <!--==========================
      Login and Signup  Section
    ============================-->
    <div class="wrapper">
        <div class="logo float-left">
            <a href="HomePage.aspx"><img src="img/logo.png" alt="" class="img-fluid"></a>
        </div>
        <div class="title-text">
            <div class="title login">
                Login Form
            </div>
            <div class="title signup">
                Login Form
            </div>
        </div>
        <div class="form-container">
           <div>
            <div class="form-inner">
                <form action="#" class="login" runat="server">
                    <div class="field">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Invalid Data" ControlToValidate="txtEmailId" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid ID" ControlToValidate="txtEmailId" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtEmailId" placeholder="Email Address" runat="server"></asp:TextBox>
                    </div>
                    <div class="field">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Invalid Data" ControlToValidate="txtPassword" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPassword" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <div class="pass-link">
                        <a href="ForgotPassword.aspx">Forgot password?</a>
                    </div>
                    <div class="field btn">
                        <div class="btn-layer">
                        </div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Login" OnClick="btnSubmit_Click" />
                    </div>
                    <div class="signup-link">
                        Not a member? <a href="Signup.aspx">Signup now</a>
                    </div>
                </form>
            </div>
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


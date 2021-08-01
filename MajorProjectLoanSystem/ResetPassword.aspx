<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="MajorProjectLoanSystem.ResetPassword" %>

<!DOCTYPE html>

<html lang="en" dir="ltr">
<head>
    <meta charset="utf-8">
    <!-- Main Stylesheet File -->
    <link href="css/style7.css" rel="stylesheet">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js" type="text/javascript"></script>
    <script>
        function successAlert() {

            swal({
                title: "Great Job!",
                text: "Password Reset Successfull!",
                icon: "success",
                type: "success"
            }).then(function () {
                window.location = "Login.aspx";
            });
        }

        function oopsAlert() {
            swal(

                'Oops...!',
                "Something went Wrong!",
                'warning'

            )
        }

        function msgAlert() {
            swal(

                'Oops...!',
                "msg",
                'warning'


            )
        }

        function msgsAlert() {
            swal(

                'Oops...!',
                "msgssss",
                'warning'


            )
        }

        function errorAlert() {
            swal(

                'Oops...!',
                'Try Again Later',
                'error'

            )
        }
    </script>
</head>
<body>
    <!--==========================
      Reset Password  Section
    ============================-->
    <div class="wrapper">
        <div class="logo float-left">
            &nbsp;<a href="HomePage.aspx"><img src="img/logo.png" alt="" class="img-fluid"></a></div>
        <div class="title-text">
            <div class="title login">
                Reset Password
            </div>
        </div>
        <div class="form-container">
            <div class="form-inner">
                <form class="login" runat="server">
                    <div class="field">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Invalid Password" ControlToValidate="txtNewPassword" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNewPassword" placeholder="New Password" runat="server" TextMode="Password"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Invalid Password" ControlToValidate="txtConfirmPassword" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtConfirmPassword" placeholder="Confirm New Password" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password does not match" ControlToValidate="txtConfirmPassword" ControlToCompare="txtNewpassword" ForeColor="Red" SetFocusOnError="True" Font-Size="Small"></asp:CompareValidator>
                        <br />
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="field btn">
                        <div class="btn-layer">
                        </div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
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



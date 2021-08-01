<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="MajorProjectLoanSystem.Signup" %>

<!DOCTYPE html>

<html lang="en" dir="ltr">
<head>
    <meta charset="utf-8">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />
    <link href="https://fonts.googleapis.com/css?family=Raleway:100,200,300,400,500,600,700,800&display=swap" rel="stylesheet"/>

    <!-- Main Stylesheet File -->
    <link href="css/StyleSheet7.css" rel="stylesheet">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js" type="text/javascript"></script>
    <script>
        function successAlert() {

            swal({
                title: "Great Job!",
                text: "Account Created Successfully",
                icon: "success",
                type: "success"
            }).then(function () {
                window.location = "Login.aspx";
            });
        }

        function oopsAlert() {
            swal(

                'Oops...!',
                'This Email Id is not valid',
                'warning'

            )
        }

        function panAlert() {
            swal(

                'Oops...!',
                'Invalid PAN Number or Last Name',
                'warning'

            )
        }

        function captchaAlert() {
            swal(

                'Oops...!',
                'Please Enter same Text as in Image',
                'warning'

            )
        }

        function infoAlert() {
            swal(

                'Oops...!',
                'Account using this Email Id already exist',
                'info'

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
    <script type="text/javascript"> 
        window.history.forward();
        function noBack() {
            window.history.forward();
        }
    </script>
</head>
<body>
    <!--==========================
      Signup  Section
    ============================-->
    <div class="wrapper">
        <div class="logo">
            <a href="HomePage.aspx"><img src="img/logo.png" alt="" class="img-fluid"></a>
        </div>
        <div class="title-text">
            <div class="title login">
                Signup Form
            </div>
        </div>
        <div class="form-container">
            <div class="form-inner">
                <form action="#" class="signup" runat="server">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="field fi">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Invalid Data" ControlToValidate="txtFirstName" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtFirstName" placeholder="First Name" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="field fi">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Invalid Data" ControlToValidate="txtLastName" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtLastName" placeholder="Last Name" runat="server"></asp:TextBox>
                            </div>
                        </div>
                     </div>
                    <div class="field">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Invalid Data" ControlToValidate="txtPan" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid PAN" ControlToValidate="txtPan" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtPan" style="text-transform: uppercase;" placeholder="PAN Number" runat="server"></asp:TextBox>
                    </div>
                    <div class="field">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Invalid Data" ControlToValidate="txtEmailId" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email" ControlToValidate="txtEmailId" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtEmailId" placeholder="Email Address" runat="server"></asp:TextBox>
                    </div>
                    <div class="field">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Invalid Data" ControlToValidate="txtContact" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter 10 digit Mobile Number" ControlToValidate="txtContact" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtContact" placeholder="Mobile Number" runat="server"></asp:TextBox>
                    </div>
                    <div class="field">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Invalid Data" ControlToValidate="txtPassword" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPassword" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <div class="field">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Invalid Data" ControlToValidate="txtConfirmPassword" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtConfirmPassword" placeholder="Confirm password" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password does not match" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ForeColor="Red" SetFocusOnError="True" Font-Size="Small"></asp:CompareValidator>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-12">
                            <div class="field">
                                <asp:Image ID="Image1" BorderStyle="Ridge" ToolTip="Captcha Image" style="border-radius: 5px 5px;" runat="server" ImageUrl="CaptchaImage.aspx"/>
                            </div>
                        </div>
                     </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="field">
                                <asp:TextBox ID="txtCaptchaText" placeholder="Enter Text in Image" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Invalid Text" ControlToValidate="txtCaptchaText" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                     </div>

                    <div class="field btn" >
                        <div class="btn-layer">
                        </div>
                        <asp:Button ID="btnSubmit"  runat="server" Text="Signup" OnClick="btnSubmit_Click" />
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


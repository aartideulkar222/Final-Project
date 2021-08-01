<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="MajorProjectLoanSystem.payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

        <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="keywords" />
    <meta content="" name="description" />

    <!-- Favicons -->
    <link href="img/favicon.png" rel="icon" />
    <link href="img/apple-touch-icon.png" rel="apple-touch-icon" />

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,700,700i|Montserrat:300,400,500,700" rel="stylesheet" />

    <!-- Bootstrap CSS File -->
    <link href="lib/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Libraries CSS Files -->
    <link href="lib/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="lib/animate/animate.min.css" rel="stylesheet" />
    <link href="lib/ionicons/css/ionicons.min.css" rel="stylesheet" />
    <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet" />
    <link href="lib/lightbox/css/lightbox.min.css" rel="stylesheet" />

    <!-- Main Stylesheet File -->
    <link href="css/style1.css" rel="stylesheet">
    <link href="css/style2.css" rel="stylesheet" />
    <link href="css/style4.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous" />
    <link href="https://fonts.googleapis.com/css?family=Raleway:100,200,300,400,500,600,700,800&display=swap" rel="stylesheet"/>

    <title>EMI Payment</title>
</head>
<body>

   <!--==========================
    Header
    ============================-->
    <header id="header" class="fixed-top">
        <div class="container">

            <div class="logo float-left">
                <a href="LoanHomePage.aspx" class="scrollto"><img src="img/logo.png" alt="" class="img-fluid"></a>
            </div>

            <nav class="main-nav float-right d-none d-lg-block">
                <ul>
                    <li class="drop-down">
                        <a href="#" class="login-btn" style="margin-top:0px;"><asp:Label ID="lblProfileId" runat="server" Text="User Profile"></asp:Label></a>
                        <ul>
                            <li><a href="LoanHomePage.aspx">Home</a></li>
                            <li><a href="HomePage.aspx">Sign out</a></li>
                        </ul>
                    </li>
               </ul>
            </nav><!-- .main-nav -->
        </div>
     </header><!-- #header -->
     <br />
     <br />

    <form id="form1" runat="server">

        <div class="card" style="width: 100%;border-color: white;">
         
             <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>Loan Trusty EMI Payment</h3>
                        </div>
                    </div>
                </div><br />

                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-2">
                        <br />
                        <label>Order ID :</label>
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txtOrder" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="txtOrder" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="col-md-5"></div>
                </div>

                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-2">
                        <br />
                        <label>Name :</label>
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txtName" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="txtName" placeholder="Enter Name" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-5"></div>
                </div>

                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-2">
                        <br />
                        <label>Mobile :</label>
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txtMobileNumber" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txtMobileNumber" Font-Size="Small" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                        <br />
                        <asp:TextBox ID="txtMobileNumber" placeholder="10 Digit Mobile Number" TextMode="Number"  runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-5"></div>
                </div>

                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-2">
                        <br />
                        <label>Email ID :</label>
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txtEmail" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"></asp:RegularExpressionValidator>
                        <br />
                        <asp:TextBox ID="txtEmail" placeholder="Enter Mail Id" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-5"></div>
                </div>

                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-2">
                        <br />
                        <label>Amount :</label>
                    </div>
                    <div class="col-md-4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txtAmount" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="txtAmount" TextMode="Number" placeholder="Enter Payable Amount" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-5"></div>
                </div>

                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-2"></div>
                    <div class="col-md-4">
                        <br />
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Paynow" BackColor="#0D86E7" ForeColor="White" Height="50px" Width="148px" />
                    </div>
                    <div class="col-md-5"></div>
                </div>
           </div>
        </div>

    </form>
</body>
</html>

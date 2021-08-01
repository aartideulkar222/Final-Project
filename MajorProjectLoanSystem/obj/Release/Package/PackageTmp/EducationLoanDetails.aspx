<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EducationLoanDetails.aspx.cs" Inherits="MajorProjectLoanSystem.EducationLoanDetails" %>

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
    <title>Education Loan</title>
    <style type="text/css">
        .auto-style1 {
            width: 188px;
            height: 215px;
        }
        .auto-style3 {
            width: 257px;
            height: 149px;
            border: 1px solid #dee2e6;
        }
    </style>
</head>
<body>

   <!--==========================
    Header
    ============================-->
    <header id="header" class="fixed-top">
        <div class="container">

            <div class="logo float-left">
                <a href="http://document.somee.com/LoanHomePage.aspx" class="scrollto"><img src="img/logo.png" alt="" class="img-fluid"></a>
            </div>

            <nav class="main-nav float-right d-none d-lg-block">
                <ul>
                    <li class="drop-down">
                        <a href="#" class="login-btn" style="margin-top:0px;"><asp:Label ID="lblProfileId" runat="server" Text="User Profile"></asp:Label></a>
                        <ul>
                            <li><a href="LoanHomePage.aspx">Home</a></li>
                            <li><a href="Profile.aspx">Edit Profile</a></li>
                            <li><a href="HomePage.aspx">Sign out</a></li>
                        </ul>
                    </li>
               </ul>
            </nav><!-- .main-nav -->
        </div>
    </header><!-- #header -->
     <br />
     <br />

    <!-- Form -->
    <form id="EducationLoanDetailsPage" runat="server">

    <!--==========================
     1. Profile  Section
    ============================-->
     <div class="card" style="width: 100%; ">
         
             <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>1. Personal Details</h3>
                        </div>
                    </div>
                </div><br />

                <div class="row">
                    <div class="col-md-2">
                        <br />
                        <label>Applicant Name :</label>
                    </div>
                    <div class="col-md-3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1ApplicantFirst" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="txt1ApplicantFirst" runat="server" class="form-control"  placeholder="First Name"  ></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1ApplicantMiddle" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="txt1ApplicantMiddle" runat="server" class="form-control"  placeholder="Middle Name" ></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1ApplicantLast" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="txt1ApplicantLast" runat="server" class="form-control"  placeholder="Last Name"  ></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <br />
                        <label>Father/Spous Name :</label>
                    </div>
                    <div class="col-md-3">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1FatherFirst" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                       <br />
                       <asp:TextBox ID="txt1FatherFirst" runat="server" class="form-control"  placeholder="First Name"  ></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1FatherMiddle" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="txt1FatherMiddle" runat="server" class="form-control"  placeholder="Middle Name"  ></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1FatherLast" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="txt1FatherLast" runat="server" class="form-control"  placeholder="Last Name"  ></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <br />
                        <label>Mother Name :</label>
                    </div>
                    <div class="col-md-3">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1MotherFirst" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                       <asp:TextBox ID="txt1MotherFirst" runat="server" class="form-control"  placeholder="First Name"  ></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1MotherMiddle" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="txt1MotherMiddle" runat="server" class="form-control"  placeholder="Middle Name"  ></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1MotherLast" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:TextBox ID="txt1MotherLast" runat="server" class="form-control"  placeholder="Last Name"  ></asp:TextBox>
                    </div>
                </div><br/>

              
                <div class="row">
                    <div class="col-md-4">
                        <label>Status :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator110" InitialValue="Choose..." runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ControlToValidate="ddl1Status"></asp:RequiredFieldValidator>
                        <br />
                        <asp:DropDownList ID="ddl1Status" runat="server" class="form-control">
                            <asp:ListItem >Choose...</asp:ListItem>
                            <asp:ListItem>Resident Indivisual</asp:ListItem>
                            <asp:ListItem>Non Resident India</asp:ListItem>
                            <asp:ListItem>Foreign National</asp:ListItem>
                            <asp:ListItem>Person Of Indian Origin</asp:ListItem>
                            <asp:ListItem>OCI</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-4">
                        <label>PAN Number :</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator111" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1PAN" ForeColor="Red" Font-Size="Small" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt1PAN" Font-Size="Small" ForeColor="Red" ValidationExpression="^([a-zA-Z]){5}([0-9]){4}([a-zA-Z]){1}?$" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        <br />
                        <asp:TextBox ID="txt1PAN" runat="server" class="form-control" style="text-transform: uppercase;" placeholder="PAN Number" ></asp:TextBox>
                    </div>
                </div><br/>

                <!--==>>>>>>>>>   proof of identity   <<<<<<<=====-->
                <div class="row">
                    <div class="col-md-4">
                        <label>Select any Document :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator112" InitialValue="Choose..." runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ControlToValidate="ddl1Document"></asp:RequiredFieldValidator>

                        <asp:DropDownList ID="ddl1Document" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Passport No.</asp:ListItem>
                                <asp:ListItem>Voter ID Card</asp:ListItem>
                                <asp:ListItem>Driving Licence</asp:ListItem>
                                <asp:ListItem>NREGA Job Card</asp:ListItem>
                                <asp:ListItem>Aadhar Number</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-md-4">
                        <!--document number-->
                        <label>Enter Document Number :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator113" runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ControlToValidate="txt1Document"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt1Document" class="form-control" placeholder="enter card number" runat="server"></asp:TextBox><br />
                    </div>
                    <div class="col-md-4">
                        <label>Expiry of Proof : </label> <i>(if Applicable)</i>
                        <asp:TextBox ID="txt1Expiry" class="form-control" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date"  placeholder="YYYY-MM-DD" runat="server" ></asp:TextBox>
                    </div>
                  </div>
                  <br />

                 <div class="row">
                    <div class="col-md-4">
                        <label>CKYC No. :(if available)</label>
                        <asp:TextBox ID="txt1CKYC" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label>Date of Birth :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator114" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1DOB" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                        <asp:TextBox ID="txt1DOB" class="form-control" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date" placeholder="YYYY-MM-DD" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label>Gender : </label><asp:RequiredFieldValidator ID="RequiredFieldValidator115" InitialValue="Choose..." runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="ddl1Gender" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddl1Gender" runat="server" class="form-control">
                            <asp:ListItem  Value="Choose...">Choose...</asp:ListItem>
                            <asp:ListItem Value="Male">Male</asp:ListItem>
                            <asp:ListItem Value="Female">Female</asp:ListItem>
                            <asp:ListItem Value="Other">Other</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div><br />

                 
                <div class="row">
                    <div class="col-md-4">
                        <label>Nationality :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator116" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1Nationality" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt1Nationality" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                         <label>Community :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator117" InitialValue="Choose..." runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ControlToValidate="ddl1Community"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddl1Community" runat="server" class="form-control">
                            <asp:ListItem >Choose...</asp:ListItem>
                            <asp:ListItem>Hindu</asp:ListItem>
                            <asp:ListItem>Muslim</asp:ListItem>
                            <asp:ListItem>Sikh</asp:ListItem>
                            <asp:ListItem>Jain</asp:ListItem>
                            <asp:ListItem>Parsi</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txt1Community" placeholder="mention if 'Other'" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                         <label>Category :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator118" InitialValue="Choose..." runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ControlToValidate="ddl1Category"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddl1Category" runat="server" class="form-control">
                            <asp:ListItem >Choose...</asp:ListItem>
                            <asp:ListItem>SC</asp:ListItem>
                            <asp:ListItem>ST</asp:ListItem>
                            <asp:ListItem>OBC</asp:ListItem>
                            <asp:ListItem>General</asp:ListItem>
                            <asp:ListItem>Minority</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtCategory" placeholder="mention if 'Other'" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div><br />    
                  

                <div class="row">
                   <div class="col-md-4">
                    <label dir="ltr">Personal with Disability :</label>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator119" InitialValue="Choose..." runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ControlToValidate="ddl1Disability"></asp:RequiredFieldValidator>  
                       <asp:DropDownList ID="ddl1Disability" runat="server" class="form-control">
                            <asp:ListItem >Choose...</asp:ListItem>
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList> 
                   </div>
                   
                      <div class="col-md-4">
                         <label>Education :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator120" InitialValue="Choose..." runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ControlToValidate="ddl1Education"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddl1Education" runat="server" class="form-control">
                            <asp:ListItem >Choose...</asp:ListItem>
                            <asp:ListItem>Matriculate</asp:ListItem>
                            <asp:ListItem>Undergraduate</asp:ListItem>
                            <asp:ListItem>Graduate</asp:ListItem>
                            <asp:ListItem>Postgraduate</asp:ListItem>
                            <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txt1Education" placeholder="mention if 'Other'" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div><br />

                 <div class="row">
                    <!--marital status-->
                    <div class="col-md-4">
                        <label>Marital Status : </label><asp:RequiredFieldValidator ID="RequiredFieldValidator121" InitialValue="Choose..." runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="ddl1Marital" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddl1Marital" runat="server" class="form-control">
                            <asp:ListItem>Choose...</asp:ListItem>
                            <asp:ListItem Value="Married">Married</asp:ListItem>
                            <asp:ListItem Value="Unmaried">Unmarried</asp:ListItem>
                            <asp:ListItem Value="Other">Other</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <label>No. of Dependents : </label><asp:RequiredFieldValidator ID="RequiredFieldValidator122" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1Dependents" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt1Dependents" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    </div><br />

                <div class="row">
                    <div class="col-md-4">
                        <label>Email ID (Personal):</label><asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txt1PersonalEmail"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator123" runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ControlToValidate="txt1PersonalEmail"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt1PersonalEmail" class="form-control" runat="server"></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-md-4">
                        <label>Email ID (Official):</label><asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txt1OfficialEmail"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txt1OfficialEmail" class="form-control" runat="server"></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-md-4">
                        <label>Telephone No(if available) :</label><asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt1Telephone" Font-Size="Small" ForeColor="Red" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txt1Telephone" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <label>Mobile No :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator124" runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ControlToValidate="txt1Mobile"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt1Mobile" Font-Size="Small" ForeColor="Red" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txt1Mobile" class="form-control" runat="server"></asp:TextBox>
                    </div>
               </div><br />

                    
                <!--address details-->
                <label><u>Present Address :</u></label>
                <div class="row">
                    <div class="col-md-4">
                        <label>Address :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator125" runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ControlToValidate="txt1PresentAddress"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt1PresentAddress" class="form-control" runat="server" TextMode="MultiLine" ></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-md-4">
                         <label>Landmark :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator126" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1PresentLandmark" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt1PresentLandmark" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                         <label>Postal Code :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator127" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1PresentPostal" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt1PresentPostal" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txt1PresentPostal" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                         <label>City/Town :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator128" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1PresentCity" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt1PresentCity" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                         <label>State :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator129" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1PresentState" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt1PresentState" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div><br />

                <label><u>Permanent Address :</u></label>
                <div class="row">
                    <div class="col-md-4">
                        <label>Address :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator135" runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ControlToValidate="txt1PermanentAddress"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt1PermanentAddress" class="form-control" runat="server" TextMode="MultiLine" ></asp:TextBox>
                        <br />
                    </div>
                    <div class="col-md-4">
                         <label>Landmark :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator136" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1PermanentCity" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt1PermanentLandmark" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                         <label>Postal Code :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator137" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1PermanentPostal" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt1PermanentPostal" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\d{6}"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txt1PermanentPostal" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                         <label>City/Town :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator138" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1PermanentCity" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt1PermanentCity" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                         <label>State :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator139" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt1PermanentState" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt1PermanentState" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div><br />
           </div>
  </div>
    
    <!--==========================
      2. GSTIN  Section
    ============================-->
     <div class="card" style="width: 100%; ">
         <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>2. GST Details</h3>
                        </div>
                    </div>
                </div><br />

                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="Label1" runat="server" Text="Whether registration under GST"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl21UnderGst" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddl21UnderGst" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label2" runat="server" Text="GST Exemption"></asp:Label>
                        <asp:DropDownList ID="ddl22GstExemption" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label3" runat="server" Text="Exemption Reason (If Yes)"></asp:Label>
                        <asp:TextBox ID="txt2ExemptionReason" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div><br />

                 <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="Label4" runat="server" Text="Exemption Valid till (if yes)"></asp:Label>
                        <asp:TextBox ID="txt2ExemptionValid" class="form-control" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date"  placeholder="YYYY-MM-DD" runat="server" ></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label5" runat="server" Text="GSTIN Registration Date"></asp:Label>
                        <asp:TextBox ID="txt2GstinDate" class="form-control" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date"  placeholder="YYYY-MM-DD" runat="server" ></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label6" runat="server" Text="GST Registration Type"></asp:Label>
                        <asp:DropDownList ID="ddl2GstType" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Single</asp:ListItem>
                                <asp:ListItem>Multiple</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div><br />

                 <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="Label7" runat="server" Text="Special Economic Zone"></asp:Label>
                        <asp:TextBox ID="txt2GstZone" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label8" runat="server" Text="GSTIN Default"></asp:Label>
                        <asp:TextBox ID="txt2GstinDefault" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label9" runat="server" Text="Address registered for GSTIN"></asp:Label>
                        <asp:TextBox ID="txt2GstinAddress" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div><br />

                 <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="Label10" runat="server" Text="Pin"></asp:Label>
                        <asp:TextBox ID="txt2Pin" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label11" runat="server" Text="City"></asp:Label>
                        <asp:TextBox ID="txt2City" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label12" runat="server" Text="State"></asp:Label>
                        <asp:TextBox ID="txt2State" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div><br />

                 <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="Label13" runat="server" Text="Country"></asp:Label>
                        <asp:TextBox ID="txt2Country" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
           </div><br />
  </div>

    <!--==========================
      3. NRI  Section
    ============================-->
    <div class="card" style="width: 100%; ">
         <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>3. NRI Details&nbsp;&nbsp;&nbsp;&nbsp; (fill if appliacble)</h3>
                        </div>
                    </div>
                </div><br />

                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="Label14" runat="server" Text="Country"></asp:Label>
                        <asp:TextBox ID="txt3CountryName" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label15" runat="server" Text="Country Code"></asp:Label>
                        <asp:TextBox ID="txt3CountryCode" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label16" runat="server" Text="If applicant resident for tax purposes in Jurisdiction outside India:"></asp:Label>
                        <asp:DropDownList ID="ddl31TaxOutsideIndia" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div><br />

                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="Label17" runat="server" Text="Jurisdiction of residence"></asp:Label>
                        <asp:TextBox ID="txt3JurisdictionResidence" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label18" runat="server" Text="Tax Identification Number or equivalent (If issued by jurisdiction)"></asp:Label>
                        <asp:TextBox ID="txt3Tin" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label19" runat="server" Text="Country of Birth"></asp:Label>
                        <asp:TextBox ID="txt3BirthCountry" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div><br />

                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="Label20" runat="server" Text="City of Birth"></asp:Label>
                        <asp:TextBox ID="txt3BirthCity" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label21" runat="server" Text="Address in Jurisdiction"></asp:Label>
                        <asp:TextBox ID="txt3JurisdictionAddress" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label22" runat="server" Text="City"></asp:Label>
                        <asp:TextBox ID="txt3JurisdictionCity" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div><br />

                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="Label23" runat="server" Text="State"></asp:Label>
                        <asp:TextBox ID="txt3JurisdictionState" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label24" runat="server" Text="ZIP/Post Code"></asp:Label>
                        <asp:TextBox ID="txt3PostCode" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label25" runat="server" Text="ISO 3166 Country Code "></asp:Label>
                        <asp:TextBox ID="txt3IsoCode" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div><br />
           </div>
  </div>

    <!--==========================
      4. Education & Course  Section
    ============================-->
    <div class="card" style="width: 100%; ">
         <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>4. Education & Course Details</h3>
                        </div>
                    </div>
                </div><br />

                    <div class="row mb-2">
                        <div class="col-md-12">
                            <table class="table table-bordered table-responsive">
                                <thead>
                                    <tr>
                                        <th>Examination Passed </th>
                                        <th>Institution & University</th>
                                        <th>Year of Passing</th>
                                        <th>Percentage of marks</th>
                                        <th>Class Obtained</th>
                                        <th>Scholarship / Prizes won for Academic Distinction</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th>
                                            <br />
                                            10th

                                        </th>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4SscInstitute" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt4SscInstitute" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4SscYear" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt4SscYear" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4SscPercentage" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt4SscPercentage" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt4SscClassObtained" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt4SscScholarship" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th>
                                            <br />
                                            12th
                                        </th>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4HscInstitute" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt4HscInstitute" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4HscYear" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt4HscYear" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4HscPercentage" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt4HscPercentage" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt4HscClassObtained" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt4HscScholarship" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th>
                                            <br />
                                            Last Degree

                                        </th>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt4LdInstitute" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt4LdYear" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt4LdPercentage" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt4LdClassObtained" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt4LdScholarship" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div><br />

                    <div class="row mb-2">
                        <div class="col-md-4">
                            <label>GRE/GMAT/OTHER EXAM SCORE</label>
                            <asp:TextBox ID="txt4ExamScore" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-8">
                            <label>Name and Address of College / Institution in which the Student intends to Join.</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4CollegeAddress" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4CollegeAddress" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div><br />

                    <div class="row mb-2">
                        <div class="col-md-3">
                            <label>City</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4CollegeCity" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4CollegeCity" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>State</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4CollegeState" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4CollegeState" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>District</label>
                            <asp:TextBox ID="txt4CollegeDistrict" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>Pin Code</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4CollegePin" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4CollegePin" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div><br />

                    <div class="row mb-2">
                        <div class="col-md-3">
                            <label>Country</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4CollegeCountry" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4CollegeCountry" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>Admission Status</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="ddl4AdmissionStatus" ForeColor="Red" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl4AdmissionStatus" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Applied</asp:ListItem>
                                <asp:ListItem>Confirmed</asp:ListItem>
                                <asp:ListItem>Awaited</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                        </div>
                    </div><br />

                    <div class="row mb-2">
                        <div class="col-md-12">
                            <label>Name of the University / Recognised Authority to which the college / Institute is affiliated</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4UniversityName" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4UniversityName" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <hr />

                    <div class="row mb-2">
                        <div class="col-md-4">
                            <label>Contact person at the University</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4UniversityPerson" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4UniversityPerson" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Course applied for</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="ddl4CourseApplied" ForeColor="Red" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl4CourseApplied" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Management</asp:ListItem>
                                <asp:ListItem>Engineering</asp:ListItem>
                                <asp:ListItem>Medical</asp:ListItem>
                                <asp:ListItem>Architecture</asp:ListItem>
                                <asp:ListItem>Vocational</asp:ListItem>
                                <asp:ListItem>other</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label>if other please specify</label>
                            <asp:TextBox ID="txt4CourseAppliedOther" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div><br />

                    <div class="row mb-2">
                        <div class="col-md-4">
                            <label>Course Name</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator410" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4CourseName" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4CourseName" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Course Approved by</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator411" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="ddl4CourseApproved" ForeColor="Red" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl4CourseApproved" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>UGC</asp:ListItem>
                                <asp:ListItem>Govt</asp:ListItem>
                                <asp:ListItem>AICTE</asp:ListItem>
                                <asp:ListItem>AIBMS</asp:ListItem>
                                <asp:ListItem>ICMR</asp:ListItem>
                                <asp:ListItem>Dept of Electronics</asp:ListItem>
                                <asp:ListItem>other</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label>if other please specify</label>
                            <asp:TextBox ID="txt4CourseApprovedOther" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div><br />

                    <div class="row mb-2">
                        <div class="col-md-6">
                            <label>Whether admission through Entrance/Merit based</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator412" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="ddl4AdmissionEntrance" ForeColor="Red" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator> 
                            <asp:DropDownList ID="ddl4AdmissionEntrance" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <label>Course Category</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator413" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="ddl4CourseCategory" ForeColor="Red" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl4CourseCategory" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Diploma</asp:ListItem>
                                <asp:ListItem>Under-graduate</asp:ListItem>
                                <asp:ListItem>Post-graduate</asp:ListItem>
                                <asp:ListItem>Other</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <label>if other please specify</label>
                            <asp:TextBox ID="txt4CourseCategoryOther" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div><br />

                    <div class="row mb-2">
                        <div class="col-md-4">
                            <label>Course Type</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator414" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="ddl4CourseType" ForeColor="Red" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl4CourseType" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Full Time</asp:ListItem>
                                <asp:ListItem>Part Time</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label>Course begins from</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator415" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4CourseStart" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4CourseStart" class="form-control" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date" placeholder="YYYY-MM-DD" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Course ends on</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator416" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4CourseEnd" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4CourseEnd" class="form-control" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date" placeholder="YYYY-MM-DD" runat="server"></asp:TextBox>
                        </div>
                    </div><br />

                    <div class="row mb-2">
                        <div class="col-md-6">
                            <label>Moratorium During course period (A)</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator417" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="ddl4A" ForeColor="Red" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl4A" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>18</asp:ListItem>
                                <asp:ListItem>24</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>36</asp:ListItem>
                                <asp:ListItem>42</asp:ListItem>
                                <asp:ListItem>48</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                            <label>Moratorium Post course period (B)</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator418" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="ddl4B" ForeColor="Red" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl4B" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div><br />

                    <div class="row mb-2">
                        <div class="col-md-5">
                            <label>Total Moratorium (C = A + B)</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator419" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="ddl4C" ForeColor="Red" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl4C" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>>6</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>18</asp:ListItem>
                                <asp:ListItem>24</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>36</asp:ListItem>
                                <asp:ListItem>42</asp:ListItem>
                                <asp:ListItem>48</asp:ListItem>
                                <asp:ListItem>54</asp:ListItem>
                                <asp:ListItem>60</asp:ListItem>
                                <asp:ListItem>other</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <label>if other please specify</label>
                            <asp:TextBox ID="txt4C" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Emi Repayment (D)</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator420" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="ddl4D" ForeColor="Red" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl4D" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>>6</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>24</asp:ListItem>
                                <asp:ListItem>36</asp:ListItem>
                                <asp:ListItem>48</asp:ListItem>
                                <asp:ListItem>60</asp:ListItem>
                                <asp:ListItem>72</asp:ListItem>
                                <asp:ListItem>84</asp:ListItem>
                                <asp:ListItem>96</asp:ListItem>
                                <asp:ListItem>108</asp:ListItem>
                                <asp:ListItem>120</asp:ListItem>
                                <asp:ListItem>132</asp:ListItem>
                                <asp:ListItem>144</asp:ListItem>
                                <asp:ListItem>156</asp:ListItem>
                                <asp:ListItem>168</asp:ListItem>
                                <asp:ListItem>180</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div><br />

                    <div class="row mb-2">
                        <div class="col-md-5">
                            <label>Total Loan Period (E=C+D)</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator421" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4E" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4E" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <label>Interest servicing during Moratorium Period</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator422" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="ddl4Servicing" ForeColor="Red" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl4Servicing" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem>No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div><br />

                    <div class="row mb-2">
                        <div class="col-md-6">
                            <label>Expected Future income per month</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator423" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4ExpectedIncome" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4ExpectedIncome" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div><br />

                    <div class="row mb-2">
                        <div class="col-md-4">
                            <label>College / Institute Name</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator424" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4InstituteName" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4InstituteName" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Course being pursued</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator425" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4CoursePursued" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4CoursePursued" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Course completion date</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator426" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt4CourseCompletion" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4CourseCompletion" class="form-control" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date" placeholder="YYYY-MM-DD" runat="server"></asp:TextBox>
                        </div>
                    </div><br />
           </div>
  </div>

    <!--==========================
      5. Loan Details  Section
    ============================-->
    <div class="card" style="width: 100%; ">
         <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>5. Loan Details</h3>
                        </div>
                    </div>
                </div><br />

                <div class="row mb-2">
                        <div class="col-md-12">
                            <table class="table table-bordered table-responsive">
                                <thead>
                                    <tr>
                                        <th>A) Cost of the Course Amount</th>
                                        <th>Amount</th>
                                        <th>B) Funds Available</th>
                                        <th>Amount</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th>1) Tuition Fees<asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt5TutionFees" Font-Bold="False" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></th>
                                        <td>

                                            <asp:TextBox ID="txt5TutionFees" class="form-control" runat="server" placeholder="enter amount"></asp:TextBox>
                                        </td>
                                        <th>1) Own Source<asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt5OwnSource" ForeColor="Red" SetFocusOnError="True" Font-Bold="False"></asp:RequiredFieldValidator></th>
                                        <td>

                                            <asp:TextBox ID="txt5OwnSource" class="form-control" runat="server" placeholder="enter amount"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>2) Living Expenses/Hostel and Food<asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt5LivingExpenses" Font-Bold="False" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></th>
                                        <td>

                                            <asp:TextBox ID="txt5LivingExpenses" class="form-control" runat="server" placeholder="enter amount"></asp:TextBox>
                                        </td>
                                        <th>2) Scholarship<asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt5Scholarship" ForeColor="Red" SetFocusOnError="True" Font-Bold="False"></asp:RequiredFieldValidator></th>
                                        <td>

                                            <asp:TextBox ID="txt5Scholarship" class="form-control" runat="server" placeholder="enter amount"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>3) Traveling Expenses<asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt5TravelingExpenses" Font-Bold="False" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></th>
                                        <td>

                                            <asp:TextBox ID="txt5TravelingExpenses" class="form-control" runat="server" placeholder="enter amount"></asp:TextBox>
                                        </td>
                                        <th>3) Others<asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt5Others" ForeColor="Red" SetFocusOnError="True" Font-Bold="False"></asp:RequiredFieldValidator></th>
                                        <td>

                                            <asp:TextBox ID="txt5Others" class="form-control" runat="server" placeholder="enter amount"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>4) Others<asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt5OtherExpenses" Font-Bold="False" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></th>
                                        <td>

                                            <asp:TextBox ID="txt5OtherExpenses" class="form-control" runat="server" placeholder="enter amount"></asp:TextBox>
                                        </td>
                                        <td>

                                        </td>
                                        <td>

                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Total<asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt5TotalExpenses" Font-Bold="False" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></th>
                                        <td>

                                            <asp:TextBox ID="txt5TotalExpenses" class="form-control" runat="server" placeholder="enter amount"></asp:TextBox>
                                        </td>
                                        <th>Total<asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt5TotalFundsAvailable" Font-Bold="False" ForeColor="Red"></asp:RequiredFieldValidator></th>
                                        <td>

                                            <asp:TextBox ID="txt5TotalFundsAvailable" class="form-control" runat="server" placeholder="enter amount"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <label>Loan Required (A-B)</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator510" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt5LoanRequired" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt5LoanRequired" class="form-control mb-2" runat="server"></asp:TextBox>

                                            <label>1) Disbursement Details</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator511" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="ddl5DisbursementDetails" ForeColor="Red" SetFocusOnError="True" InitialValue="Choose..."></asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="ddl5DisbursementDetails" runat="server" class="form-control mb-2">
                                                <asp:ListItem>Choose...</asp:ListItem>
                                                <asp:ListItem>a. Full</asp:ListItem>
                                                <asp:ListItem>b. Tranche</asp:ListItem>
                                            </asp:DropDownList>

                                            <label>2) Mode </label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator512" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="ddl5Mode" ForeColor="Red" SetFocusOnError="True" InitialValue="Choose..."></asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="ddl5Mode" runat="server" class="form-control mb-2">
                                                <asp:ListItem>Choose...</asp:ListItem>
                                                <asp:ListItem>a. DD</asp:ListItem>
                                                <asp:ListItem>b. RTGS</asp:ListItem>
                                                <asp:ListItem>c. Wire Trasfer</asp:ListItem>
                                                <asp:ListItem>others</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                <div class="row mb-2">
                        <div class="col-md-12">
                            <table class="table table-bordered table-responsive">
                                <thead>
                                    <tr>
                                        <th colspan="3">MODE OF DISBURSEMENT (any one of the following)</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th rowspan="3">1</th>
                                        <td>
                                            DD In favour of
                                        </td>
                                        <td>

                                            <asp:TextBox ID="txt5DdInFavour" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            payable at for
                                        </td>
                                        <td>

                                            <asp:TextBox ID="txt5Payable" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Amount
                                        </td>
                                        <td>

                                            <asp:TextBox ID="txt5Amount" class="form-control" runat="server" placeholder="enter amount"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th rowspan="2">2</th>
                                        <td>
                                             T.T. Swift Code 
                                        </td>
                                        <td>

                                            <asp:TextBox ID="txt5TtSwiftCode" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            University Account No
                                        </td>
                                        <td>

                                            <asp:TextBox ID="txt5UniversityAccount" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>3</th>
                                        <td>
                                            . RTGS/NEFT
                                        </td>
                                        <td>

                                            <asp:TextBox ID="txt5RtgsNeft" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        </div>
                    </div>   
                
                <div class="row mb-2">
                    <div class="col-md-6">
                        <label>University Account no.</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator513" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt5UniversityAccountNo" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt5UniversityAccountNo" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
           </div><br />
  </div>

    <!--==========================
      6. Employment / Business  Section
    ============================-->
    <div class="card" style="width: 100%; ">
         <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>6. Employment Details&nbsp;&nbsp;&nbsp;&nbsp; (fill if appliacble)</h3>
                        </div>
                    </div>
                </div><br />

                <div class="row mb-2">
                        <div class="col-md-4">
                            <label>Employment Type</label>

                            <asp:DropDownList ID="ddl6EmploymentType" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Salaried</asp:ListItem>
                                <asp:ListItem>Self-Employed</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label>Type of Organisation :</label>

                            <asp:DropDownList ID="ddl6OrganisationType" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Pvt. Ltd.</asp:ListItem>
                                <asp:ListItem>Public Ltd.</asp:ListItem>
                                <asp:ListItem>Partnership</asp:ListItem>
                                <asp:ListItem>Proprietorship</asp:ListItem>
                                <asp:ListItem>Other</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label>if other please specify</label>
                            <asp:TextBox ID="txt6OrganisationTypeOther" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                <div class="row mb-2">
                        <div class="col-md-6">
                            <label>Name of Current Employer / Business</label>

                            <asp:TextBox ID="txt6EmployerName" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label>Office address</label>

                            <asp:TextBox ID="txt6OfficeAddress" class="form-control" runat="server"></asp:TextBox>
                        </div>
                </div>

                <div class="row mb-2">
                        <div class="col-md-4">
                            <label>City</label>

                            <asp:TextBox ID="txt6City" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>State</label>

                            <asp:TextBox ID="txt6State" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Pin Code</label>

                            <asp:TextBox ID="txt6PinCode" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                <div class="row mb-2">
                        <div class="col-md-3">
                            <label>Telephone</label>

                            <asp:TextBox ID="txt6Telephone" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>Designation</label>

                            <asp:TextBox ID="txt6Designation" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label>Total no. of Years in Current Employment / Business</label>

                            <asp:TextBox ID="txt6EmploymentYears" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                
         </div>
     </div>

    <!--==========================
      7. Financial Details  Section
    ============================-->
    <div class="card" style="width: 100%; ">
         <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>7. Financial Details&nbsp;&nbsp;&nbsp;&nbsp; (fill if applicable)</h3>
                        </div>
                    </div>
                </div><br />

                <div class="row mb-2">
                        <div class="col-md-3">
                            <label>Employment Type</label>

                            <asp:DropDownList ID="ddl7EmploymentType" runat="server" class="form-control">
                            <asp:ListItem>Choose...</asp:ListItem>
                            <asp:ListItem Value="Salaried">Salaried</asp:ListItem>
                            <asp:ListItem Value="Self-Employed">Self-Employed</asp:ListItem>
                            </asp:DropDownList>
                        </div>   
               </div><br />
             
               <div class="row mb-2">
                        <div class="col-md-3">
                            <label>a. Gross Monthly Salary</label>

                            <asp:TextBox ID="txt7GrossIncome" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>b. Net Monthly Salary</label>

                            <asp:TextBox ID="txt7NetIncome" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>c. Other Income</label>

                            <asp:TextBox ID="txt7OtherIncome" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>d. Total Income (b+C)</label>

                            <asp:TextBox ID="txt7TotalIncome" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div><br />

               <div class="row mb-2">
                        <div class="col-md-4">
                            <label>Total Investment In Value :</label>

                            <asp:TextBox ID="txt7TotalInvestment" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div><br />

               <div class="row mb-2">
                        <div class="col-md-12">
                            <p><u><b>Bank Account Details</b></u></p>
                            <table class="table table-bordered table-responsive">
                                <thead>
                                    <tr>
                                        <th>Account</th>
                                        <th>Bank Name </th>
                                        <th>Branch</th>
                                        <th>Type of A/c</th>
                                        <th>A/c No.</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <th>Account 1 Details</th>
                                        <td>
                                            <asp:TextBox ID="txt7Bank1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt7Branch1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt7AccountType1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt7AccountNo1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Account 2 Details</th>
                                        <td>
                                            <asp:TextBox ID="txt7Bank2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt7Branch2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt7AccountType2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt7AccountNo2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
         </div>
     </div>

    <!--==========================
      8. References  Section
    ============================-->
    <div class="card" style="width: 100%; ">
         <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>8. References</h3>
                        </div>
                    </div>
                </div><br />

                <div class="row mb-2">
                        <div class="col-md-12">
                            <table class="table table-bordered table-responsive">
                                <thead>
                                    <tr>
                                        <th style="text-align:center;" colspan="2">Reference 1</th>
                                        <th style="text-align:center;" colspan="2">Reference 2</th>
                                    </tr>
                                </thead>
                                <tbody>
                                   <tr>
                                        <td>Name<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt8Name1" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt8Name1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>Name</td>
                                        <td>
                                            <asp:TextBox ID="txt8Name2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Relation<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt8Relation1" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt8Relation1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>Relation</td>
                                        <td>
                                            <asp:TextBox ID="txt8Relation2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Address<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt8Address1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt8Address1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>Address</td>
                                        <td>
                                            <asp:TextBox ID="txt8Address2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>City<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt8City2" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt8City1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>City</td>
                                        <td>
                                            <asp:TextBox ID="txt8City2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>State<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt8State1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt8State1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>State</td>
                                        <td>
                                            <asp:TextBox ID="txt8State2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Country<asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt8Country2" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt8Country1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>Country</td>
                                        <td>
                                            <asp:TextBox ID="txt8Country2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>PIN Code<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt8Pin1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt8Pin1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>PIN Code</td>
                                        <td>
                                            <asp:TextBox ID="txt8Pin2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Mobile<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt8Mobile1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt8Mobile1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>Mobile</td>
                                        <td>
                                            <asp:TextBox ID="txt8Mobile2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>E-Mail<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt8Email1" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt8Email1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>E-Mail</td>
                                        <td>
                                            <asp:TextBox ID="txt8Email2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div> 
           </div>
  </div>
 
    <!--==========================
      9. Declaration  Section
    ============================-->
    <div class="card" style="width: 100%; ">
         <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>9. Declaration</h3>
                        </div>
                    </div>
                </div><br />

                <div class="row">
                    <div class="col-md-12">
                        <p><i class="fa fa-check-square" style="color: #0026ff;"></i>&nbsp;I/We declare that the particulars and Information given in the Application Form are true, correct, complete and upto date in all respects and I/We have not withheld any information. I/We confirm that I/We have had no insolvency proceeding initiated against me/us nor have I/We ever been adjudicated insolvent. I/We authorise the Loan Trusty to make references and enquiries relative to information. In this application which the Bank considers necessary. I/We authorise the Loan Trusty to exchange, share/part with all information relating to my/our loan details and repayment history information to other Banks/Financial Institutions, etc. as may be required and shall not hold the Bank liable for use of this information. I/We undertake to inform the Bank regarding change in my/our residence/employment and to provide any further information that the Bank may require. I/We agree that my/our loan shall be governed by the rules of the Bank which may be In force from time to time. I/We understand that the Loan Trusty has the right to reject my/our application without providing any reason</p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <label><b><u>Upload Image :</u></b></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator91" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="imageFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:FileUpload ID="imageFileUpload"  accept="image/*" class="form-control" onchange="preview_image(event)" runat="server" /><br />
                        <img id="output_image" class="auto-style3" /><br />
                        <asp:Label ID="imguploadlbl" runat="server"></asp:Label>               
                    </div><br />
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-4">
                        <label><b><u>Upload Signature :</u></b></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator92" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="signFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:FileUpload ID="signFileUpload" accept="image/*" class="form-control" onchange="preview_sign(event)"  runat="server" /><br />
                        <img id="output_sign" class="auto-style3" /><br />
                        <asp:Label ID="signuploadlbl" runat="server"></asp:Label>               
                    </div><br />
                </div><br />

                <div class="row">
                    <div class="col-md-12">
                            <table class="table table-bordered table-responsive">
                                <thead>
                                    <tr>
                                        <th style="text-align:center;">Documents</th>
                                        <th style="text-align:center;">Select</th>
                                        <th style="text-align:center;">Upload</th>
                                    </tr>
                                </thead>
                                <tbody>
                                   <tr>
                                        <td>
                                            <br />
                                            <asp:Label ID="Label26" runat="server" Text="Proof Of Identity"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl9Identity" runat="server" class="form-control">
                                                <asp:ListItem>Choose...</asp:ListItem>
                                                <asp:ListItem>Passport</asp:ListItem>
                                                <asp:ListItem>Aadhaar Card</asp:ListItem>
                                                <asp:ListItem>Driving License</asp:ListItem>
                                                <asp:ListItem>Voter ID</asp:ListItem>
                                                <asp:ListItem>PAN Card</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="ddl9Identity" InitialValue="Choose..." Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="identityFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:FileUpload ID="identityFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="lbl9Identity" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <asp:Label ID="Label27" runat="server" Text="Proof Of Residence"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl9Residence" runat="server" class="form-control">
                                                <asp:ListItem>Choose...</asp:ListItem>
                                                <asp:ListItem>Leave and License Agreement</asp:ListItem>
                                                <asp:ListItem>Utility Bill (not more than 3 months old)</asp:ListItem>
                                                <asp:ListItem>Passport </asp:ListItem>
                                                <asp:ListItem>Aadhaar Card</asp:ListItem>
                                                <asp:ListItem>Driving License</asp:ListItem>
                                                <asp:ListItem>Voter ID</asp:ListItem>
                                                <asp:ListItem>Ration Card</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="ddl9Residence" InitialValue="Choose..." Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="residenceFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:FileUpload ID="residenceFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="lbl9Residence" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <asp:Label ID="Label28" runat="server" Text="Financial Proof"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl9Financial" runat="server" class="form-control">
                                                <asp:ListItem>Choose...</asp:ListItem>
                                                <asp:ListItem>Latest 3 months Bank Statement (where salary/income is credited)</asp:ListItem>
                                                <asp:ListItem>Salary slips for last 3 months</asp:ListItem>
                                                <asp:ListItem>Income Certificate</asp:ListItem>
                                                <asp:ListItem>Form 16</asp:ListItem>
                                                <asp:ListItem>Audited financials for the last two years</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="ddl9Financial" InitialValue="Choose..." Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="financialFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:FileUpload ID="financialFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="lbl9Financial" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <asp:Label ID="Label29" runat="server" Text="Admission Letter"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl9AdmissionLetter" runat="server" class="form-control">
                                                <asp:ListItem>Choose...</asp:ListItem>
                                                <asp:ListItem>Admission Letter of Institute</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="ddl9AdmissionLetter" InitialValue="Choose..." Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="AdmissionLetterFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:FileUpload ID="AdmissionLetterFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="Label30" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <asp:Label ID="Label37" runat="server" Text="Demand Letter from College or University"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl9DemandLetter" runat="server" class="form-control">
                                                <asp:ListItem>Choose...</asp:ListItem>
                                                <asp:ListItem>Demand Letter</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="ddl9DemandLetter" InitialValue="Choose..." Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="DemandLetterFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:FileUpload ID="DemandLetterFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="Label38" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <asp:Label ID="Label31" runat="server" Text="10th Mark sheet"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl9SscMarkSheet" runat="server" class="form-control">
                                                <asp:ListItem>Choose...</asp:ListItem>
                                                <asp:ListItem>10th Mark sheet (SSC)</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="ddl9SscMarkSheet" InitialValue="Choose..." Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="SscMarkSheetFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:FileUpload ID="SscMarkSheetFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="Label32" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <asp:Label ID="Label33" runat="server" Text="12th Mark sheet"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl9HscMarkSheet" runat="server" class="form-control">
                                                <asp:ListItem>Choose...</asp:ListItem>
                                                <asp:ListItem>12th Mark sheet (HSC)</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="ddl9HscMarkSheet" InitialValue="Choose..." Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="HscMarkSheetFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:FileUpload ID="HscMarkSheetFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="Label34" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <asp:Label ID="Label35" runat="server" Text="Last Degree (if applicable)"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl9LastDegree" runat="server" class="form-control">
                                                <asp:ListItem>Choose...</asp:ListItem>
                                                <asp:ListItem>Last Degree Certificate</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:FileUpload ID="LastDegreeFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="Label36" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                </div><br />

                <div class="row">
                    <div class="col-md-4">
                        <label>Place :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt9Place" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt9Place" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label>Date of Declaration :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt9DateOfDeclaration" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt9DateOfDeclaration" class="form-control" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date"  placeholder="YYYY-MM-DD" runat="server"></asp:TextBox>
                    </div>
                </div><br />

                <!--Save Data Button-->
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div id="submit" class="text-center">
                            <asp:Button ID="submit6" Class=" btn btn-primary" runat="server" Text="Save" />
                            <br/><br/>
                        </div>
                    </div>
                </div>
           </div>
        </div>
  </div>  
  </form>
    <script>

        function preview_image(event) {
            var reader = new FileReader();
            reader.onload = function() {
                var output = document.getElementById('output_image');
                output.src = reader.result;
            }
            reader.readAsDataURL(event.target.files[0]);
        }

        function preview_sign(event) {
            var reader = new FileReader();
            reader.onload = function() {
                var output = document.getElementById('output_sign');
                output.src = reader.result;
            }
            reader.readAsDataURL(event.target.files[0]);
        }
    </script>

    <!-- Back to Top Button -->
    <a href="#" class="back-to-top"><i class="fa fa-chevron-up"></i></a>
    <!-- <div id="preloader"></div> -->
    <!-- JavaScript Libraries -->
    <script src="lib/jquery/jquery.min.js"></script>
    <script src="lib/jquery/jquery-migrate.min.js"></script>
    <script src="lib/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="lib/easing/easing.min.js"></script>
    <script src="lib/mobile-nav/mobile-nav.js"></script>
    <script src="lib/wow/wow.min.js"></script>
    <script src="lib/waypoints/waypoints.min.js"></script>
    <script src="lib/counterup/counterup.min.js"></script>
    <script src="lib/owlcarousel/owl.carousel.min.js"></script>
    <script src="lib/isotope/isotope.pkgd.min.js"></script>
    <script src="lib/lightbox/js/lightbox.min.js"></script>
    <!-- Contact Form JavaScript File -->
    <script src="contactform/contactform.js"></script>

    <!-- Template Main Javascript File -->
    <script src="js/main.js"></script>
</body>
</html>


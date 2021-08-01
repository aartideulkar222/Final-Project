<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeLoanDetails.aspx.cs" Inherits="MajorProjectLoanSystem.HomeLoanDetails" %>

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
    <title>Home or Property Loan</title>

    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js" type="text/javascript"></script>
    <script>
        function successAlert() {
            var startd = document.getElementById('lblApp_ID').innerHTML;
            swal({
                title: "Great! Application Submitted",
                text: "Application ID : " + startd,
                icon: "success",
                type: "success"
            }).then(function () {
                window.location = "LoanHomePage.aspx";
            });
        }

        function editAlert() {
            swal({
                title: "You have already Applied",
                text: "Do you want to Re-apply with new details ?",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willEdit) => {
                    if (willEdit) {
                        swal("Do you really want to Re-Apply ?", {
                            icon: "warning",
                        });
                    }
                    else {
                        window.location = "LoanHomePage.aspx";
                    }
                });
        }

        function oopsAlert() {
            swal(

                'Oops...!',
                'Something went wrong!',
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

    <style type="text/css">
        .auto-style3 {
            width: 257px;
            height: 149px;
            border: 1px solid #dee2e6;
        }
        .auto-style4 {
            width: 154px;
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
                <a href="LoanHomePage.aspx" class="scrollto"><img src="img/logo.png" alt="" class="img-fluid"></a>
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


<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

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
                        <asp:TextBox ID="txt1Dependents" class="form-control" TextMode="Number" min="1" max="99" step="1" runat="server"></asp:TextBox>
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
                        <label>Telephone No(if available) :</label><asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt1Telephone" Font-Size="Small" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txt1Telephone" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <label>Mobile No :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator124" runat="server" ErrorMessage=" (Invalid Data)" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ControlToValidate="txt1Mobile"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt1Mobile" Font-Size="Small" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txt1Mobile" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
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
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt1PresentPostal" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]{6}"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txt1PresentPostal" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
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
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt1PermanentPostal" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]{6}"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txt1PermanentPostal" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
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
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt2Pin" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]{6}"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txt2Pin" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
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
      3. Employment / Business  Section
    ============================-->
    <div class="card" style="width: 100%; ">
         <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>3. Employment / Business Details</h3>
                        </div>
                    </div>
                </div><br />

                <div class="row mb-2">
                        <div class="col-md-4">
                            <label>Residence Ownership</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl3ResidenceOwnership" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl3ResidenceOwnership" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Self Owned</asp:ListItem>
                                <asp:ListItem>Rental</asp:ListItem>
                                <asp:ListItem>Parental</asp:ListItem>
                                <asp:ListItem>Co. Provided</asp:ListItem>
                                <asp:ListItem>Paying Guest</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label>Employment Nature</label>
                            <asp:DropDownList ID="ddl3EmploymentNature" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Salaried</asp:ListItem>
                                <asp:ListItem>Self-Employed</asp:ListItem>
                                <asp:ListItem>Retired</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label>Designation</label>
                            <asp:TextBox ID="txt3Designation" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div><br />

                <div class="row mb-2">
                        <div class="col-md-4">
                            <label>Nature of Employer/Business</label>
                            <asp:DropDownList ID="ddl3EmployerNature" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Trading</asp:ListItem>
                                <asp:ListItem>Mfg.</asp:ListItem>
                                <asp:ListItem>Service</asp:ListItem>
                                <asp:ListItem>Agri.</asp:ListItem>
                                <asp:ListItem>Other</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txt3EmployerNatureOther" class="form-control" PlaceHolder="if Other Specify" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Nature of Organisation :</label>
                            <asp:DropDownList ID="ddl3OrganisationNature" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Govt./PSU</asp:ListItem>
                                <asp:ListItem>Public Ltd.</asp:ListItem>
                                <asp:ListItem>Pvt. Ltd.</asp:ListItem>
                                <asp:ListItem>MNC</asp:ListItem>
                                <asp:ListItem>Partnership</asp:ListItem>
                                <asp:ListItem>Proprietorship</asp:ListItem>
                                <asp:ListItem>Local Civic Body</asp:ListItem>
                                <asp:ListItem>Other</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="txt6OrganisationTypeOther" class="form-control" PlaceHolder="if Other Specify" runat="server"></asp:TextBox>
                        </div>
                </div><br />

                <div class="row mb-2">
                        <div class="col-md-6">
                            <label>Period in Current Employment/Business (year)</label>
                            <asp:TextBox ID="txt3CurrentEmploymentYear" class="form-control" TextMode="Number" PlaceHolder="Year" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label>Total Employment/Business Period (year)</label>
                            <asp:TextBox ID="txt3TotalEmploymentYear" class="form-control" TextMode="Number" PlaceHolder="Year" runat="server"></asp:TextBox>
                        </div>
                </div><br />

                <div class="row mb-2">
                        <div class="col-md-6">
                            <label>Name of Organisation</label>
                            <asp:TextBox ID="txt3OrganisationName" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label>Address</label>
                            <asp:TextBox ID="txt3Address" class="form-control" runat="server"></asp:TextBox>
                        </div>
                </div><br />

                <div class="row mb-2">
                        <div class="col-md-4">
                            <label>City</label>

                            <asp:TextBox ID="txt3City" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>State</label>

                            <asp:TextBox ID="txt3State" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Pin Code</label>
                            
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt3PinCode" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]{6}"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txt3PinCode" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                </div><br />

                <div class="row mb-2">
                        <div class="col-md-4">
                            <label>Country</label>

                            <asp:TextBox ID="txt3Country" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Phone</label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt3Phone" Font-Size="Small" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                            <asp:TextBox ID="txt3Phone" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>UAN (Udyog Aadhaar Number)</label>

                            <asp:TextBox ID="txt3Uan" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                
         </div><br />
     </div>

    <!--==========================
      4. Financial Details  Section
    ============================-->
    <div class="card" style="width: 100%; ">
         <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>4. Financial Details</h3>
                        </div>
                    </div>
                </div><br />

                <div class="row mb-2">
                        <div class="col-md-4">
                            <label>Financial Status</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl4FinancialStatus" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddl4FinancialStatus" runat="server" class="form-control">
                            <asp:ListItem>Choose...</asp:ListItem>
                            <asp:ListItem Value="Financial">Financial</asp:ListItem>
                            <asp:ListItem Value="Non-Financial">Non-Financial</asp:ListItem>
                            </asp:DropDownList>
                        </div>   
               </div><br />
             
                <div class="row mb-2">
                        <div class="col-md-4">
                            <label>a. Gross Monthly Income</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt4GrossIncome" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4GrossIncome" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>b. Net Monthly Salary</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt4NetIncome" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4NetIncome" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>c. Other Income</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt4OtherIncome" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4OtherIncome" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
                        </div>
                </div><br />

                <div class="row mb-2">
                        <div class="col-md-4">
                            <label>d. Total Income (b+C)</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt4TotalIncome" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txt4TotalIncome" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
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
                                            <asp:TextBox ID="txt4Bank1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt4Branch1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt4AccountType1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt4AccountNo1" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Account 2 Details</th>
                                        <td>
                                            <asp:TextBox ID="txt4Bank2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt4Branch2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt4AccountType2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt4AccountNo2" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div><br />

                <p><u><b>Investment Details</b></u></p>
                <div class="row mb-2">
                        <div class="col-md-4">
                            <label>Deposits</label>
                            <asp:TextBox ID="txt4Deposits" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Insurance</label>
                            <asp:TextBox ID="txt4Insurance" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Shares</label>
                            <asp:TextBox ID="txt4Shares" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                </div><br />

                <div class="row mb-2">
                        <div class="col-md-4">
                            <label>Mutual Funds</label>
                            <asp:TextBox ID="txt4MutualFunds" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Other Investment</label>
                            <asp:TextBox ID="txt4Others" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>Total Investment</label>
                            <asp:TextBox ID="txt4TotalInvestment" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                        </div>
                </div>
         </div><br />
     </div>

    <!--==========================
      5. Propose Loan  Section
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
                
                <div class="row">
                    <div class="col-md-4">
                                <asp:Label ID="Label14" runat="server" Text="Loan Required"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl5LoanRequired" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                <asp:DropDownList ID="ddl5LoanRequired" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnSelectedIndexChanged" class="form-control" EnableViewState="False">
                                    <asp:ListItem Value="Choose...">Choose...</asp:ListItem>
                                    <asp:ListItem Value="Home Loan">Home Loan</asp:ListItem>
                                    <asp:ListItem Value="Loan Against Property">Loan Against Property</asp:ListItem>
                                </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label15" runat="server" Text="Loan Amount(Rs.)"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt5LoanAmount" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt5LoanAmount" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label16" runat="server" Text="Terms (Months)"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt5Terms" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt5Terms" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                </div><br />

                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="Label17" runat="server" Text="Purpose of Loan"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl5LoanPurpose" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddl5LoanPurpose" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Purchase Home</asp:ListItem>
                                <asp:ListItem>Construction</asp:ListItem>
                                <asp:ListItem>Plot + Construction</asp:ListItem>
                                <asp:ListItem>Home Repair</asp:ListItem>
                                <asp:ListItem>BT</asp:ListItem>
                                <asp:ListItem>Top-up</asp:ListItem>
                                <asp:ListItem>Business</asp:ListItem>
                                <asp:ListItem>Agriculture</asp:ListItem>
                                <asp:ListItem>Home Repair</asp:ListItem>
                                <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txt5LoanPurpose" class="form-control" PlaceHolder="if Other specify" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label18" runat="server" Text="Type of Loan/Product Category"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl5LoanProductType" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddl5LoanProductType" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Vanilla</asp:ListItem>
                                <asp:ListItem>Fast Forward Home Loan</asp:ListItem>
                                <asp:ListItem>Super Saver Home Loan</asp:ListItem>
                                <asp:ListItem>Asha Home Loan</asp:ListItem>
                                <asp:ListItem>Quick Pay Home Loan</asp:ListItem>
                                <asp:ListItem>Power Advantage Home Loan</asp:ListItem>
                                <asp:ListItem>PMAY HL</asp:ListItem>
                                <asp:ListItem>IMGC</asp:ListItem>
                                <asp:ListItem>Loan Against Property(Vanilla)</asp:ListItem>
                                <asp:ListItem>Lease Rental Discounting</asp:ListItem>
                                <asp:ListItem>Purchase of Commercial Property</asp:ListItem>
                                <asp:ListItem>Overdraft  Facility (Dropline)</asp:ListItem>
                                <asp:ListItem>Overdraft  Facility (Straightline)</asp:ListItem>
                                <asp:ListItem>Reverse Mortgage Loan</asp:ListItem>
                                <asp:ListItem>Other</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txt5LoanProductTypeOther" class="form-control" PlaceHolder="if Other specify" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label19" runat="server" Text="Repayment Mode"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl5RepaymentMode" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddl5RepaymentMode" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>PDC</asp:ListItem>
                                <asp:ListItem>NACH</asp:ListItem>
                                <asp:ListItem>SI</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

           </div><br />
  </div>
                                
    <!--==========================
      6. Property Details  Section
    ============================-->
    <div class="card" style="width: 100%; ">
         <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>6. Property Details</h3>
                        </div>
                    </div>
                </div><br />
                <div class="row">
                        <div class="col-md-12">
                            <p><u>Fill Details of any One Loan as applicable</u></p>
                            <table class="table table-bordered table-responsive">
                                <thead>
                                    <tr>
                                        <th colspan="2" style="text-align:center;">Home Loan</th>
                                        <th colspan="2" style="text-align:center;">Loan Against Property</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <br />
                                            Property Type

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl6PropertyType1" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                           <asp:DropDownList ID="ddl6PropertyType1" runat="server" class="form-control">
                                               <asp:ListItem>Choose...</asp:ListItem>
                                               <asp:ListItem>Flat</asp:ListItem>
                                               <asp:ListItem>Single Story House</asp:ListItem>
                                               <asp:ListItem>Extension</asp:ListItem>
                                               <asp:ListItem>Repair</asp:ListItem>
                                           </asp:DropDownList> 
                                        </td>
                                        <td>
                                            <br />
                                            Property Type

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl6PropertyType2" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="ddl6PropertyType2" runat="server" class="form-control">
                                               <asp:ListItem>Choose...</asp:ListItem>
                                               <asp:ListItem>Residential</asp:ListItem>
                                               <asp:ListItem>Commercial</asp:ListItem>
                                               <asp:ListItem>Residential Cum Office</asp:ListItem>
                                               <asp:ListItem>Multi tenanted and mixed usage</asp:ListItem>
                                           </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            Transaction Type

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl6TransactionType1" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="ddl6TransactionType1" runat="server" class="form-control">
                                               <asp:ListItem>Choose...</asp:ListItem>
                                               <asp:ListItem>Builder</asp:ListItem>
                                               <asp:ListItem>Society</asp:ListItem>
                                               <asp:ListItem>Authority</asp:ListItem>
                                               <asp:ListItem>Resale</asp:ListItem>
                                               <asp:ListItem>Existing and Owned (Repair/Renovation)</asp:ListItem>
                                           </asp:DropDownList>
                                        </td>
                                        <td>
                                            <br />
                                            Property Classification New
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl6PropertyClassification2" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:DropDownList ID="ddl6PropertyClassification2" runat="server" class="form-control">
                                               <asp:ListItem>Choose...</asp:ListItem>
                                               <asp:ListItem>Yes</asp:ListItem>
                                               <asp:ListItem>No</asp:ListItem>
                                               <asp:ListItem>Resale</asp:ListItem>
                                           </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            Builder Name

                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt6BuilderName1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            Age of Building (months)

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6BuildingAge2" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6BuildingAge2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            Project/Property Name

                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt6PropertName1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            Market Value(Rs.)

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6MarketValue2" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6MarketValue2" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            Building Name

                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt6BuildingName1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            Registered Value/Agreement Value(Rs.)
                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt6RegisteredValue2" TextMode="Number" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            Area of Property/Land(In Sq. Ft.)
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6Area1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6Area1" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            Area of Property/Land(In Sq. Ft.)
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6Area2" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6Area2" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            Market Value of Property / Land(Rs.)
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6PropertyCost1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6PropertyCost1" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            Build-up Area(In Sq. Ft.)

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6BuildArea2" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6BuildArea2" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            Address of Property

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6Address1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6Address1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            Address of Property

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6Address2" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6Address2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            Landmark

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6landmark1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6landmark1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            Landmark

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6landmark2" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6landmark2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            Pin

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6Pin1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6Pin1" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            Pin

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6Pin2" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6Pin2" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            City

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6City1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6City1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            City

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6City2" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6City2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            State

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6State1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6State1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            State

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6State2" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6State2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            Country

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6Country1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6Country1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            Country

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6Country2" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6Country2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            Property Ownership

                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="txt6Ownership1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txt6Ownership1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            For Applications Under Reverse Mortgage Scheme

                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl6ApplicationFor2" runat="server" class="form-control">
                                               <asp:ListItem>Choose...</asp:ListItem>
                                               <asp:ListItem>Lumsum</asp:ListItem>
                                               <asp:ListItem>Annuity</asp:ListItem>
                                               <asp:ListItem>Combination of Lumpsum and Annuity</asp:ListItem>
                                           </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            Name of Seller

                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt6SellerName1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            In case of Lumpsum plan, please specify the lumpsum Amount(Rs.)

                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt6LumpsumPlan2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            Address of Selle

                                        </td>
                                        <td>
                                            <br />
                                            <asp:TextBox ID="txt6SellerAddress1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <br />
                                            In case of Annuity, please specify the periodicity of Annuity

                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl6AnnuityPeriod2" runat="server" class="form-control">
                                               <asp:ListItem>Choose...</asp:ListItem>
                                               <asp:ListItem>Monthly</asp:ListItem>
                                               <asp:ListItem>Quarterly</asp:ListItem>
                                               <asp:ListItem>half Yearly</asp:ListItem>
                                               <asp:ListItem>Annual</asp:ListItem>
                                           </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div><br />
                
             <p><u><b>Other Details</b> (Only for Home Loan)</u></p>
                <div class="row">
                    <div class="col-md-4">
                        <asp:Label ID="Label20" runat="server" Text="Stage of Construction"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl3ResidenceOwnership" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddl6ConstructionStage" runat="server" class="form-control">
                                <asp:ListItem>Choose...</asp:ListItem>
                                <asp:ListItem>Complete</asp:ListItem>
                                <asp:ListItem>Under Progress</asp:ListItem>
                                <asp:ListItem>Yet to Start</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label21" runat="server" Text="Cost of Purchase/Construction(Rs.)"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl3ResidenceOwnership" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt6PurchaseCost" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="Label22" runat="server" Text="Registration Cost(Rs.)"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl3ResidenceOwnership" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt6RegistratonCost" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                </div><br />

                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label23" runat="server" Text="Total Cost(Rs.)"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ErrorMessage="(Invalid Data)" ForeColor="Red" ControlToValidate="ddl3ResidenceOwnership" InitialValue="Choose..." SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt6TotalCost" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label26" runat="server" Text="Stamp Duty Cost(Rs.)"></asp:Label>
                        <asp:TextBox ID="txt6StampCost" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label24" runat="server" Text="Other Cost(Rs.)"></asp:Label>
                        <asp:TextBox ID="txt6OtherCost" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="Label25" runat="server" Text="Own Contribution(Rs.)"></asp:Label>
                        <asp:TextBox ID="txt6OwnContribution" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                </div>

           </div><br />
  </div>

               
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddl5LoanRequired" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>

    <!--==========================
      7. References  Section
    ============================-->
    <div class="card" style="width: 100%; ">
         <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>7. References</h3>
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
                                        <td>Name<asp:RequiredFieldValidator ID="RequiredFieldValidator71" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt7Name1" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt7Name1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>Name</td>
                                        <td>
                                            <asp:TextBox ID="txt7Name2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Relation<asp:RequiredFieldValidator ID="RequiredFieldValidator72" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt7Relation1" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt7Relation1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>Relation</td>
                                        <td>
                                            <asp:TextBox ID="txt7Relation2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Address<asp:RequiredFieldValidator ID="RequiredFieldValidator73" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt7Address1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt7Address1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>Address</td>
                                        <td>
                                            <asp:TextBox ID="txt7Address2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>City<asp:RequiredFieldValidator ID="RequiredFieldValidator74" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt7City1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt7City1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>City</td>
                                        <td>
                                            <asp:TextBox ID="txt7City2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>State<asp:RequiredFieldValidator ID="RequiredFieldValidator75" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt7State1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt7State1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>State</td>
                                        <td>
                                            <asp:TextBox ID="txt7State2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Country<asp:RequiredFieldValidator ID="RequiredFieldValidator76" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt7Country1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt7Country1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>Coutry</td>
                                        <td>
                                            <asp:TextBox ID="txt7Country2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>PIN Code<asp:RequiredFieldValidator ID="RequiredFieldValidator77" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt7Pin1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt7Pin1" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                        </td>
                                        <td>PIN Code</td>
                                        <td>
                                            <asp:TextBox ID="txt7Pin2" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Mobile<asp:RequiredFieldValidator ID="RequiredFieldValidator78" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt7Mobile1" ForeColor="Red"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt7Mobile1" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                        </td>
                                        <td>Mobile</td>
                                        <td>
                                            <asp:TextBox ID="txt7Mobile2" class="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>E-Mail<asp:RequiredFieldValidator ID="RequiredFieldValidator79" runat="server" ErrorMessage="(Invalid Data)" ControlToValidate="txt7Email1" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                                        <td>
                                            <asp:TextBox ID="txt7Email1" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                        <td>E-Mail</td>
                                        <td>
                                            <asp:TextBox ID="txt7Email2" class="form-control" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div> 
           </div>
  </div>
 
    <!--==========================
      8. Declaration  Section
    ============================-->
    <div class="card" style="width: 100%; ">
         <div class="container">
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div id="sub-head">
                            <h3>8. Declaration</h3>
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator81" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="imageFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:FileUpload ID="imageFileUpload"  accept="image/*" class="form-control" onchange="preview_image(event)" runat="server" /><br />
                        <asp:Image ID="output_image" class="auto-style4" runat="server" /><br />
                        <asp:Label ID="imguploadlbl" runat="server"></asp:Label>               
                    </div><br />
                    <div class="col-md-2">
                    </div>
                    <div class="col-md-4">
                        <label><b><u>Upload Signature :</u></b></label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator82" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="signFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <br />
                        <asp:FileUpload ID="signFileUpload" accept="image/*" class="form-control" onchange="preview_sign(event)"  runat="server" /><br />
                        <asp:Image ID="output_sign" class="auto-style3" runat="server" /><br />
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
                                            <asp:Label ID="Label27" runat="server" Text="Proof Of Identity"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl8Identity" runat="server" class="form-control">
                                                <asp:ListItem>Choose...</asp:ListItem>
                                                <asp:ListItem>Passport</asp:ListItem>
                                                <asp:ListItem>Aadhaar Card</asp:ListItem>
                                                <asp:ListItem>Driving License</asp:ListItem>
                                                <asp:ListItem>Voter ID</asp:ListItem>
                                                <asp:ListItem>PAN Card</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="ddl8Identity" InitialValue="Choose..." Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="identityFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:FileUpload ID="identityFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="lbl8Identity" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <asp:Label ID="Label28" runat="server" Text="Proof Of Residence"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl8Residence" runat="server" class="form-control">
                                                <asp:ListItem>Choose...</asp:ListItem>
                                                <asp:ListItem>Leave and License Agreement</asp:ListItem>
                                                <asp:ListItem>Utility Bill (not more than 3 months old)</asp:ListItem>
                                                <asp:ListItem>Passport </asp:ListItem>
                                                <asp:ListItem>Aadhaar Card</asp:ListItem>
                                                <asp:ListItem>Driving License</asp:ListItem>
                                                <asp:ListItem>Voter ID</asp:ListItem>
                                                <asp:ListItem>Ration Card</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="ddl8Residence" InitialValue="Choose..." Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="residenceFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:FileUpload ID="residenceFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="lbl8Residence" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <asp:Label ID="Label29" runat="server" Text="Financial Proof"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl8Financial" runat="server" class="form-control">
                                                <asp:ListItem>Choose...</asp:ListItem>
                                                <asp:ListItem>Latest 3 months Bank Statement (where salary/income is credited)</asp:ListItem>
                                                <asp:ListItem>Payslip of last 2 months</asp:ListItem>
                                                <asp:ListItem>Income Certificate</asp:ListItem>
                                                <asp:ListItem>Certified letter from Employer</asp:ListItem>
                                                <asp:ListItem>Form 16</asp:ListItem>
                                                <asp:ListItem>IT returns of past 3 years</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="ddl8Financial" InitialValue="Choose..." Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="financialFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:FileUpload ID="financialFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="lbl8Financial" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <asp:Label ID="Label30" runat="server" Text="Age Proof"></asp:Label>
                                        </td>
                                        <td>
                                            <br />
                                            <asp:DropDownList ID="ddl8Age" runat="server" class="form-control">
                                                <asp:ListItem>Choose...</asp:ListItem>
                                                <asp:ListItem>Aadhar Card</asp:ListItem>
                                                <asp:ListItem>PAN Card</asp:ListItem>
                                                <asp:ListItem>Passport</asp:ListItem>
                                                <asp:ListItem>Birth Certificate</asp:ListItem>
                                                <asp:ListItem>Driving License</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="ddl8Age" InitialValue="Choose..." Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="ageFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:FileUpload ID="ageFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="lbl8Age" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th colspan="3"  style="text-align:center;">
                                            <br />
                                            <asp:Label ID="Label36" runat="server" Text="Home/Property Documents"></asp:Label>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <br />
                                            <asp:Label ID="Label32" runat="server" Text="Registered Sale Deed / Allotment Letter / Stamped Agreement of Sale with the Builder (Original Document)"></asp:Label>
                                            <br />
                                            <br />
                                            <br />
                                        </td>
                                        
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="saleDeedFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:FileUpload ID="saleDeedFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="lbl8SaleDeed" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <br />
                                            <asp:Label ID="Label34" runat="server" Text="Latest Property Tax Receipts (For Loan Against Property)"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Label ID="Label31" runat="server" Text="Latest Electricity Bill (For Home Loan)"></asp:Label>
                                        </td>
                                        
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="PropertyTaxFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:FileUpload ID="PropertyTaxFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="lbl8PropertyTax" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <br />
                                            <asp:Label ID="Label39" runat="server" Text="Receipts of the advance payments made towards the purchase of Property (original document) (For Home Loan)"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Label ID="Label33" runat="server" Text="Income Tax Receipt (For Loan Against Property)"></asp:Label>
                                        </td>
                                        
                                        <td>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="AdvancePaymentFileUpload" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                            <asp:FileUpload ID="AdvancePaymentFileUpload" accept="image/*" class="form-control" runat="server" />
                                            <asp:Label ID="lbl8AdvancePayment" runat="server" Text="(Only Images accepted & Max. Size allowed 256 KB)" Font-Size="Small" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                </div><br />

                <div class="row">
                    <div class="col-md-4">
                        <label>Place :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator83" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt8Place" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt8Place" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label>Date of Declaration :</label><asp:RequiredFieldValidator ID="RequiredFieldValidator84" runat="server" ErrorMessage=" (Invalid Data)" ControlToValidate="txt8DateOfDeclaration" Font-Size="Small" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txt8DateOfDeclaration" class="form-control" Text='<%# Bind("DateofBirth", "{0:yyyy-MM-dd}") %>' TextMode="Date"  placeholder="YYYY-MM-DD" runat="server"></asp:TextBox>
                    </div>
                </div><br />

             <asp:Label ID="lblApp_ID" ForeColor="White" runat="server"></asp:Label>

                <!--Save Data Button-->
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div id="submit" class="text-center">
                            <asp:Button ID="submit6" Class=" btn btn-primary" runat="server" Text="Save" OnClick="submit6_Click" />
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
            reader.onload = function () {
                var output = document.getElementById('output_image');
                output.src = reader.result;
            }
            reader.readAsDataURL(event.target.files[0]);
        }

        function preview_sign(event) {
            var reader = new FileReader();
            reader.onload = function () {
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


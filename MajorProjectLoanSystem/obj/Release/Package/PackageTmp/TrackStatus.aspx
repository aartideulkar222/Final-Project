<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrackStatus.aspx.cs" Inherits="MajorProjectLoanSystem.TrackStatus" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>Track Loan Application</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <meta content="" name="keywords">
    <meta content="" name="description">

    <!-- Favicons -->
    <link href="img/favicon.png" rel="icon">
    <link href="img/apple-touch-icon.png" rel="apple-touch-icon">

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,700,700i|Montserrat:300,400,500,700" rel="stylesheet">

    <!-- Bootstrap CSS File -->
    <link href="lib/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Libraries CSS Files -->
    <link href="lib/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <link href="lib/animate/animate.min.css" rel="stylesheet">
    <link href="lib/ionicons/css/ionicons.min.css" rel="stylesheet">
    <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">
    <link href="lib/lightbox/css/lightbox.min.css" rel="stylesheet">

    <!-- Main Stylesheet File -->
    <link href="css/style2.css" rel="stylesheet">

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

            <div class="logo float-right">
                <a href="LoanHomePage.aspx" class="scrollto"><button class="home-btn">Home</button></a>
            </div>
        </div>
    </header><!-- #header -->
    <!--==========================
      Track  Section
    ============================-->
    <section id="track">
        <div class="container">

            <header class="section-header">
                <h3>Track Application Status</h3>
                <p>Below Table shows status of your Applied Loan Application(s)</p>
            </header>

            <div class="table-responsive">
                <table class="table table-bordered">
                    <tr>
                        <th>Sr.No</th>
                        <th>Application</th>
                        <th>Applied</th>
                        <th>Status</th>
                        <th>Corrections / Reason</th>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>Personal Loan</td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="NA"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="NA"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="NA"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>Home Loan</td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="NA"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="NA"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="NA"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>Education Loan</td>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="NA"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="NA"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="NA"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>4</td>
                        <td>Gold Loan</td>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="NA"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="NA"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label12" runat="server" Text="NA"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

        </div>
    </section>

    <!--==========================
      Footer
    ============================-->
    <footer id="footer">
        <div class="footer-top">
            <div class="container">
                <div class="row">

                    <div class="col-lg-6 col-md-6 footer-info">
                        <h3>Loan Trusty</h3>
                        <p>Loan Trusty is one of the most trusted and bank neutral platform that works to provide the lowest interest rate personal loan, home loan, education loan, gold loan. Leave your worries behind as Loan Trusty is here to the rescue.</p>
                    </div>

                    <div class="col-lg-3 col-md-6 footer-links">
                        <h4>Useful Links</h4>
                        <ul>
                            <li><a href="#">Home</a></li>
                            <li><a href="#">Privacy policy</a></li>
                        </ul>
                    </div>

                    <div class="col-lg-3 col-md-6 footer-contact">
                        <h4>Contact Us</h4>
                        <p>
                            Nagpur-441108<br>
                            Maharashtra<br>
                            India<br>
                            <strong>Phone:</strong> +91 9403866393<br>
                            <strong>Email:</strong> info@loantrusty.com<br>
                        </p>

                    </div>
                </div>
            </div>

    </footer><!-- #footer -->

    <a href="#" class="back-to-top"><i class="fa fa-chevron-up"></i></a>
    <!-- Uncomment below i you want to use a preloader -->
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

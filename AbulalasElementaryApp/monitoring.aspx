<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="monitoring.aspx.cs" Inherits="AbulalasElementaryApp.monitoring" %>


<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8">
  <title>Abulalas Elementary School | Admin</title>
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css'>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
  <link rel="stylesheet" href="https://unpkg.com/ag-grid-community/dist/styles/ag-grid.css">
  <link rel="stylesheet" href="https://unpkg.com/ag-grid-community/dist/styles/ag-theme-alpine.css">
  <script src="https://cdn.rawgit.com/davidshimjs/qrcodejs/gh-pages/qrcode.min.js"></script>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/5.10.1/main.min.css">
  <link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.9.0/fullcalendar.min.css'>

  <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
  <link rel="stylesheet" href="css/main.css">


</head>
<body>
<!-- partial:index.partial.html -->
<div class="app">
  <header>
    <div class="logo">
      <img src="logo/logo.png"  style="max-width: 70%; height: auto;" />
    </div>
    <div class="nav-trigger hidden-M">
      <i class="fa fa-bars"></i>
    </div>
    <div class="right-links visible-M">
    <a href="login.aspx" style="text-decoration:none; color:white;"><i class="fas fa-sign-out-alt" style="font-size:30px;"></i></a>
    </div>
  </header>
  <div class="body">
    <nav class="side-nav">
      <ul>
        <li class="label">Main</li>
        <li class="active"><i class="fas fa-columns"></i><a href="home.aspx" style="text-decoration:none; color:white;">Dashboard</a></li>
        <li><i class="fas fa-edit"></i><a href="request.aspx" style="text-decoration:none; color:white;">Student Request</a></li>
        <li><i class="fas fa-user-graduate"></i><a href="enrollment.aspx" style="text-decoration:none; color:white;">Enrollment</a></li>
        <li><i class="fa fa-desktop"></i><a href="users.aspx" style="text-decoration:none; color:white;">Accounts</a></li>
        <li><i class="fa fa-bullhorn"></i><a href="announcement.aspx" style="text-decoration:none; color:white;">Announcement</a></li>
        <li><i class="fa fa-question-circle"></i><a href="lost.aspx" style="text-decoration:none; color:white;">Lost & Found</a></li>
      </ul>
    </nav>
    <div class="content">
        <form id="form1" runat="server">
               <div class="row" style="margin-top:20px;">
                   <div class="col-md-12">
                     <div class="content-with-shadow">
                         <asp:Label ID="lblEmail" runat="server" Text="" Style="font-weight: bold;"></asp:Label>
                      </div>
                   </div>
                </div>

        <div class="row" style="margin-top:20px;">
            <div class="col-md-6">
                <div class="content-with-shadow">
                       <h4 style="text-align:center">QR CODE</h4>
                          <hr />
                      <center>
                         <asp:Image ID="imgQRCode" runat="server" Style="width:20%;  margin-top:10px;" CssClass="img-fluid" />
                      </center>
                </div>
            </div>
            <div class="col-md-6">
                <div class="content-with-shadow">
                       <h4 style="text-align:center">PERSONAL DETAILS</h4>
                          <hr />
                      <center>
                          <p style="text-align: left; font-size:13px;"><asp:Label ID="Label1" runat="server" Text="" Style="font-weight: bold;"></asp:Label></p>
                          <p style="text-align: left; font-size:13px;"><asp:Label ID="Label2" runat="server" Text="" Style="font-weight: bold;"></asp:Label></p>
                          <p style="text-align: left; font-size:13px;"><asp:Label ID="Label3" runat="server" Text="" Style="font-weight: bold;"></asp:Label></p>
                          <p style="text-align: left; font-size:13px;"><asp:Label ID="Label4" runat="server" Text="" Style="font-weight: bold;"></asp:Label></p>
                          <p style="text-align: left; font-size:13px;"><asp:Label ID="Label5" runat="server" Text="" Style="font-weight: bold;"></asp:Label></p>
                          <p style="text-align: left; font-size:13px;"><asp:Label ID="Label6" runat="server" Text="" Style="font-weight: bold;"></asp:Label></p>
                      </center>
                </div>
            </div>
        </div>

        <div class="row" style="margin-top:20px;">
            <div class="col-md-12">
                <div class="content-with-shadow">
                     <h4 style="text-align:center">SCHOOL DETAILS</h4>
                          <hr />
                </div>
            </div>
        </div>


        </form>
    </div>
  </div>
</div>
<!-- partial -->

<script  src="js/main.js"></script>



</body>
</html>

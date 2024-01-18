<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="security.aspx.cs" Inherits="AbulalasElementaryApp.security" %>


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
  <link rel="stylesheet" href="css/main.css">

</head>
<body>
<form id="form2" runat="server">
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

    </div>
  </header>
  <div class="body">
    <div class="content">
        
        <div class="row" style="margin-top:20px; display: flex; justify-content: center; align-items: center;">
            <div class="col-md-3">
                <div class="content-with-shadow" style="background-color:#eece32;">
                     <center>
                         <img src="logo/main.png" style="width:50%; display: flex; justify-content: center; align-items: center;" />
                     </center>
                     <br />
                     <center><asp:Label ID="lblEmail" runat="server" Text="" Style="font-weight: bold; text-align:center;"></asp:Label></center>
                     <asp:TextBox ID="txtCode" class="rounded-input" runat="server" ToolTip="Enter 4-Digit Code" TextMode="Number"></asp:TextBox>
                     <asp:Button ID="btnValidate" class="rounded-button" runat="server" Text="VALIDATE" OnClick="btnValidate_Click"  />
                </div>
            </div>
        </div>

    </div>
  </div>
</div>
</form>
<!-- partial -->
  <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js'></script>
  <script src="https://cdn.jsdelivr.net/npm/ag-grid-enterprise@30.0.6/dist/ag-grid-enterprise.min.js"></script>
  <script  src="js/main.js"></script>


</body>
</html>
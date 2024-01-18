<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacherlist.aspx.cs" Inherits="AbulalasElementaryApp.teacherlist" %>


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
    <a href="logout.php" style="text-decoration:none; color:white;"><i class="fas fa-sign-out-alt" style="font-size:30px;"></i></a>
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
                   <div class="col-md-12">
                     <div class="content-with-shadow">
                         <asp:TextBox ID="txtSearch" runat="server" Style="padding: 8px 20px;" placeholder="Enter search query"></asp:TextBox>
                         <asp:Button ID="btnSearch" CssClass="createRequestBtn" runat="server" Text="SEARCH" OnClick="btnSearch_Click" />
                         <asp:Button ID="btnExportToExcel" runat="server" Text="DOWNLOAD TO EXCEL" OnClick="btnExportToExcel_Click" CssClass="createRequestBtn"/>
                         <asp:GridView ID="teacherGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10"
                            HeaderStyle-BackColor="#337ab7" HeaderStyle-ForeColor="White"
                            FooterStyle-BackColor="#337ab7" FooterStyle-ForeColor="White"
                            RowStyle-BackColor="#f5f5f5" RowStyle-ForeColor="#333333" AlternatingRowStyle-BackColor="White"
                            AlternatingRowStyle-ForeColor="#333333"  CssClass="responsive-grid">
                            <Columns>
                                <asp:BoundField DataField="uid" HeaderText="UID" ItemStyle-Width="100px"/>
                                <asp:BoundField DataField="email" HeaderText="EMAIL" ItemStyle-Width="100px"/>
                                <asp:BoundField DataField="date_created" HeaderText="REGISTERED" ItemStyle-Width="150px"/>
                                <asp:BoundField DataField="level" HeaderText="GRADE" ItemStyle-Width="100px"/>
                                <asp:BoundField DataField="section" HeaderText="SECTION" ItemStyle-Width="100px"/>
                                <asp:BoundField DataField="fname" HeaderText="FIRSTNAME" ItemStyle-Width="150px"/>
                                <asp:BoundField DataField="mname" HeaderText="MIDDLENAME" ItemStyle-Width="150px"/>
                                <asp:BoundField DataField="lname" HeaderText="LASTNAME" ItemStyle-Width="150px"/>
                             
                            </Columns>
                        </asp:GridView>
                      </div>
                   </div>
                </div>


        </form>
    </div>
  </div>
</div>
<!-- partial -->

<script  src="js/main.js"></script>

  <style type="text/css">
     /* Style for the GridView */
    .responsive-grid {
        width: 100%;
        border-collapse: collapse;
        margin: auto;
    }

    /* Style for the GridView header */
    .responsive-grid th {
        background-color: #337ab7;
        color: white;
        text-align: center;
        padding: 10px;
    }

    /* Style for the GridView rows */
    .responsive-grid td {
        text-align: center;
        padding: 5px;
    }

    /* Media query for smaller screens */
    @media (max-width: 767px) {
        .responsive-grid {
            font-size: 12px; /* Decrease font size for smaller screens */
        }

        /* Hide columns or adjust layout as needed for smaller screens */
        .responsive-grid th:nth-child(2),
        .responsive-grid td:nth-child(2) {
            display: none; /* Hide the second column on smaller screens */
        }
    }

       .createRequestBtn {
          margin-bottom: 20px;
          padding: 10px 20px;
          background-color: #007bff;
          color: white;
          border: none;
          border-radius: 4px;
          cursor: pointer;
        }

        .createRequestBtn:hover {
          background-color: #0056b3;
        }
</style>


</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="ElectionTabulatorFPA.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src='<%=ResolveClientUrl("~/Scripts/jquery-3.3.1.min.js") %>'></script>
     <script src='<%=ResolveClientUrl("~/Scripts/jquery.signalR-2.2.2.min.js") %>'></script>  
    <script src='<%=ResolveClientUrl("~/signalr/hubs") %>'></script>
    <script src="VoteTicker.js"></script>
    <link rel="stylesheet" href="StyleSheet.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-master">
 <header>

    </header>
  <div class="container-fluid fluff">
     <div class="row center">
         <div class="col-md-3"></div>
        <div class="col-md-2"> <asp:Button ID="ButtonSeat1" runat="server" Text="Seat 1" CssClass="btn" />
            </div>
     <div class="col-md-2"><asp:Button ID="ButtonSeat2" runat="server" Text="Seat 2" CssClass="btn" />
         </div> 
     <div class="col-md-2"><asp:Button ID="ButtonSeat3" runat="server" Text="Seat 3" CssClass="btn" />
         </div> 
          <div class="col-md-3"></div>
         </div>
  </div>
    <div class="container-fluid">
         <div id="resultsTable" class="row">
        <div class="col-md-1"></div>
     <div class="col-md-9"><table id="results" border="1" class="table">
            <thead>
                <tr><th>First Name</th>
                    <th>Last Name</th>
                    <th>Party</th>
                    <th>Seat</th>
                    <th>Vote Count</th>
                </tr>
            </thead>
            <tbody>
                <tr class="loading"><td colspan="5">loading...</td></tr>
            </tbody>
        </table>
         </div>
      </div>
    </div>
        </div>

</asp:Content>

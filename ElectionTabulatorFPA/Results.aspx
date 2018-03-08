<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="ElectionTabulatorFPA.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src='<%=ResolveClientUrl("~/Scripts/jquery-3.3.1.min.js") %>'></script>
     <script src='<%=ResolveClientUrl("~/Scripts/jquery.signalR-2.2.2.min.js") %>'></script>  
    <script src='<%=ResolveClientUrl("~/signalr/hubs") %>'></script>
    <script src="VoteTicker.js"></script>
    <link rel="stylesheet" href="StyleSheet.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="voterTicker" class="inner">
        <h2>Live Vote Ticker</h2>
        <ul>
            <li class="loading">loading...</li>
        </ul>s
    </div>

  
    <div id="resultsTable">
       <h2>Live Results Table</h2>
        <table border="1">
            <thead>
                <tr><th>First Name</th><th>Last Name</th><th>Party</th><th>Seat</th><th>Vote Count</th></tr>
            </thead>
            <tbody>
                <tr class="loading"><td colspan="5">loading...</td></tr>
            </tbody>
        </table>
    </div>
</asp:Content>

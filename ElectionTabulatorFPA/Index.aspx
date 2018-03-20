<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ElectionTabulatorFPA.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
    <div class="container-fluid">
        <div class="center extra-fluff">

        <asp:Button ID="ButtonVote" runat="server" Text="Vote" CssClass="home-btn btn" Height="180px" Width="220px" OnClick="ButtonVote_Click"/>
        <asp:Button ID="ButtonResults" runat="server" Text="View Results" CssClass="home-btn btn" Width="220" Height="180" OnClick="ButtonResults_Click" />
        </div>
   
    </div>
</asp:Content>

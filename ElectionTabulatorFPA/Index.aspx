<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ElectionTabulatorFPA.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
    <div class="container-fluid">
        <div class="center">
            <div class="btn-group">
        <asp:Button ID="ButtonVote" runat="server" Text="Vote" CssClass="home-btn btn" Height="180px" Width="240px" OnClick="ButtonVote_Click"/>
        <asp:Button ID="ButtonResults" runat="server" Text="View Results" CssClass="home-btn btn" Width="240" Height="180" />
        </div>
        </div>
    </div>
</asp:Content>

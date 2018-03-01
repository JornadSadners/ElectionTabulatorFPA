<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="ElectionTabulatorFPA.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
    <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
       <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="txtLast" runat="server"></asp:TextBox>
    </div>

</asp:Content>

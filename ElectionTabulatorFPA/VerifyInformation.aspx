<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VerifyInformation.aspx.cs" Inherits="ElectionTabulatorFPA.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2>Verify Your Information</h2>
        <asp:Label ID="Label1" runat="server" Text="First Name: " Font-Size="X-Large"></asp:Label>
        <br />
        <asp:TextBox ID="txtFirstName" runat="server" Font-Size="X-Large"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" Display="Dynamic" ErrorMessage="You must enter your first name" Font-Size="X-Large"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Last Name: " Font-Size="X-Large"></asp:Label>
        <br />
        <asp:TextBox ID="txtLastName" runat="server" Font-Size="X-Large"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" Display="Dynamic" ErrorMessage="You must enter your flast name" Font-Size="X-Large"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label3" runat="server" Text="DOB (dd-mm-yyyy)" Font-Size="X-Large"></asp:Label>
        <br />
        <asp:TextBox ID="txtDOB" runat="server" Font-Size="X-Large"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDOB" Display="Dynamic" ErrorMessage="You must enter your date of birth" Font-Size="X-Large"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDOB" Display="Dynamic" ErrorMessage="Must follow the dd-mm-yyyy format" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" Font-Size="X-Large"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Country:" Font-Size="X-Large"></asp:Label>
        <br />
        <asp:TextBox ID="txtCountry" runat="server" Font-Size="X-Large"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCountry" Display="Dynamic" ErrorMessage="You must enter your country" Font-Size="X-Large"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Region:" Font-Size="X-Large"></asp:Label>
        <br />
        <asp:TextBox ID="txtRegion" runat="server" Font-Size="X-Large"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRegion" Display="Dynamic" ErrorMessage="You must enter your region" Font-Size="X-Large"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Address:" Font-Size="X-Large"></asp:Label>
        <br />
        <asp:TextBox ID="txtAddress" runat="server" Font-Size="X-Large"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="You must enter your address" Font-Size="X-Large"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Email:" Font-Size="X-Large"></asp:Label>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" Font-Size="X-Large"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ErrorMessage="You must enter your email" ControlToValidate="txtEmail" Font-Size="X-Large"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email is invalid" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" Font-Size="X-Large"></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Font-Size="X-Large" />
</asp:Content>


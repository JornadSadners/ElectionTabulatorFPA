<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ballot.aspx.cs" Inherits="ElectionTabulatorFPA.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Vote</h2>
    <div class="container">
        <div class="row">
            <div class="col-sm-12 col-md-12 col-lg-4">
                <div class="panel vote-panel">
                    <div class="panel-heading">
                        <h4>Mayor</h4>
                    </div>
                    <div class="panel-body">
                        <ul class="list-group">
                            <li class="list-group-item">
                                <div class="radio sm-fluff">
<%--                                    <asp:Label ID="LabelGB" runat="server" Text="Birmingham, Gregory" AssociatedControlID="RadioButtonGB"></asp:Label>--%>
                                    <asp:RadioButton ID="RadioButtonGB" runat="server" Text="Birmingham, Gregory" GroupName="Mayor" OnCheckedChanged="RadioButton_CheckedChanged" />
                                </div>
                            </li>
                            <li class="list-group-item">
                                <div class="radio sm-fluff">
<%--                                    <asp:Label ID="LabelJDane" runat="server" Text="Dane, Joe" AssociatedControlID="RadioButtonJDane"></asp:Label>--%>
                                    <asp:RadioButton ID="RadioButtonJDane" runat="server" Text="Dane, Joe" GroupName="Mayor" OnCheckedChanged="RadioButton_CheckedChanged" />
                                </div>
                            </li>
                            <li class="list-group-item">
                                <div class="radio sm-fluff">
<%--                                    <asp:Label ID="LabelJDoe" runat="server" Text="Doe, Jane" AssociatedControlID="RadioButtonJDoe"></asp:Label>--%>
                                    <asp:RadioButton ID="RadioButtonJDoe" runat="server" Text="Doe, Jane" GroupName="Mayor" OnCheckedChanged="RadioButton_CheckedChanged" />
                                </div>
                            </li>
                            <li class="list-group-item">
                                <div class="radio sm-fluff">
<%--                                    <asp:Label ID="LabelMP" runat="server" Text="Poppy, Melissa" AssociatedControlID="RadioButtonMP"></asp:Label>--%>
                                    <asp:RadioButton ID="RadioButtonMP" runat="server" Text="Poppy, Melissa"  GroupName="Mayor" OnCheckedChanged="RadioButton_CheckedChanged" />
                                </div>
                            </li>
                             <li class="list-group-item">
                                <div class="radio sm-fluff">
                                    <asp:TextBox ID="TextBoxMayorWritein" runat="server"></asp:TextBox>
                                    <asp:RadioButton ID="RadioButtonMayorWritein" runat="server" GroupName="Mayor" OnCheckedChanged="RadioButton_CheckedChanged" />
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-sm-12 col-md-12 col-lg-4">
                <div class="panel vote-panel">
                    <div class="panel-heading">
                        <h4>City Council</h4>
                    </div>
                    <div class="panel-body">
                        <ul class="list-group">
                            <li class="list-group-item">
                                <div class="radio sm-fluff">
                                    <%--<asp:Label ID="LabelSH" runat="server" Text="Hillcrane, Sandy" AssociatedControlID="RadioButtonSH"></asp:Label>--%>
                                    <asp:RadioButton ID="RadioButtonSH" runat="server" GroupName="CityCouncil" Text="Hillcrane, Sandy" OnCheckedChanged="RadioButton_CheckedChanged" />
                                </div>
                            </li>
                            <li class="list-group-item">
                                <div class="radio sm-fluff">
                                    <asp:Label ID="LabelJJ" runat="server" Text="Jick, Jack" AssociatedControlID="RadioButtonJJ"></asp:Label>
                                    <asp:RadioButton ID="RadioButtonJJ" runat="server" GroupName="CityCouncil" OnCheckedChanged="RadioButton_CheckedChanged" />
                                </div>
                            </li>
                               <li class="list-group-item">
                                <div class="radio sm-fluff">
                                    <asp:TextBox ID="TextBoxCityCouncilWritein" runat="server"></asp:TextBox>
                                    <asp:RadioButton ID="RadioButtonCityCouncilWritein" runat="server" GroupName="CityCouncil" OnCheckedChanged="RadioButton_CheckedChanged" />
                                </div>
                            </li>
                        </ul>
                    </div>

                </div>
            </div>
            <div class="col-sm-12 col-md-12 col-lg-4">
                <div class="panel vote-panel">
                    <div class="panel-heading">
                        <h4>Superintendent</h4>
                    </div>
                    <div class="panel-body">
                        <ul class="list-group">
                            <li class="list-group-item">
                                <div class="radio sm-fluff">
                                    <asp:Label ID="LabelGF" runat="server" Text="Fink, Gertrude" AssociatedControlID="RadioButtonGF"></asp:Label>
                                    <asp:RadioButton ID="RadioButtonGF" runat="server" GroupName="Superintendent" />
                                </div>
                            </li>
                            <li class="list-group-item">
                                <div class="radio sm-fluff">
                                    <asp:Label ID="LabelFH" runat="server" Text="Holly, Frank" AssociatedControlID="RadioButtonFH"></asp:Label>
                                    <asp:RadioButton ID="RadioButtonFH" runat="server" GroupName="Superintendent" />
                                </div>
                            </li>
                            <li class="list-group-item">
                                <div class="radio sm-fluff">
                                    <asp:Label ID="LabelDJ" runat="server" Text="Johnson, Dean" AssociatedControlID="RadioButtonDJ"></asp:Label>
                                    <asp:RadioButton ID="RadioButtonDJ" runat="server" GroupName="Superintendent" />

                                </div>
                            </li>
                               <li class="list-group-item">
                                <div class="radio sm-fluff">
                                    <asp:TextBox ID="TextBoxSuperintendentWritein" runat="server"></asp:TextBox>
                                    <asp:RadioButton ID="RadioButtonSuperintendentWritein" runat="server" GroupName="Superintendent" />
                                </div>
                            </li>
                        </ul>
                    </div>

                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="submit">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-lg font-weight-bold float-right" OnClick="btnSubmit_Click" />
           </div>
                    </div>
        </div>
    </div>

</asp:Content>

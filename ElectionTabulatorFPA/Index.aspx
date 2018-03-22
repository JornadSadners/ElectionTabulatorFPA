<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ElectionTabulatorFPA.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h2>Vote then view results.</h2>
    <div class="container">
        <div class="center extra-fluff">

        <asp:Button ID="ButtonVote" runat="server" Text="Vote" CssClass="home-btn btn"  OnClick="ButtonVote_Click"/>
        <asp:Button ID="ButtonResults" runat="server" Text="View Results" CssClass="home-btn btn" OnClick="ButtonResults_Click" />
        </div>
   
    </div>
     <div class="container">
        <div id="sideBar">

                <table>
                    <thead>
                        <tr>
                            <th>Candidate Name</th>
                            <th>Seat</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Jane Doe</td>
                            <td>Mayor</td>
                        </tr>
                        <tr>
                            <td colspan="2">Jane, after being a constant victim of serious crime, has decided to run for Mayor.
                            </td>
                        </tr>
                        <tr>
                            <td>Joe Dane</td>
                            <td>Mayor</td>
                        </tr>
                        <tr>
                            <td colspan="2">Joe Dane, generic brand Mayor. Corruption Level: high.
                            </td>
                        </tr>
                        <tr>
                            <td>Jack Jick</td>
                            <td>City Council</td>
                        </tr>
                        <tr>
                            <td colspan="2">100% not a member of the Illuminati and does not want to rule the world *Wink wink*.
                            </td>
                        </tr>
                        <tr>
                            <td>Sandy Hillcrane</td>
                            <td>City Council</td>
                        </tr>
                        <tr>
                            <td colspan="2">This year's migration, Sandy has decided to land and run for office.
                            </td>
                        </tr>
                        <tr>
                            <td>Dean Johnson</td>
                            <td>Superintendent</td>
                        </tr>
                        <tr>
                            <td colspan="2">Dean Johnson has a sandwich and you will vote for him.
                            </td>
                        </tr>
                        <tr>
                            <td>Frank Holly</td> 
                            <td>Superintendent</td>
                        </tr>
                        <tr>
                            <td colspan="2"> no ones as cool as Frank Holly
                            </td>
                        </tr>
                        <tr>
                            <td>Gregory Birmingham</td>
                            <td>Mayor</td>
                        </tr>
                        <tr>
                            <td colspan="2">Gregory Birmingham believes in the revival of the british empire. Is also a super villian in his off hours.
                            </td>
                        </tr>
                        <tr>
                            <td>Melissa Poppy</td>
                            <td>Mayor</td>
                        </tr>
                        <tr>
                            <td colspan="2"> I don't know man
                            </td>
                        </tr>
                        <tr>
                            <td>Gertrude Fink</td>
                            <td>Superintendent</td>
                        </tr>
                        <tr>
                            <td colspan="2">Gertrude enjoys knitting and tea in her free time as much as her name implies
                            </td>
                        </tr>
                    </tbody>
                </table>
          </div>  </div>
</asp:Content>

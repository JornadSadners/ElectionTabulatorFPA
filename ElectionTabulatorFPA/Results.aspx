<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="ElectionTabulatorFPA.Results" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src='<%=ResolveClientUrl("~/Scripts/jquery-3.3.1.min.js") %>'></script>
     <script src='<%=ResolveClientUrl("~/Scripts/jquery.signalR-2.2.2.min.js") %>'></script>  
    <script src='<%=ResolveClientUrl("~/signalr/hubs") %>'></script>
    <script src="VoteTicker.js"></script>
    <script src="~/Scripts/sorttable.js" ></script>
    <link rel="stylesheet" href="StyleSheet.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>

    </header>
 <%--   <div class="chart">
        <asp:Chart ID="ChartVotes" runat="server">
            <Series>
                <asp:Series Name="SeriesVotes" ChartType="Line"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartAreaVotes"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>--%>
  <div class="container-fluid fluff">
     <div class="row center">
         <%--<div class="col-md-1"></div>--%>
          <div class="col-md-3">
              <asp:Button ID="Button1" runat="server" Text="View All" CssClass="btn"/>
<%--              <input id="viewAll" type="button" value="View All" class="btn" onclick="viewAll()"/>--%>
         </div>
           <div class="col-md-1">
         </div>
        <div class="col-md-2"> 
            <input id="mayor" type="button" value="For Mayor" class="btn" onclick="filterCandidates(event)"/>
            </div>
     <div class="col-md-2">
         <input id="city" type="button" value="For City Council" class="btn" onclick="filterCandidates(event)"/>
         </div> 
     <div class="col-md-2">
         <input id="superintendent" type="button" value="For Superintendent" class="btn" onclick="filterCandidates(event)"/>
         </div> 
          <div class="col-md-2">
         </div>
         </div>
  </div>
    <div class="container-fluid">
        <%-- <div class="row-header center">
     <div class="col-md-9"><h2>Live Results Table</h2>
     </div>
 </div>--%>
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
   <script type="text/javascript">
       //modified from: https://www.w3schools.com/howto/tryit.asp?filename=tryhow_js_filter_table
       function filterCandidates(event) {  
            btn = event.target;
           filter = btn.id.toUpperCase();
           table = document.getElementById("results");
           tr = table.getElementsByTagName("tr");
           for (i = 0; i < tr.length; i++) {
               td = tr[i].getElementsByTagName("td")[3];
               if (td) {
                   if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                       tr[i].style.display = "";
                   } else {
                       tr[i].style.display = "none";
                   }
               }
           }
       }
      </script>

</asp:Content>

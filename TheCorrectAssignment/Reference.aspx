<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reference.aspx.cs" Inherits="TheCorrectAssignment.About" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />

    <div class="container-fluid">
	<div class="row">
		<div class="col-md-3">
		</div>
		<div class="col-md-9">
			<div class="row">
				<div class="col-md-4">

					   <table>
            <tr>
                <td>
                   Profiles
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Height="272px" Width="281px">
                         <Columns>
                            <asp:BoundField HeaderText="ID"               DataField="Profile_ID"/>
                            <asp:BoundField HeaderText="Type"     DataField="Profile"/>
                         </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

				</div>
				<div class="col-md-4">

                       <table>
            <tr>
                <td>
                   Accounts
                </td>
            </tr>
            <tr>
                <td>
                     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" Height="272px" Width="281px">
                         <Columns>
                            <asp:BoundField HeaderText="ID"               DataField="ID"/>
                            <asp:BoundField HeaderText="Type"     DataField="Account_Type"/>
                         </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

				</div>
				<div class="col-md-4">

                       <table>
            <tr>
                <td>
                   Cards
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" Height="272px" Width="281px">
                         <Columns>
                            <asp:BoundField HeaderText="ID"               DataField="ID"/>
                            <asp:BoundField HeaderText="Type"     DataField="Card_Type"/>
                         </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>

				</div>
			</div>
		</div>
	</div>
</div>
    

    
</asp:Content>

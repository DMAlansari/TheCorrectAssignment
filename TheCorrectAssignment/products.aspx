<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="TheCorrectAssignment.products" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />

    
    <div class="container-fluid">
	<div class="row">
		<div class="col-md-3">

		</div>

		<div class="col-md-9">
			 
			 <table>
            <tr>
                <td style="font-size: medium">
                    <strong>Accounts
                </strong>
                </td>
                <td style="font-size: medium">
                    <strong>Cards
                </strong>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridViewAccounts" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" OnSelectedIndexChanged="GridViewAccounts_SelectedIndexChanged1" Width="320px">
                        <Columns >
                            <asp:BoundField DataField="Civil_ID"   HeaderText ="Civil ID" /> 
                            <asp:BoundField DataField="Account_ID" HeaderText="Account Number" /> 
                            <asp:BoundField DataField="Balance"    HeaderText="Balance" /> 
                            
                        </Columns>

                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#37474F" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#487575" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#275353" />

                    </asp:GridView>
                </td>
                <td>
                       <asp:GridView ID="GridViewCards" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Width="234px">
                        <Columns >
                            <asp:BoundField DataField="Card_ID" HeaderText="Card Number" /> 
                            <asp:BoundField DataField="Card_Type"    HeaderText="Card Type" /> 
                            
                        </Columns>

                           <FooterStyle BackColor="White" ForeColor="#333333" />
                           <HeaderStyle BackColor="#37474F" Font-Bold="True" ForeColor="White" />
                           <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                           <RowStyle BackColor="White" ForeColor="#333333" />
                           <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                           <SortedAscendingCellStyle BackColor="#F7F7F7" />
                           <SortedAscendingHeaderStyle BackColor="#487575" />
                           <SortedDescendingCellStyle BackColor="#E5E5E5" />
                           <SortedDescendingHeaderStyle BackColor="#275353" />

                    </asp:GridView>
                </td>
            </tr>

        </table>
		</div>
		</div>
		</div>

</asp:Content>



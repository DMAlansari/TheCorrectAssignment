<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="new_client.aspx.cs" Inherits="TheCorrectAssignment.WebForm1" %>
<%@ MasterType VirtualPath="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
	
    <div class="container-fluid">
	<div class="row">
		<div class="col-md-3">
		</div>
		<div class="col-md-9">
			<h3>
				New Client
			</h3>
			<hr />

			<asp:TextBox ID="CivilID" runat="server" placeholder="Civil ID"></asp:TextBox>
			<asp:TextBox ID="RIM_Number" runat="server" placeholder="RIM Number"></asp:TextBox>
			<asp:TextBox ID="Name" runat="server" placeholder="Name"></asp:TextBox>
			<asp:TextBox ID="Gender" runat="server" placeholder="Gender"></asp:TextBox>
			<asp:TextBox ID="Address" runat="server" placeholder="Address"></asp:TextBox>
			<asp:TextBox ID="Phone_Number" runat="server" placeholder="Phone Number"></asp:TextBox>
			<asp:TextBox ID="Type_ID" runat="server" placeholder="Type ID"></asp:TextBox>
			<asp:TextBox ID="Account_ID" runat="server" placeholder="Account ID"></asp:TextBox>
			<asp:TextBox ID="Account_Type" runat="server" placeholder="Account Type"></asp:TextBox>
			<asp:TextBox ID="Balance" runat="server" placeholder="Balance"></asp:TextBox>
			<asp:TextBox ID="Card_ID" runat="server" placeholder="Card ID"></asp:TextBox>
			<asp:TextBox ID="Card_Type" runat="server" placeholder="Card Type"></asp:TextBox>
            <asp:ListView ID="ListView2" runat="server" DataSourceID="CardType" DataKeyNames="ID">
                <AlternatingItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label Text='<%# Eval("ID") %>' runat="server" ID="IDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Card_Type") %>' runat="server" ID="Card_TypeLabel" /></td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Eval("ID") %>' runat="server" ID="IDLabel1" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("Card_Type") %>' runat="server" ID="Card_TypeTextBox" /></td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# Bind("ID") %>' runat="server" ID="IDTextBox" /></td>
                        <td>
                            <asp:TextBox Text='<%# Bind("Card_Type") %>' runat="server" ID="Card_TypeTextBox" /></td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label Text='<%# Eval("ID") %>' runat="server" ID="IDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Card_Type") %>' runat="server" ID="Card_TypeLabel" /></td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                                    <tr runat="server" style="">
                                        <th runat="server">ID</th>
                                        <th runat="server">Card_Type</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style=""></td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Label Text='<%# Eval("ID") %>' runat="server" ID="IDLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Card_Type") %>' runat="server" ID="Card_TypeLabel" /></td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource runat="server" ID="CardType" ConnectionString='<%$ ConnectionStrings:myConnection %>' SelectCommand="SELECT [ID], [Card_Type] FROM [Card_Type] ORDER BY [ID]"></asp:SqlDataSource>
            <div class="submitdiv">
			<asp:Button Class="btn btn-primary" ID="submitNewClient" runat="server" Text="submit" OnClick="submitNewClient_Click" />
			</div>
			
			
		</div>
	</div>
</div>

</asp:Content>



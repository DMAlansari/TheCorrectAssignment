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
            <div class="submitdiv">
			<asp:Button Class="btn btn-primary" ID="submitNewClient" runat="server" Text="submit" OnClick="submitNewClient_Click" />
			</div>
			
			
		</div>
	</div>
</div>

</asp:Content>



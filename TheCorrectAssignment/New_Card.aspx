<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="New_Card.aspx.cs" Inherits="TheCorrectAssignment.New_Card" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
	
    <div class="container-fluid">
	<div class="row">
		<div class="col-md-3">
		</div>
		<div class="col-md-9">
			<h3>
				New Card
			</h3>
			<hr />

			<asp:TextBox ID="CardID" runat="server" placeholder="Card ID"></asp:TextBox>
			<asp:TextBox ID="Card_TypeID" runat="server" placeholder="Card Type ID"></asp:TextBox>
			<asp:TextBox ID="Civil_ID" runat="server" placeholder="Civil ID"></asp:TextBox>
			<asp:TextBox ID="Account_ID" runat="server" placeholder="Account ID"></asp:TextBox>
			
			<div class="submitdiv">
			<asp:Button Class="btn btn-primary" ID="submitNewClient" runat="server" Text="submit" OnClick="submitNewClient_Click" />
			</div>
		</div>
	</div>
</div>
</asp:Content>

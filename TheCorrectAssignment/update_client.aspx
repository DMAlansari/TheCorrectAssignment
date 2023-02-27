<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="update_client.aspx.cs" Inherits="TheCorrectAssignment.update_client" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
	
	<div class="container-fluid">
	<div class="row">
		<div class="col-md-3">
		</div>
		<div class="col-md-9">
			<h3 class="update_h3">
				Update Client's Information
			</h3>
			
			<hr />
			<br />
			
			<div class="row">
				<div class="col-md-4">
					<div class="update_pageheader">
				
				Client Rim Number:<asp:TextBox ID="RIM_Number" runat="server"></asp:TextBox>
			</div>
					
				<div class="col-md-8">
					<div class="update_fields">
			<asp:TextBox ID="Civil_ID" runat="server" placeholder="Civil ID"></asp:TextBox><br />
			<asp:TextBox ID="Name" runat="server" placeholder="Name"></asp:TextBox><br />
			<asp:TextBox ID="Gender" runat="server" placeholder="Gender"></asp:TextBox><br />
			<asp:TextBox ID="Address" runat="server" placeholder="Address"></asp:TextBox><br />
			<asp:TextBox ID="Phone_Number" runat="server" placeholder="Phone_Number"></asp:TextBox>
			</div>
					<br />
					<br />
					<br />
					<br />
					<br />
					<br />
					<br />
			<div class="submit_update_page">
			<asp:Button Class="btn btn-primary" ID="updatebtn" runat="server" Text="update" OnClick="submitNewClient_Click" />
			</div>
				</div>
			</div>
		</div>
	</div>
</div>

    
</div>
</asp:Content>

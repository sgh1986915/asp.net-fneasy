<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="OwnerEdit.aspx.cs" Inherits="OwnerEdit" %>

<%@ MasterType VirtualPath="~/admin/AdminMasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--startoutrbanner-->
<div id="outerbanner2">
	<!--startbanner-->
	<div id="banner2">
		<p>
			Owner Edit
		</p>
		<div class="spacer">
		</div>
	</div>
	<!--closebanner-->
</div>
<!--closedouterbanner-->
<div id="mainbody">
	<!--startmidbody-->
	<div id="midbody">
		<!--startcontent-->
		<div id="Div1">
			<div id="benefit">
				<h3>Owner Edit</h3>
                <table border="0" width="600">
                    <tr>
                        <td align="left" width="160"><p><asp:Label ID="Label1" runat="server" Text="Email Address"></asp:Label>:</p> </td>
                        <td align="left"> 
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        </td>
                        <td align="left"> </td>
                        <td align="left" width="20%"> </td>
                    </tr>
                    <tr>
                        <td align="left" width="160"><p><asp:Label ID="Label4" runat="server" Text="Business Name"></asp:Label>:</p> </td>
                        <td align="left"> 
                            <asp:TextBox ID="txtBusinessName" runat="server"></asp:TextBox>
                        </td>
                        <td align="left"> </td>                        
                        <td align="left" width="20%"> </td>
                    </tr>
                    <tr>
                        <td align="left" width="160"><p><asp:Label ID="Label5" runat="server" Text="Address"></asp:Label>:</p> </td>
                        <td align="left"> 
                            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                        </td>
                        <td align="left"> </td>
                        <td align="left" width="20%"> </td>
                    </tr>
                    <tr>
                        <td align="left" width="160"><p><asp:Label ID="Label8" runat="server" Text="Phone Number"></asp:Label>:</p> </td>
                        <td align="left"> 
                            <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                        </td>
                        <td align="left"> </td>
                        <td align="left" width="20%"> </td>
                    </tr>
                    <tr>
                        <td align="left" width="160"><p><asp:Label ID="Label9" runat="server" Text="Name To Display"></asp:Label>:</p> </td>
                        <td align="left"> 
                            <asp:TextBox ID="txtNameToDisplay" runat="server"></asp:TextBox>
                        </td>
                        <td align="left"> </td>
                        <td align="left" width="20%"> </td>
                    </tr>
                    <tr>
                        <td align="left" width="160"><p><asp:Label ID="Label10" runat="server" Text="Contact Person"></asp:Label>:</p> </td>
                        <td align="left"> 
                            <asp:TextBox ID="txtContactPerson" runat="server"></asp:TextBox>
                        </td>
                        <td align="left"> </td>
                        <td align="left" width="20%"> </td>
                    </tr>
                    <tr>
                        <td align="left" width="160"><p><asp:Label ID="Label11" runat="server" Text="Activation Code"></asp:Label>:</p> </td>
                        <td align="left"> 
                            <asp:TextBox ID="txtActivationCode" runat="server"></asp:TextBox>
                        </td>
                        <td align="left"> </td>
                        <td align="left" width="20%"> </td>
                    </tr>
                    <tr>
                        <td align="left" width="160"> </td>
                        <td align="left" > 
                           <asp:Button ID="SubmitBtn" runat="server" Text="Submit" onclick="SubmitBtn_Click" />
                        </td>
                        <td align="left"> </td>
                        <td align="left" width="20%"> </td>
                    </tr>
                </table>
			</div>
			<div class="spacer">
			</div>
		</div>
		<!--closecontent-->
		<div class="spacer">
		</div>
	</div>
	<!--closemidbody-->
	<div class="spacer">
	</div>
</div>
</asp:Content>

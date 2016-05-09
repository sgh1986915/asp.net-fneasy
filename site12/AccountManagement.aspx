<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AccountManagement.aspx.cs" Inherits="AccountManagement" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--startoutrbanner-->
<div id="outerbanner2">
	<!--startbanner-->
	<div id="banner2">
		<p>
			Account Management
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
			<div class="detailcontdiv" >
				<h3>Account Management</h3>
				<p>&nbsp;</p>

      
      
        <table border="0" width="600">
        
            <tr>
                <td align="left" width="160" ><p><asp:Label ID="Label1" runat="server" Text="Business Name"></asp:Label>:</p> </td>
                <td align="left" ><asp:TextBox ID="BusinessName_txt" runat="server"></asp:TextBox> </td>
                <td align="left" width="20%"  > </td>
            </tr>
            <tr>
                <td align="left" width="160" ><p><asp:Label ID="Label2" runat="server" Text="Address"></asp:Label>:</p> </td>
                <td align="left" ><asp:TextBox ID="Address_txt" runat="server"></asp:TextBox> </td>
                <td align="left" width="20%"  > </td>
            </tr>
            <tr>
                <td align="left" width="160"><p><asp:Label ID="Label3" runat="server" Text="Phone Number"></asp:Label>: </p></td>
                <td align="left" ><asp:TextBox ID="PhoneNumber_txt" runat="server"></asp:TextBox> </td>
                <td align="left" width="20%"  > </td>
            </tr>
             <tr>
                <td align="left" width="160" ><p><asp:Label ID="Label4" runat="server" Text="Email Address"></asp:Label>: </p> </td>
                <td align="left" ><asp:TextBox ID="Email_txt" runat="server"></asp:TextBox> </td>
                <td align="left" width="20%"  > </td>
            </tr>
            
             <tr>
                <td align="left" width="160" > <p><asp:Label ID="Label6" runat="server" Text="Trading name to display"></asp:Label>: </p></td>
                <td align="left" > <asp:TextBox ID="Tradingname_txt" runat="server"></asp:TextBox></td>
                <td align="left" width="20%"  > </td>
            </tr>
             <tr>
                <td align="left" width="160" ><p><asp:Label ID="Label7" runat="server" Text="Contact Person"></asp:Label>: </p> </td>
                <td align="left" ><asp:TextBox ID="ContactPerson_txt" runat="server"></asp:TextBox> </td>
                <td align="left" width="20%"  > </td>
            </tr>
            
        </table>
        

        <p>&nbsp;</p>
      <p>
            <asp:HiddenField ID="package_id" runat="server" />
            
            <asp:HiddenField ID="buy_type" runat="server" />
            
                  
	  </p>
      
      
      <p><asp:Button ID="submit_btn" runat="server" Text="Submit" 
              onclick="submit_btn_Click" /> </p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>
      <p>&nbsp;</p>



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


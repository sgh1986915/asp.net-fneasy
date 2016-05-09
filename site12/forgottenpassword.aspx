<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="forgottenpassword.aspx.cs" Inherits="forgottenpassword" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--startoutrbanner-->
<div id="outerbanner2">
	<!--startbanner-->
	<div id="banner2">
		<p>
			Forgotten Password
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
				<h3>Please enter your  email , our system will generate a new password from scratch and email it to you</h3>



                <p>
     
      
                </p>
                 <table border="0" width="600">
        
                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>:</p> </td>
                        <td align="left" ><asp:TextBox ID="Email_txt" runat="server"></asp:TextBox> </td>
                        <td align="left" width="20%"  > </td>
                    </tr>

                </table>

                <p>&nbsp;</p>
                 <p><asp:Button ID="submit_btn" runat="server" Text="Submit" 
              onclick="submit_btn_Click"  /> </p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>

                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
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


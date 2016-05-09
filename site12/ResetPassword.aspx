<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="css/createaccount.css" rel="stylesheet" type="text/css" />
<!--startoutrbanner-->
<div id="outerbanner2">
	<!--startbanner-->
	<div id="banner2">
		<p>
			Reset Password
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
		
			<div id="reset_pass" >
				

                 <table border="0" width="600px">
        
                    <tr>
                        <td class="td1" ><p> <asp:Label ID="Label1" runat="server" Text="Old Password"></asp:Label>:</p> </td>
                        <td class="td2" > <asp:TextBox CssClass="signuptxt" ID="Oldpassword_txt" runat="server" TextMode="Password" ></asp:TextBox> </td>
                        
                    </tr>
                   <tr>
                        <td class="td1" ><p> <asp:Label ID="Label8" runat="server" Text="New Password"></asp:Label>:</p> </td>
                        <td class="td2" > <asp:TextBox CssClass="signuptxt" ID="Password_txt" runat="server" TextMode="Password" ></asp:TextBox> </td>
                        
                    </tr>
                     <tr>
                        <td class="td1" > <p> <asp:Label ID="Label9" runat="server" Text="Verify Password"></asp:Label>: </p></td>
                        <td class="td2" ><asp:TextBox CssClass="signuptxt" ID="VerifyPassword_txt" runat="server" TextMode="Password" ></asp:TextBox>  </td>
                        
                    </tr>
                    <tr><td></td><td><div  class="btn_con"> <asp:Button ID="submit_btn" CssClass="signup_btn" runat="server" Text="Submit" 
              onclick="submit_btn_Click" /></div>  </td></tr>
            
                </table>

             
      <p>
            <asp:HiddenField ID="package_id" runat="server" />
            
            <asp:HiddenField ID="buy_type" runat="server" />
            
                  
	  </p>
      
      

     
               
			</div>
			<div class="spacer">
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


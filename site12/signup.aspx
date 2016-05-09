<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>

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
			<asp:Label ID="headertxt" runat="server" Text="Sign Up"></asp:Label>
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
				
    

      <div id="package_con">
      <ul>
      <li>Package : <asp:Label ID="package_name" CssClass="package_info" runat="server" Text=""></asp:Label>    for <asp:Label CssClass="package_info" ID="sitename" runat="server" Text=""></asp:Label> </li>
    
      <li class="btn_con_s">
            <asp:HiddenField ID="package_id" runat="server" />
            

            <asp:Button CssClass="signup_btn" ID="nowbuy_btn" runat="server" Text="Buy Now" 
                onclick="nowbuy_btn_Click" /> 
      
	  </li>
      </ul>
      </div>
      
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


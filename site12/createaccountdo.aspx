<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createaccountdo.aspx.cs" Inherits="createaccountdo" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--startoutrbanner-->
<div id="outerbanner2">
	<!--startbanner-->
	<div id="banner2">
		<p>
			Sign Up
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
				 <p>
      <asp:Label ID="showinfo" runat="server" Text=" "></asp:Label>
     </p>
      
     
     
      
     
      <p>&nbsp;</p>
      <p>
            <asp:HiddenField ID="package_id" runat="server" />
            
            <asp:HiddenField ID="buy_type" runat="server" />
            
                  
	  </p>
      
      
      <p> </p>
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


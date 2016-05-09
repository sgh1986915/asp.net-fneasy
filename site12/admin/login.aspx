<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="outerbanner2">
	<!--startbanner-->
	<div id="banner2">
		<p>
			Login
		</p>
		<div class="spacer">
		</div>
	</div>
	<!--closebanner-->
</div>
<div id="mainbody">
	<!--startmidbody-->
	<div id="midbody">
		<!--startcontent-->
        <div style="text-align: center; height:400px;">
            <asp:Panel ID="headerPanel1" runat="server">
                <div id="login">
				    UserName: <asp:TextBox  ID="txtUsername"  runat="server" class="login" ></asp:TextBox>
			    </div>
			    <div id="password">
				    Password: <asp:TextBox  ID="txtPassword"  runat="server" class="password" TextMode="Password" ></asp:TextBox>
			    </div>
                <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" Text="Login" />
                <a class="forgotlink"  href="#">forgot password</a>
            </asp:Panel>
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


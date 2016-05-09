<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TopWebControl.ascx.cs" Inherits="controls_TopWebControl" %>
<!--startouterheader-->
<div id="outerheader" >
	<!--startmainheader-->
	<div id="mainheader">
		<div id="logo">
			<a href="index.aspx"><img src="images/logo.jpg" width="135" height="60" border="0" /></a>
		</div>
		<div id="rightheader">
			<div id="headerinput">
				<div id="login">
					<input type="text" name="login" value="login" class="login" />
				</div>
				<div id="password">
					<input type="text" name="password" value="*******" class="password" />
				</div>
				<a href="#"><img src="images/login-butoon.gif" width="61" height="24" border="0" /></a>
			</div>
			<div id="headernav">
				<ul>
					<li><a href="index.aspx" class="active">Home</a></li>
					<li><a href="benefits.aspx">Benefits</a></li>
					<li><a href="about-us.aspx">About Us</a></li>
					<li><a href="contact-us.aspx">Contact Us</a></li>
				</ul>
				<div class="spacer">
				</div>
			</div>
			<div class="spacer">
			</div>
		</div>
		<div class="spacer">
		</div>
	</div>
	<!--closemainheader-->
</div>
<!--closedouterheader-->

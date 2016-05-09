<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="createaccount.aspx.cs" Inherits="createaccount" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<meta http-equiv="X-UA-Compatible" content="IE=9" />
    <link href="css/createaccount.css" rel="stylesheet" type="text/css" />

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
		<div >
			<div id="signup_con" >
				
      <p>&nbsp;</p>

      
      
        <table border="0" width="600">
        
            <tr>
            
                <td class="td1"  ><p><asp:Label ID="Label1" runat="server" Text="Business Name"></asp:Label>:</p> </td>
                <td  class="td2"  > <asp:TextBox CssClass="signuptxt" ID="BusinessName_txt" runat="server"></asp:TextBox> 
                   </td>
               
            </tr>
  
            <tr>
                <td class="td1"  style="vertical-align:middle;"  ><p><asp:Label ID="Label2" runat="server" Text="Address"></asp:Label>:</p> </td>
                <td class="td2"  style=" padding:5px;"  ><asp:TextBox ValidationGroup="sfrm" CssClass="signuptxt" ID="Address_txt" TextMode="MultiLine" runat="server"></asp:TextBox> 
               <span>*</span></td>
               
            </tr>
            <tr>
                <td  class="td1" ><p><asp:Label ID="Label3" runat="server" Text="Phone Number"></asp:Label>: </p></td>
                <td class="td2" ><asp:TextBox CssClass="signuptxt" ID="PhoneNumber_txt" runat="server"></asp:TextBox> </td>
               
            </tr>
             <tr>
                <td   class="td1" ><p><asp:Label ID="Label4" runat="server" Text="Email Address"></asp:Label>: </p> </td>
                <td class="td2"  ><asp:TextBox CssClass="signuptxt" ID="Email_txt" runat="server"></asp:TextBox><span>*</span> </td>
               
            </tr>
             <tr>
                <td   class="td1" ><p><asp:Label ID="Label5" runat="server" Text="Username"></asp:Label>:</p> </td>
                <td class="td2" > <asp:TextBox CssClass="signuptxt" ID="Username_txt" runat="server"></asp:TextBox><span>*</span> </td>
               
            </tr>
             <tr>
                <td   class="td1" > <p><asp:Label ID="Label6" runat="server" Text="Trading name to display"></asp:Label>: </p></td>
                <td  class="td2" > <asp:TextBox CssClass="signuptxt" ID="Tradingname_txt" runat="server"></asp:TextBox><span>*</span></td>
               
            </tr>
             <tr>
                <td  class="td1"  ><p><asp:Label ID="Label7" runat="server" Text="Contact Person"></asp:Label>: </p> </td>
                <td class="td2" ><asp:TextBox CssClass="signuptxt" ID="ContactPerson_txt" runat="server"></asp:TextBox> </td>
               
            </tr>
             <tr>
                <td  class="td1"   ><p> <asp:Label ID="Label8" runat="server" Text="Password"></asp:Label>:</p> </td>
                <td class="td2"  > <asp:TextBox CssClass="signuptxt" ID="Password_txt" runat="server" TextMode="Password" ></asp:TextBox> <span>*</span> </td>
               
            </tr>
             <tr>
                <td  class="td1"  > <p> <asp:Label ID="Label9" runat="server" Text="Verify Password"></asp:Label>: </p></td>
                <td class="td2" ><asp:TextBox ID="VerifyPassword_txt" runat="server" TextMode="Password" ></asp:TextBox> <span>*</span> </td>
               
            </tr>
             <tr>
                <td  class="td1"  ><p> <asp:Label ID="Label10" runat="server" Text="Activation Code"></asp:Label>:</p>  </td>
                <td class="td2" ><asp:TextBox CssClass="signuptxt" ID="ActivationCode_txt" runat="server"></asp:TextBox>  <span>*</span> </td>
               
            </tr>
            <tr>
            <td>
            </td>
            <td>
            <div class="btn_con">
            <asp:Button ValidationGroup="sfrm" CssClass="signup_btn" ID="submit_btn" runat="server" Text="Submit" 
              onclick="submit_btn_Click" />
              </div>
            </td>
            <td>
            </td>
            </tr>
        </table>
      
      
      
      
      
     
     
      
     
      <p>
            <asp:HiddenField ID="package_id" runat="server" />
            
            <asp:HiddenField ID="buy_type" runat="server" />
            
                  
	  </p>
      
      
      
               

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


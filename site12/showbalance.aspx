<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="showbalance.aspx.cs" Inherits="showbalance" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--startoutrbanner-->
<div id="outerbanner2">
	<!--startbanner-->
	<div id="banner2">
		<p>
			Balance
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
				<h3>Your balance as follow:</h3>



                <p>
     
      
                </p>
                <table border="0" width="700">
        
            <tr>
                <td align="left" width="300" ><p><asp:Label ID="Label1" runat="server" Text="SMS Total"></asp:Label>:</p> </td>
                <td align="left" ><asp:TextBox ID="total_sms_txt" runat="server" ReadOnly="true" ></asp:TextBox> </td>
                <td align="left" width="10%"  > </td>
                <td align="left" width="300" ><p><asp:Label ID="Label2" runat="server" Text="Used SMS"></asp:Label>:</p> </td>
                <td align="left" ><asp:TextBox ID="used_sms_txt" runat="server" ReadOnly="true" ></asp:TextBox> </td>
                <td align="left" width="10%"  > </td>
            </tr>
           
             <tr>
                <td align="left" width="300" ><p><asp:Label ID="Label3" runat="server" Text="Volume Total"></asp:Label>:</p> </td>
                <td align="left" ><asp:TextBox ID="total_valume_txt" runat="server" ReadOnly="true" ></asp:TextBox> </td>
                <td align="left" width="10%"  > </td>
                <td align="left" width="300" ><p><asp:Label ID="Label4" runat="server" Text="Used Volume"></asp:Label>:</p> </td>
                <td align="left" ><asp:TextBox ID="used_valume_txt" runat="server" ReadOnly="true" ></asp:TextBox> </td>
                <td align="left" width="10%"  > </td>
            </tr>
            
             
        </table>

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

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VisitorAdd.aspx.cs" Inherits="VisitorAdd" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
    
        #DateSelector
        {
            display:none;
            z-index:200;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function PopupWindow() {

            var CalenderWindow = document.getElementById("DateSelector");

            CalenderWindow.style.display = "block";

        }    
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--startoutrbanner-->
<div id="outerbanner2">
	<!--startbanner-->
	<div id="banner2">
		<p>
			Visitor Add
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
				<h3>Visitor Add
                </h3>
                <table border="0" width="600">
                     <tr>
                        <td align="left" width="160" > Campaign Name:</td>
                        <td align="left" > 
                            
                           
                            
                            <asp:DropDownList ID="CampaignDropDownList" runat="server">
                            </asp:DropDownList>
                            
                           
                            
                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>
                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label1" runat="server" Text="Email"></asp:Label>:</p> </td>
                        <td align="left" > 

                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            

                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>
                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label4" runat="server" Text="Mobile Number"></asp:Label>:</p> </td>
                        <td align="left" > 

                            <asp:TextBox ID="txtMobileNumber" runat="server"></asp:TextBox>
                            

                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>
                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label5" runat="server" Text="First Name"></asp:Label>:</p> </td>
                        <td align="left" > 

                            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                            

                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>
                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label6" runat="server" Text="Last Name"></asp:Label>:</p> </td>
                        <td align="left" > 

                            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                            

                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>
                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label7" runat="server" Text="Driving Licence Number"></asp:Label>:</p> </td>
                        <td align="left" > 

                            <asp:TextBox ID="txtDrivingLicenceNumber" runat="server"></asp:TextBox>
                            

                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>

                   <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label8" runat="server" Text="Address"></asp:Label>:</p> </td>
                        <td align="left" > 

                            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                            

                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>

                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label9" runat="server" Text="State"></asp:Label>:</p> </td>
                        <td align="left" > 

                            <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
                            

                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>

                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label10" runat="server" Text="Postcode"></asp:Label>:</p> </td>
                        <td align="left" > 

                            <asp:TextBox ID="txtPostcode" runat="server"></asp:TextBox>
                            

                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>


                   
                   
                    <tr>
                        <td align="left" width="160" > Age:</td>
                        <td align="left" > 
                            
                           
                            
                            <asp:DropDownList ID="AgeDropDownList" runat="server">
                            </asp:DropDownList>
                            
                           
                            
                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>

                    <tr>
                        <td align="left" width="160" > </td>
                        <td align="left" > 
                            
                           
                            
                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>

                     <tr>
                        <td align="left" width="160" > </td>
                        <td align="left" > 
                            
                           <asp:Button ID="SubmitBtn" runat="server" Text="Submit" 
                                onclick="SubmitBtn_Click" />
                            
                        </td>
                        <td align="left"  > 
                            
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
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


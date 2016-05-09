<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CampaignAdd.aspx.cs" Inherits="CampaignAdd" %>

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
			Campaign Add
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
				<h3>Campaign Add
                </h3>
                <table border="0" width="600">
                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label1" runat="server" Text="Campaign Name"></asp:Label>:</p> </td>
                        <td align="left" > 

                            <asp:TextBox ID="txtCampaignName" runat="server"></asp:TextBox>
                            

                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>
                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label4" runat="server" Text="Show"></asp:Label>:</p> </td>
                        <td align="left" > 

                            <asp:TextBox ID="txtCampainShow" runat="server"></asp:TextBox>
                            

                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>
                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label5" runat="server" Text="Venue"></asp:Label>:</p> </td>
                        <td align="left" > 

                            <asp:TextBox ID="txtCampainVenue" runat="server"></asp:TextBox>
                            

                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>
                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label7" runat="server" Text="Date"></asp:Label>:</p> </td>
                        <td align="left" > 

                            <asp:TextBox ID="txtCampainDate" runat="server" ReadOnly="true" ></asp:TextBox>
                            <img src="images/Calendar_scheduleHS.png" alt="Click To Choose Date"  onclick="PopupWindow()" />
                            
                            <div id="DateSelector" >
                                <asp:Calendar ID="Calendar1" runat="server"   OnSelectionChanged="Calendar1_SelectionChanged" ></asp:Calendar>
                            </div>
                            
                            

                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>

                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label6" runat="server" Text="Logo"></asp:Label>:</p> </td>
                        <td align="left" > 

                            
                            <asp:FileUpload ID="LogoFileUpload1" runat="server" />

                        </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>
                    
                   
                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label2" runat="server" Text="Package Site"></asp:Label>:</p> </td>
                        <td align="left" > 
                            <asp:DropDownList ID="SiteDropDownList" runat="server"  AutoPostBack="True"
                                onselectedindexchanged="SiteDropDownList_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align="left"  > </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>

                    <tr>
                        <td align="left" width="160" > <p><asp:Label ID="Label8" runat="server" Text="Background Color"></asp:Label>:</p></td>
                        <td align="left" > 
                            
                           
                            
                            <asp:DropDownList ID="BgColorDropDownList" runat="server">
                            </asp:DropDownList>
                            
                            
                            </td>
                        <td align="left"  > 
                            
                        </td>
                        
                        <td align="left" width="20%"  > </td>
                    </tr>


                    <tr>
                        <td align="left" width="160" ><p><asp:Label ID="Label3" runat="server" Text="Field Selection"></asp:Label>:</p> </td>
                        <td align="left" > 
                            <asp:CheckBoxList ID="MainFieldCheckBoxList" runat="server" Enabled="False" 
                                ForeColor="#FF9933" >
                            </asp:CheckBoxList>
                            <asp:CheckBoxList ID="FieldCheckBoxList" runat="server">
                            </asp:CheckBoxList>
                            
                            
                            
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

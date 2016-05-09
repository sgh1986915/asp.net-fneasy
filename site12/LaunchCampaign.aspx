<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LaunchCampaign.aspx.cs" Inherits="LaunchCampaign" %>



<html >
<head runat="server">
    <title>capture screen</title>

    <script type="text/javascript" charset="uft-8">


       // window.onload = function () {

            //window.open(location.href, "newwindow", "fullscreen=3,height=300, width=300, top=0, left=0, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no");
       // }

        //window.moveTo(0, 0);
        //window.resizeTo(screen.availWidth, screen.availHeight);

        
       

    </script>
    <script src="./js/jquery-1.6.4.min.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript" charset="uft-8">
        /*
        window.onbeforeunload = function () {

            var isclose = $("#Labelshow").html();
            
            if (isclose == "close") {
              
            } else {
               
                //window.open('LaunchCampaign.aspx', 'newwindow', 'fullscreen=3, top=0, left=0, height=1200, width=1600,toolbar=no, menubar=no, scrollbars=no, location=no,   status=no,resizable=no,location=no');
                return "";
            }
        } 
        */



	</script> 
    <link rel="stylesheet" href="buttons/style_button.css" type="text/css" />
	
	
   
    
    <style type="text/css">
        .style1
        {
            width: 206px;
        }
    </style>
	
	
   
    
</head>
<body  bgcolor="<%=mybgcolor %>" >
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer ID="Timer1"  OnTick="Timer_Tick" runat="server" Interval="3000" ></asp:Timer>
    <div>
    <table border="0"  align="center"  width="96%"  >
        <tr>
            <td width="90%">&nbsp;
            </td>
            <td align="right">
            
                <asp:Button ID="ExitButton" runat="server" Text="Exit" 
                    onclick="ExitButton_Click" />
            
            </td>
        </tr>
    </table>
    <table border="0" width="100%" height="100%" align="center"   >
	<tr>
		<td valign="middle" align="center" width="100%" height="100%"  >

        
            
            <p>
        
                <asp:Image ID="LogoImage" runat="server" />
                <asp:Label ID="Labelshow" runat="server" Text="" ForeColor="AliceBlue"  Visible="false" ></asp:Label>
    </p>
    <asp:Panel ID="ShowInfoPanel"   runat="server" BackColor="AliceBlue"  >
        <asp:Label ID="ShowInfoLabel" runat="server" Text="Label"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="UserLoginPanel" runat="server" BackColor="ActiveBorder" BorderStyle="Dotted" >
    <table border="0"   align="center"   >
        <tr>
            <td  colspan="2"  align="left" ><asp:Label ID="Label3" runat="server" Text="Please input Owner username  and password to exit  capture screen, only Owner can exit capture screen . " ForeColor="AliceBlue" Font-Size="32px"  ></asp:Label></td>
            
        </tr>
        <tr>
            <td width="210" align="left" ><asp:Label ID="Label1" runat="server" Text="Account:" ForeColor="AliceBlue" Font-Size="30px"  ></asp:Label></td>
            <td width="80%" >
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td width="210" align="left" ><asp:Label ID="Label2" runat="server" Text="Password:" ForeColor="AliceBlue" Font-Size="30px"  ></asp:Label></td>
            <td width="80%" >
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"  ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="210" align="left" ></td>
            <td width="80%" >
                <asp:Button ID="LoginSubmit" runat="server" Text="Submit" 
                    onclick="LoginSubmit_Click" />
                <asp:Button ID="LoginCancel" runat="server" Text="Cancel" 
                    onclick="LoginCancel_Click" />
            </td>
            
        </tr>
    </table>
    </asp:Panel> 
    <asp:Panel ID="inputAreaPanel" runat="server">
        <asp:Panel ID="EmailAddressPanel" runat="server">
        <table border="0"   align="center"   >
            <tr>
                <td width="260" align="left" ><asp:Label ID="Label10" runat="server" Text="Email Address:" ForeColor="AliceBlue" Font-Size="36px"  ></asp:Label></td>
                <td><input  style="WIDTH: 560px; height:62px; line-height:50px; padding:1px; font-size:40px; border-style:solid; border-color:#000000; background-color:#ffffff; border-width:3px; padding-left:10px" id="EmailAddress" runat="server"  value="" type="text" name="EmailAddress" /></td>
            </tr>
         
        </table>
        </asp:Panel>
        <asp:Panel ID="MobilePhoneNumberPanel" runat="server">
            <table border="0"  align="center"   >
                <tr>
                    <td width="260" align="left" ><asp:Label ID="MobilePhoneNumberLabel" runat="server" Text="Mobile Number:" ForeColor="AliceBlue" Font-Size="36px"  ></asp:Label></td>
                    <td>
                        <input  style="WIDTH: 560px; height:62px; line-height:50px; padding:1px; font-size:40px; border-style:solid; border-color:#000000; background-color:#ffffff; border-width:3px; padding-left:10px" id="MobileNumber"  runat="server"  value="" type="text" name="MobileNumber" />
                    </td>
                </tr>
            </table>
         
        </asp:Panel>
        <asp:Panel ID="FirstNamePanel" runat="server">
            <table border="0"  align="center"   >
                <tr>
                    <td width="260">
                        <asp:Label ID="FirstNameLabel" runat="server" Text="First Name:" ForeColor="AliceBlue" Font-Size="36px"  ></asp:Label>
                    </td>
                    <td>
                        <input  style="WIDTH: 560px; height:62px; line-height:50px; padding:1px; font-size:40px; border-style:solid; border-color:#000000; background-color:#ffffff; border-width:3px; padding-left:10px" id="FirstName" runat="server" value="" type="text" name="FirstName" />
                    </td>
                </tr>
            </table>
         
        </asp:Panel>
        <asp:Panel ID="LastNamePanel" runat="server" >
            <table border="0"  align="center"   >
                <tr>
                    <td width="260">
                        <asp:Label ID="LastNameLabel" runat="server" Text="Last Name:" ForeColor="AliceBlue" Font-Size="36px"  ></asp:Label>
                    </td>
                    <td>
                        <input  style="WIDTH: 560px; height:62px; line-height:50px; padding:1px; font-size:40px; border-style:solid; border-color:#000000; background-color:#ffffff; border-width:3px; padding-left:10px" id="LastName" runat="server" value="" type="text" name="LastName" />
                    </td>
                </tr>
            </table>
         
        </asp:Panel>
        <asp:Panel ID="DrivingLicenceNumberPanel" runat="server">
            <table border="0"  align="center"   >
                <tr>
                    <td width="260">
                        <asp:Label ID="DrivingLicenceNumberLabel" runat="server" Text="Driving Licence Number:" ForeColor="AliceBlue" Font-Size="36px"  ></asp:Label>
                    </td>
                    <td>
                        <input  style="WIDTH: 560px; height:62px; line-height:50px; padding:1px; font-size:40px; border-style:solid; border-color:#000000; background-color:#ffffff; border-width:3px; padding-left:10px" id="DrivingLicenceNumber" runat="server" value="" type="text" name="DrivingLicenceNumber" />
                    </td>
                </tr>
            </table>
         
        </asp:Panel>
        <asp:Panel ID="AddressPanel" runat="server">
            <table border="0"  align="center"   >
                <tr>
                    <td width="260">
                        <asp:Label ID="AddressLabel" runat="server" Text="Address:" ForeColor="AliceBlue" Font-Size="36px"  ></asp:Label>
                    </td>
                    <td>
                        <input  style="WIDTH: 560px; height:62px; line-height:50px; padding:1px; font-size:40px; border-style:solid; border-color:#000000; background-color:#ffffff; border-width:3px; padding-left:10px" id="Address"  runat="server" value="" type="text" name="Address" />
                    </td>
                </tr>
            </table>
         
        </asp:Panel>
        <asp:Panel ID="StatePanel" runat="server">
            <table border="0"  align="center"   >
                <tr>
                    <td width="260">
                        <asp:Label ID="StateLabel" runat="server" Text="State:" ForeColor="AliceBlue" Font-Size="36px"  ></asp:Label>
                    </td>
                    <td>
                        <input  style="WIDTH: 560px; height:62px; line-height:50px; padding:1px; font-size:40px; border-style:solid; border-color:#000000; background-color:#ffffff; border-width:3px; padding-left:10px" id="State" runat="server" value="" type="text" name="State" />
                    </td>
                </tr>
            </table>
         
        </asp:Panel>
        <asp:Panel ID="PostcodePanel" runat="server">
            <table border="0"  align="center"   >
                <tr>
                    <td width="260">
                        <asp:Label ID="PostcodeLabel" runat="server" Text="Postcode:" ForeColor="AliceBlue" Font-Size="36px"  ></asp:Label>
                    </td>
                    <td>
                        <input  style="WIDTH: 560px; height:62px; line-height:50px; padding:1px; font-size:40px; border-style:solid; border-color:#000000; background-color:#ffffff; border-width:3px; padding-left:10px" id="Postcode" runat="server"  value="" type="text" name="Postcode" />
                    </td>
                </tr>
            </table>
         
        </asp:Panel>
        <asp:Panel ID="AgePanel" runat="server">
            <table border="0"  align="center"   >
                <tr>
                    <td class="style1">
                        <asp:Label ID="AgeLabel" runat="server" Text="Age:" ForeColor="AliceBlue" Font-Size="36px"  ></asp:Label>
                    </td>
                    <td width="560" >
                    
                        <select style="WIDTH: 360px; height:62px; line-height:50px; padding:1px; font-size:40px; border-style:solid; border-color:#000000; background-color:#ffffff; border-width:3px; padding-left:10px"  ID="Age" name="Age" runat="server">
                            <option value="Under 18" >Under 18</option>
                            <option value="18-30" >18-30</option>
                            <option value="30-39" >30-39</option>
                            <option value="40-49" >40-49</option>
                            <option value="50-59" >50-59</option>
                            <option value="60-69" >60-69</option>
                            <option value="70-79" >70-79</option>
                            <option value="80-89" >80-89</option>
                            <option value="90-99" >90-99</option>
                            <option value="100+" >100+</option>
                        </select>
                    </td>
                </tr>
            </table>
         
        </asp:Panel>
   
        <br />


            <asp:Button ID="submit_btn" runat="server" Text="Submit" 
                onclick="submit_btn_Click" />
	    &nbsp;

	    &nbsp;

		    <asp:Button ID="remove1_btn" runat="server" 
                Text="Remove permanently from mailing list" onclick="remove1_btn_Click" />
            &nbsp;
	        &nbsp;
            <asp:Button ID="remove2_btn" runat="server" 
                Text="Remove from todays promotion only" onclick="remove2_btn_Click" />
    </asp:Panel>      
    

	


		   

	


		    </td>
	</tr>
</table>



    </div>
    </form>
</body>
</html>

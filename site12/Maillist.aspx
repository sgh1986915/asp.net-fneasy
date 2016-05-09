<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Maillist.aspx.cs" Inherits="Maillist" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    
    <script src="./js/jquery-1.6.4.min.js" type="text/javascript" charset="utf-8"></script>

    <SCRIPT LANGUAGE="JavaScript" SRC="./combined/CalendarPopup.js"></SCRIPT>
    <STYLE>
	.TESTcpYearNavigation,
	.TESTcpMonthNavigation
			{
			background-color:#6677DD;
			text-align:center;
			vertical-align:center;
			text-decoration:none;
			color:#FFFFFF;
			font-weight:bold;
			}
	.TESTcpDayColumnHeader,
	.TESTcpYearNavigation,
	.TESTcpMonthNavigation,
	.TESTcpCurrentMonthDate,
	.TESTcpCurrentMonthDateDisabled,
	.TESTcpOtherMonthDate,
	.TESTcpOtherMonthDateDisabled,
	.TESTcpCurrentDate,
	.TESTcpCurrentDateDisabled,
	.TESTcpTodayText,
	.TESTcpTodayTextDisabled,
	.TESTcpText
			{
			font-family:arial;
			font-size:8pt;
			}
	TD.TESTcpDayColumnHeader
			{
			text-align:right;
			border:solid thin #6677DD;
			border-width:0 0 1 0;
			}
	.TESTcpCurrentMonthDate,
	.TESTcpOtherMonthDate,
	.TESTcpCurrentDate
			{
			text-align:right;
			text-decoration:none;
			}
	.TESTcpCurrentMonthDateDisabled,
	.TESTcpOtherMonthDateDisabled,
	.TESTcpCurrentDateDisabled
			{
			color:#D0D0D0;
			text-align:right;
			text-decoration:line-through;
			}
	.TESTcpCurrentMonthDate
			{
			color:#6677DD;
			font-weight:bold;
			}
	.TESTcpCurrentDate
			{
			color: #FFFFFF;
			font-weight:bold;
			}
	.TESTcpOtherMonthDate
			{
			color:#808080;
			}
	TD.TESTcpCurrentDate
			{
			color:#FFFFFF;
			background-color: #6677DD;
			border-width:1;
			border:solid thin #000000;
			}
	TD.TESTcpCurrentDateDisabled
			{
			border-width:1;
			border:solid thin #FFAAAA;
			}
	TD.TESTcpTodayText,
	TD.TESTcpTodayTextDisabled
			{
			border:solid thin #6677DD;
			border-width:1 0 0 0;
			}
	A.TESTcpTodayText,
	SPAN.TESTcpTodayTextDisabled
			{
			height:20px;
			}
	A.TESTcpTodayText
			{
			color:#6677DD;
			font-weight:bold;
			}
	SPAN.TESTcpTodayTextDisabled
			{
			color:#D0D0D0;
			}
	.TESTcpBorder
			{
			border:solid thin #6677DD;
			}
</STYLE>

<SCRIPT LANGUAGE="JavaScript" ID="js1">
    var cal1 = new CalendarPopup();
    var cal2 = new CalendarPopup();
</SCRIPT>

    <link rel="stylesheet" type="text/css" href="./ptTime/jquery.ptTimeSelect.css" media="screen" />
	<script type="text/javascript" language="JavaScript" src="./ptTime/jquery.ptTimeSelect.js"></script>

    <script language="JavaScript">
        $(document).ready(
			function () {
			    $('code').each(
					function () {
					    eval($(this).html());
					}
				)
			}
		);
		
		
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--startoutrbanner-->
<div id="outerbanner2">
	<!--startbanner-->
	<div id="banner2">
		<p>
			Mailing List
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
				<h3>Mailing List
                </h3>
                <asp:Button ID="VisitorAddBtn" runat="server" Text="Add Visitor Info" 
                    onclick="VisitorAddBtn_Click" />
				
                <br />
                <table border="0" width="600">
                    <tr>
                        <td width="200" ><asp:CheckBox ID="AgeCheckBox" runat="server" /> Age:</td>
                        <td width="80%" >
                            <asp:DropDownList ID="AgeDropDownList" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="200" ><asp:CheckBox ID="PostcodeCheckBox" runat="server" />Postcode:</td>
                        <td width="80%">
                            <asp:DropDownList ID="PostcodeDropDownList" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="200" ><asp:CheckBox ID="StateCheckBox" runat="server" /> State:</td>
                        <td width="80%">
                            <asp:DropDownList ID="StateDropDownList" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="200" ><asp:CheckBox ID="CampaignCheckBox" runat="server" /> Campaign: </td>
                        <td width="80%"> 
                            <asp:DropDownList ID="CampaignDropDownList" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="200" ><asp:CheckBox ID="ShowCheckBox" runat="server" /> Show: </td>
                        <td width="80%"> 
                            <asp:DropDownList ID="ShowDropDownList" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="200" ></td>
                        <td width="80%"></td>
                    </tr>
                    <tr>
                        <td width="200" ></td>
                        <td width="80%">
                            <asp:Button ID="Filter_btn" runat="server" Text="Apply" 
                                onclick="Filter_btn_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="ShowAll_btn" runat="server" onclick="ShowAll_btn_Click" 
                                Text="Show All" />
                        </td>
                    </tr>
                </table>
                
                
				
                
                
                <br />
                
                <table border="0" >
                     
                 
                      
                        <tr>
                            <td width="200" ></td>
                            <td width="80%"></td>
                        </tr>
                        <tr>
                            <td width="200" ></td>
                            <td width="80%">
                                <asp:Button ID="SendBtn" runat="server" Text="Send Mass Message" 
                                    onclick="SendMassMessage_btn_Click" />
                                
                            </td>
                        </tr>
                </table>
                <br />
                <table border="0" width="90%" >
                                    <tr>
                                         <td width="200" >&nbsp;</td>
                                         <td width="80%">
                                            <asp:Button ID="ExportCSVBtn" runat="server" Text="Export CSV" 
                                    onclick="ExportCSV_Click" />
                                         </td>
                                    </tr>
                                
                                </table>
				<br />
                
                
				<asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="false"   onselectedindexchanged="CustomersGridView_SelectedIndexChanged"  OnRowDeleting="visitor_RowDelete"  
                       DataKeyNames="ID"  AllowPaging="true"   PageSize="50"     OnPageIndexChanging="GridViewPageIndexChange"  >
                    <Columns >
                        <asp:BoundField DataField="Title" HeaderText="Campaign Name" ReadOnly="true" />
                        <asp:BoundField DataField="Show" HeaderText="Show" ReadOnly="true" />
                        <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="true" />
                        <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" ReadOnly="true" />
                        <asp:BoundField DataField="FirstName" HeaderText="First Name" ReadOnly="true" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" ReadOnly="true" />
                        <asp:BoundField DataField="DrivingLicenceNumber" HeaderText="Driving Licence Number" ReadOnly="true" />
                        <asp:BoundField DataField="Address" HeaderText="Address" ReadOnly="true" />
                        <asp:BoundField DataField="State" HeaderText="State" ReadOnly="true" />
                        <asp:BoundField DataField="Postcode" HeaderText="Postcode" ReadOnly="true" />
                        <asp:BoundField DataField="Age" HeaderText="Age" ReadOnly="true" />
                       

                        <asp:CommandField      ShowSelectButton="true"  SelectText="Edit"  DeleteText="Delete"  ShowDeleteButton="true"  HeaderText="Operation" />

                    </Columns>
                 </asp:GridView>
                 
                
                 <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                 <br />

                <ajaxToolkit:ModalPopupExtender ID="SendMassModalPopupExtender" runat="server"  PopupControlID="SendMassPanel"  TargetControlID="hiddenTargetControlForModalPopup"   PopupDragHandleControlID="SendMassLabelPanel" 
            CancelControlID="SendMassCancelButton" >
                </ajaxToolkit:ModalPopupExtender>
                <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
                <asp:Panel ID="SendMassPanel" runat="server" CssClass="modalPopup2"  Style="display: none;" >
                    <asp:Panel ID="SendMassLabelPanel" runat="server" Style="cursor: move; background-color: #DDDDDD;
                border: solid 1px Gray; color: Black">
                        <div>
                            <p>please  send the mass mail-out at the select date & time?</p>
                        </div>
                    </asp:Panel>
                    
                    <table border="0" cellpadding="3"  cellspacing="3"  >
                        <tr>
                            <td width="30" > </td>
                            <td width="120" >Type: </td>
                            <td width="70%"> 
                                <asp:RadioButtonList ID="SendMassTypeRadioButtonList" runat="server" RepeatDirection="Horizontal"  >
                                        <asp:ListItem Value="email" Selected="true" >Email</asp:ListItem>
                                        <asp:ListItem Value="sms">SMS</asp:ListItem>
                                        <asp:ListItem Value="emailsms">Email&SMS</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                           <td width="30" > </td>
                            <td width="120" >Email Subject: </td>
                            <td width="70%">
                                <asp:TextBox ID="EmailSubjectTextBox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                           <td width="30" > </td>
                            <td width="120" >Message: </td>
                            <td width="70%">
                                <asp:TextBox ID="MessageTextBox" runat="server" Height="152px" TextMode="MultiLine" 
                                    Width="327px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                           <td width="30" > </td>
                            <td width="120" >Attachment: </td>
                            <td width="70%">
                                <asp:FileUpload ID="FileUpload1" runat="server"  />
                            </td>
                        </tr>
                        <tr>
                           <td width="30" > </td>
                            <td width="120" > </td>
                            <td width="70%">
                               <asp:RadioButtonList ID="SendMassLaterRadioButtonList" runat="server" RepeatDirection="Horizontal"    autopostback="true"  OnSelectedIndexChanged="mySelectedIndexChanged"  >
                                        <asp:ListItem Value="now" Selected="true" >Send Now</asp:ListItem>
                                        <asp:ListItem Value="later">Send Later</asp:ListItem>
                                        
                                </asp:RadioButtonList>
                                
                            </td>
                        </tr>
                        <tr>
                           <td width="30" > </td>
                            <td width="120" > </td>
                            <td width="70%">
                                <asp:Panel ID="DatePanel" runat="server" Visible="false" >
                                
                                     Date:
                                <asp:TextBox ID="SendMassDateText"   runat="server" Width="114px" onClick="cal1.select(document.forms[0].ctl00$ContentPlaceHolder1$SendMassDateText,'anchor1','MM/dd/yyyy'); return false;" ></asp:TextBox>
                                
                                 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                                &nbsp;Time:<asp:TextBox ID="SendMassTimeText" runat="server" Width="114px"    ></asp:TextBox>
                                
                               <A HREF="#"  NAME="anchor1" ID="anchor1"></A>
                               
                                
                                </asp:Panel>
                               

                            </td>
                        </tr>
                        <tr>
                            <td width="30" > </td>
                            <td width="120" > </td>
                            <td width="70%">
                                <asp:Button ID="SendMassButton" runat="server" Text="Send"  onclick="SendMassButton_Click" />
                                <asp:Button ID="SendMassCancelButton" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                    <br /><br />
                </asp:Panel>


                
			     
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

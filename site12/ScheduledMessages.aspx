<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ScheduledMessages.aspx.cs" Inherits="ScheduledMessages" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="./js/jquery-1.6.4.min.js" type="text/javascript" charset="utf-8"></script>
    <SCRIPT LANGUAGE="JavaScript" SRC="./combined/CalendarPopup.js"></SCRIPT>
    <SCRIPT LANGUAGE="JavaScript" ID="js1">
        var cal1 = new CalendarPopup();
        var cal2 = new CalendarPopup();
</SCRIPT>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <!--startoutrbanner-->
    <div id="outerbanner2">
	    <!--startbanner-->
	    <div id="banner2">
		    <p>
			    Scheduled Messages
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
				    <h3>Scheduled Messages
                    </h3>
				
                    <br />
               
				    <br />

				    <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="false"     
                           DataKeyNames="ID"  AllowPaging="true"   PageSize="10"     
                        OnPageIndexChanging="GridViewPageIndexChange" style="margin-top: 0px"  >
                        <Columns >
                           
                            <asp:BoundField DataField="SendType" HeaderText="Type" ReadOnly="true" />
                            <asp:BoundField DataField="SendTime" HeaderText="Send Time" ReadOnly="true" />
                            <asp:BoundField DataField="Subject" HeaderText="Subject" ReadOnly="true" />
                            

                            
                            <asp:TemplateField>   
                               <ItemTemplate>   
                                       <asp:Button    ID="MessageButton"    runat="server"    OnClick="GridViewMessage_Click"    Text="Message"    />   
                                       <asp:Button    ID="FilterButton"    runat="server"    OnClick="GridViewFilter_Click"    Text="Filter"    />   
                                       <asp:Button    ID="DeleteButton"    runat="server"    OnClick="GridViewDelete_Click"    Text="Delete"    />   
                               </ItemTemplate>   
                            </asp:TemplateField>   
                        </Columns>
                     </asp:GridView>
                 
                
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                     <br />
                     <ajaxToolkit:ModalPopupExtender ID="FilterModalPopupExtender" runat="server"  PopupControlID="FilterPanel"  TargetControlID="hiddenTargetControlForModalPopup"   PopupDragHandleControlID="FilterLabelPanel" 
                CancelControlID="FilterCancelButton" >
                    </ajaxToolkit:ModalPopupExtender>
                    
                    <asp:Panel ID="FilterPanel" runat="server" CssClass="modalPopup2"  Style="display: block;" >
                        
                        <asp:Panel ID="FilterLabelPanel" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
                            <div>
                                <p>please  set   the schedule filter</p>
                            </div>
                        </asp:Panel>
                        <table border="0" cellpadding="3"  cellspacing="3"  >
                            
                           <tr>
                                <td width="30" ><asp:HiddenField ID="FilterIDHiddenField" runat="server" /> </td>
                                <td width="200" ><asp:CheckBox ID="AgeCheckBox" runat="server" /> Age:</td>
                                <td width="80%" >
                                    <asp:DropDownList ID="AgeDropDownList" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td width="30" > </td>
                                <td width="200" ><asp:CheckBox ID="PostcodeCheckBox" runat="server" />Postcode:</td>
                                <td width="80%">
                                    <asp:DropDownList ID="PostcodeDropDownList" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td width="30" > </td>
                                <td width="200" ><asp:CheckBox ID="StateCheckBox" runat="server" /> State:</td>
                                <td width="80%">
                                    <asp:DropDownList ID="StateDropDownList" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td width="30" > </td>
                                <td width="200" ><asp:CheckBox ID="CampaignCheckBox" runat="server" /> Campaign: </td>
                                <td width="80%"> 
                                    <asp:DropDownList ID="CampaignDropDownList" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            
                            <tr>
                                <td width="30" > </td>
                                <td width="200" ><asp:CheckBox ID="ShowCheckBox" runat="server" /> Show: </td>
                                <td width="80%"> 
                                    <asp:DropDownList ID="ShowDropDownList" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td width="30" > </td>
                                <td width="200" ></td>
                                <td width="80%">
                                    <asp:Button ID="FilterButton" runat="server" Text="Submit"  OnClick="Filter_btn_Click"  />
                                    <asp:Button ID="FilterCancelButton" runat="server" Text="Cancel" />
                                </td>
                            </tr>
                           
                        </table>
                        <br /><br />
                    </asp:Panel>

                    <ajaxToolkit:ModalPopupExtender ID="SetMessageModalPopupExtender" runat="server"  PopupControlID="SetMessagePanel"  TargetControlID="hiddenTargetControlForModalPopup"   PopupDragHandleControlID="SetMessageLabelPanel" 
                CancelControlID="SetMessageCancelButton" >
                    </ajaxToolkit:ModalPopupExtender>
                    <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
                    <asp:Panel ID="SetMessagePanel" runat="server" CssClass="modalPopup2"  Style="display: none;" >
                        <asp:Panel ID="SetMessageLabelPanel" runat="server" Style="cursor: move; background-color: #DDDDDD;
                    border: solid 1px Gray; color: Black">
                            <div>
                                <p>please  set   the schedule message</p>
                            </div>
                        </asp:Panel>
                    
                        <table border="0" cellpadding="3"  cellspacing="3"  >
                            <tr>
                                <td width="30" ><asp:HiddenField ID="IDHiddenField" runat="server" /> </td>
                                <td width="120" >Type: </td>
                                <td width="70%"> 
                                    <asp:RadioButtonList ID="SetMessageTypeRadioButtonList" runat="server" RepeatDirection="Horizontal"  >
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
                                <asp:Panel ID="currentFilePanel" runat="server">
                                    <asp:Label ID="currentFileLabel" runat="server" Text="Your  File:"></asp:Label>
                                    <asp:HyperLink ID="currentFileHyperLink" runat="server">HyperLink</asp:HyperLink>
                    
                                    <asp:Button ID="currentFileDelButton" runat="server" Text="Delete File" 
                                        onclick="currentFileDelButton_Click" />
                                </asp:Panel>
                                    <asp:FileUpload ID="FileUpload1" runat="server"  />
                                </td>
                            </tr>
                           
                            <tr>
                               <td width="30" > </td>
                                <td width="120" > </td>
                                <td width="70%">
                                    <asp:Panel ID="DatePanel" runat="server" Visible="true" >
                                
                                         Date:
                                    <asp:TextBox ID="DateText"   runat="server" Width="114px" onClick="cal1.select(document.forms[0].ctl00$ContentPlaceHolder1$DateText,'anchor1','MM/dd/yyyy'); return false;" ></asp:TextBox>
                                
                                     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
                                    &nbsp;Time:<asp:TextBox ID="TimeText" runat="server" Width="114px"    ></asp:TextBox>
                                
                                   <A HREF="#"  NAME="anchor1" ID="anchor1"></A>
                               
                                
                                    </asp:Panel>
                               

                                </td>
                            </tr>
                            <tr>
                                <td width="30" > </td>
                                <td width="120" > </td>
                                <td width="70%">
                                    <asp:Button ID="SetMessageButton" runat="server" Text="Submit"  OnClick="SetMessage_btn_Click"  />
                                    <asp:Button ID="SetMessageCancelButton" runat="server" Text="Cancel" />
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


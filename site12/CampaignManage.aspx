<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"  EnableEventValidation="true"  AutoEventWireup="true" CodeFile="CampaignManage.aspx.cs" Inherits="CampaignManage" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--startoutrbanner-->
<div id="outerbanner2">
	<!--startbanner-->
	<div id="banner2">
		<p>
			Campaign Management
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
				<h3>Campaign Management
                </h3>
                <asp:Button ID="CampaignAddBtn" runat="server" Text="Add Campaign" 
                    onclick="CampaignAddBtn_Click" />
				<asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="false"    OnRowDataBound="GridRowDataBound"   
                        DataKeyNames="ID"  AllowPaging="true"   PageSize="8"     OnPageIndexChanging="GridViewPageIndexChange"  >
                    <Columns >
                        <asp:BoundField DataField="Title" HeaderText="Campaign Name" ReadOnly="true" />
                        <asp:BoundField DataField="Website" HeaderText="Website Type" ReadOnly="true" />
                        <asp:BoundField DataField="Show" HeaderText="Show" ReadOnly="true" />
                        <asp:BoundField DataField="Venue" HeaderText="Venue" ReadOnly="true" />
                        <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="true" />
                        
                       <asp:TemplateField HeaderText="Field List" >
                            <ItemTemplate>
                                <asp:GridView runat="server" ID="camFieldlist" AutoGenerateColumns="false"  BorderStyle="None" >
                                    <Columns>
                                        
                                        <asp:BoundField DataField="FieldText" HeaderText="FieldText" />
                                    </Columns>
                                </asp:GridView>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                       <asp:TemplateField  HeaderText="Operation">   
                            <ItemTemplate> 
                        
                                <asp:Button    ID="GridEditCampaignButton"    runat="server"    OnClick="GridViewEditCampaign_Click"    Text="Edit Campaign"    />
                                <asp:Button    ID="GridDelCampaignButton"    runat="server"    OnClick="GridViewDeleteCampaign_Click"    Text="Delete Campaign"    />   
                                <asp:Button    ID="GridLaunchButton"    runat="server"    OnClick="GridViewLauchCampaign_Click"    Text="Launch"    />
                                <asp:Button    ID="GridAutoRespondButton"    runat="server"    OnClick="GridViewAutoRespondCampaign_Click"    Text="Auto Respond"    />
                                
                            </ItemTemplate>
                        
                        </asp:TemplateField>


                        


                    
                    </Columns>
                 </asp:GridView>
			    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                     <br />

                <ajaxToolkit:ModalPopupExtender ID="SetAutoModalPopupExtender" runat="server"  PopupControlID="SetAutoPanel"  TargetControlID="hiddenTargetControlForModalPopup"   PopupDragHandleControlID="SetAutoLabelPanel" 
                CancelControlID="SetAutoCancelButton" >
                    </ajaxToolkit:ModalPopupExtender>
                    <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />
                    <asp:Panel ID="SetAutoPanel" runat="server" CssClass="modalPopup2"  Style="display: none;" >
                        <asp:Panel ID="SetAutoLabelPanel" runat="server" Style="cursor: move; background-color: #DDDDDD;
                    border: solid 1px Gray; color: Black">
                            <div>
                                <p>please  set   auto respond for campaign</p>
                            </div>
                        </asp:Panel>
                    
                        <table border="0" cellpadding="3"  cellspacing="3"  >
                            <tr>
                                <td width="30" >
                                    <asp:HiddenField ID="IDHiddenField" runat="server" /> 
                                
                                    <asp:HiddenField ID="CampaignIDHiddenField" runat="server" />
                                </td>
                                <td width="120" >Type: </td>
                                <td width="70%"> 
                                    <asp:RadioButtonList ID="SetAutoTypeRadioButtonList" runat="server" RepeatDirection="Horizontal"  >
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
                                    <asp:HyperLink ID="currentFileHyperLink" runat="server"></asp:HyperLink>
                    
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
                                    
                               

                                </td>
                            </tr>
                            <tr>
                                <td width="30" > </td>
                                <td width="120" > </td>
                                <td width="70%">
                                    <asp:Button ID="SetAutoButton" runat="server" Text="Submit"  OnClick="SetAuto_btn_Click"  />
                                    <asp:Button ID="SetAutoCancelButton" runat="server" Text="Cancel" />
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


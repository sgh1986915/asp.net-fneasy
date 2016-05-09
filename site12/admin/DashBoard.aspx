<%@ Page Title="" Language="C#" MasterPageFile="~/admin/AdminMasterPage.master"  EnableEventValidation="true"  AutoEventWireup="true" CodeFile="DashBoard.aspx.cs" Inherits="AdminDashBoard" %>

<%@ MasterType VirtualPath="~/admin/AdminMasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--startoutrbanner-->
<div id="outerbanner2">
	<!--startbanner-->
	<div id="banner2">
		<p>
			Administrator DashBoard
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
				<h3>Administrator DashBoard</h3>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                    OnRowDataBound="GridRowDataBound" DataKeyNames="ID"
                    OnPageIndexChanging="GridView1_PageIndexChanging" 
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                    OnSorting="GridView1_Sorting"
                    AllowPaging="true" AllowSorting="true">
                    <PagerSettings Mode="Numeric" Position="Bottom" PageButtonCount="10"/>
                    <PagerStyle Height="30px" VerticalAlign="Bottom" HorizontalAlign="Center"/>
                    <Columns >
                        <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="true" ItemStyle-Width="150" SortExpression="Email" />
                        <asp:BoundField DataField="BusinessName" HeaderText="Business Name" ReadOnly="true" ItemStyle-Width="100" SortExpression="BusinessName" />
                        <asp:BoundField DataField="Address" HeaderText="Address" ReadOnly="true" ItemStyle-Width="100" SortExpression="Address" />
                        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone" ReadOnly="true" ItemStyle-Width="120" SortExpression="PhoneNumber" />
                        <asp:BoundField DataField="NameToDisplay" HeaderText="User" ReadOnly="true" ItemStyle-Width="100" SortExpression="NameToDisplay" />
                        <asp:BoundField DataField="ContactPerson" HeaderText="Contact" ReadOnly="true" ItemStyle-Width="100" SortExpression="ContactPerson" />
                        <asp:BoundField DataField="ActivationCode" HeaderText="Activation Code" ReadOnly="true" ItemStyle-Width="120" SortExpression="ActivationCode" />
                        <asp:TemplateField  HeaderText="Operation">
                            <ItemTemplate> 
                                <asp:Button ID="GridEditOwnerButton" runat="server" OnClick="GridViewEditOwner_Click" Text="Edit Owner" />
                                <asp:Button ID="GridDelOwnerButton" runat="server" OnClick="GridViewDeleteOwner_Click" Text="Delete Owner" />   
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
			    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
			</div>
            <div style="text-align: center; margin-top: 30px;">
                <asp:Button ID="ExportCSVBtn" runat="server" Text="Export CSV" onclick="ExportCSV_Click" />
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


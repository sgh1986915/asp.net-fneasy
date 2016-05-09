<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="createaccount_two.aspx.cs" Inherits="createaccount_two" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/createaccount.css" rel="stylesheet" type="text/css" />
    <!--startoutrbanner-->
    <div id="outerbanner2">
        <!--startbanner-->
        <div id="banner2">
            <p>
             Activate Account
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
                <div class="detailcontdiv">
                    
                    <div id="activate_con">
                    <p style="text-align:center; color:#666;"><asp:Label CssClass="active_label" ID="Label10" runat="server" Text="Have Activation Code?"></asp:Label></p>
                        <ul>
                           
                                
                          
                            <li>
                                <asp:TextBox placeholder="Enter Code Here" CssClass="signuptxt2" ID="ActivationCode_txt"
                                    runat="server"></asp:TextBox>
                            </li>
                            <li>
                                <asp:Button Width="100px" Height="25px" CssClass="signup_btn" ID="submit_btn" runat="server"
                                    Text="Submit" OnClick="submit_btn_Click" />
                            </li>
                        </ul>
                        <div id="or_con">
                         <p  style="  text-align:center;">OR </p>
                         </div>
                         <p  style="text-align:center;"> <asp:Button CssClass="signup_btn" ID="nocode" runat="server" Text="I do not have an activation code" OnClick="nocode_Click" /></p>
                    </div>
                    <p>
                        &nbsp;</p>
                    <p>
                        <asp:HiddenField ID="package_id" runat="server" />
                        <asp:HiddenField ID="buy_type" runat="server" />
                    </p>
                  
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;</p>
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

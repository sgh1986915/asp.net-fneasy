<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="price.aspx.cs" Inherits="pricing" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="css/common.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--startoutrbanner-->
<div id="outerbanner2">
	<!--startbanner-->
	<div id="banner2">
		<p>
			Pricing &amp; Signup
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
				<h3>Pricing &amp; Signup</h3>



     <p>
      <%
          for (int j = 0; j < site_table.Rows.Count; j++)
          {
              string website_name = site_table.Rows[j]["Website"].ToString();
              string website_price = site_table.Rows[j]["Price"].ToString();
              string siteID = site_table.Rows[j]["ID"].ToString();
              %>
              <div class="nav_links">
				<p class="nav_text1" ><a align="center" ><%=website_name%></a></p>
				<p  ><a class="nav_text2" ><% =website_price %> +</a></p>
				
                <%
                    temp_table = mymembership.Package_by_site(siteID);
                    for (int m = 0; m < temp_table.Rows.Count; m++)
                    {

                            %>
                            <p  ><a class="nav_text3"  href="signup.aspx?package=<% =temp_table.Rows[m]["ID"]%>" ><% =temp_table.Rows[m]["PackageName"]%></a></p>

                            <%
                    }
              
                 %>
				
				
		       </div>

              <%
             
          }

          
        %>
         <div class="nav_links">
				<p class="nav_text1" ><a align="center" >7 day free trial</a></p>
				<p  ></p>
				<p  ><br /></p>
                
                            <p  ><a class="nav_text3"  href="createaccount.aspx?Package_ID=12123121&Buy_Type=free" >Sign up now</a></p>

                 
				
		       </div>
      
	  </p>
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


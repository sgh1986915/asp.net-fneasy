<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="pageCont1" ContentPlaceHolderID="head" Runat="Server">
    
    <script type="text/javascript" src="js/stepcarousel.js"></script>
    <style type="text/css">
        .stepcarousel{
            position: relative; /*leave this value alone*/
            border: 0px;
            overflow: scroll; /*leave this value alone*/
            width: 948px; /*Width of Carousel Viewer itself*/
            height: 220px; /*Height should enough to fit largest content's height*/
        }
        .stepcarousel .belt{
            position: absolute; /*leave this value alone*/
            left: 0;
            top: 0;
        }
        .stepcarousel .panel{
            float: left; /*leave this value alone*/
            overflow: hidden; /*clip content that go outside dimensions of holding panel DIV*/
            margin: 10px; /*margin around each panel*/
            width: 303px; /*Width of each panel holding each content. If removed, widths should be individually defined on each content DIV then. */
        }
    </style>
    
    <script type="text/javascript">
        stepcarousel.setup({
            galleryid: 'mygallery', //id of carousel DIV
            beltclass: 'belt', //class of inner "belt" DIV containing all the panel DIVs
            panelclass: 'panel', //class of panel DIVs each holding content
            autostep: { enable: true, moveby: 1, pause: 4000 },
            panelbehavior: { speed: 500, wraparound: true, wrapbehavior: 'slide', persist: true },
            defaultbuttons: { enable: true, moveby: 1, leftnav: ['IMAGES/LeftArrow.png', -18, 90], rightnav: ['IMAGES/RightArrow.png', -8, 90] },
            statusvars: ['statusA', 'statusB', 'statusC'], //register 3 variables that contain current panel (start), current panel (last), and total panels
            contenttype: ['inline'],
            onpanelclick: function (target) {
                if (target.tagName == "IMG") //if clicked on element is an image
                //window.open(target.src, "", "width=900px, height=800px")
                    window.location.href = target.parentNode.href;
            }

        })
    </script>
</asp:Content>
<asp:Content ID="pageCont2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!--startoutrbanner-->
<div id="outerbanner">
	<!--startbanner-->
	<div id="banner">
		<img src="images/the-smarter-text.gif" width="458" height="66" class="the" />
		<ul>
			<li> Electronically capture contact details, anywhere, anytime</li>
			<li> Instantly send information via email and SMS</li>
			<li> Export your customer database as a CSV file</li>
		</ul>
		<a href="createaccount.aspx?Buy_Type=free"><img   src="images/banner-button.gif" width="219" height="43" border="0" class="button" /> </a>
		<div class="spacer">
		</div>
	</div>
	<!--closebanner-->
</div>
<!--closedouterbanner-->

<div id="outericons">
	<div id="topicons">
		<div id="icon1">
			<img src="images/img1.gif" width="61" height="62" class="img1" />
			<h3>Easy to use and setup<br />
			 Try it for FREE today!</h3>
			<div class="spacer">
			</div>
		</div>
		<div id="icon1">
			<img src="images/img2.gif" width="53" height="62" class="img2" />
			<h3>Use your own logo<br />
			 and company colours</h3>
			<div class="spacer">
			</div>
		</div>
		<div id="icon1">
			<img src="images/img3.gif" width="41" height="62" class="img3" />
			<h3>Works on iPad, iPhone,<br />
			 Android, Samsung, PC</h3>
			<div class="spacer">
			</div>
		</div>
		<div class="spacer">
		</div>
	</div>
</div>


<div id="mainbody">
	<!--startmidbody-->
	<div id="midbody">
		<div id="categeory">
			<div id="heading">
				<h2>Select the category that best suits your business</h2>
			</div>
			<div id="subcategeory" align="center">



                    <div id="Compo" style="border: 0px; width:948px; height:220px; margin-top:4px;font-size:10px;text-align:left">
                        <!-- CAROUSEL -->
                        <div id="mygallery" class="stepcarousel">
                            <div class="belt">
                                <div class="panel">
					<div id="categeory1">
						<h3>fneasymail</h3>
                        <a  class="notextline"  href="price.aspx">
						<img id="mmyy" src="images/categeory-img1.gif" width="153" height="123" />
                        </a>
						<p>
							Business<br />
							 Trade Shows<br />
							 Expos
						</p>
					</div>
                                </div>
 
                                <div class="panel">
					<div id="categeory1">
						<h3>realfneasy</h3>
                         <a  class="notextline"  href="price.aspx">
						<img src="images/categeory-img2.gif" width="153" height="123" />
                        </a>
						<p>
							Real Estate<br />
							 Agent
						</p>
					</div>
                                </div>
 
                                <div class="panel">
					<div id="categeory3">
						<h3>fneasypromos</h3>
                         <a  class="notextline"  href="price.aspx">
						<img src="images/categeory-img3.gif" width="153" height="123" />
                        </a>
						<p>
							In-store <br />
							 interactive<br />
							 promotions
						</p>
					</div>
                                </div>
                                
                                <div class="panel">
					<div id="categeory1">
						<h3>fneasyoffers </h3>
                        <a  class="notextline"  href="price.aspx">
						<img src="images/categeory-img1.gif" width="153" height="123" />
                        </a>
						<p>
							Small<br/>&nbsp;&nbsp;&nbsp;Business<br />
							 Restaurants<br />
							 Fast Food
						</p>
					</div>
                                </div>
 
                                <div class="panel">
					<div id="categeory1">
						<h3>fneasyinfo </h3>
                         <a  class="notextline"  href="price.aspx">
						<img src="images/categeory-img2.gif" width="153" height="123" />
                        </a>
						<p>
							Information<br/>&nbsp;&nbsp;&nbsp;Distribution<br />
							 
						</p>
					</div>
                                </div>
                                
                                <div class="panel">
				<div id="categeory3">
					<h3>fneasytouch </h3>
                     <a  class="notextline"  href="price.aspx">
					<img src="images/categeory-img3.gif" width="153" height="123" />
                    </a>
					<p>
						Electronic<br/>Discount<br/>Coupon<br />
					</p>
				</div>
                                </div>
                                                         
 
                            </div>
                        </div>
                    </div>

			</div>
			<div id="spacer">
				<img src="images/spacer.gif" width="1" height="20" />
			</div>
			<div class="spacer">
			</div>
		</div>
		<!--startcontent-->
		<div id="content">
			<div class="txtcontent" >
				<h3>What is fneasy?</h3>
				<p>
					fneasy allows its owner to capture the details of interested or potential customers and automatically set up an instant email connection with them to provide information, brochures, special offers etc. without the cost and wastage of printed literature.
				</p>
			</div>
			<div class="txtcontent" >
				<h3>Who uses fneasy?</h3>
				<p>
					Any business who exhibits at trade shows, realestate agents, retail businesses capturing details in store. fneasy can even be used as an electronic competition entry form, the possibilities are endless.
				</p>
			</div>
			<div id="content3">
				<h3>Why use fneasy?</h3>
				<p>
					fneasy is an eco friendly product using no paper or ink meaning that by using your existing website and fneasy you are now able to save money and the environment.
				</p>
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




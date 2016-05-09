<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UploadLogo.aspx.cs" Inherits="UploadLogo" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" href="_assets/css/progress.css" />
    <link rel="Stylesheet" href="_assets/css/upload.css" />
    <script src="./js/jquery-1.6.4.min.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript" charset="uft-8">
        function beforeUpload(sender) {
            var Sys = {};
            Sys.firefox = false;
            Sys.ie = false;
            var filePath = sender.value;
            var fileExt = filePath.substring(filePath.lastIndexOf(".")).toLowerCase();


            sender.onreadystatechange = function () {
                if (sender.readyState == "complete") {
                    alert("111 file size: " + sender.fileSize); 
                }
            }


            if (navigator.userAgent.indexOf("Firefox") > 0 ) {
                Sys.firefox = true;  
            } else
            //if(isFirefox=navigator.userAgent.indexOf("Firefox")>0) 
            {
                Sys.ie = true;
            }  
            var filesize = 0; 
        
            if(Sys.firefox){
                filesize = sender.files[0].fileSize;
            }else if(Sys.ie){ 

                //var fileobject = new ActiveXObject("Scripting.FileSystemObject");//获取上传文件的对象 
                //var file = fileobject.GetFile(document.getElementById("ctl00_ContentPlaceHolder1_FileUpload1").value); //获取上传的文件 
               // var filesize = file.Size;//文件大小 
                //filesize = sender.files[0].fileSize;
                //var objstream = new ActiveXObject("adodb.stream");
                //objstream.type = 1;
                //objstream.open();
                //objstream.loadfromfile(sender.value);
                //filesize = objstream.size;

                var img = new Image();

                var imgfilepath = $("input[name='ctl00$ContentPlaceHolder1$FileUpload1']").val();
                img.src = imgfilepath;
                /*
                while(true){
                    if(img.fileSize>0){

                        alert("img size is " + img.fileSize);
                        //return false;
                        break;
                    }
                    
                } 
                */


                
            } 
            

           
            //alert("file size is " + sender.fileSize);
            //alert("this is beforeUpload");
            //alert("filePath is " + filePath);
            //alert("fileExt is " + fileExt);
            //alert("file size is " + filesize);
        }

    </script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   
    
    


    <!--startoutrbanner-->
<div id="outerbanner2">
	<!--startbanner-->
	<div id="banner2">
		<p>
			Logo Upload
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
				<h3>Please upload  your company logo 
                    
                    
                    
                </h3>
   <asp:Label ID="showinfo" runat="server"  ForeColor="#ff3300"  Text=""></asp:Label>
                
                <asp:Panel ID="currentLogoPanel" runat="server">
                    
                    <asp:Label ID="currentLogoLabel" runat="server" Text="Your Logo File:"></asp:Label>
                    <asp:HyperLink ID="currentLogoHyperLink" runat="server">HyperLink</asp:HyperLink>
                    
                    <asp:Button ID="currentLogoDelButton" runat="server" Text="Delete Logo" 
                        onclick="currentLogoDelButton_Click" />
                </asp:Panel>
  <div class="upload">
            <h3>Upload your logo</h3>
            <div>
                
                <asp:FileUpload ID="FileUpload1" runat="server" OnDataBinding="onMyFileUpload"  onchange="javascript:beforeUpload(this);"   />
               
                <div id="status" class="info">Image formats are JPG and PNG</div>
                <div class="commands">
                        <asp:Button ID="upload_btn" runat="server" Text="Upload" 
                            onclick="upload_btn_Click" />
                        
                    </div>
                
            </div>
        </div> 
</div>

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


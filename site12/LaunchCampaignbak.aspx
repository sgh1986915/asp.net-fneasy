<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LaunchCampaignbak.aspx.cs" Inherits="LaunchCampaignbak" %>



<html >
<head runat="server">
    <title>capture screen</title>

    <script type="text/javascript" charset="uft-8">


       // window.onload = function () {

            //window.open(location.href, "newwindow", "fullscreen=3,height=300, width=300, top=0, left=0, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no");
       // }

        //window.moveTo(0, 0);
        //window.resizeTo(screen.availWidth, screen.availHeight);

        window.onbeforeunload = function () {

            
            if (event.clientX > document.body.clientWidth && event.clientY < 0 || event.altKey) {
                window.event.returnValue = " ";
            } 
        } 
       

    </script>
    <script type="text/javascript" charset="uft-8">
        $(function () {
            $('#add_btn').click(function () {

                if (isTelephone($('#mobileNumber').val())) {
                    //alert("this is mobile num :" + $('#mobileNumber').val());
                } else {
                    alert("Please enter a valid mobile number");
                }
                $.get('http://199.48.165.215//soap/service.asmx/MultiLoopSMSMessageByNumber?telephonenumber=' + $('#mobileNumber').val(), function (data) {



                });

            });

            $('#remove_btn1').click(function () {

                if (isTelephone($('#mobileNumber').val())) {

                } else {
                    alert("Please enter a valid mobile number");
                }
                $.get('http://199.48.165.215//soap/service.asmx/StopMultiLoopSMSMessage?telephonenumber=' + $('#mobileNumber').val(), function (data) {

                    //alert("data is "+data);

                });

            });


            $('#remove_btn2').click(function () {

                if (isTelephone($('#mobileNumber').val())) {

                } else {
                    alert("Please enter a valid mobile number");
                }

                /*
                $.get('http://199.48.165.215//soap/service.asmx/StopMultiLoopSMSMessage?telephonenumber=' + $('#mobileNumber').val(), function (data) {

                //alert("data is "+data);

                });
                */
            });
        });


        function isTelephone(mystr) {
            // parseInt
            if (mystr.length <= 0) {
                return false;
            }
            if (mystr.indexOf('.') > -1) {
                return false;
            }

            if (mystr.indexOf(';') > -1) {

                var arrTmp = mystr.split(";");
                for (var i = 0; i < arrTmp.length; i++) {
                    if (isNaN(arrTmp[i])) {
                        // alert("this is break");
                        return false;
                        break;
                    } else {


                    }




                }


                return true;

            } else {

                if (isNaN(mystr)) {
                    //alert("this 1111 is not telephone");
                    return false;

                } else {
                    return true;
                }
            }
        }

	</script> 
    <link rel="stylesheet" href="buttons/style_button.css" type="text/css" />
	
	
    <script src="./js/jquery-1.6.4.min.js" type="text/javascript" charset="utf-8"></script>
    
</head>
<body  bgcolor="#000000" >
    <form id="form1" runat="server">
    <div>
        <table border="0" width="100%" height="100%" align="center"   >
	<tr>
		<td valign="middle" align="center" width="100%" height="100%"  >


    <p>
        <img src="images/LogoBlack.jpg"  />
    </p>

    <br />

    <p>
        <input  style="WIDTH: 560px; height:62px; line-height:50px; padding:1px; font-size:40px; border-style:solid; border-color:#000000; background-color:#ffffff; border-width:3px; padding-left:10px" id="mobileNumber" value="" type="text" name="mobileNumber" />
    </p>

    <br />


    <button class="green_btn" id="add_btn">
	  <span>Add</span>
	</button>
	&nbsp;

	<button class="orange_btn" id="remove_btn1">
	  <span>Remove from Promo</span>
	</button>
	&nbsp;

	


		</td>
	</tr>
</table>



    </div>
    </form>
</body>
</html>

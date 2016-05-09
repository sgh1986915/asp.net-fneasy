<%@ Application Language="C#" %>
<%@ import Namespace="System.IO" %>

<%@ import Namespace="System.Data.SqlClient" %>
<%@ import Namespace="System.Data" %>

<%@ import Namespace="au.com.messagenet.www" %>
<%@ import Namespace="System.Net" %>
<%@ import Namespace="System.Net.Mail" %>

<%@ import Namespace="Touchdevice.Dal" %>
<%@ import Namespace="Touchdevice.Common" %>




<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        //在应用程序启动时运行的代码
       
        
        
        System.Timers.Timer myTimer = new System.Timers.Timer(20000);
       myTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
        myTimer.Interval = 20000;
       myTimer.Enabled = true;
       

        //string path = AppDomain.CurrentDomain.BaseDirectory.ToString();

        //mycampaign.LoopSendNow_EmailSMS(path);
        

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        //在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        //在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        //在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式 
        //设置为 StateServer 或 SQLServer，则不会引发该事件。

    }

    private  void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
    {
        //间隔时间执行某动作

        campaign mycampaign = new campaign();
        //string path = Server.MapPath("/");
        //string path = HttpContext.Current.Server.MapPath("/");
        //mycampaign.LoopCreateSendByFilter();
        string path = AppDomain.CurrentDomain.BaseDirectory.ToString();
        
        mycampaign.LoopSendNow_EmailSMS(path);
        mycampaign.LoopSendLaterEmailSMS();


        mycampaign.LoopCreateSendByFilter();

    }
       
</script>

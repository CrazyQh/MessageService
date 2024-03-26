using System;
using System.ServiceProcess;

namespace MessageService
{
    public partial class MessageService : ServiceBase
    {
        public MessageService()
        {
            InitializeComponent();
            this.timerMessage.Interval = 60000;
            this.timerMessage.Elapsed += new System.Timers.ElapsedEventHandler(SendMessage); //timerMessage_Elapsed是到达时间的时候执行事件的函数
        }

        protected override void OnStart(string[] args)
        {
            Common.WriteLog(DateTime.Now.ToString() + "服务启动！");
        }

        protected override void OnStop()
        {
            Common.WriteLog(DateTime.Now.ToString() + "服务停止！");
        }

        private void SendMessage(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {

                this.timerMessage.Enabled = false;
                string message = Common.HttpGet("http://gms.yiyuninfo.com/Message/AutoSend");
                Common.WriteLog(message);
            }
            finally
            {
                this.timerMessage.Enabled = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MessageService
{
    public class Common
    {
        public static void WriteLog(string _content, string _path = null)
        {
            //日志目录默认C:盘
            if (string.IsNullOrEmpty(_path))
            {
                _path = @"C:/log";
            }
            //如果日志目录不存在就创建
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            //文件完整名称
            string filename = _path + "/" + TimerHelper.GetDate() + ".txt";
            using (StreamWriter reader = File.AppendText(filename))
            {
                reader.WriteLine(TimerHelper.GetDateTime() + " : " + _content);
            }
        }

        public static string HttpGet(string url, Encoding encoding = null)
        {
            string message = string.Empty;
            try
            {
                WebClient wc = new WebClient();
                wc.Encoding = encoding ?? Encoding.UTF8;
                message = wc.DownloadString(url);
            }
            catch (Exception ex0)
            {
                message = ex0.Message;
            }
            return message;
        }
    }

    public class TimerHelper
    {
        /// <summary>
        /// 返回当前日期
        /// </summary>
        /// <returns></returns>
        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 返回当前时间
        /// </summary>
        /// <returns></returns>
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 返回当前时间
        /// </summary>
        /// <returns></returns>
        public static string GetTimeToString()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
        /// <summary>
        /// 返回当前月的第一天
        /// </summary>
        /// <returns></returns>
        public static string GetNowMonthFirstDay()
        {
            return DateTime.Now.ToString("yyyy-MM") + "-1";
        }
        /// <summary>
        /// 返回时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimestamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        /// <summary>
        /// 获取时间差-天数
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static string GetDateDiff(DateTime StartDate, DateTime EndDate)
        {
            DateTime start = Convert.ToDateTime(StartDate.ToShortDateString());
            DateTime end = Convert.ToDateTime(EndDate.ToShortDateString());

            TimeSpan sp = end.Subtract(start);

            return sp.Days.ToString();
        }
    }

    
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Collections;
using System.Threading;

namespace robClass
{
    public partial class Form2 : Form
    {
        public Form1 f1 = null;
        CookieContainer cookieContainer = new CookieContainer();
        ArrayList choseData = new ArrayList();
        Thread[] myThread = {};
        int time;
        bool stop = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            cookieContainer = f1.cookieContainer;
            Form.CheckForIllegalCrossThreadCalls = false;

            for (int i = 1; i <= 7; i++)
                for (int j = 1; j <= 14; j++)
                    ClassTimeChosen.Items.Add(Convert.ToString(i) + (j < 10 ? "0" : "") + Convert.ToString(j));

           
            time = 4500;
            textBox1.Text = Convert.ToString(4500) ;
            InfoList.Items.Add("您已經可以開始使用選課系統 - " + f1.msg);
            InfoList.SelectedIndex = InfoList.Items.Count - 1;
        }

        private string getRequest(string url , string method , byte [] postData)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = method ;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.110 Safari/537.36";
            request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, */*";
            request.Headers.Add("Accept-Encoding", "gzip-deflate");
            request.Headers.Add("Cache-Control", "no-cache");
            request.Headers.Add("Accept-Language", "zh-TW");
            request.AllowAutoRedirect = true;
            request.Expect = "";
            request.KeepAlive = true;

            if (method != "POST")
                request.CookieContainer = cookieContainer;
            else
            {
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postData.Length;
                System.Net.ServicePointManager.Expect100Continue = false;

                Stream outputStream = request.GetRequestStream();
                outputStream.Write(postData, 0, postData.Length);
                outputStream.Close();
            }

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            string srcString = reader.ReadToEnd();

            return srcString;
            
        }

        private void getCredit()
        {
            string maxAndGet = getRequest("https://isdna1.yzu.edu.tw/Cnstdsel/SelCurr/CosTable.aspx" , "GET" , null);

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(maxAndGet);
            HtmlNode flag = html.DocumentNode.SelectSingleNode("//span[@id='LabT_SelCredit']");
            SelCredit.Text = flag.InnerText.Trim();
            flag = html.DocumentNode.SelectSingleNode("//span[@id='LabT_OverCredit']");
            MaxCredit.Text = flag.InnerText.Trim();
        }

        private void ClassTimeChosen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Application.DoEvents();
            ClassChosen.DataSource = null;
            ClassChosen.Text = "";

            string chosen = getRequest("https://isdna1.yzu.edu.tw/cnstdsel/SelCurr/CosList.aspx?schd_time=" + ClassTimeChosen.Text, "GET", null);

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(chosen);
            HtmlNodeCollection flag = html.DocumentNode.SelectNodes("//table[@id='CosListTable']/tr/td/a");

            ArrayList classData = new ArrayList();
            int count = 1 ;
            string value = "" ;

            foreach (HtmlNode node in flag)
            {
                string token = node.Attributes["onclick"].Value.Trim();
                string[] url = token.Split(new string []{"&#39;"}, StringSplitOptions.RemoveEmptyEntries);
                if (count % 2 != 0)
                    url[1] = url[1].Substring(0, url[1].Length - 1);

                value += url[1] + "@";

                if (node.InnerText.Trim() != "")
                {
                    classData.Add(new DictionaryEntry(node.InnerText.Trim(), value));
                    value = "";
                }
                count++ ;
            }

            ClassChosen.DisplayMember = "Key";
            ClassChosen.ValueMember = "Value";
            ClassChosen.DataSource = classData;
        }

        private void StartRob_Click(object sender, EventArgs e)
        {
            AddClass.Enabled = false;
            RemoveClass.Enabled = false;
            StartRob.Enabled = false;

            stop = false;
            Array.Resize(ref myThread, ClassList.Items.Count);
            for (int i = 0; i < ClassList.Items.Count ; i++)
            {
                myThread[i] = new Thread(new ParameterizedThreadStart(RobClassRun));
                DictionaryEntry data = (DictionaryEntry)choseData[i];
                string dataStr = Convert.ToString(data.Value) + Convert.ToString(i);
                myThread[i].Start(dataStr);
            }
        }

        private void RobClassRun(object command)
        {
            string dataStr = Convert.ToString(command);
            string[] splitStr = dataStr.Split('@');
            int id = Convert.ToInt32(splitStr[2]);
            string check = splitStr[1];
            string send = splitStr[0];

            try
            {
                while (true)
                {
                    string checkRequest = getRequest("https://isdna1.yzu.edu.tw/cnstdsel/SelCurr/CosInfo.aspx?mCosInfo=" + check, "GET", null);
                    HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
                    html.LoadHtml(checkRequest);
                    HtmlNodeCollection flag = html.DocumentNode.SelectNodes("//td[@class='cls_info_main']");

                    InfoList.Items.Add(check + " 上限:" + flag[9].InnerText.Trim() + " 已選:" + flag[10].InnerText.Trim());
                    InfoList.SelectedIndex = InfoList.Items.Count - 1;

                    if (Convert.ToInt32(flag[9].InnerText.Trim()) - Convert.ToInt32(flag[10].InnerText.Trim()) >= 1)
                    {
                        string get = getRequest("https://isdna1.yzu.edu.tw/cnstdsel/SelCurr/CurrMainTrans.aspx?mSelType=SelCos&mUrl=" + send , "GET" , null) ;
                        InfoList.Items.Add(check + " 已取得，請確認您的學分數是否增加。");
                        myThread[id].Interrupt();
                    }

                    if (stop)
                        myThread[id].Interrupt();

                    Thread.Sleep(time);
                }
            }
            catch (ThreadInterruptedException)
            {
                getCredit();
                InfoList.Items.Add(check + " 已停止");
            }
            
        }

        private void AddClass_Click(object sender, EventArgs e)
        {
            if (f1.msg == "免費版用戶" && ClassList.Items.Count > 0)
                MessageBox.Show("免費版本僅能一次選擇一門課程！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                choseData.Add(new DictionaryEntry(ClassChosen.Text, ClassChosen.SelectedValue));

            ClassList.DataSource = null;
            ClassList.DisplayMember = "Key";
            ClassList.ValueMember = "Value";
            ClassList.DataSource = choseData;
        }

        private void RemoveClass_Click(object sender, EventArgs e)
        {
            choseData.Remove(new DictionaryEntry(ClassList.Text, ClassList.SelectedValue));

            ClassList.DataSource = null;
            ClassList.DisplayMember = "Key";
            ClassList.ValueMember = "Value";
            ClassList.DataSource = choseData;
        }

        private void InfoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InfoList.Items.Count > 30)
                InfoList.Items.Clear();
        }

        private void StopRob_Click(object sender, EventArgs e)
        {
            stop = true;
            AddClass.Enabled = true;
            RemoveClass.Enabled = true;
            StartRob.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            time = Convert.ToInt32(textBox1.Text);
        }
    }
}

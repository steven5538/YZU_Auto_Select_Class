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

namespace robClass
{
    public partial class Form1 : Form
    {
        public CookieContainer cookieContainer = new CookieContainer();
        public string msg;
        public string loginInfo;
        string viewState;
        string eventValidation;
        string userName;
        string password;
        string checkcode;
        string costype;
        string submitButton;
        string srcString;
        HttpWebRequest request;
        HttpWebResponse response;
        Stream responseStream;
        StreamReader reader;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            info.Text = "登入中";

            #region Get Setting
            if (checkBox1.Checked == true)
            {
                StreamWriter Setting = new StreamWriter("Setting");
                Setting.WriteLine(Convert.ToBase64String(Encoding.UTF8.GetBytes(Usr.Text + "::::" + Pwd.Text)));
                Setting.Close();
            }
            else
                File.Delete("Setting");
            #endregion
          
            #region POST login
            userName = Usr.Text;
            password = Pwd.Text;
            checkcode = Check.Text;
            submitButton = "確定";
            costype = comboBox1.Text;

            viewState = HttpUtility.UrlEncode(viewState);
            eventValidation = HttpUtility.UrlEncode(eventValidation);
            submitButton = HttpUtility.UrlEncode(submitButton);
            userName = HttpUtility.UrlEncode(userName);
            password = HttpUtility.UrlEncode(password);

            string formatString = "Txt_User={0}&Txt_Password={1}&btnOK={2}&__VIEWSTATE={3}&__EVENTVALIDATION={4}&Txt_CheckCode={5}&DPL_SelCosType={6}";
            string postString = string.Format(formatString, userName, password, submitButton, viewState, eventValidation, checkcode, costype);

            byte[] postData = Encoding.ASCII.GetBytes(postString);

            createRequest("https://isdna1.yzu.edu.tw/CnStdSel/index.aspx", "POST", postData , false , true);
            #endregion
            
            if (srcString.IndexOf("保障") == -1)
            {
                MessageBox.Show("帳號、密碼或驗證碼錯誤！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Form1_Shown(sender, e);
                info.Text = "等待使用者輸入";
            }
            else
            {
                Form2 f2 = new Form2();
                f2.f1 = this;
                f2.Show();
                this.Visible = false;
            }
        }

        private void Check_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                button1_Click(sender, e);
        }

        private void createRequest(string url, string method , byte[] postData , bool picture , bool cookie)
        {
            request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = method;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.110 Safari/537.36";
            request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, */*";
            request.Headers.Add("Accept-Encoding", "gzip-deflate");
            request.Headers.Add("Cache-Control", "no-cache");
            request.Headers.Add("Accept-Language", "zh-TW");
            request.AllowAutoRedirect = true;
            request.Expect = "";
            request.KeepAlive = true;
            if (cookie)
                request.CookieContainer = cookieContainer;
            if (method == "POST")
            {
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postData.Length;

                Stream outputStream = request.GetRequestStream();
                outputStream.Write(postData, 0, postData.Length);
                outputStream.Close();
            }

            response = request.GetResponse() as HttpWebResponse;

            if (picture)
                pictureBox1.Image = Image.FromStream(response.GetResponseStream());
            else
            {
                responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream, Encoding.UTF8);
                srcString = reader.ReadToEnd();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            comboBox1.Items.Clear();
            Check.Text = "";

            #region Get Account Setting
            if (System.IO.File.Exists("Setting"))
            {
                string s;
                StreamReader Setting = new StreamReader("Setting");
                s = Setting.ReadToEnd();
                string[] set = Regex.Split(Encoding.UTF8.GetString(Convert.FromBase64String(s)), "::::", RegexOptions.IgnoreCase);
                Usr.Text = set[0];
                Pwd.Text = set[1];
                checkBox1.Checked = true;
                Setting.Close();
            }
            #endregion

            #region Get Login Cookie and cosType
            createRequest("https://isdna1.yzu.edu.tw/CnStdSel/index.aspx", "GET", null , false , true);

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(srcString);
            HtmlNode viewStateFlag = html.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATE']");
            viewState = viewStateFlag.Attributes["value"].Value;

            html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(srcString);
            HtmlNode eventValidationFlag = html.DocumentNode.SelectSingleNode("//input[@id='__EVENTVALIDATION']");
            eventValidation = eventValidationFlag.Attributes["value"].Value;

            html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(srcString);
            HtmlNodeCollection CosFlag = html.DocumentNode.SelectNodes("//option");
            foreach (HtmlNode cos in CosFlag)
            {
                if (cos.Attributes["value"].Value != "00")
                {
                    comboBox1.Items.Add(cos.Attributes["value"].Value);
                    comboBox1.Text = cos.Attributes["value"].Value;
                }
            }
            #endregion

            #region GET Check Code
            createRequest("https://isdna1.yzu.edu.tw/Cnstdsel/SelRandomImage.aspx", "GET", null , true , true);
            #endregion

            info.Text = "等待使用者輸入";
        }
    }
}

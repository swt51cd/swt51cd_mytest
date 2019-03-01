using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListoString
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("a");
            list.Add("b");
            list.Add("c");
            string s = string.Join(",", list.ToArray());
            MessageBox.Show(s);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string[] s = { "张三", "李四", "王五" };
            string myStr = string.Join("\r\n", s);
            MessageBox.Show(myStr);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "1,2,3";
            List<string> list = new List<string>(s.Split(','));
            foreach (string t in list)
            {
                MessageBox.Show("*" + t + "*");
            }
            //string myTest = "cehs";
            //string s = "1, 2, 3";
            //List<string> list = new List<string>(s.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries));
            //foreach (string t in list)
            //{
            //    MessageBox.Show("*" + t + "*");
            //}

        }
        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            string s1 = "已经习惯了回车和换行一次搞定\n，敲一个回车键，即是回";
            MessageBox.Show(s1);
            //MessageBox.Show("safsf");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s1 = "已经习惯了回车和换行一次搞定\r\n，敲一个回车键，即是回";
            MessageBox.Show(s1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> myDictionary = new Dictionary<int, string>();//实现IDictionary接口，IDictionary<T key,T value>类
            myDictionary.Add(1, "a");
            myDictionary.Add(2, "b");
            myDictionary.Add(3, "c");

            //foreach (var i in myDictionary.Keys)
            //{
            //    var test = myDictionary;
            //    MessageBox.Show("Key=I=" + i.ToString() + "   Value=" + myDictionary[i]);
            //}

            foreach (var item in myDictionary)
            {
                MessageBox.Show(item.Key + item.Value);
            }

            //foreach (KeyValuePair<int, string> temp in myDictionary)//返回的是KeyValuePair<int, string>泛型数组
            //{
            //    MessageBox.Show(temp.Key + temp.Value);
            //}


        }

        private void button7_Click(object sender, EventArgs e)
        {
            //序列化DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("Age", Type.GetType("System.Int32"));
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("Sex", Type.GetType("System.String"));
            dt.Columns.Add("IsMarry", Type.GetType("System.Boolean"));
            for (int i = 0; i < 4; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Age"] = i + 1;
                dr["Name"] = "Name" + i;
                dr["Sex"] = i % 2 == 0 ? "男" : "女";
                dr["IsMarry"] = i % 2 > 0 ? true : false;
                dt.Rows.Add(dr);
            }
            MessageBox.Show(JsonConvert.SerializeObject(dt));   //序列化

            //---------反序列化 对象转换字符串
            string json = JsonConvert.SerializeObject(dt);
            dt = JsonConvert.DeserializeObject<DataTable>(json);//反序列化
            foreach (DataRow dr in dt.Rows)
            {
                var s = string.Format("{0}\t{1}\t{2}\t{3}\t", dr[0], dr[1], dr[2], dr[3]);
                MessageBox.Show(s);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        ///// <summary>
        ///// 客户端上传图片发至服务器指定文件夹
        ///// 并获得保存至服务器数据库的相对路径
        ///// </summary>
        ///// <param name="file">客户端HtmlInputFile控件的对象</param>
        ///// <returns>如果成功返回相对路径字符串否则为错误提示字符串</returns>
        //public string updateImage(System.Web.UI.HtmlControls.HtmlInputFile file)//,string path
        //{
        //    string[] imgType = new string[] { "image/gif", "image/jpg", "image/png", "image/bmp" };

        //    int i = 0;
        //    bool blean = false;
        //    string message = string.Empty;

        //    //判断是否为Image类型文件
        //    while (i < imgType.Length)
        //    {
        //        if (file.PostedFile.ContentType.Equals(imgType[i].ToString()))
        //        {
        //            blean = true;
        //            break;
        //        }
        //        else if (i == (imgType.Length - 1))
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            i++;
        //        }
        //    }

        //    //对获得的路径进行分析处理 
        //    switch (blean)
        //    {
        //        case true:
        //            //服务器路径
        //            string serverpath = System.Web.HttpContext.Current.Server.MapPath(".") + "//";
        //            //上传和返回(保存到数据库中)的路径
        //            string uppath = string.Empty, savepath = string.Empty;
        //            //创建图片新的名称
        //            string nameImg = DateTime.Now.ToString("yyyyMMddHHmmss");
        //            //获得上传图片的路径
        //            string strPath = file.Value;
        //            //获得上传图片的类型(后缀名)
        //            string type = strPath.Substring(strPath.LastIndexOf(".") + 1).ToLower();
        //            //拼写数据库保存的相对路径字符串
        //            savepath = "..\\" + System.Configuration.ConfigurationSettings.AppSettings["imgPath"].ToString();
        //            savepath += nameImg + "." + type;
        //            //拼写上传图片的路径
        //            uppath = System.Web.HttpContext.Current.Server.MapPath("~/");
        //            uppath += System.Configuration.ConfigurationSettings.AppSettings["imgPath"].ToString();
        //            uppath += nameImg + "." + type;
        //            //上传图片
        //            file.PostedFile.SaveAs(uppath);
        //            message = savepath;
        //            break;
        //        case false:
        //            message = "您上传的为非图片请重新选择！";
        //            break;
        //        default: break;
        //    }
        //    return message;
        //}
    }
}

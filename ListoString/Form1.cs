using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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
            //string s = string.Join(",", list.ToArray());
            var sb = new StringBuilder();
            string separator = String.Empty;
            foreach (var value in list)
            {
                sb.Append(separator).Append(value);
                separator = ",";
            }

            MessageBox.Show(sb.ToString());
            //MessageBox.Show(list);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("{ \"张三\", \"李四\", \"王五\" }");
            list.Add("{ \"AAA\", \"BB\", \"CC\" }");
            list.Add("{ \"1张三\", \"2李四\", \"3王五\" }");

            //string[] s = { "张三", "李四", "王五" };
            //string myStr = string.Join("\r\n", s);
            string myStr = string.Join(",", list);
            MessageBox.Show(myStr);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string s = "1,2,3";
            string s = @"{ '三', '李四', '王五' },{ 'AAA', 'BB', 'CC' },{ '1张三', '2李四', '3王五' }";
            var joined = string.Join(",", s);

            MessageBox.Show(joined);
            List<string> list = new List<string>(joined.Split(','));
            list.ForEach(t => MessageBox.Show("*" + t + "*"));
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
            var str = "1,2";
            var tt = "1";
            var aa = tt.Split(',');

            List<string> list = new List<string>(tt.Split(','));

            MessageBox.Show(aa.Length.ToString());
            var date = DateTime.Now;

            //var dt1 = DateTime.Parse("2004-04-01").Year;
            //var dt2 = DateTime.Parse("2004-05-01").Year;

            //var year1 = dt1 < dt2 ? 0 : dt1 - dt2;
            //var diff1 = dt1.Subtract(dt2);
           // MessageBox.Show(year1.ToString());
            ////循环枚举
            //Dictionary<int, string> myDictionary = new Dictionary<int, string>();
            //foreach (QueryProgressEnum progresStatu in Enum.GetValues(typeof(QueryProgressEnum)))
            //{
            //    string strName = Enum.GetName(typeof(QueryProgressEnum), progresStatu);//获取名称
            //    int vaule = progresStatu;//获取值
            //    var tt = (QueryProgressEnum)progresStatu;
            //    tt.Description();
            //    myDictionary.Add(vaule, strName);
            //}
        }
        private void button9_Click(object sender, EventArgs e)
        {
            int a = 4780;
            int b;
            TimeSpan ts = new TimeSpan(0, 0, a);
            var ccc= (int)ts.TotalHours + "小时" + ts.Minutes + "分钟" + ts.Seconds + "秒";
            MessageBox.Show(ccc.ToString());

            //var dt = DateTime.Now.ToString("yyMMddhhmmss");
            //dt = "aa" + dt;
            //MessageBox.Show(dt);


        }

        private void button10_Click(object sender, EventArgs e)
        {
            var a ="";
            MessageBox.Show(a.ToString());
            int? bt = null;
            MessageBox.Show(bt.HasValue.ToString());
            MessageBox.Show(bt.GetValueOrDefault().ToString());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int outInt;
            bool boo = int.TryParse("123",out  outInt);
            MessageBox.Show(outInt.ToString());
        }
    }
}

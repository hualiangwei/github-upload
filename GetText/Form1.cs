using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace GetText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.DataBindings.Add("Text", textBox1, "Text");
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string text = string.Empty;
                foreach (var file in openFileDialog1.FileNames)
                {
                    using (Stream stream = File.OpenRead(file))
                    {
                        var reader = new StreamReader(stream);
                        text += "\r\n" + reader.ReadToEnd();
                    }
                }
                saveFileDialog1.Filter = "文本|*.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, text);
                    MessageBox.Show("导入完成");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // var a= JsonConvert.DeserializeObject<JTokenCrmModifyProspect>(richTextBox1.Text);
            var b = JsonSerializer.Deserialize<JTokenCrmModifyProspect>(richTextBox1.Text);

        }
    }
    public class JTokenCrmModifyProspect
    {
        public JTokenCrmDetail crm { get; set; }
        public JTokenCrmShop Shop { get; set; }
    }

    public class JTokenCrmShop
    {
        public int[] Id { get; set; }
        public string[] Name { get; set; }
        public int[] Brand { get; set; }
        public double[] Cost_rate { get; set; }
        public double[] Release_rate { get; set; }
        public int[] Debt { get; set; }
        public int[] Promoter { get; set; }//业务负责人
        public string[] Enable { get; set; }
        public int[] Join_fee { get; set; }
        public DateTime[] Join_time { get; set; }
        public DateTime[] Due_time { get; set; }
        public int[] Account { get; set; }
        public string[] Remark { get; set; }
        public string[] UserName { get; set; }
        public string[] Uid { get; set; }
        public string[] Pwd { get; set; }
        public string[] Phone { get; set; }
        public string[] Weixin { get; set; }
        public string[] Province { get; set; }
        public string[] City { get; set; }
        public string[] District { get; set; }
        public string[] Address { get; set; }
    }

    public class JTokenCrmDetail
    {
        public string[] Name { get; set; }
        public string[] Source { get; set; }
        public string[] Promoter { get; set; }//推荐人
        public string[] Phone { get; set; }
        public string[] Wechat { get; set; }
        public string[] Province { get; set; }
        public string[] City { get; set; }
        public string[] District { get; set; }
        public string[] Address { get; set; }
        public string[] Industry { get; set; }//行业
        public string[] Product_solution { get; set; }//窗帘解决方案
        public JTokenCrmWorry Worry { get; set; }//顾虑
        public string[] Intention { get; set; }//意向评估
        public int[] Creator { get; set; }//登记人
        public DateTime[] Time_creat { get; set; }
        public int[] Manager { get; set; }//招商负责人
        public string[] Demand { get; set; }//痛点需求
        public string[] Remark { get; set; }//备注
        public JTokenCrmIntroduce Introduce { get; set; }//介绍
        public CrmPolicy[][] Policy { get; set; }//承诺 
        public JTokenCrmRatelearn Rate_learn { get; set; }//学习进度
        public string[] Level_soft { get; set; }//软件水平
        public JTokenCrmReasonNoPurchase Reason_no_purchase { get; set; }//不采购原因
        public DateTime[] Time_last { get; set; }
        public DateTime[] Time_next { get; set; }
        public string[] Open_state { get; set; }
        public int[] Last_operator { get; set; }
    }
    public class CrmPolicy
    {
        public int Sort { get; set; }
        public string Promise { get; set; }
        public string Cash { get; set; }
        public bool Finish { get; set; }
        public override int GetHashCode() => Sort;
        public override bool Equals(object obj)
        {
            if (obj is CrmPolicy o)
            {
                return Sort == o.Sort
                    && Promise == o.Promise
                    && Cash == o.Cash
                    && Finish == o.Finish;
            }
            return false;
        }
    }
    public class JTokenCrmWorry
    {
        public string[] Price { get; set; }
        public string[] Material { get; set; }
        public string[] Technology { get; set; }
        public string[] Region { get; set; }
    }
    public class JTokenCrmIntroduce
    {
        public bool[] Standard { get; set; }
        public bool[] Factory { get; set; }
        public bool[] App { get; set; }
        public bool[] Applet { get; set; }
        public bool[] Pattern { get; set; }
        public bool[] Paltform { get; set; }
    }
    public class JTokenCrmRatelearn
    {
        public bool[] Down_load { get; set; }
        public bool[] Size { get; set; }
        public bool[] Card { get; set; }
        public bool[] Share { get; set; }
        public bool[] Custom { get; set; }
        public bool[] Purchase { get; set; }
        public bool[] Coupon { get; set; }
        public bool[] Acount { get; set; }
        public bool[] Search { get; set; }
        public bool[] Complex { get; set; }
        public bool[] Code { get; set; }
        public bool[] Change { get; set; }
        public string[] Other { get; set; }
    }
    public class JTokenCrmReasonNoPurchase
    {
        public bool[] Price { get; set; }
        public bool[] Service { get; set; }
        public bool[] Technology { get; set; }
        public bool[] Business { get; set; }
        public bool[] Material { get; set; }
        public bool[] Attitude { get; set; }
        public bool[] Edition { get; set; }
        public bool[] Forget { get; set; }
        public bool[] Style { get; set; }
        public bool[] Not_in_time { get; set; }
        public bool[] Out_of_stock { get; set; }
        public bool[] Soft { get; set; }
        public string[] Other { get; set; }
    }
}

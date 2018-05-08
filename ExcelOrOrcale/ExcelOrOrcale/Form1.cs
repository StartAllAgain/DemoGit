using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelOrOrcale
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Message;
            bool Is = RandData.IsOracleConn(out Message);
            if (Is)
            {
                MessageBox.Show("连接Oracle" + Message);
            }
            else
            {
                MessageBox.Show("连接Oracle" + Message);

            }

        }
        RandData data = new RandData();
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() == "")
            {

            }
            DataTable dt1 = RandData.getExcelData(openFileDialog1.FileName, comboBox1.Text);
            foreach (DataRow dr in dt1.Rows)
            {
                if (!data.IsGOP01Exist(dr["区域编号"].ToString()))
                {
                    string str = data.AddGOP01(dr["医院名称"].ToString(), dr["区域编号"].ToString(), "", "");
                }
            }
            if (comboBox1.Text == "科室信息")
            {
                DataTable dt = RandData.getExcelData(openFileDialog1.FileName, comboBox1.Text);
                foreach (DataRow dr in dt.Rows)
                {
                    if (!data.IsGOP02Exist(dr["科室代码"].ToString()))
                    {
                        string str = data.AddGOP02(RandData.getAearCode(dr["区域编号"].ToString()), dr["科室名称"].ToString(), dr["科室代码"].ToString(), "1");
                    }
                }
            }
            else if (comboBox1.Text == "医生信息")
            {
                DataTable dt = RandData.getExcelData(openFileDialog1.FileName, comboBox1.Text);
                foreach (DataRow dr in dt.Rows)
                {
                    if (!data.IsGOP03Exist(dr["医院名称"].ToString()))
                    {
                        string str = data.AddGOP03(RandData.getAearCode(dr["区域编号"].ToString()), dr["医生名称"].ToString(), dr["医生代码"].ToString(), "1");
                    }
                }
            }
            else if (comboBox1.Text == "收费项目信息")
            {
                DataTable dt = RandData.getExcelData(openFileDialog1.FileName, comboBox1.Text);
                foreach (DataRow dr in dt.Rows)
                {
                    if (!data.IsHIS01Exist(dr["医院名称"].ToString()))
                    {
                        string str = data.AddHIS01(int.Parse(RandData.getAearCode(dr["区域编号"].ToString())), dr["收费项目名称"].ToString(), dr["项目代码"].ToString(), float.Parse(dr["收费单价"].ToString()));
                    }
                }
            }

        }
    }
}

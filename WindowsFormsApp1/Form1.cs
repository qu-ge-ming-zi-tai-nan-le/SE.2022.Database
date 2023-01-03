using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(new User(), 1);
            form2.ShowDialog();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string sqlStr = "select Number,Name,Age,Major,Gender,Phone,Mail,UserType,Term,Signature from user";
            DataSet ds = MySqlHelper.ExecSqlQuery(sqlStr);
            if (ds != null && ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dataGridView1.CurrentRow;
            if (dr == null)
            {
                MessageBox.Show("请选择要修改的数据");
                return;
            }
            User user = new User();
            user.Number = Dr2Int(Dr2Str(dr.Cells["Number"].Value));
            user.Name = Dr2Str(dr.Cells["Name"].Value);
            user.Age = Dr2Int(Dr2Str(dr.Cells["Age"].Value));
            user.Major = Dr2Str(dr.Cells["Major"].Value);
            user.Gender = Dr2Str(dr.Cells["Gender"].Value);
            user.Phone = Dr2Str(dr.Cells["Phone"].Value);
            user.Mail = Dr2Str(dr.Cells["Mail"].Value);
            user.UserType = Dr2Int(Dr2Str(dr.Cells["UserType"].Value));
            user.Term = Dr2Int(Dr2Str(dr.Cells["Term"].Value));
            user.Signature = Dr2Str(dr.Cells["Signature"].Value);
            Form2 form2 = new Form2(user, 0);
            form2.ShowDialog();
        }
        public string Dr2Str(object o)
        {
            if (o != null)
            {
                return o.ToString();
            }
            return string.Empty;
        }
        public int Dr2Int(object o)
        {
            int result = 0;
            if (o != null)
            {
                int.TryParse(o.ToString(), out result);

            }
            return result;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dataGridView1.CurrentRow;
            if (dr == null)
            {
                MessageBox.Show("请选择要删除的数据");
                return;
            }
            string sqlStr = "delete from user where Number=@Number";
            MySqlParameter para = new MySqlParameter("@Number", dr.Cells["Number"].Value);
            if (MySqlHelper.ExecSql(sqlStr, para))
            {
                MessageBox.Show("删除成功");
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }
    }
}

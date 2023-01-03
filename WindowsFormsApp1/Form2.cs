using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        int _type = 0;
        public Form2(User user, int type)
        {
            InitializeComponent();
            _type = type;
            if (user != null)
            {
                textNumber.Text = user.Number.ToString();
                textName.Text = user.Name;
                textAge.Text = user.Age.ToString();
                textMajor.Text = user.Major;
                textGender.Text = user.Gender;
                textPhone.Text = user.Phone;
                textMail.Text = user.Mail;
                textUserType.Text = user.UserType.ToString();
                textTerm.Text = user.Term.ToString();
                textSignature.Text = user.Signature;
            }
            if (type == 1)
            {
                button1.Text = "添加";
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (_type == 1)
            {
                User user = new User();
                user.Number = Dr2Int(textNumber.Text);
                user.Name = textName.Text;
                user.Age = Dr2Int(textAge.Text);
                user.Major = textMajor.Text;
                user.Gender = textGender.Text;
                user.Phone = textPhone.Text;
                user.Mail = textMail.Text;
                user.UserType = Dr2Int(textUserType.Text);
                user.Term = Dr2Int(textTerm.Text);
                user.Signature = textSignature.Text;
                string sqlStr = "insert into user (Number,Name,Age,Major,Gender,Phone,Mail,UserType,Term,Signature) values(@Number,@Name,@Age,@Major,@Gender,@Phone,@Mail,@UserType,@Term,@Signature)";
                MySqlParameter[] para = new MySqlParameter[]
                {
                    new MySqlParameter("@Number",user.Number),
                    new MySqlParameter("@Name",user.Name),
                    new MySqlParameter("@Age",user.Age),
                    new MySqlParameter("@Major",user.Major),
                    new MySqlParameter("@Gender",user.Gender),
                    new MySqlParameter("@Phone",user.Phone),
                    new MySqlParameter("@Mail",user.Mail),
                    new MySqlParameter("@UserType",user.UserType),
                    new MySqlParameter("@Term",user.Term),
                    new MySqlParameter("@Signature",user.Signature)
                };
                if (MySqlHelper.ExecSql(sqlStr, para))
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else
            {
                string sqlStr = "update user set Number=@Number,Name=@Name,Age=@Age,Major=@Major,Gender=@Gender,Phone=@Phone,Mail=@Mail,UserType=@UserType,Term=@Term,Signature=@Signature where Number=@Number";
                MySqlParameter[] para = new MySqlParameter[]
               {
                    new MySqlParameter("@Number",Dr2Int(textNumber.Text)),
                    new MySqlParameter("@Name",textName.Text),
                    new MySqlParameter("@Age",Dr2Int(textAge.Text)),
                    new MySqlParameter("@Major",textMajor.Text),
                    new MySqlParameter("@Gender",textGender.Text),
                    new MySqlParameter("@Phone",textPhone.Text),
                    new MySqlParameter("@Mail",textMail.Text),
                    new MySqlParameter("@UserType",Dr2Int(textUserType.Text)),
                    new MySqlParameter("@Term",Dr2Int(textTerm.Text)),
                    new MySqlParameter("@Signature",textSignature.Text)
               };
                if (MySqlHelper.ExecSql(sqlStr, para))
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }

            }
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

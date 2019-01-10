using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace opcClient
{
    public partial class FormPWD : Form
    {
        //public FormPWD()
        public FormPWD(FormMain Parentform)//Parent form, 父視窗
        {
            InitializeComponent();
            this.Tag = Parentform;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (CheckPWDOK(textBoxPWD.Text))
            {
                //((FormMain)this.Tag).BackColor = Color.Gold;//傳值設定Form1的TextBox
                ((FormMain)this.Tag).EnableSetting(true);//執行Form1的Function

                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Password!");
            }
        }

        //private void FormPWD_Load(object sender, EventArgs e)
        //{
        //    textBoxPWD.Focus(); //Kenny: 無效, 待確認
        //    //textBoxPWD.Select(0, 0);//Kenny: 無效, 待確認
        //}

        private void textBoxPWD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//按下Enter鍵
            {
                if (CheckPWDOK(textBoxPWD.Text)) //確認密碼OK?
                {
                    //((FormMain)this.Tag).BackColor = Color.Gold;//傳值設定Form1的TextBox
                    ((FormMain)this.Tag).EnableSetting(true);//執行Form1的Function

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Password!");
                    textBoxPWD.Text = "";
                }

            }
        }

        private bool CheckPWDOK(string _input)
        {
            
            if (_input == "foxconnauto")
                return true;
            else
                return false;
        }

        private void FormPWD_Activated(object sender, EventArgs e)
        {
            textBoxPWD.Focus(); //FORM啟動完後成, 油標的初始位置

        }

    }
}

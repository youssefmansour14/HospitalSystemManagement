using HospitalSystemManagement.Model;
using HospitalSystemManagement.Test;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    public partial class Profile : Form
    {
        public static string Username{set;get;}
        UserLogic userLogin;
        DataContext dataContext;
        public Profile()
        {
            InitializeComponent();
            userLogin= new UserLogic();
            dataContext= new DataContext();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.FromArgb(224,224,224);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            var users = userLogin.getUsers(Username);
            if (users != null)
            {
                txtShowPassword.Visible = true;
                cmBoxShowPassword.Visible = true;
                cmBoxShowPassword.DataSource = users;
                cmBoxShowPassword.DisplayMember = "Username";
            }
            
             
        }

        private void cmBoxShowPassword_SelectedIndexChanged(object sender, EventArgs e)
        {
            string user = cmBoxShowPassword.SelectedItem.ToString();
           txtShowPassword.Text = dataContext.Users.Where(u => u.Username == user).Select(u => u.Password).First();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            UserAdmin user = dataContext.Users.Where(u => u.Username == Username).Select(u => u).First();
            if (user.Password == txtOldPassword.Text)
            {
                if (txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    user.Password = txtNewPassword.Text;
                    dataContext.SaveChanges();
                    MessageBox.Show("Password Changed Successfully ");
                    Close();
                }
                else
                {
                    lblConfirmPassError.Visible = true;
                }
            }
            else
            {
                oldPassError.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtOldPassword.UseSystemPasswordChar= !txtOldPassword.UseSystemPasswordChar;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtNewPassword.UseSystemPasswordChar = !txtNewPassword.UseSystemPasswordChar;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = !txtConfirmPassword.UseSystemPasswordChar;
        }
    }
}

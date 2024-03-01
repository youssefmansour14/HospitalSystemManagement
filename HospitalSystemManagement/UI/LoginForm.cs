using HospitalSystemManagement.Model;
using HospitalSystemManagement.Test;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {

            if(txtUsername.Text=="" || txtPassword.Text == "")
            {
                lblError.Visible = true;
            }
            else
            {
                UserLogic userLogin = new UserLogic();
                if (userLogin.Login(txtUsername.Text, txtPassword.Text))
                {
                    Hide();
                    Main main = new Main();
                    main.ShowDialog();
                    Close();
                }
                else{
                txtUsername.Clear();
                txtPassword.Clear();
                lblError.Visible = true; 
                }
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

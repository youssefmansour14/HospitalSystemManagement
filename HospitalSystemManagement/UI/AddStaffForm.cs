using HospitalSystemManagement.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    public partial class AddStaffForm : Form
    {
        DataContext dataContext;
        Staff staff;
        public AddStaffForm()
        {
            InitializeComponent();
            dataContext=new DataContext();
            btnUpdate.Visible=false;
        }
        internal AddStaffForm(Staff staff)
        {
            InitializeComponent();
            dataContext = new DataContext();
            btnAdd.Visible = false;
            this.staff = staff;
            txtName.Text = staff.Name;
            txtPhone.Text = staff.Phone;
            txtAddress.Text = staff.Address;
            txtJopTitle.Text = staff.JopTitle;
            txtSalary.Text = staff.Salary;
            dateTimePicker1.Value = staff.BirthDate;
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double salary = double.Parse(txtSalary.Text);
            dataContext.Staffs.Add(new Staff {
                Name=txtName.Text,
                Phone=txtPhone.Text,
                Address=txtAddress.Text,
                JopTitle=txtJopTitle.Text,
                Salary=txtSalary.Text,
                BirthDate=dateTimePicker1.Value
            });
            dataContext.SaveChanges();
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Staff st = dataContext.Staffs.First(s => s.ID == staff.ID);
            st.Name = txtName.Text;
            st.Phone = txtPhone.Text;
            st.Address = txtAddress.Text;
            st.JopTitle = txtJopTitle.Text;
            st.Salary = txtSalary.Text;
            st.BirthDate = dateTimePicker1.Value;
            dataContext.SaveChanges();
            Close();
        }
    }
}

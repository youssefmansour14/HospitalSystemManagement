using HospitalSystemManagement.Model;
using HospitalSystemManagement.PrinterReports;
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
    public partial class StaffForm : Form
    {
        DataContext dataContext;
        public StaffForm()
        {
            InitializeComponent();
            dataContext = new DataContext();
            fillStaff();
        }

        void fillStaff() {
            dgvStaff.DataSource = dataContext.Staffs.Select(s => new
            {
                s.ID,
                s.Name,
                s.Address,
                s.Phone,
                Age = DateTime.Now.Year - s.BirthDate.Year,
                s.JopTitle,
                s.Salary
            }).ToList();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.FromArgb(224,224,224);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStaffForm addStaffForm = new AddStaffForm();
            addStaffForm.ShowDialog();
            fillStaff();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintReports.print("Employees Report ", dataContext.Staffs.Select(s => new
            {
                s.ID,
                s.Name,
                s.Address,
                s.Phone,
                Age = DateTime.Now.Year - s.BirthDate.Year,
                s.JopTitle,
                s.Salary
            }).ToList());
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
            { lblCancel.Visible = false; fillStaff(); }
            else lblCancel.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvStaff.DataSource = dataContext.Staffs.Select(s => new
            {
                s.ID,
                s.Name,
                s.Address,
                s.Phone,
                Age = DateTime.Now.Year - s.BirthDate.Year,
                s.JopTitle,
                s.Salary
            }).Where(s=>s.Name.Contains(txtSearch.Text)||s.Address.Contains(txtSearch.Text)||
            s.Phone.Contains(txtSearch.Text)||s.JopTitle.Contains(txtSearch.Text)).ToList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStaff.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = int.Parse(dgvStaff.CurrentRow.Cells[0].Value.ToString());
                Staff staff = dataContext.Staffs.Select(pa => pa).First(p => p.ID == id);
                
                AddStaffForm addPatientForm = new AddStaffForm(staff);
                addPatientForm.ShowDialog();
                fillStaff();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStaff.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Do you want to delete this field", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int id = int.Parse(dgvStaff.CurrentRow.Cells[0].Value.ToString());
                    Staff staff = dataContext.Staffs.Select(pa => pa).First(p => p.ID == id);

                    dataContext.Staffs.Remove(staff);
                    dataContext.SaveChanges();
                    fillStaff();
                }
            }
        }
    }
}

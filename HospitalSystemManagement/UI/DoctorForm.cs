using HospitalSystemManagement.Model;
using HospitalSystemManagement.PrinterReports;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    public partial class DoctorForm : Form
    {
        DataContext dataContext;
        public DoctorForm()
        {
            InitializeComponent();
            dataContext = new DataContext();
            fillDocotr();
        }
        void fillDocotr()
        {
            var doctors = dataContext.Doctors.Select(d =>
                new { d.ID, d.Name, d.Email, d.Phone, d.Salary, d.Address, Department = d.Department.Name, Age = DateTime.Now.Year - d.BirthDate.Year }).ToList();
            dgvDoctor.DataSource = doctors;
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
                lblCancel.Visible = false;
            else lblCancel.Visible = true;
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var doctors = dataContext.Doctors.Select(d =>
               new { d.ID, d.Name, d.Email, d.Phone, d.Salary, d.Address, Department = d.Department.Name, Age = DateTime.Now.Year - d.BirthDate.Year }).ToList();
            PrintReports.print("Doctors Report", doctors);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDoctorForm addDoctorForm = new AddDoctorForm();
            addDoctorForm.ShowDialog();
            fillDocotr();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDoctor.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = int.Parse(dgvDoctor.CurrentRow.Cells[0].Value.ToString());
                AddDoctorForm addDoctorForm = new AddDoctorForm(dataContext.Doctors.First(d => d.ID == id));
                addDoctorForm.ShowDialog();
                fillDocotr();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDoctor.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Do you want to delete this field", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        int id = int.Parse(dgvDoctor.CurrentRow.Cells[0].Value.ToString());
                        var doctor = dataContext.Doctors.FirstOrDefault(d => d.ID == id);
                        var patient = dataContext.Patients.Select(p => new { p.Doctor });

                        dataContext.Doctors.Remove(doctor);
                        dataContext.SaveChanges();
                        fillDocotr();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("can't to delete item that related anthor table");
                    }
                    
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var result = dataContext.Doctors.Where(p => p.Name.Contains(txtSearch.Text)||p.Department.Name.Contains(txtSearch.Text)||p.Address.Contains(txtSearch.Text)||p.Email.Contains(txtSearch.Text)).
               Select(d =>
           new { d.ID, d.Name, d.Email, d.Phone, d.Salary, d.Address, department = d.Department.Name, d.BirthDate });
            dgvDoctor.DataSource = result.ToList();
        }
    }
}

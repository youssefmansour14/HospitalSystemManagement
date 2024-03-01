using HospitalSystemManagement.Model;
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
    public partial class Reservation : Form
    {
        DataContext dataContext;
        public Reservation()
        {
            InitializeComponent();
            dataContext=new DataContext();
            var patient = dataContext.Patients.Select(p => new
            {
                p.ID,
                p.NationalID,
                p.Name,
                p.Address,
                p.Description,
                Doctor = p.Doctor.Name,
                p.BloodType,
                Room = p.Room.ID


            }).ToList();
            dgvRservation.DataSource = patient;
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

        private void lblCancel_Click(object sender, EventArgs e)
        {
            dgvRservation.DataSource = dataContext.Patients.ToList();
            txtSearch.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text))
                lblCancel.Visible = false;
            else lblCancel.Visible = true;
        }

        private void btnSearchDept_Click(object sender, EventArgs e)
        {
            dgvRservation.DataSource = dataContext.Patients.Where(p=>p.NationalID.Contains(txtSearch.Text)||p.Name.Contains(txtSearch.Text)||p.Address.Contains(txtSearch.Text)||p.Doctor.Name.Contains(txtSearch.Text)||p.Description.Contains(txtSearch.Text)).ToList();
        }
    }
}

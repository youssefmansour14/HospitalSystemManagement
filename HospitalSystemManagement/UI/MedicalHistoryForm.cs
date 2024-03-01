using HospitalSystemManagement.Model;
using HospitalSystemManagement.PrinterReports;
using HospitalSystemManagement.Resources;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    public partial class MedicalHistoryForm : Form
    {
        DataContext dataContext;
        public MedicalHistoryForm()
        {
            InitializeComponent();
            dataContext = new DataContext();
            fillMedicalHistory();
        }
       void fillMedicalHistory() {
        dgvMedical.DataSource = dataContext.MedicalHistories.ToList();
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text)) { lblCancel.Visible = false; fillMedicalHistory(); }
            else lblCancel.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvMedical.DataSource = dataContext.MedicalHistories.Where(m => m.PatientName.Contains(txtSearch.Text) || m.Treatment.Contains(txtSearch.Text) || m.Diagnosis.Contains(txtSearch.Text) || m.OtherDetails.Contains(txtSearch.Text)).ToList();
        }

        private void btnPrintPayment_Click(object sender, EventArgs e)
        {
            PrintReports.print("Medical History Report",dataContext.MedicalHistories.ToList());
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.White;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.FromArgb(224,224,224);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMedicalForm addMedicalForm = new AddMedicalForm();
            addMedicalForm.ShowDialog();
            fillMedicalHistory();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMedical.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = int.Parse(dgvMedical.CurrentRow.Cells[0].Value.ToString());
                MedicalHistory medicalHistory = dataContext.MedicalHistories.First(m => m.MedicalHistoryID == id);
                AddMedicalForm addMedicalForm = new AddMedicalForm(medicalHistory);
                addMedicalForm.ShowDialog();
                fillMedicalHistory();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMedical.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Do you want to delete this field", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int x = int.Parse((dgvMedical.CurrentRow.Cells[0].Value).ToString());
                    var medical = dataContext.MedicalHistories.Where(d => d.MedicalHistoryID == x).First();
                    dataContext.MedicalHistories.Remove(medical);
                    dataContext.SaveChanges();
                    fillMedicalHistory();
                }
            }
        }
    }
}

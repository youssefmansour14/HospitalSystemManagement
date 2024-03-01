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

namespace HospitalSystemManagement.Resources
{
    public partial class AddMedicalForm : Form
    {
        DataContext dataContext;
        MedicalHistory medicalHistory;
        public AddMedicalForm()
        {
            InitializeComponent();
            dataContext=new DataContext();
            btnUpdate.Visible = false;
            cmBoxPatients.DataSource = dataContext.Patients.ToList();
            cmBoxPatients.DisplayMember = "Name";
            txtName.Visible=false;
        }
        internal AddMedicalForm(MedicalHistory medicalHistory)
        {
            InitializeComponent();
            dataContext = new DataContext();
            this.medicalHistory = medicalHistory;
            btnAdd.Visible = false;
            cmBoxPatients.Visible = false;
            txtName.Text = medicalHistory.PatientName;
            txtDiagnois.Text = medicalHistory.Diagnosis;
            txtTreatement.Text = medicalHistory.Treatment;
            txtMedication.Text = medicalHistory.Medication;
            txtOtherDetails.Text = medicalHistory.OtherDetails;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDiagnois_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.FromArgb(224,224,224);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Patient patient = (Patient)cmBoxPatients.SelectedItem;
            dataContext.MedicalHistories.Add(new MedicalHistory { 
            PatientName=patient.Name,
            PatientID=patient.ID,
            Diagnosis=txtDiagnois.Text,
            Treatment=txtTreatement.Text,
            Medication=txtMedication.Text,
            OtherDetails=txtOtherDetails.Text
            });
            dataContext.SaveChanges();
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MedicalHistory medical = dataContext.MedicalHistories.First(m=>m.MedicalHistoryID==medicalHistory.MedicalHistoryID);

            medical.PatientName = txtName.Text;
            medical.Diagnosis = txtDiagnois.Text;
            medical.Treatment = txtTreatement.Text;
            medical.Medication = txtMedication.Text;
            medical.OtherDetails = txtOtherDetails.Text;
            dataContext.SaveChanges();
            Close();
        }
    }
}

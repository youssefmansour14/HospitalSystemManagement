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
    public partial class AddPaymentForm : Form
    {
        DataContext dataContext;
        Payments payment;
        public AddPaymentForm()
        {
            InitializeComponent();
            dataContext = new DataContext();
            getPatients();
            btnDone.Enabled = false;
            btnUpdate.Visible = false;
            txtPatientName.Visible = false;
        }
        internal AddPaymentForm(Payments payment)
        {
            InitializeComponent();
            this.payment= payment;
            dataContext = new DataContext();
            txtPatientName.Text = payment.PatientName;
            txtTotal.Text = payment.Total.ToString();
            txtPaymented.Text = payment.Paymented.ToString();
            txtRemained.Text = payment.Remained.ToString();
            btnDone.Visible = false;
            cmBoxPatientName.Visible = false;
        }
        List<Patient> getPatients()
        {
            var patients = dataContext.Patients.Select(p=>p).ToList();
            foreach (var patient in patients) {
            cmBoxPatientName.Items.Add(patient.Name);
            }
            return patients;
        }
        private void txtTotal_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void txtTotal_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.FromArgb(224,224,224);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            
        }

        private void txtRemained_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTotal.Text) || int.Parse(txtTotal.Text) == 0)
            { txtTotal.Text = "0"; btnDone.Enabled = false; btnUpdate.Enabled = false; }
            else
            {
                btnUpdate.Enabled = true;
                btnDone.Enabled = true;
            }
           txtRemained.Text = (int.Parse(txtTotal.Text) - int.Parse(txtPaymented.Text)).ToString();
                       
        }

        private void txtPaymented_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtPaymented.Text))
                txtPaymented.Text = "0";

            if (int.Parse(txtPaymented.Text) > int.Parse(txtTotal.Text) || int.Parse(txtTotal.Text)==0)
            {
                btnDone.Enabled = false;
                lblError.Visible = true;
                btnUpdate.Enabled = false;
            }
            else
            {
                btnDone.Enabled = true;
                lblError.Visible = false;
                btnUpdate.Enabled = true;
            }
            txtRemained.Text = (int.Parse(txtTotal.Text) - int.Parse(txtPaymented.Text)).ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           

        }

        private void btnDone_Click_1(object sender, EventArgs e)
        {
            int index = cmBoxPatientName.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("Must choose the patient name !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Patient patient = getPatients()[index];
                double total = double.Parse(txtTotal.Text);
                double paymented = double.Parse(txtPaymented.Text);
                double remained = double.Parse(txtRemained.Text);
                bool status = remained == 0 ? true : false;
                dataContext.Payments.Add(new Payments { PatientID = patient.ID, PatientName = patient.Name, Date = dateTimePicker1.Value, Total = total, Paymented = paymented, Remained = remained, Status = status });
                dataContext.SaveChanges();
                Close();
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            Payments pay = dataContext.Payments.Where(p => p.ID == payment.ID).First();
            pay.Total = double.Parse(txtTotal.Text);
            pay.Paymented = double.Parse(txtPaymented.Text);
            pay.Remained = double.Parse(txtRemained.Text);
            pay.Status = double.Parse(txtRemained.Text) == 0 ? true : false;
            pay.Date = dateTimePicker1.Value;
            dataContext.SaveChanges();
            Close();
        }
    }
}

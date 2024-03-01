using HospitalSystemManagement.Model;
using DGVPrinterHelper;
using HospitalSystemManagement.PrinterReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    public partial class PaymentForm : Form
    {
        DataContext dataContext;
        public PaymentForm()
        {
            InitializeComponent();
            dataContext=new DataContext();
            fillPaymentData();
        }
        void fillPaymentData() {
            dgvPayment.DataSource = dataContext.Payments.Select(pay => pay).ToList();
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
            AddPaymentForm addPaymentForm = new AddPaymentForm();
            addPaymentForm.ShowDialog();
            fillPaymentData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPayment.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = int.Parse(dgvPayment.CurrentRow.Cells[0].Value.ToString());
                Payments pay = dataContext.Payments.First(d => d.ID == id);
                AddPaymentForm editPaymentForm = new AddPaymentForm(pay);
                editPaymentForm.ShowDialog();
                fillPaymentData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPayment.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Do you want to delete this field", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int id = int.Parse(dgvPayment.CurrentRow.Cells[0].Value.ToString());
                    Payments pay = dataContext.Payments.First(p => p.ID == id);
                    dataContext.Payments.Remove(pay);
                    dataContext.SaveChanges();
                    fillPaymentData();
                }
            }
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            fillPaymentData();
            txtSearch.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text)) { lblCancel.Visible = false; fillPaymentData(); }
            else lblCancel.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var payments = dataContext.Payments.Where(p => p.PatientName.Contains(txtSearch.Text)).ToList();
            dgvPayment.DataSource = payments;
        }

        private void cmBoxPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBoxPayment.SelectedIndex == 1) {
                var currentPatients = dataContext.Patients.ToList();
                List<Payments> payments = new List<Payments>();
                if (currentPatients.Count > 0)
                {
                    foreach(var patient in currentPatients)
                    {
                        var currentPayment= dataContext.Payments.FirstOrDefault(p => p.PatientID == patient.ID);
                        if (currentPayment != null)
                        {
                            payments.Add(currentPayment);
                        }
                    }
                    dgvPayment.DataSource = payments;
                }
              
            } else
            {
                fillPaymentData();
            }
        }

        private void btnPrintPayment_Click(object sender, EventArgs e)
        {
            PrintReports.print("Payment Report",dataContext.Payments.ToList());  
        }
    }
}

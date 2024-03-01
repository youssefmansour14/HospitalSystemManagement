using HospitalSystemManagement.Model;
using HospitalSystemManagement.PrinterReports;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    public partial class HistoryForm : Form
    {
        DataContext dataContext;
        public HistoryForm()
        {
            InitializeComponent();
            dataContext = new DataContext();
            fillHistory();
            cmBoxYealyHistory.DataSource = dataContext.Histories.Select(h => h.StartDate.Year).Distinct().ToList();
        }
        void fillHistory() {
            dgvHistory.DataSource = dataContext.Histories.Select(h => new
            {
               h.ID,
               h.PatientName,
               h.PatientId,
               h.Doctor.Name,
              RoomID= h.Room.ID,
               h.StartDate,
               h.EndDate,
               h.Description
            }).ToList();
        }

        private void txtSearchHistory_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void txtSearchHistory_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void cmBoxYealyHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = int.Parse(cmBoxYealyHistory.Text);
            dgvHistory.DataSource = dataContext.Histories.Select(h => new {
                h.ID,
                h.PatientName,
                h.PatientId,
                h.Doctor.Name,
                RoomID = h.Room.ID,
                h.StartDate,
                h.EndDate,
                h.Description
            }).Where(h=>h.StartDate.Year==year).ToList();
        }

        private void cmBoxMonthlyHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = int.Parse(cmBoxYealyHistory.Text);
            int month = int.Parse(cmBoxMonthlyHistory.Text);
            dgvHistory.DataSource = dataContext.Histories.Select(h=>new {
                h.ID,
                h.PatientName,
                h.PatientId,
                h.Doctor.Name,
                RoomID = h.Room.ID,
                h.StartDate,
                h.EndDate,
                h.Description
            }).Where(h => h.StartDate.Year == year && h.StartDate.Month==month).ToList();

        }

        private void dtimepHistory_ValueChanged(object sender, EventArgs e)
        {
            int year = dtimepHistory.Value.Year;
            int month = dtimepHistory.Value.Month;
            int day = dtimepHistory.Value.Day;

            dgvHistory.DataSource = dataContext.Histories.Select(h =>new {
                h.ID,
                h.PatientName,
                h.PatientId,
                h.Doctor.Name,
                RoomID = h.Room.ID,
                h.StartDate,
                h.EndDate,
                h.Description
            }).Where(h => h.StartDate.Day == day&&h.StartDate.Month==month&&h.StartDate.Year==year).ToList();
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtSearchHistory_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text)) { lblCancel.Visible = false;fillHistory(); }
            else lblCancel.Visible = true;
        }

        private void btnSearchHistory_Click(object sender, EventArgs e)
        {
            dgvHistory.DataSource = dataContext.Histories.Select(h=>new {
                h.ID,
                h.PatientName,
                h.PatientId,
                h.Doctor.Name,
                RoomID = h.Room.ID,
                h.StartDate,
                h.EndDate,
                h.Description
            }).Where(h=>h.PatientName.Contains(txtSearch.Text)||h.Description.Contains(txtSearch.Text)
            ).ToList();
          
        }

        private void btnPrintHistory_Click(object sender, EventArgs e)
        {
            PrintReports.print("History of Hospital ", dataContext.Histories.Select(h => new
            {
                h.ID,
                h.PatientName,
                h.PatientId,
                h.Doctor.Name,
                RoomID = h.Room.ID,
                h.StartDate,
                h.EndDate,
                h.Description
            }).ToList());
        }
    }
}

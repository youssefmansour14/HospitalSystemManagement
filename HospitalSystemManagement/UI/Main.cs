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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Reservation reservation = new Reservation() { TopLevel = false };
            panel2.Controls.Add(reservation);
            reservation.Show();
        }

        private void btnFloors_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            FloorrsOfHospital floorrsOfHospital = new FloorrsOfHospital() { TopLevel = false };
            panel2.Controls.Add(floorrsOfHospital);
            floorrsOfHospital.Show();
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            DepartmentForm departmentForm = new DepartmentForm() { TopLevel = false };
            panel2.Controls.Add(departmentForm);
            departmentForm.Show();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            RoomForm roomForm = new RoomForm() { TopLevel = false };
            panel2.Controls.Add(roomForm);
            roomForm.Show();
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            DoctorForm doctorForm = new DoctorForm() { TopLevel = false };
            panel2.Controls.Add(doctorForm);
            doctorForm.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            StaffForm staffForm = new StaffForm() { TopLevel = false };
            panel2.Controls.Add(staffForm);
            staffForm.Show();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            PatientForm patientForm = new PatientForm() { TopLevel = false };
            panel2.Controls.Add(patientForm);
            patientForm.Show();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            PaymentForm payment = new PaymentForm() { TopLevel = false };
            panel2.Controls.Add(payment);
            payment.Show();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            HistoryForm history = new HistoryForm() { TopLevel = false };
            panel2.Controls.Add(history);
            history.Show();
        }

        private void btnReception_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            Reservation reservation = new Reservation() { TopLevel = false };
            panel2.Controls.Add(reservation);
            reservation.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            InveForm inventoryForm = new InveForm() { TopLevel=false};
            panel2.Controls.Add(inventoryForm);
            inventoryForm.Show();
        }

        private void btnMedical_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            MedicalHistoryForm medicalHistoryForm = new MedicalHistoryForm() { TopLevel = false };
            panel2.Controls.Add(medicalHistoryForm);
            medicalHistoryForm.Show();
        }
    }
}

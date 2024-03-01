using HospitalSystemManagement.BusinessLogic;
using HospitalSystemManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    public partial class AddPatientForm : Form
    {
        DataContext dataContext;
        Patient patient;
       
        PatientLogic patientLogic = new PatientLogic();
        int oldRoomID;
        public AddPatientForm()
        {
            InitializeComponent();
            dataContext = new DataContext();
            cmBoxDoctorName.DataSource = dataContext.Doctors.ToList();
            cmBoxDoctorName.DisplayMember = "Name";
            cmBoxRoom.DataSource = patientLogic.GetEmptyRooms();
            cmBoxRoom.DisplayMember = "ID";
            btnUpdate.Visible = false;
        }
        internal AddPatientForm(Patient patient,Doctor doctor ,int roomID)
        {
            InitializeComponent();
            dataContext = new DataContext();
            this.patient = patient;
            this.oldRoomID=roomID;
           
            cmBoxDoctorName.DataSource = patientLogic.GetDoctors(patient.ID);
            cmBoxDoctorName.DisplayMember = "Name";

            cmBoxRoom.DataSource = patientLogic.GetRooms(roomID);
            cmBoxRoom.DisplayMember = "ID";

            cmBoxRoom.Text = roomID.ToString();
            txtName.Text = patient.Name;
            txtNID.Text = patient.NationalID;
            txtPhone.Text = patient.Phone;
            txtAddress.Text = patient.Address;
            txtDescription.Text = patient.Description;
            cmBoxBlood.Text = patient.BloodType;
                    btnAdd.Visible = false;      
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

        private void btnAdd_Click(object sender, EventArgs e)
        { Doctor doctor= cmBoxDoctorName.SelectedItem as Doctor;
            if (patientLogic.AddPatient(txtName.Text, txtNID.Text, txtAddress.Text, txtPhone.Text, txtDescription.Text,
                cmBoxBlood.Text, doctor.ID, cmBoxRoom.SelectedItem as Room))
                Close();
            else MessageBox.Show("Somthing Error Check Validate Data and Try Again","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
         
        }

        private void txtNID_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressNumber.KeyPressNumber(sender,e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Doctor doctor = cmBoxDoctorName.SelectedItem as Doctor;
            Room room = cmBoxRoom.SelectedItem as Room;
            if (patientLogic.UpdatePatient(patient.ID,txtName.Text, txtNID.Text, txtAddress.Text, txtPhone.Text, txtDescription.Text,
                   cmBoxBlood.Text, doctor.ID,oldRoomID ,room.ID))
                Close();
            else MessageBox.Show("Somthing Error Check Validate Data and Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

using HospitalSystemManagement.BusinessLogic;
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
    public partial class AddOrEditFloors : Form
    {
      Floor floorOfHospital;
        FloorLogic floorLogic;
        int id;

        public AddOrEditFloors()
        {
            InitializeComponent();
            btnSave.Enabled=false;
           btnUpdate.Visible=false;
            floorLogic = new FloorLogic();
        }
        internal AddOrEditFloors(Floor floorOfHospital)
        {
            InitializeComponent();
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            this.floorOfHospital = floorOfHospital;
            txtNameOfFloor.Text = floorOfHospital.Name;
            txtNumOfRoom.Text = floorOfHospital.NumberOfRooms.ToString();
            floorLogic = new FloorLogic();
        }

        private void txtNameOfFloower_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void txtNameOfFloower_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtNumOfRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressNumber.KeyPressNumber(sender,e);
        }

        private void txtNumOfRoom_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNumOfRoom.Text) || int.Parse(txtNumOfRoom.Text) == 0)
            { txtNumOfRoom.Text = "0"; btnSave.Enabled = false; btnUpdate.Enabled = false; }
            else
            {
                btnUpdate.Enabled = true;
                btnSave.Enabled = true;
            }
        }
        private void btnSaveFloor_Click(object sender, EventArgs e)
        {
           if(floorLogic.AddFloor(txtNameOfFloor.Text,int.Parse(txtNumOfRoom.Text)))Close();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
           if(floorLogic.UpdateFloor(floorOfHospital.ID, txtNameOfFloor.Text, floorOfHospital.Name, int.Parse(txtNumOfRoom.Text)))Close();
        }
    }
}

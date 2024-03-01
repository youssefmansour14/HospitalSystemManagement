using HospitalSystemManagement.BusinessLogic;
using HospitalSystemManagement.Model;
using HospitalSystemManagement.PrinterReports;
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
    public partial class RoomForm : Form
    {
        RoomLogic roomLogic;
        public RoomForm()
        {
            InitializeComponent();
            roomLogic = new RoomLogic();
            dgvRoom.DataSource = roomLogic.GetAllRoom();
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
            AddRoom addRoom = new AddRoom();
            addRoom.ShowDialog();
            dgvRoom.DataSource = roomLogic.GetAllRoom();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRoom.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = int.Parse(dgvRoom.CurrentRow.Cells[0].Value.ToString());
                AddRoom addRoom = new AddRoom(roomLogic.GetRoom(id));
                addRoom.ShowDialog();
                dgvRoom.DataSource = roomLogic.GetAllRoom();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRoom.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id =int.Parse(dgvRoom.CurrentRow.Cells[0].Value.ToString());
                roomLogic.DeleteRoom(id);
               dgvRoom.DataSource= roomLogic.GetAllRoom();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           PrintReports.print("Rooms Report", roomLogic.GetAllRoom());
        }
        
    }
}

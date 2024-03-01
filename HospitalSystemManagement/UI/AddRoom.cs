using HospitalSystemManagement.BusinessLogic;
using HospitalSystemManagement.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    public partial class AddRoom : Form
    {
        DataContext dataContext;
        Room room1;
        RoomLogic roomLogic;
        public AddRoom()
        {
            InitializeComponent();
            dataContext = new DataContext();
            cmBoxLocation.DataSource=dataContext.Floors.ToList();
            cmBoxLocation.DisplayMember = "Name";
            cmBoxDept.DataSource = dataContext.Departments.ToList();
            cmBoxDept.DisplayMember = "Name";
            btnUpdate.Visible = false;
            roomLogic = new RoomLogic();
        }
        internal AddRoom(Room room)
        {
            InitializeComponent();
            dataContext = new DataContext();
            this.room1 = room;
            cmBoxLocation.DataSource = dataContext.Floors.ToList();
            cmBoxLocation.DisplayMember = "Name";
            cmBoxDept.DataSource = dataContext.Departments.ToList();
            cmBoxDept.DisplayMember = "Name";
            btnSave.Visible = false;
            roomLogic = new RoomLogic();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (roomLogic.AddRoom(cmBoxDept.SelectedItem as Department, cmBoxLocation.SelectedItem as Floor))
                Close();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (roomLogic.UpdateRoom(room1.ID,cmBoxDept.SelectedItem as Department, cmBoxLocation.SelectedItem as Floor))
                Close();
        }
    }
}

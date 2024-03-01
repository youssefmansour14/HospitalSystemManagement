using HospitalSystemManagement.BusinessLogic;
using HospitalSystemManagement.Model;
using HospitalSystemManagement.PrinterReports;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    public partial class FloorrsOfHospital : Form
    {
        
        FloorLogic floorLogic;
        public FloorrsOfHospital()
        {
            InitializeComponent();
            floorLogic = new FloorLogic();
            dgvFloor.DataSource = floorLogic.GetAllFloor();
        }
     

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddOrEditFloors addOrEditFloors = new AddOrEditFloors();
            addOrEditFloors.ShowDialog();
            dgvFloor.DataSource = floorLogic.GetAllFloor();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvFloor.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = int.Parse(dgvFloor.CurrentRow.Cells[0].Value.ToString());
                AddOrEditFloors addOrEditFloors = new AddOrEditFloors(floorLogic.GetFloor(id));
                addOrEditFloors.ShowDialog();
                dgvFloor.DataSource = floorLogic.GetAllFloor();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFloor.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Do you want to delete this field", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int id = int.Parse((dgvFloor.CurrentRow.Cells[0].Value).ToString());
                    floorLogic.DeleteFloor(id);
                    dgvFloor.DataSource = floorLogic.GetAllFloor();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintReports.print("Floor of Hospital Report",floorLogic.GetAllFloor());
        }
    }
}

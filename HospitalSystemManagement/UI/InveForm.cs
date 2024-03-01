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
    public partial class InveForm : Form
    {
        DataContext dataContext;
        public InveForm()
        {
            InitializeComponent();
            dataContext = new DataContext();
            fillInventory();
        }
        void fillInventory()
        {
            dgvInventor.DataSource = dataContext.Inventories.ToList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvInventor.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = int.Parse(dgvInventor.CurrentRow.Cells[0].Value.ToString());
                Inventory inventory = dataContext.Inventories.First(m => m.ID == id);
                AddInventoryForm addMedicalForm = new AddInventoryForm(inventory);
                addMedicalForm.ShowDialog();
                fillInventory();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvInventor.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Do you want to delete this field", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int x = int.Parse((dgvInventor.CurrentRow.Cells[0].Value).ToString());
                    Inventory inventory = dataContext.Inventories.First(d => d.ID == x);
                    dataContext.Inventories.Remove(inventory);
                    dataContext.SaveChanges();
                    fillInventory();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddInventoryForm addInventoryForm = new AddInventoryForm();
            addInventoryForm.ShowDialog();
            fillInventory();
        }

        private void btnPrintPayment_Click(object sender, EventArgs e)
        {
            PrintReports.print("Inventory Report", dataContext.Inventories.ToList());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text)) { lblCancel.Visible = false; fillInventory(); }
            else lblCancel.Visible = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvInventor.DataSource = dataContext.Inventories.Where(m => m.ItemName.Contains(txtSearch.Text) || m.SupplierName.Contains(txtSearch.Text) || m.SupplierPhone.Contains(txtSearch.Text)).ToList();
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.White;
        }


    }
}

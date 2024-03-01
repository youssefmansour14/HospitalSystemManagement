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
    public partial class AddInventoryForm : Form
    {
        DataContext dataContext;
        Inventory inventory;
        public AddInventoryForm()
        {
            InitializeComponent();
            dataContext = new DataContext();
            btnUpdate.Visible=false;
        }
        public AddInventoryForm(Inventory inventory)
        {
            InitializeComponent();
            dataContext = new DataContext();
            btnAdd.Visible = false;
            this.inventory = inventory;
            txtName.Text = inventory.ItemName;
            txtQuantity.Text = inventory.Quantity.ToString();
            txtUnitPrice.Text = inventory.UnitPrice.ToString();
            txtSupName.Text = inventory.SupplierName.ToString();
            txtSupPhone.Text = inventory.SupplierPhone.ToString();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.BackColor = Color.White;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.BackColor = Color.FromArgb(224,224,224);
        }

        private void txtDiagnois_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(txtQuantity.Text);
            double unitPrice = double.Parse(txtUnitPrice.Text);

            dataContext.Inventories.Add(new Inventory
            {
                ItemName=txtName.Text,
                Quantity=quantity,
                UnitPrice=unitPrice,
                SupplierName=txtSupName.Text,
                SupplierPhone=txtSupPhone.Text
            });
            dataContext.SaveChanges();
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Inventory inventoryUpdate = dataContext.Inventories.First(i=>i.ID==inventory.ID);
            inventoryUpdate.SupplierPhone = txtSupPhone.Text;
            inventoryUpdate.SupplierName = txtSupName.Text;
            inventoryUpdate.UnitPrice = double.Parse(txtUnitPrice.Text);
            inventoryUpdate.Quantity = int.Parse(txtQuantity.Text);
            inventoryUpdate.ItemName = txtName.Text;
            dataContext.SaveChanges();
            Close();
        }
    }
}

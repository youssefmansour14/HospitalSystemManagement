using HospitalSystemManagement.BusinessLogic;
using HospitalSystemManagement.Model;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    public partial class DepartmentForm : Form
    {
        DataContext dataContext;
        DepartmentLogic departmentLogic;
        public DepartmentForm()
        {
            InitializeComponent();
           dataContext = new DataContext();
            departmentLogic = new DepartmentLogic();
            dgvDepartment.DataSource= departmentLogic.getAllDept();
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
            AddDepartmentForm addDepartmentForm = new AddDepartmentForm();
            addDepartmentForm.ShowDialog();
            dgvDepartment.DataSource = departmentLogic.getAllDept();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDepartment.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                int id = int.Parse(dgvDepartment.CurrentRow.Cells[0].Value.ToString());
                AddDepartmentForm addDepartmentForm = new AddDepartmentForm(departmentLogic.getDept(id));
                addDepartmentForm.ShowDialog();
                dgvDepartment.DataSource = departmentLogic.getAllDept();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDepartment.CurrentCell == null)
            {
                MessageBox.Show("No Data for make this operator !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Do you want to delete this field", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int id = int.Parse((dgvDepartment.CurrentRow.Cells[0].Value).ToString());
                    departmentLogic.deleteDept(id);
                    dgvDepartment.DataSource = departmentLogic.getAllDept();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDepartment.DataSource = departmentLogic.searchDept(txtSearch.Text);
        }

        private void lblCancel_Click(object sender, EventArgs e)
        {
            dgvDepartment.DataSource = departmentLogic.getAllDept();
            txtSearch.Clear();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text)) lblCancel.Visible = false;
            else lblCancel.Visible = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrinterReports.PrintReports.print("Department Reports",departmentLogic.getAllDept());
        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            dgvDepartment.DataSource = departmentLogic.getAllDept();
        }
    }
}

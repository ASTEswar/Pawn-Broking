using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Pawn_Broking.BLL;
using Pawn_Broking.DAL;

namespace Pawn_Broking.UI
{
    public partial class formitemdeatails : Form
    {
        public formitemdeatails()
        {
            InitializeComponent();
        }

        ItemDetailBLL item = new ItemDetailBLL();
        ItemDetailDAL dal = new ItemDetailDAL();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Enter Item Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtItemName.Focus();
                return;
            }

            item.ItemName = txtItemName.Text;
            item.ItemType = cmbitemtype.Text;

            bool success = dal.Insert(item);
            if (success == true)
            {
                MessageBox.Show("New Item Successfully added", "Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
            }
            else
            {
                MessageBox.Show("Failed to add Item", "Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formitemdeatails_Load(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            panelFind.Location = new Point(12, 345);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
        }
        private void Clear()
        {
            txtID.Text = "";
            txtItemName.Text = "";
            cmbitemtype.Text = "";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            panelFind.Location = new Point(12, 23);

            btnEdit.Enabled = true;
            btnSave.Enabled = false;

            DataTable dt = dal.Select();            
            dgvItems.DataSource = dt;
        }
    }
}

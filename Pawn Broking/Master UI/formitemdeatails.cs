using System;
using System.Data;
using System.Windows.Forms;
using Pawn_Broking.BLL;
using Pawn_Broking.DAL;

namespace Pawn_Broking.UI
{
    public partial class formitemdeatails : Form
    {
        private ItemDetailDAL dal = new ItemDetailDAL();
        private bool SaveFlg = false;

        public formitemdeatails()
        {
            InitializeComponent();
        }

        ItemDetailBLL item = new ItemDetailBLL();
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
            bool success;
            if (!SaveFlg)
            {
                // Insert new record
                success = dal.Insert(item);
                MessageBox.Show(success ? "One Record Inserted" : "Insertion Failed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Update existing record
                item.ItemCode = Convert.ToInt32(txtID.Text);
                success = dal.Update(item);
                MessageBox.Show(success ? "One Record Updated" : "Update Failed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Reset the form
            btnReset_Click(sender, e);
        }

        //private void btnFind_Click(object sender, EventArgs e)
        //{
        //    int itemCode = Convert.ToInt32(txtID.Text);

        //    DataTable dt = dal.GetItemDetailByCode(itemCode);
        //    if (dt.Rows.Count > 0)
        //    {
        //        txtID.Text = dt.Rows[0]["ItemCode"].ToString();
        //        cmbitemtype.Text = dt.Rows[0]["ItemType"].ToString();
        //        txtItemName.Text = dt.Rows[0]["ItemName"].ToString();
        //        SaveFlg = true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Record Not Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtItemName.Text = "";
            cmbitemtype.SelectedIndex = -1;
            SaveFlg = false;
        }
    }
}

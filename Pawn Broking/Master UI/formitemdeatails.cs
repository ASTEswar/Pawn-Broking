using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Pawn_Broking.BLL;
using Pawn_Broking.DAL;
using System.Data.SqlClient;

namespace Pawn_Broking.UI
{
    public partial class formitemdeatails : Form
    {
        private bool UpdateMode = false;
        public formitemdeatails()
        {
            InitializeComponent();
        }

        private void DisplayNextID()
        {
            string query = "SELECT ISNULL(MAX(ItemCode), 0) + 1 FROM ItemDetail";

            using (SqlConnection dbcon = new SqlConnection("Data Source=DESKTOP-6JKB17U\\SQL;Initial Catalog=PawnBrokingNew;User ID=sa;Password=1234;")) // Replace with your actual connection string
            using (SqlCommand cmd = new SqlCommand(query, dbcon))
            {
                try
                {
                    dbcon.Open();
                    object result = cmd.ExecuteScalar();

                    txtID.Text = result != null ? result.ToString() : "1";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dbcon.Close();
                }
            }
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

            if (!UpdateMode)
            {
                bool success = dal.Insert(item); 

                if (success)
                {
                    MessageBox.Show("New Item Successfully added", "Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear(); 
                }
                else
                {
                    MessageBox.Show("Failed to add Item", "Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                item.ItemCode = int.Parse(txtID.Text);

                bool success = dal.Update(item); 

                if (success)
                {
                    MessageBox.Show("Item Updated Successfully", "Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    UpdateMode = false;
                }
                else
                {
                    MessageBox.Show("Failed to update Item", "Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void formitemdeatails_Load(object sender, EventArgs e)
        {
            DisplayNextID();
            btnEdit.Enabled = false;
            panelFind.Location = new Point(12, 345);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DisplayNextID();
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnFind.Enabled = true;
            Clear();
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
   
        #region DGV Cell Click
        private void dgvItems_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvItems.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvItems.Rows[e.RowIndex];

                txtID.Text = selectedRow.Cells["ItemCode"].Value?.ToString();
                txtItemName.Text = selectedRow.Cells["ItemName"].Value?.ToString();
                cmbitemtype.Text = selectedRow.Cells["ItemType"].Value?.ToString();

                UpdateMode = true;

                panelFind.Location = new Point(12, 345);
                btnFind.Enabled =false;           
            }
        }

        private void dgvItems_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvItems.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvItems.Rows[e.RowIndex];

                txtID.Text = selectedRow.Cells["ItemCode"].Value?.ToString();
                txtItemName.Text = selectedRow.Cells["ItemName"].Value?.ToString();
                cmbitemtype.Text = selectedRow.Cells["ItemType"].Value?.ToString();

                UpdateMode = true;
                panelFind.Location = new Point(12, 345);
                btnFind.Enabled = false;
            }
        }

        private void dgvItems_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvItems.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvItems.Rows[e.RowIndex];

                txtID.Text = selectedRow.Cells["ItemCode"].Value?.ToString();
                txtItemName.Text = selectedRow.Cells["ItemName"].Value?.ToString();
                cmbitemtype.Text = selectedRow.Cells["ItemType"].Value?.ToString();

                UpdateMode = true;
                panelFind.Location = new Point(12, 345);
                btnFind.Enabled = false;
            }
        }

        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        EditPasswordBLL EditPasswordBLL = new EditPasswordBLL();
        public static string loggedIn;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //item.Username = txtUsername.Text;
            //l.Password = txtPassword.Text;
            //l.User_type = cmbUserType.Text;

            //// Checking the login credentials
            //bool success = dal.loginCheck(l);
            //if (success == true)
            //{
            //    // Login Success
            //    MessageBox.Show("Login Successful");
            //    loggedIn = l.Username;

            //    // Open Admin Dashboard and pass user type
            //    FrmAdminDashboard adminDashboard = new FrmAdminDashboard(l.User_type);
            //    adminDashboard.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    // Login Failed
            //    MessageBox.Show("Login Failed. Please Try Again");
            //    txtUsername.Text = "";
            //    txtPassword.Text = "";
            //    cmbUserType.Text = "";
            //}
        }

    }
}

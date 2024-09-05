using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pawn_Broking.UI
{
    public partial class formitemdeatails : Form
    {
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DataSet ds = new DataSet();
        private SqlConnection dbcon = new SqlConnection("Data Source=DESKTOP-6JKB17U\\SQL;Initial Catalog=PawnBrokingNew;User ID=sa;Password=1234;");
        private bool SaveFlg = false;
        public formitemdeatails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void formitemdeatails_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void Store()
        {
            DataRow row = ds.Tables[0].NewRow();
            row["ItemType"] = cmbitemtype.Text.Trim();
            row["ItemName"] = txtItemName.Text.Trim();
            ds.Tables[0].Rows.Add(row);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Enter Item Name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtItemName.Focus();
                return;
            }

            if (!SaveFlg)
            {
                using (SqlCommand cmd = new SqlCommand("select * from ItemDetail", dbcon))
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                    Store();
                  //  adapter.Update(ds);
                    MessageBox.Show("One Record Inserted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("select * from ItemDetail where ItemCode=@ItemCode", dbcon))
                {
                    cmd.Parameters.AddWithValue("@ItemCode", Convert.ToInt32(txtID.Text));
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                    Store();
                    adapter.Update(ds);
                    MessageBox.Show("One Record Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            //btnReset_Click(sender, e);
            btnEdit.Focus();
        }
    }
}

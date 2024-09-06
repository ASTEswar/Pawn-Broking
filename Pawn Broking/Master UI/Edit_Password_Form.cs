using Pawn_Broking.BLL;
using Pawn_Broking.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Pawn_Broking.Master_UI
{
    public partial class Edit_Password_Form : Form
    {
        private int userId;
        private string KKey;

        EditPasswordBLL passwordBLL = new EditPasswordBLL();
        EditPasswordDAL passwordDAL = new EditPasswordDAL();
        public Edit_Password_Form()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            // Fill BLL object with data
            passwordBLL.EPId = userId;
            passwordBLL.EPassword = txtName.Text.Trim();

            // Call DAL to check if password is valid
            bool isPasswordValid = passwordDAL.ValidatePassword(passwordBLL);

            if (isPasswordValid)
            {
                KKey = "Y"; // Set KKey to 'Y' for correct password
                MessageBox.Show("Password accepted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Close the form after success
            }
            else
            {
                KKey = "N"; // Password is incorrect
                MessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Clear();
                txtName.Focus();
            }
        }

        private void Edit_Password_Form_Load(object sender, EventArgs e)
        {

        }
    }
}

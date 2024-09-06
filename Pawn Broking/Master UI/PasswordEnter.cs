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

namespace Pawn_Broking.Master_UI
{
    public partial class PasswordEnter : Form
    {
        public PasswordEnter()
        {
            InitializeComponent();
        }

        private void PasswordEnter_Load(object sender, EventArgs e)
        {

        }

        EditPasswordBLL EditPasswordBLL = new EditPasswordBLL();
        EditPasswordDAL dal = new EditPasswordDAL();
        public static string loggedIn;

        private void btnOk_Click(object sender, EventArgs e)
        {
            EditPasswordBLL.EPassword = txtPassword.Text;

            // Checking the login credentials
            bool success = dal.loginCheck(EditPasswordBLL);
            if (success == true)
            {
                // Login Success
                MessageBox.Show("Login Successful");
                loggedIn = EditPasswordBLL.EPassword;

                PasswordEnter passwordEnter = new PasswordEnter();
                passwordEnter.Hide();
            }
            else
            {
                // Login Failed
                MessageBox.Show("Login Failed. Please Try Again");
               
            }
        }
    }
}

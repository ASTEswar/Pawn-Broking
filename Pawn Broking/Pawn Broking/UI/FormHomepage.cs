using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;


namespace Pawn_Broking.UI
{
    public partial class krypton : KryptonForm
    {
        public krypton()
        {
            InitializeComponent();
        }

        private void krypton_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {

        }

        private void itemDeatailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formitemdeatails itemdetails = new formitemdeatails();
            itemdetails.Show();
        }

        private void customerSearchEngineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomSearchEng customSearchEng = new CustomSearchEng();
            customSearchEng.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomChange customerChange = new CustomChange();
            customerChange.Show();
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LedgerForm ledgerForm = new LedgerForm();
            ledgerForm.Show();
        }
    }
}

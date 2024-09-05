using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pawn_Broking.UI
{
    public partial class Homepage_Form : Form
    {
        public Homepage_Form()
        {
            InitializeComponent();
        }

        private void itemDeatailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formitemdeatails itemdetails = new formitemdeatails();
            itemdetails.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void loanToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void customerSearchEngineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomSearchEng customSearchEng = new CustomSearchEng();
            customSearchEng.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Custom_Details_Change customChange = new Custom_Details_Change();
            customChange.Show();
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LedgerForm ledgerForm = new LedgerForm();
            ledgerForm.Show();
        }

        private void bankTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanktransactionForm1 banktransactionForm1 = new BanktransactionForm1();
            banktransactionForm1.Show();    
        }

        private void receiptsPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceiptentrysForm1 recieptentryForm1 = new ReceiptentrysForm1();
            recieptentryForm1.Show();
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymententryForm1 paymententryForm1 = new PaymententryForm1();
            paymententryForm1.Show();
        }

        private void daybookEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DaybookentryForm1 daybookentryForm1 = new DaybookentryForm1();
            daybookentryForm1.Show();   
        }

        private void receiptReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecieptreportForm1 recieptreportForm1= new RecieptreportForm1();
            recieptreportForm1.Show();
        }

        private void paymentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentreportForm1 paymentreportForm1 = new PaymentreportForm1();
            paymentreportForm1.Show();
        }

        private void ledgerStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LedgerstatmentForm1 ledgerstatmentForm1 = new LedgerstatmentForm1();
            ledgerstatmentForm1.Show(); 
        }

        private void dayBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DaybookForm1 daybookForm1 = new DaybookForm1();
            daybookForm1.Show();
        }

        private void customerBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_Balance_Form customer_Balance_Form = new Customer_Balance_Form();
            customer_Balance_Form.Show();
        }

        private void partyBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PartybalanceForm1 partybalanceForm1 = new PartybalanceForm1();
            partybalanceForm1.Show();
        }
    }
}

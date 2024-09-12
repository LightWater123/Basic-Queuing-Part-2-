using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueuingFrom
{
    public partial class QueuingForm : Form
    {
        private CashierClass cashier;
        CashierWindowQueue CWQ;
        public QueuingForm()
        {
            InitializeComponent();

            cashier = new CashierClass();
            CWQ = new CashierWindowQueue();
        }

        public class CashierClass
        {
            private int x;
            public static string getNumberInQueue = "";
            public static Queue<string> CashierQueue;
            public CashierClass()
            {
                x = 10000;
                CashierQueue = new Queue<string>();
            }
            public string CashierGeneratedNumber(string CashierNumber)
            {
                x++;
                CashierNumber = CashierNumber + x.ToString();
                return CashierNumber;
            }
        }

        // CASHIER BUTTON
        private void btnCashier_Click(object sender, EventArgs e)
        {
            try
            {
                lblQueue.Text = cashier.CashierGeneratedNumber("P - ");
                CashierClass.getNumberInQueue = lblQueue.Text;
                CashierClass.CashierQueue.Enqueue(CashierClass.getNumberInQueue);

                // DISPLAY CASHIER WINDOW
                CWQ.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void lblQueue_Click(object sender, EventArgs e)
        {

        }

        private void QueuingForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}

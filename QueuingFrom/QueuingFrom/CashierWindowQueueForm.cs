using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows.Forms;
using static QueuingFrom.QueuingForm;

namespace QueuingFrom
{
    public partial class CashierWindowQueue : Form
    {
        //private Timer timer; // create the timer
        private Queue<string> numberQueue; // create the queue
        CustomerView CV;

        public CashierWindowQueue()
        {
            InitializeComponent();
            Refresh();
            numberQueue = new Queue<string>(); // initialize the queue
            CV = new CustomerView();
        }

        
        public void DisplayCashierQueue(IEnumerable<string> cashierList)
        {
            listCashierQueue.Items.Clear();

            // Display items from the cashierList
            foreach (var obj in cashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }

            // displays queue numbers
            foreach (var obj in numberQueue)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }

        // TIMER METHOD
        private void timer1_tick(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        // REFRESH
        public void Refresh()
        {
            Timer timer = new Timer();
            timer.Interval = (1 * 1000); // 1 second
            timer.Tick += new EventHandler(timer1_tick);
            timer.Start();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        private void listCashierView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                // dequeue
                if (CashierClass.CashierQueue.Count > 0)
                {
                    string nextStudent = CashierClass.CashierQueue.Dequeue();

                    // update 
                    CV.update(nextStudent);

                    // refresh queue
                    DisplayCashierQueue(CashierClass.CashierQueue);

                    // Display CustomerView
                    CV.Show();
                }
                else
                {
                    CV.update("");
                    CV.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

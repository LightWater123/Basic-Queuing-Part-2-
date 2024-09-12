using System;
using System.Windows.Forms;

namespace QueuingFrom
{
    public partial class CustomerView : Form
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        // update label showing next student in the queue
        public void update(string nextCustomer)
        {
            try
            {
                if (!string.IsNullOrEmpty(nextCustomer))
                {
                    label2.Text = nextCustomer;
                }
                else
                {
                    label2.Text = "Empty.";
                }
            }
            catch (Exception ex)
            {
                label2.Text = ex.Message;
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

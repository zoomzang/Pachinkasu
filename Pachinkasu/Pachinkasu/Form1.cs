using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pachinkasu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PlayPanel plaPa = new PlayPanel(5, 2, new Random());
            plaPa.SwapPin(3, 0);
            plaPa.SwapPin(0, 0); // saying it twice would remove it all together thrice would be once
            plaPa.SwapPin(2, 1);
            plaPa.SwapPin(4, 1);
            plaPa.DropEveryLocation();
            int[] results = plaPa.GetResult();
            for (int i = 0; i < 5; i++)
            {
                MessageBox.Show(results[i] + "");
            }
        }
    }
}

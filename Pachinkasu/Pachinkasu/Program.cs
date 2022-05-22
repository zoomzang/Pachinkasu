using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pachinkasu
{
    
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Random rand = new Random();
            //this does nothing now apparently... it needs to be triggered somehow withing the winform
            PlayPanel plaPa = new PlayPanel(5, 2, rand);
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


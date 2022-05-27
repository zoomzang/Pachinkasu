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
        Random rand = new Random();
        PlayPanel plaPa;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializePlaPa();
            int[] dropRank = FindDropRank();
            SetBoardState(plaPa);
            RunGame(plaPa, dropRank);
            OutputResults(dropRank);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //tabbed methods to work on
        private void InitializePlaPa()
        {
            this.plaPa = new PlayPanel(5, 3, rand);//create a 5x3 play area 
        }
        private int[] FindDropRank()
        {
            int[] rankF = new int[5];
            rankF[0] = int.Parse(textBox1.Text);
            rankF[1] = int.Parse(textBox2.Text);
            rankF[2] = int.Parse(textBox3.Text);
            rankF[3] = int.Parse(textBox4.Text);
            rankF[4] = int.Parse(textBox5.Text);
            return rankF;
        }

        private void SetBoardState(PlayPanel plaPa)
        {
            plaPa.SetPin(0, 0, checkBox1.Checked);
            plaPa.SetPin(1, 0, checkBox2.Checked);
            plaPa.SetPin(2, 0, checkBox3.Checked);
            plaPa.SetPin(3, 0, checkBox4.Checked);
            plaPa.SetPin(4, 0, checkBox5.Checked);

            plaPa.SetPin(0, 1, checkBox6.Checked);
            plaPa.SetPin(1, 1, checkBox7.Checked);
            plaPa.SetPin(2, 1, checkBox8.Checked);
            plaPa.SetPin(3, 1, checkBox9.Checked);
            plaPa.SetPin(4, 1, checkBox10.Checked);

            plaPa.SetPin(0, 2, checkBox11.Checked);
            plaPa.SetPin(1, 2, checkBox12.Checked);
            plaPa.SetPin(2, 2, checkBox13.Checked);
            plaPa.SetPin(3, 2, checkBox14.Checked);
            plaPa.SetPin(4, 2, checkBox15.Checked);
        }

        private void RunGame(PlayPanel plaPa, int[] dropRank)
        {
            plaPa.DropBallRanks(dropRank);
        }
        private int[] GetResults()
        {
            return plaPa.GetResult();
        }
        private void OutputResults(int[] resultRanks)
        {
            textBox6.Text = resultRanks[0].ToString();
            textBox7.Text = resultRanks[1].ToString();
            textBox8.Text = resultRanks[2].ToString();
            textBox9.Text = resultRanks[3].ToString();
            textBox10.Text = resultRanks[4].ToString();

        }
    }
}

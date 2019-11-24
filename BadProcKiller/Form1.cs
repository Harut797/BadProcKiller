using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Collections;

namespace BadProcKiller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ArrayList badprocess = new ArrayList();
            Process[] currentProcess = Process.GetProcesses();
            for (int i = 0; i < currentProcess.Length; i++)
            {
                allproclist.Items.Add(currentProcess[i].ProcessName);
            }
            timer1.Enabled = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            allproclist.ForeColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (object itemChecked in badproclist.CheckedItems)
            {
                foreach(Process killedproc in Process.GetProcessesByName(itemChecked.ToString()))
                {
                    killedproc.Kill();
                    MessageBox.Show(itemChecked.ToString() + "Killed!");
                    this.Refresh();
                    badproclist.Items.Remove(itemChecked);
                }
            }

        }

        private void allproclist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void allproclist_DoubleClick(object sender, EventArgs e)
        {
            if (allproclist.SelectedItem != null)
            {
                badproclist.ForeColor = Color.Red;
                badproclist.Items.Add(allproclist.SelectedItem.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
        }
    }
}

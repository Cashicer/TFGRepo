using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TalonApp
{
    public partial class frmInit : Form
    {
        string domeID = "ASCOM.TalonSuccessor.Dome";
        ASCOM.DriverAccess.Dome dome;

        public frmInit()
        {
            InitializeComponent();
            dome = new ASCOM.DriverAccess.Dome(domeID);
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void setupToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Program.DoSetupSetup();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dome.Connected)
            {
                if (btnOC.Text == "Open")
                {
                    dome.OpenShutter();
                    lblShutter.Text = "Opened";
                    btnOC.Text = "Close";
                }
                else
                {
                    dome.CloseShutter();
                    lblShutter.Text = "Closed";
                    btnOC.Text = "Open";
                }
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.DoMonitorSetup();
        }

        private void exitToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.DoAboutSetup();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnCon.Text == "Connect")
            {
                dome.Connected = true;
                connectionStatus.Text = "Connected";
                btnCon.Text = "Disconnect";
            }
            else
            {
                dome.Connected = false;
                connectionStatus.Text = "Disconnected";
                btnCon.Text = "Connect";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dome.SetupDialog();
        }
    }
}

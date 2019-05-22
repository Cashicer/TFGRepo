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

        //Variables estatus
        char [] status_code;

        public frmInit()
        {
            InitializeComponent();
            dome = new ASCOM.DriverAccess.Dome(domeID);
        }

        private void setupToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dome.SetupDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dome.Connected)
            {
                if (btnOC.Text == "Open")
                {
                    dome.OpenShutter();
                    btnOC.Text = "Close";
                }
                else
                {
                    dome.CloseShutter();
                    btnOC.Text = "Open";
                }
            }


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
                if (!dome.Connected)
                {
                    dome.Connected = true;
                }
                connectionStatus.Text = "Connected";
                timer.Enabled = true;
                btnCon.Text = "Disconnect";
            }
            else
            {
                timer.Enabled = false;
                dome.Connected = false;
                connectionStatus.Text = "Disconnected";
                lblShutter.Text = "N/A";
                lbl_last_action.Text = "---";
                btnCon.Text = "Connect";
            }
        }

        // Formato de la cadena del estado: &GLxxxbbtttppccllmm#
        private void timer_Tick(object sender, EventArgs e)
        {
            status_code = dome.Action("GetStatus", "").ToCharArray();
            if (status_code.Length < 20) return;
            setShutterState();
            setLastAction();
        }

        private void setShutterState()
        {
            long shutter_state = (status_code[2] / 16) & 7;
            switch (shutter_state)
            {
                case 0:
                    lblShutter.Text = "Open";
                    break;
                case 1:
                    lblShutter.Text = "Closed";
                    break;
                case 2:
                    lblShutter.Text = "Opening";
                    break;
                case 3:
                    lblShutter.Text = "Closing";
                    break;
                case 4:
                    lblShutter.Text = "Error";
                    break;
                default:
                    lblShutter.Text = "Unknown";
                    break;
            }
        }

        private void setLastAction()
        {
            long last_action = status_code[2] & 15;
            switch (last_action)
            {
                case 0:
                    lbl_last_action.Text = "NONE";
                    break;
                case 1:
                    lbl_last_action.Text = "Open by user";
                    break;
                case 2:
                    lbl_last_action.Text = "Close by user";
                    break;
                case 4:
                    lbl_last_action.Text = "Go to by user";
                    break;
                case 5:
                    lbl_last_action.Text = "Calibrate by user";
                    break;
                case 6:
                    lbl_last_action.Text = "Close due to cloud-rain condition";
                    break;
                case 7:
                    lbl_last_action.Text = "Close due to power down";
                    break;
                case 8:
                    lbl_last_action.Text = "Close due to communication lost";
                    break;
                case 9:
                    lbl_last_action.Text = "Close due to internet lost";
                    break;
                case 10:
                    lbl_last_action.Text = "Close due to timeout expired";
                    break;
                case 11:
                    lbl_last_action.Text = "Close by management";
                    break;
                case 12:
                    lbl_last_action.Text = "Close by automation";
                    break;
                case 13:
                    lbl_last_action.Text = "Stop -- motor stalled";
                    break;
                case 14:
                    lbl_last_action.Text = "Emergency stop";
                    break;
                case 15:
                    lbl_last_action.Text = "Order the mount to park";
                    break;
                default:
                    break;
            }
        }
    }
}

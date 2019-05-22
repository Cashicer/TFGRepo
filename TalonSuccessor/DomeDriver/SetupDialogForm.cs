using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASCOM.TalonSuccessor
{
    public partial class SetupDialogForm : Form
    {
        public SetupDialogForm()
        {
            InitializeComponent();
            lbl_version_driver.Text = "1.0";
        }

        private void SetupDialogForm_Load(object sender, EventArgs e)
        {
            txtCOMport.Text = "10";
        }

        private void lbl_version_driver_Click(object sender, EventArgs e)
        {

        }
    }
}

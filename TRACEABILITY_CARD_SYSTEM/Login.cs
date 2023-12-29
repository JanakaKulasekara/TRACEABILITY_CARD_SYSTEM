using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.OracleClient;
using TRACEABILITY_CARD_SYSTEM.Logic;
using System.Threading;


namespace TRACEABILITY_CARD_SYSTEM
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            BLL objlogin = new BLL();
            int ret = objlogin.ValidateLogin(txtUsername.Text, txtPassword.Text);
            if (ret == 1) //admin user
            {
                var level = "ADMIN";
                this.Hide();
                Traceability_Main objtracemain = new Traceability_Main(txtUsername.Text, level, ret);
                objtracemain.ShowDialog();

            }

            else if (ret == 2) //user
            {
                var level = "USER";
                this.Hide();
                Traceability_Main objtracemain = new Traceability_Main(txtUsername.Text, level, ret);
                objtracemain.ShowDialog();
            }

            else 
            {
                lblError.Text = "Pls Enter Correct Username and Password!!!";
            }


        }
    }
}

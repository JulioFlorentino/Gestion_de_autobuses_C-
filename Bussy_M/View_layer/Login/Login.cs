using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bussy_M.Data_Layer;
namespace Bussy_M.View_layer
{
    public partial class Login : Form

      
    {
        Data_layer ObjData = new Data_layer(); 
        public Login()
        {
            InitializeComponent();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            if (ObjData.Login_d(Email_txbx.Text, Password_txbx.Text) != null)
            {
                Dashboard dashboard = new Dashboard(Password_txbx.Text, ObjData.Login_d(Email_txbx.Text, Password_txbx.Text));
                dashboard.Show();
                this.Hide();
            }
            else
            {
                WP_label.Visible = true;
            }
            
        }

        private void l_close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

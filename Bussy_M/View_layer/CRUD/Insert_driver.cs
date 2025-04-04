using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bussy_M.Data_Layer;

namespace Bussy_M.View_layer.CRUD
{
    public partial class Insert_driver : Form
    {
        Data_layer data = new Data_layer();
        bool confirm = false;
        public Insert_driver()
        {
            InitializeComponent();
        }


        private void Insert_info()
        {
            try
            {
                List<string> datosConductor = new List<string>
                {
                    Name_txb.Text,
                    Last_name_tbx.Text,
                    cedula_tbx.Text,
                    Hire_picker.Text
                };

                bool insert = data.Insert_driver(datosConductor);
                confirm = true;

                MessageBox.Show("Datos ingresador correctamente");
            }
            catch (Exception ex) {
                MessageBox.Show("Error al ingresar los datos" );
                confirm = false;

            }

        }

        private void Insert_credentials()
        {
            try {
                List<string> Credentials = new List<string>
            {
                Email_txbx.Text,
                Password_txbx.Text
            };

                bool insert_Cdt = data.Insert_credentials(Credentials);

                Error_lbl.Text = "Usuario creado correctamente";
                Error_lbl.ForeColor = Color.Green;
                Error_lbl.Visible = true;

              


            } catch(Exception ex) 
            { 
                MessageBox.Show("Error al ingresar los datos");
                Error_lbl.Text = "Error al crear usuario";
                Error_lbl.ForeColor = Color.Red;
                Error_lbl.Visible = true;
               

            }
            }
            

        private void Close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            Insert_credentials();
            Insert_info();

            Name_txb.Text = "";
            Last_name_tbx.Text = "";
            cedula_tbx.Text = "";
            Hire_picker.Text = "";
            Email_txbx.Text = "";
            Password_txbx.Text = "";
        }
    }
}

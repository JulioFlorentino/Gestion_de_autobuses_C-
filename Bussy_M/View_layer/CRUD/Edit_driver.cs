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
    public partial class Edit_driver : Form
    {
        Data_layer data = new Data_layer();
        
        public Edit_driver(string ID, string Name, string last_name, string cedula, string Hire_date)
        {
            InitializeComponent();

            Id_lbl.Text = ID;
            Name_txb.Text = Name;
            Last_name_tbx.Text = last_name; 
            cedula_tbx.Text = cedula;
            Hire_picker.Text = Hire_date;

        }

        private void Insert_info()
        {
            try
            {
                List<string> datosConductor = new List<string>
                {
                    Id_lbl.Text,
                    Name_txb.Text,
                    Last_name_tbx.Text,
                    cedula_tbx.Text,
                    Hire_picker.Text
                };

                bool insert = data.update_driver(datosConductor);


                MessageBox.Show("Datos ingresador correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar los datos");


            }


        }

        private void Insert_credentials()
        {
            try
            {
                List<string> Credentials = new List<string>
            {
                Email_txbx.Text,
                Password_txbx.Text
            };

                bool insert_Cdt = data.update_credentials(Credentials);

                Error_lbl.Text = "Usuario actualizado correctamente";
                Error_lbl.ForeColor = Color.Green;
                Error_lbl.Visible = true;




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar los datos");
                Error_lbl.Text = "Error al crear usuario";
                Error_lbl.ForeColor = Color.Red;
                Error_lbl.Visible = true;


            }
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            Insert_credentials();
            Insert_info();
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

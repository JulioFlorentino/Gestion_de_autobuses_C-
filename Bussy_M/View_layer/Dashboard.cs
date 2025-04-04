using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Bussy_M.Data_Layer;
using Bussy_M.View_layer.CRUD;


namespace Bussy_M
{

    public partial class Dashboard : Form
    {
       protected Data_layer db = new Data_layer();
        
        public Dashboard(string Email, string Password)
        {
            InitializeComponent();
            CallUserData();

            
        }
        
        public void CallUserData()
        {
            List<DataGridViewRow> DataProducts = db.GetEmployes();

            Driver_dgv.Rows.Clear();

            foreach (DataGridViewRow row in DataProducts)
            {
                Driver_dgv.Rows.Add(row);
            }

            List<DataGridViewRow> DataUsers = db.GetEmployes();

            

           
        }

        private void Delete_user() 
        {
            if (Driver_dgv.SelectedRows.Count > 0) // Verifica si hay una fila seleccionada
            {

                int ID = Convert.ToInt32(Driver_dgv.SelectedRows[0].Cells[0].Value); //tomar el valor de la primera columna seleccionada

                db.DeleteProduct(ID);

                Driver_dgv.Rows.RemoveAt(Driver_dgv.SelectedRows[0].Index); // Elimina la fila del DataGridView

            }
            else
            {
                MessageBox.Show("Seleccione un producto para eliminar.");
            }

        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            Panels.SetPage(0);
        }

        private void Driver_btn_Click(object sender, EventArgs e)
        {
            Panels.SetPage(1);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Delete_user();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Insert_driver insert_Driver = new Insert_driver();
            insert_Driver.ShowDialog();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            CallUserData();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (Driver_dgv.SelectedRows.Count > 0) // Verifica si hay una fila seleccionada
            {

                int ID = Convert.ToInt32(Driver_dgv.SelectedRows[0].Cells[0].Value); //tomar el valor de la primera columna seleccionada

                Edit_driver edit_driver = new Edit_driver(Driver_dgv.SelectedRows[0].Cells[0].Value.ToString(), Driver_dgv.SelectedRows[0].Cells[1].Value.ToString(),
                                                           Driver_dgv.SelectedRows[0].Cells[2].Value.ToString(), Driver_dgv.SelectedRows[0].Cells[3].Value.ToString(),
                                                           Driver_dgv.SelectedRows[0].Cells[4].Value.ToString());
                edit_driver.ShowDialog();

            }
            else
            {
                MessageBox.Show("Seleccione un producto para actualizar.");
            }
               
            
        }

        private void Driver_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id_lbl.Text = Driver_dgv.SelectedRows[0].Cells[0].Value.ToString();
            Name_lbl.Text = Driver_dgv.SelectedRows[0].Cells[1].Value.ToString();
            LastN_lbl.Text = Driver_dgv.SelectedRows[0].Cells[2].Value.ToString();
            Cedula_lbl.Text = Driver_dgv.SelectedRows[0].Cells[3].Value.ToString();
            date_lbl.Text = Driver_dgv.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}

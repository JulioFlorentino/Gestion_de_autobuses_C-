using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Bussy_M.Data_Layer
{
    public class Data_layer
    {
        static string serverName = Environment.MachineName;
        string connectionString = $"Server={serverName};Database=BUSSYDB;Integrated Security=True;";


        //login
        public string Login_d(string User_email, string User_password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("LOGIN_U ", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@USER_EMAIL", User_email);
                        cmd.Parameters.AddWithValue("@USER_PASSWORD", User_password);

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.Read())
                            {
                                return rd.GetString(0);
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                return null;
            }
        }

        //metodo para llamar los datos de los empleados a la tabla.
        public List<DataGridViewRow> GetEmployes() //creamos un metodo tipo lista
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                List<DataGridViewRow> data = new List<DataGridViewRow>();

                try
                {
                    con.Open();
                    string qry = "SELECT * FROM USER_INFO;";
                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                DataGridViewRow tem = new DataGridViewRow();
                                for (int i = 0; i < rd.FieldCount; i++)
                                {
                                    tem.Cells.Add(new DataGridViewTextBoxCell());
                                    tem.Cells[i].Value = rd[i];

                                }
                                data.Add(tem);
                            }
                        }
                    }
                }
                catch (Exception ex) { }

                return data;
            }

        }

        //Procediniento para eliminar un conductor
        public void DeleteProduct(int ID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_DELETE_USER", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID", ID);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        //metodo para insertar
        public bool Insert_driver(List<string> ls)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_INSERT_DRIVER", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Agregar parametros al llamado del procedimiento
                        cmd.Parameters.AddWithValue("@SP_First_name", ls[0]);
                        cmd.Parameters.AddWithValue("@SP_Last_name", ls[1]);
                        cmd.Parameters.AddWithValue("@SP_cedula", ls[2]);
                        cmd.Parameters.AddWithValue("@SP_Hire_date", ls[3]);

                        cmd.ExecuteNonQuery();

                        using (SqlCommand checkError = new SqlCommand("SELECT @@ERROR", con))
                        {
                            int errorCode = (int)checkError.ExecuteScalar();
                            if (errorCode == 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }


            }
        }

        public bool Insert_credentials(List<string> ls) {


            using (SqlConnection con = new SqlConnection(connectionString)) 
            {
                try {  con.Open();
                       using(SqlCommand cmd = new SqlCommand("SP_INSERT_CREDENTIALS", con))
                       {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@SP_User_email", ls[0]);
                            cmd.Parameters.AddWithValue("@SP_User_password", ls[1]);

                           cmd.ExecuteNonQuery ();
                      
                        using (SqlCommand checkError = new SqlCommand("SELECT @@ERROR", con))
                        {
                            int errorCode = (int)checkError.ExecuteScalar();
                            if (errorCode == 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    } 
                
                } catch(Exception ex) {

                    MessageBox.Show("error de credenciales");
                    return false; }
            }
        }



        public bool update_driver(List<string> ls)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_UPDATE_DRIVER", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        //Agregar parametros al llamado del procedimiento
                        cmd.Parameters.AddWithValue("@ID", ls[0]);
                        cmd.Parameters.AddWithValue("@SP_First_name", ls[1]);
                        cmd.Parameters.AddWithValue("@SP_Last_name", ls[2]);
                        cmd.Parameters.AddWithValue("@SP_cedula", ls[3]);
                        cmd.Parameters.AddWithValue("@SP_Hire_date", ls[4]);

                        cmd.ExecuteNonQuery();

                        using (SqlCommand checkError = new SqlCommand("SELECT @@ERROR", con))
                        {
                            int errorCode = (int)checkError.ExecuteScalar();
                            if (errorCode == 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }


            }
        }
        public bool update_credentials(List<string> ls)
        {


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_UPDATE_DRIVER", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SP_User_email", ls[0]);
                        cmd.Parameters.AddWithValue("@SP_User_password", ls[1]);

                        cmd.ExecuteNonQuery();

                        using (SqlCommand checkError = new SqlCommand("SELECT @@ERROR", con))
                        {
                            int errorCode = (int)checkError.ExecuteScalar();
                            if (errorCode == 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("error de credenciales");
                    return false;
                }
            }
        }



    }
}

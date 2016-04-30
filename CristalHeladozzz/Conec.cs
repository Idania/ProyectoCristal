using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Forms;

namespace CristalHeladozzz
{
    public class Datos
    {


        MySqlConnection carretera = new MySqlConnection();
        public MySqlCommand cadena_Acc;
        public MySqlDataReader dr;

        private MySqlDataAdapter adapt;

        public bool AbrirConexion()
        {

            carretera.ConnectionString = "Server=74.63.196.2; Database=eliarome35448DB; uid=eliarome35448; pwd=4lnS6eodR3Ei;";
            try
            {

                carretera.Open();

                return true;

            }
            catch (Exception s)
            {

                MessageBox.Show("Error: " + s.Message);
                carretera = null;
                return false;


            }

        }



        public void desconectar()
        {
            carretera.Close();
        }



        //****************METODOS DE CONSTRUCCION DE COMANDOS*****************
        public MySqlCommand construye_command(string cadena)
        {
            cadena_Acc = new MySqlCommand(cadena, carretera);

            return (cadena_Acc);
        }
        public int ejecutanonquery()
        {
            int afectados;
            try
            {
                afectados = cadena_Acc.ExecuteNonQuery();
                return (afectados);
            }
            catch (Exception oEx)
            {
                MessageBox.Show(oEx.Message);
                return (0);
            }
        }

       
    }
}

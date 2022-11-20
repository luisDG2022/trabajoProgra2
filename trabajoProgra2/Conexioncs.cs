using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace trabajoProgra2
{
    internal class Conexioncs
    {
        public static MySqlConnection establerconeccion()
        {
        MySqlConnection con = new MySqlConnection();
        string servidor = "localhost";
        string bd = "bdprogra";
         string usuario = "root";
        string password = "";
        string puerto = "3306";
        string cadenaconexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";
            try
            {
                con.ConnectionString = cadenaconexion;
                con.Open();
               // MessageBox.Show("se conecto correctamente");

            }
            catch (MySqlException error)
            {
                MessageBox.Show("No se pudo conte3xtar " + error.ToString());
            }
            return con;
        }
    }
}

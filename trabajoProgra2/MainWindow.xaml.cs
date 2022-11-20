using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace trabajoProgra2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string consulta = "SELECT * FROM bdprogra.usuario where usuario=@usuario&& contraseña=@password;";
            MySqlConnection con = Conexioncs.establerconeccion();
            MySqlCommand comando = new MySqlCommand(consulta, con);
            comando.CommandType=System.Data.CommandType.Text;
            comando.Parameters.Add("@usuario",MySqlDbType.VarChar).Value=txtUsuario.Text;
            comando.Parameters.Add("@password",MySqlDbType.VarChar).Value=txtPassword.Text;
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            DataTable tbl = new DataTable();
            adaptador.Fill(tbl);
            try
            {
              comando.ExecuteNonQuery();
                if (tbl.Rows.Count==1)
                {
            Window1 MiVentana = new Window1();
            MiVentana.Owner = this;
            MiVentana.Show();

                }
                else
                {
                MessageBox.Show("Usuario o password incorrecto");
                }
            }
            catch
            {
                MessageBox.Show("error en la consulta ");
            }
        }
        private Conexioncs conectar=new Conexioncs();

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Conexioncs conectar = new Conexioncs();
        }
    }
}

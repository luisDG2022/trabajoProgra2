using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MessageBox = System.Windows.Forms.MessageBox;
using Window = System.Windows.Window;

namespace trabajoProgra2
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Estudiante est;
        List<Estudiante> pupils = new List<Estudiante>();

        public Window1()
        {
            InitializeComponent();
        }


        private void btnCalcularPromedio_Click(object sender, RoutedEventArgs e)
        {
            if (txtNota1.Text == string.Empty || txtNota2.Text == string.Empty || txtNota3.Text == string.Empty)
            {
                MessageBox.Show("ingrese un numero");
                return;
            }
            int n1, n2, n3;
            double pro;
            n1 = int.Parse(txtNota1.Text);
            n2 = int.Parse(txtNota2.Text);
            n3 = int.Parse(txtNota3.Text);
            pro = (n1 + n2 + n3) / 3;
            txtPromedio.Text = pro.ToString();


        }
        /*public class Registro
            {
            public string nombre { get; set; }
            public int nota1 { get; set; }
            public int nota2 { get; set; }
            public int nota3 { get; set; }
            public double promedio { get; set; }
        }*/

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {

            est = new Estudiante(1,txtnombre.Text, int.Parse(txtNota1.Text), int.Parse(txtNota2.Text), int.Parse(txtNota3.Text), double.Parse(txtPromedio.Text));
            pupils.Add(est);
            string consulta = "insert into estudiante value (null,@nom,@n1,@n2,@n3,@p)";
            MySqlConnection con = Conexioncs.establerconeccion();
            MySqlCommand comando = new MySqlCommand(consulta, con);
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.Add("@nom", MySqlDbType.VarChar).Value = txtnombre.Text;
            comando.Parameters.Add("@n1", MySqlDbType.Int32).Value = int.Parse(txtNota1.Text);
            comando.Parameters.Add("@n2", MySqlDbType.Int32).Value = int.Parse(txtNota2.Text);
            comando.Parameters.Add("@n3", MySqlDbType.Int32).Value = int.Parse(txtNota3.Text);
            comando.Parameters.Add("@p", MySqlDbType.Double).Value = double.Parse(txtPromedio.Text);
            try
            {
                comando.ExecuteNonQuery();
               // dtgDatosEstudiante.Items.Add(est);
            }
            catch (Exception ex)
            {
            }
                dtgDatosEstudiante.ItemsSource = null;
            dtgDatosEstudiante.ItemsSource = pupils;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string consulta = "SELECT * FROM bdprogra.estudiante";
            MySqlConnection con = Conexioncs.establerconeccion();
            MySqlCommand comando = new MySqlCommand(consulta, con);
            comando.CommandType = System.Data.CommandType.Text;
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            DataTable tbl = new DataTable();
            adaptador.Fill(tbl);
            try
            {
                comando.ExecuteNonQuery();
                if (tbl.Rows.Count > 0)
                {
                    foreach (DataRow dr in tbl.Rows)
                    {
                        est = new Estudiante(int.Parse(dr["idEstudiante"].ToString()), dr["nombre"].ToString(), int.Parse(dr["nota1"].ToString()), int.Parse(dr["nota2"].ToString()), int.Parse(dr["nota3"].ToString()), double.Parse(dr["promedio"].ToString()));
                        pupils.Add(est);
                    }
                    dtgDatosEstudiante.ItemsSource = pupils;
                }
                else
                {
                    MessageBox.Show("Usuario o password incorrecto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error en la consulta la cargar el grid "+ex.Message);
            }
            con.Close();
        }
    }
}

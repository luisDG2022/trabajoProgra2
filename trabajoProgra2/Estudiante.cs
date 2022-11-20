using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabajoProgra2
{
    internal class Estudiante
    {
        public int idEstudiante { get; set; }
        public string nombre { get; set; }
        public int nota1 { get; set; }
        public int nota2 { get; set; }
        public int nota3 { get; set; }
        public double promedio { get; set; }

        public Estudiante( int idestu,string nombre,int nota1, int nota2, int nota3, double promedio)
        {
            this.idEstudiante = idestu;
            this.nombre = nombre;
            this.nota1 = nota1;
            this.nota2=nota2 ;
            this.nota3=nota3;
            this.promedio=promedio;

        }
        

    }
}

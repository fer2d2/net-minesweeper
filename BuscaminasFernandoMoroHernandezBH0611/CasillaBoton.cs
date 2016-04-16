using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaminasFernandoMoroHernandezBH0611
{
    class CasillaBoton :Button
    {
        public int fila;
        public int columna;

        public CasillaBoton(int fila, int columna)
        {
            this.fila = fila;
            this.columna = columna;
        }
    }
}

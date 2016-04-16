using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaminasFernandoMoroHernandezBH0611
{
    public partial class JuegoTerminado : Form
    {
        public JuegoTerminado(int puntuacion)
        {
            InitializeComponent();

            this.label3.Text = "" + puntuacion;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

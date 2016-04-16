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
    public partial class MenuInicio : Form
    {
        public static MenuInicio menu;

        public MenuInicio()
        {
            menu = this;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form juego = new Juego(5, 5);
            juego.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form juego = new Juego(8, 8);
            juego.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form juego = new Juego(16, 16);
            juego.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form listaPuntuaciones = new ListaPuntuaciones();
            listaPuntuaciones.Show();
            this.Hide();
        }

        private void MenuInicio_Load(object sender, EventArgs e)
        {

        }

    }
}

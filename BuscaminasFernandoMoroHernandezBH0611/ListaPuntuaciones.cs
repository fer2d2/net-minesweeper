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
    public partial class ListaPuntuaciones : Form
    {
        public ListaPuntuaciones()
        {
            InitializeComponent();

            PuntuacionesBuscaminasEntities context = new PuntuacionesBuscaminasEntities();
            List<Score> puntuaciones = context.Scores.ToList();

            foreach (Score puntuacion in puntuaciones)
            {
                ListViewItem row = new ListViewItem();
                row.Text = puntuacion.Id.ToString();
                row.SubItems.Add(puntuacion.Fecha.ToString());
                row.SubItems.Add(puntuacion.Puntos.ToString());
                this.listView1.Items.Add(row);
            }
            
        }

        private void ListaPuntuaciones_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListaPuntuaciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuInicio.menu.Show();
        }
    }
}

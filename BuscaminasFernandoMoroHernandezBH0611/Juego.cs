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
    public partial class Juego : Form
    {
        private Tablero tablero;
        private Button[,] botones;
        private Score puntuacion;

        public static Juego juego;

        public Juego(int filas, int columnas)
        {
            juego = this;

            InitializeComponent();

            puntuacion = new Score();
            puntuacion.Fecha = DateTime.Now;

            tablero = new Tablero(filas, columnas);

            this.tableLayoutPanel1.RowCount = filas;
            this.tableLayoutPanel1.ColumnCount = columnas;

            botones = new Button[filas, columnas];
            for (int i = 0; i < filas; i++) {
                for (int j = 0; j < columnas; j++)
                {
                    botones[i, j] = new CasillaBoton(i, j);
                    botones[i, j].Width = 40;
                    botones[i, j].Height = 40;
                    botones[i, j].Click +=
                        new EventHandler(this.click_casilla);

                    this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    this.tableLayoutPanel1.Controls.Add(botones[i, j]);
                }
            }

            actualizaUI();
        }

        private void click_casilla(object sender, EventArgs e)
        {
            tablero.levanta(((CasillaBoton)sender).fila + 1,
                             ((CasillaBoton)sender).columna + 1);

            actualizaUI();

            if (tablero.valorCasilla(((CasillaBoton)sender).fila + 1,
                 ((CasillaBoton)sender).columna + 1) == "B")
            {
                terminarJuego();
            }
        }

        private void actualizaUI()
        {
            for (int fila = 1; fila <= this.tablero.filas - Tablero.OFFSET; fila++)
                for (int columna = 1; columna <= this.tablero.columnas - Tablero.OFFSET; columna++)
                {
                    string str = tablero.valorCasilla(fila, columna);

                    if (str.Equals("0"))
                    {
                        botones[fila - 1, columna - 1].Enabled = false;
                        botones[fila - 1, columna - 1].Text = "";
                    }
                    else
                    {
                        if (str == "B")
                        {
                            botones[fila - 1, columna - 1].Text = "";
                            botones[fila - 1, columna - 1].BackgroundImage = new Bitmap(BuscaminasFernandoMoroHernandezBH0611.Properties.Resources.bomba);
                            botones[fila - 1, columna - 1].BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else
                        {
                            botones[fila - 1, columna - 1].Text = str;
                        }
                    }
                        

                }
        }

        private void terminarJuego()
        {
            desactivaTodosBotones();

            this.puntuacion.Puntos = this.tablero.obtenerPuntuacion();
            PuntuacionesBuscaminasEntities context = new PuntuacionesBuscaminasEntities();
            context.Scores.Add(this.puntuacion);
            context.SaveChanges();

            Form juegoTerminado = new JuegoTerminado(this.tablero.obtenerPuntuacion());
            juegoTerminado.Show();
        }

        private void desactivaTodosBotones()
        {
            for (int fila = 1; fila <= this.tablero.filas - Tablero.OFFSET; fila++)
                for (int columna = 1; columna <= this.tablero.columnas - Tablero.OFFSET; columna++)
                {
                    botones[fila - 1, columna - 1].Enabled = false;
                }
        }

        private void Juego_Load(object sender, EventArgs e)
        {

        }

        private void Juego_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuInicio.menu.Show();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasFernandoMoroHernandezBH0611
{
    class Tablero
    {
        private Casilla[,] casillas;

        public int filas { get; set; }
        public int columnas { get; set; }

        public const int OFFSET = 2;

        public Tablero(int f, int c)
        {
            this.filas = f + OFFSET;
            this.columnas = c + OFFSET;
            casillas = new Casilla[filas, columnas];
            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas; j++)
                    this.casillas[i, j] = new Casilla();

            inicializaTablero();
        }

        private void inicializaTablero()
        {
            Random rnd = new Random();
            for (int f = 1; f < this.filas - 1; f++)
            {
                for (int c = 1; c < this.columnas - 1; c++)
                {
                    int valor = rnd.Next(100);
                    if (valor < 10)
                    {
                        ponerBomba(f, c);
                    }
                }
            }

            creaBorde();
        }

        private void ponerBomba(int f, int c)
        {
            this.casillas[f, c].ponBomba();
            sumaUnoAlrededor(f, c);
        }

        private void creaBorde()
        {
            for (int c = 0; c < this.columnas; c++)
            {
                this.casillas[0, c].sumaUno();
                this.casillas[filas - 1, c].sumaUno();
            }
            for (int f = 0; f < this.filas; f++)
            {
                this.casillas[f, 0].sumaUno();
                this.casillas[f, columnas - 1].sumaUno();
            }
        }

        private void sumaUnoAlrededor(int f, int c)
        {
            for (int i = (f - 1); i <= (f + 1); i++)
                for (int j = (c - 1); j <= (c + 1); j++)
                    this.casillas[i, j].sumaUno();
        }

        public void visualiza()
        {
            for (int f = 1; f < this.filas - 1; f++)
            {
                for (int c = 1; c < this.columnas - 1; c++)
                {
                    Console.Write(this.casillas[f, c]);
                }
                Console.WriteLine();
            }
        }

        public bool levanta(int f, int c)
        {
            this.casillas[f, c].levanta();
            if (this.casillas[f, c].hayBomba())
                return true;

            if (this.casillas[f, c].getValor() == 0)
            {
                for (int i = (f - 1); i <= (f + 1); i++)
                    for (int j = (c - 1); j <= (c + 1); j++)
                        if (this.casillas[i, j].estaTapada())
                            this.levanta(i, j);
            }

            return false;
        }

        internal string valorCasilla(int fil, int col)
        {
            return casillas[fil, col].ToString();
        }

        public int obtenerPuntuacion()
        {
            int puntuacion = 0;

            for (int f = 1; f < this.filas - 1; f++)
            {
                for (int c = 1; c < this.columnas - 1; c++)
                {
                    if (!this.casillas[f, c].estaTapada() && !this.casillas[f, c].esBomba)
                    {
                        puntuacion += this.casillas[f, c].getValor() + 15;
                    }
                }
            }

            return puntuacion;
        }
    }
}

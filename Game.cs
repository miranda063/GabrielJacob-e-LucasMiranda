using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GabrielJacob_e_LucasMiranda
{
    public partial class Game : Form
    {

        private Player jogador;

        public Game()
        {
            InitializeComponent();

            IniciarJogo();
        }

        private void IniciarJogo()
        {
            jogador = new Player();

            jogador.Location = new Point(50, 340);

            Controls.Add(jogador);

            KeyPreview = true;
            KeyDown += Game_KeyDown;
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            jogador.Mover(
                e.KeyCode,
                ClientSize.Width,
                ClientSize.Height
            );

            if (e.KeyCode == Keys.E) {

                Bullet disparo = jogador.Atirar();
                Controls.Add(disparo);
            
            }

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            for (int i = jogador.Balas.Count - 1; i >= 0; i--)
            {

                Bullet disparo = jogador.Balas[i];
                disparo.Mover();
                if (disparo.SaiuDaTela())
                {
                    Controls.Remove(disparo);
                    jogador.Balas.RemoveAt(i);
                    disparo.Dispose();
                }

            }
        }
    }
}

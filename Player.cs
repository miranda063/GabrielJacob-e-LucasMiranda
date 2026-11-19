using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GabrielJacob_e_LucasMiranda
{
    public class Player : PictureBox
    {

        private int Velocidade { get; set; } = 10;
        public List<Bullet> Balas {  get; set; } = new List<Bullet>();

        public Player()
        {
            Size = new System.Drawing.Size(200, 200);
            SizeMode = PictureBoxSizeMode.StretchImage;

            BackColor = Color.Transparent;

            string caminhoImagem = Path.Combine(
                Application.StartupPath,
                "assets",
                "player.png"
            );

            Image = Image.FromFile(caminhoImagem);
        }

        public void Mover(Keys tecla, int larguraTela, int alturaTela)
        {
            if (tecla == Keys.W)
            {
                Top -= Velocidade;

                if (Top + Height < 0)
                {
                    Top = alturaTela;
                }
            }
            else if (tecla == Keys.A)
            {
                Left -= Velocidade;

                if (Left + Width < 0)
                {
                    Left = larguraTela;
                }
            }
            else if (tecla == Keys.S)
            {
                Top += Velocidade;

                if (Top > alturaTela)
                {
                    Top = -Height;
                }
            }
            else if (tecla == Keys.D)
            {
                Left += Velocidade;

                if (Left > larguraTela)
                {
                    Left = -Width;
                }
            }
        }

        public Bullet Atirar()
        {

                Bullet disparo = new Bullet(

                Left + (Width / 2),
                Top + (Height / 2)

            );

                Balas.Add(disparo);

                return disparo;

        }

    }
}

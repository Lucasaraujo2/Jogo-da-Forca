using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jogo_da__forca
{
    public partial class Form1 : Form
    {

        string palavra, tentadas;
        char letra;
        int quantidade = 0, erros = 0, faltam = 0;
        bool achou = false, tenta = false;
        char[] escondido;

        private void btntentar_Click(object sender, EventArgs e)
        {
            //codigo que verifica se a letra ja foi achada
            letra = mtbLetra.Text[0];
            for (int cont = 0; cont!=quantidade; cont++)
            {
                if (letra == escondido[cont])
                { tenta = true; }
            }

            //código que verifica se a letra ja foi tentada
            tentadas = lbTentadas.Text;
            int quant = tentadas.Length;
            for (int cont = 0; cont!= quant; cont++)
            {
                if (letra == tentadas[cont])
                { tenta = true; }
            }

            if (tenta == true)
            { MessageBox.Show("Voçê ja digitou essa letra."); }
            else
            //Cídigo que procura a letra na palavra escondida
            {
                for (int cont = 0;cont!= quantidade; cont++)
                {
                    if (letra == palavra[cont])
                    {
                        escondido[cont] = letra;
                        achou = true;
                        faltam = faltam - 1;

                    }
                }
            }
            //Reiniciando a palavra exibida no form
            lbPalavra.Text = "";
            for (int cont = 0; cont != quantidade; cont++)
            {
                lbPalavra.Text = lbPalavra.Text + escondido[cont];
            }
            //em caso de vitoria
            if (faltam == 0)
            {
                MessageBox.Show("Parabens voçê venceu!");
                lbPalavra.Enabled = true;
                btncomecar.Enabled = true;
                mtbLetra.Enabled = false;
                btntentar.Enabled = false;
                txbpalavra.Text = "";
                txbpalavra.Focus();
            }
            //Codigo que atualiza as letras tentadas
            if ((achou==false) & (tenta == false))
            {
                erros = erros + 1;
                lbTentadas.Text = lbTentadas.Text + " " + letra;
            }
            //codigo que atualiza a exibição do boneco
            if (erros == 1)
            { pbCabeca.Visible = true; }
            if (erros == 2)
            { pbCorpo.Visible = true; }
            if (erros == 3)
            { pbBracoD.Visible = true; }
            if (erros == 4)
            { pbBracoE.Visible = true; }
            if (erros == 5)
            { pbPernaD.Visible = true; }
            if (erros == 6)
            { pbPernaE.Visible = true; }
            if (erros == 6)
            {
                pbPernaE.Visible = true;
                MessageBox.Show("Você perdeu");
                txbpalavra.Enabled = true;
                btncomecar.Enabled = true;
                mtbLetra.Enabled = false;
                btntentar.Enabled = false;
                txbpalavra.Text = "";
                txbpalavra.Focus();
            }
            //reinicializando as variaveis de comparação
            tenta = false;
            achou = false;
            mtbLetra.Text = "";
            mtbLetra.Focus();

            lbFaltam.Text= faltam.ToString();
            lbErros.Text= erros.ToString();

        }

        private void lbFaltam_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            escondido = new char[20];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pbCabeca_Click(object sender, EventArgs e)
        {

        }

        private void btncomecar_Click(object sender, EventArgs e)
        {
            palavra = txbpalavra.Text;
            quantidade = palavra.Length;
            faltam = quantidade;
            lbPalavra.Text = "";
            lbTentadas.Text = "";
            for (int cont = 0; cont!=quantidade; cont++) 
            {
                escondido[cont] = '*';
                lbPalavra.Text = lbPalavra.Text + escondido[cont];

            }
            erros = 0;

            pbCabeca.Visible = false;
            pbCorpo.Visible = false;
            pbBracoE.Visible = false;
            pbBracoD.Visible = false;
            pbPernaE.Visible = false;
            pbPernaD.Visible = false;
            txbpalavra.Enabled = true;
            btncomecar.Enabled = false;
            mtbLetra.Enabled = true;
            btntentar.Enabled = true;
            mtbLetra.Focus();
            lbFaltam.Text = false.ToString();
            lbErros.Text = erros.ToString();


        }
    }
}

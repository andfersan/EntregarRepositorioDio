using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Rodizio
{
    public partial class RodiziodePlaca : Form
    {
        public RodiziodePlaca()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (cbo_semana.Text)
            {
                case "Segunda":
                    MessageBox.Show("Você escolheu o 2° dia da Semana", "Mensagem", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    break;
                case "Terça":
                    MessageBox.Show("Você escolheu o 3° dia da Semana", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case "Quarta":
                    MessageBox.Show("Você escolheu o 4° dia da Semana", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case "Quinta":
                    MessageBox.Show("Você escolheu o 5° dia da Semana", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case "Sexta":
                    MessageBox.Show("Você escolheu o 6° dia da Semana", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }
    }
}

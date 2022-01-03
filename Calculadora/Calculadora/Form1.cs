using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnsair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtprimeiro.Text = "";
            txtsegundo.Text = "";
            txtresultado.Text = "";
        }

        private void btnsoma_Click(object sender, EventArgs e)
        {
            double num1, num2, resultado;
            num1 = Convert.ToDouble(txtprimeiro.Text);
            num2 = Convert.ToDouble(txtsegundo.Text);
            resultado = num1 + num2;
            txtresultado.Text = resultado.ToString();
        }

        private void btnsub_Click(object sender, EventArgs e)
        {
            double num1, num2, resultado;
            num1 = Convert.ToDouble(txtprimeiro.Text);
            num2 = Convert.ToDouble(txtsegundo.Text);
            resultado = num1 - num2;
            txtresultado.Text = resultado.ToString();
        }

        private void btnmult_Click(object sender, EventArgs e)
        {
            double num1, num2, resultado;
            num1 = Convert.ToDouble(txtprimeiro.Text);
            num2 = Convert.ToDouble(txtsegundo.Text);
            resultado = num1 * num2;
            txtresultado.Text = resultado.ToString();
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            double num1, num2, resultado;
            num1 = Convert.ToDouble(txtprimeiro.Text);
            num2 = Convert.ToDouble(txtsegundo.Text);
            resultado = num1 / num2;
            txtresultado.Text = resultado.ToString();
        }
    }
}

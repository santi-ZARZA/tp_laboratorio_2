using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        #region Constructor
        public LaCalculadora()
        {
            InitializeComponent();
            this.cmbOperadores.SelectedIndex = 0;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.cmbOperadores.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #endregion

        #region Metodos
        private Double Operar(string numero1, string numero2, string operador)
        {
            Double retorno = 0;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            Calculadora calcula = new Calculadora();

            retorno = calcula.Operar(num1, num2, operador);

            return retorno;
        }

        private void Limpiar()
        {
            this.lblResultado.Text = "";
            this.cmbOperadores.SelectedIndex = 0;
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = (Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperadores.Text)).ToString();
        }

        private void btnDecimalABinario_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();

            this.lblResultado.Text = numero.DecimalBinario(this.txtNumero1.Text);
        }

        private void btnBinarioADecimal_Click(object sender, EventArgs e)
        {
            Numero numero = new Numero();

            this.lblResultado.Text = numero.BinarioDecimal(this.txtNumero1.Text);
        }
        #endregion
    }
}

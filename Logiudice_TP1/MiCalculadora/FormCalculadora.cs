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
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;

            resultado = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);

            // Envio resultado a label
            if (resultado == double.MinValue)
            {
                lstOperaciones.Items.Add(this.txtNumero1.Text + this.cmbOperador.Text + this.txtNumero2.Text + " = syntax error");
                lblResultado.Text = "No se puede dividir por 0";
                this.btnConvertirABinario.Enabled = false;
                this.btnConvertirADecimal.Enabled = false;
            }
            else
            {
                lblResultado.Text = resultado.ToString();
                lstOperaciones.Items.Add(this.txtNumero1.Text + this.cmbOperador.Text + this.txtNumero2.Text + " = " + resultado);
                this.btnConvertirABinario.Enabled = true;
                this.btnConvertirADecimal.Enabled = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Llamo al metodo
            this.Limpiar(); 
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();

            // Traigo resultado y lo pongo en label
            this.lblResultado.Text = resultado.DecimalBinario(this.lblResultado.Text);
            btnConvertirADecimal.Enabled = true;
            btnConvertirABinario.Enabled = false;
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();

            // Verifico resultado no vacio
            if(this.lblResultado.Text != null && this.lblResultado.Text != "")
            {
                // Traigo resultado y lo pongo en label
                lblResultado.Text = resultado.BinarioDecimal(this.lblResultado.Text);
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;
            }
        }

        /// <summary>
        /// Borra los datos de los TextBox, ComboBox y el Label de la pantalla.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";
        }

        /// <summary>
        /// Realiza operacion matematica
        /// </summary>
        /// <param name="numero1">Operando tipo string</param>
        /// <param name="numero2">Operador tipo string</param>
        /// <param name="operador">Operador tipo string</param>
        /// <returns>Resultado de operacion double</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            char operadorChar;

            Operando numUnoObj = new Operando(numero1);
            Operando numDosObj = new Operando(numero2);

            char.TryParse(operador, out operadorChar);

            return Calculadora.Operar(numUnoObj, numDosObj, operadorChar);
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta;

            respuesta = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
        }
    }
}

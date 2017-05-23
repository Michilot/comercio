using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EC.BusinessLogic;

namespace EC.Exam
{
    public partial class frmElComercio : Form
    {
        #region "Inicializador"
        public frmElComercio()
        {
            InitializeComponent();
        }

        #endregion

        #region "Formulario"
        private void Form1_Load(object sender, EventArgs e)
        {
            txtCadenaEntrada1.Focus();
        }

        #endregion

        #region "Cajas de Texto"

        private void txtCadenaEntrada1_TextChanged(object sender, EventArgs e)
        {
            ChangeString oChangeString = new ChangeString();
            txtCadenaSalida1.Text = oChangeString.build(txtCadenaEntrada1.Text);
        }

        private void txtCadenaEntrada2_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (txtCadenaEntrada2.Text == string.Empty)
            {
                txtCadenaSalida2.Text = string.Empty;
            }
            else
            {
                if (!int.TryParse(txtCadenaEntrada2.Text.Replace(",", "").Trim(), out n))
                {
                    MessageBox.Show("Por favor solo ingresar números.", "Alerta");
                    txtCadenaEntrada2.Text = string.Empty;
                }
                CompleteRange oCompleteRange = new CompleteRange();
                txtCadenaSalida2.Text = oCompleteRange.build(txtCadenaEntrada2.Text);
            }
        }

        private void txtCadenaEntrada3_TextChanged(object sender, EventArgs e)
        {
            double n;
            if (txtCadenaEntrada3.Text == string.Empty)
            {
                txtCadenaSalida3.Text = string.Empty;
            }
            else
            {
                if (!double.TryParse(txtCadenaEntrada3.Text.Trim(), out n))
                {
                    MessageBox.Show("Por favor solo ingresar números.", "Alerta");
                    txtCadenaEntrada3.Text = string.Empty;
                    txtCadenaSalida3.Text = string.Empty;
                }
                else
                {
                    Common oCommon = new Common();
                    int nDecimal = oCommon.ObtenerNumeroDecimales(decimal.Parse(txtCadenaEntrada3.Text.Trim()));
                    if (nDecimal > 2)
                    {
                        MessageBox.Show("Por favor solo ingresar 2 posiciones decimales.", "Alerta");
                        txtCadenaEntrada3.Text = string.Empty;
                        txtCadenaSalida3.Text = string.Empty;
                    }
                    else
                    {
                        MoneyParts oMoneyParts = new MoneyParts();
                        double sValor = double.Parse(txtCadenaEntrada3.Text);
                        string sListaDenominacion = oMoneyParts.build(sValor);
                        if (string.IsNullOrEmpty(sListaDenominacion) && sValor > 0)
                        {
                            MessageBox.Show("Por favor solo considerar denominaciones dentro del rango.\n[0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100, 200]", "Alerta");
                            txtCadenaEntrada3.Text = string.Empty;
                            txtCadenaSalida3.Text = string.Empty;
                        }
                        else
                        {
                            txtCadenaSalida3.Text = sListaDenominacion;
                        }


                    }
                }
            }
        }

        #endregion

        #region "Botones"

        private void btnLimpiar1_Click(object sender, EventArgs e)
        {
            LimpiarControl(grbAgrupador1);
        }
        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
            LimpiarControl(grbAgrupador2);
        }
        private void btnLimpiar3_Click(object sender, EventArgs e)
        {
            LimpiarControl(grbAgrupador3);
        }

        #endregion

        #region "Metodos"
        private void LimpiarControl(GroupBox GroupBox)
        {
            foreach (Control ctrl in GroupBox.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = string.Empty;
                }
            }
        }

        #endregion

    }
}

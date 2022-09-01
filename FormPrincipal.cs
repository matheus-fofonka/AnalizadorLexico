using System;
using System.Linq;
using System.Windows.Forms;

namespace AnalizadorLexico
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        ~FormPrincipal()
        {
            GC.Collect();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            btnCarregar.Enabled = false;

            var text = txtCarrega.Text.Replace("\r", "");
            using (FormIdentificador formIdentificador = new FormIdentificador(text.Split('\n').ToList()))
            {
                formIdentificador.Identificar();
            }

            btnCarregar.Enabled = true;

        }
    }
}
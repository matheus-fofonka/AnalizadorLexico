using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnalizadorLexico
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        ~FormPrincipal()
        {
            GC.Collect();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            listBox.Items.Clear();

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                var text = System.IO.File.ReadAllText(files[0]).Replace("\r", "");
                List<string> listText = text.Split('\n').ToList();

                foreach (string txt in listText) listBox.Items.Add(txt);

                pgBar.Visible = true;
                using (FormIdentificador form = new FormIdentificador(listText))
                {
                    form.Identificar();

                    FormatarResposta(form);
                }
                pgBar.Visible = false;

            }
        }

        private void FormatarResposta(FormIdentificador form)
        {
            StringBuilder texto = new StringBuilder();
            texto.AppendLine("Tokens de Entrada");
            foreach (var tk in form.ListaTokens)
            {
                var index = form.ListaSimbolos.FindIndex(x => x == tk.Simbolo) + 1;
                string numeroSimb = (index == 0) ? "" : (index).ToString();
                texto.AppendLine("[" + tk.Linha + "] " + tk.Tipo.ToString() + " " + numeroSimb);
            }

            texto.AppendLine("");

            texto.AppendLine("Tabela de Símbolos");
            for (int i = 1; i <= form.ListaSimbolos.Count; i++)
            {
                texto.AppendLine(i + " - " + form.ListaSimbolos[i - 1].texto);
            }

            texto.AppendLine("");

            texto.AppendLine("Erros nas linhas:");
            foreach (var err in form.ListaErros)
            {
                texto.AppendLine(err.Linha + " (" + err.Simbolo.texto + ")");
            }

            lblResult.Text = texto.ToString();
        }
    }
}
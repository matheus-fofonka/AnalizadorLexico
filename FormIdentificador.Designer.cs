
namespace AnalizadorLexico
{
    partial class FormIdentificador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bgWorkerIdentificaTextos = new System.ComponentModel.BackgroundWorker();
            this.bgWorkerIdentificaNumeros = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // bgWorkerIdentificaTextos
            // 
            this.bgWorkerIdentificaTextos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerIdentificaTextos_DoWork);
            this.bgWorkerIdentificaTextos.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerIdentificaTextos_RunWorkerCompleted);
            // 
            // bgWorkerIdentificaNumeros
            // 
            this.bgWorkerIdentificaNumeros.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerIdentificaNumeros_DoWork);
            this.bgWorkerIdentificaNumeros.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerIdentificaNumeros_RunWorkerCompleted);
            // 
            // FormIdentificador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 0);
            this.Name = "FormIdentificador";
            this.Text = "FormIdentificador";
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgWorkerIdentificaTextos;
        private System.ComponentModel.BackgroundWorker bgWorkerIdentificaNumeros;
    }
}

namespace AnalizadorLexico
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.listBox = new System.Windows.Forms.ListBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Analizador Léxico";
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 48);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(273, 537);
            this.listBox.TabIndex = 3;
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.Location = new System.Drawing.Point(291, 48);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(323, 532);
            this.lblResult.TabIndex = 4;
            // 
            // pgBar
            // 
            this.pgBar.Location = new System.Drawing.Point(-11, 583);
            this.pgBar.MarqueeAnimationSpeed = 5;
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(643, 10);
            this.pgBar.Step = 25;
            this.pgBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgBar.TabIndex = 5;
            this.pgBar.Visible = false;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 589);
            this.Controls.Add(this.pgBar);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "FormPrincipal";
            this.ShowIcon = false;
            this.Text = "Analizador Léxico";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ProgressBar pgBar;
    }
}


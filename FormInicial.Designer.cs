namespace Projeto_Base_De_Dados_VivaTicket
{
    partial class FormInicial
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
            this.button_Cliente = new System.Windows.Forms.Button();
            this.button_Funcionario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Cliente
            // 
            this.button_Cliente.Location = new System.Drawing.Point(142, 286);
            this.button_Cliente.Name = "button_Cliente";
            this.button_Cliente.Size = new System.Drawing.Size(210, 120);
            this.button_Cliente.TabIndex = 0;
            this.button_Cliente.Text = "Cliente";
            this.button_Cliente.UseVisualStyleBackColor = true;
            this.button_Cliente.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Funcionario
            // 
            this.button_Funcionario.Location = new System.Drawing.Point(608, 286);
            this.button_Funcionario.Name = "button_Funcionario";
            this.button_Funcionario.Size = new System.Drawing.Size(210, 120);
            this.button_Funcionario.TabIndex = 1;
            this.button_Funcionario.Text = "Funcionario";
            this.button_Funcionario.UseVisualStyleBackColor = true;
            this.button_Funcionario.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 753);
            this.Controls.Add(this.button_Funcionario);
            this.Controls.Add(this.button_Cliente);
            this.Name = "FormInicial";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormInicial_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Cliente;
        private System.Windows.Forms.Button button_Funcionario;
    }
}


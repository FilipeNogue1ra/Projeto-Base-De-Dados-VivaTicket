namespace Projeto_Base_De_Dados_VivaTicket
{
    partial class FormLoginCliente
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
            this.btnLoginCliente = new System.Windows.Forms.Button();
            this.txtPasswordCliente = new System.Windows.Forms.TextBox();
            this.txtEmailCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAbrirRegisto = new System.Windows.Forms.Button();
            this.lblMensagemLoginCliente = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoginCliente
            // 
            this.btnLoginCliente.Location = new System.Drawing.Point(282, 329);
            this.btnLoginCliente.Name = "btnLoginCliente";
            this.btnLoginCliente.Size = new System.Drawing.Size(163, 110);
            this.btnLoginCliente.TabIndex = 9;
            this.btnLoginCliente.Text = "Login";
            this.btnLoginCliente.UseVisualStyleBackColor = true;
            this.btnLoginCliente.Click += new System.EventHandler(this.btnLoginCliente_Click);
            // 
            // txtPasswordCliente
            // 
            this.txtPasswordCliente.Location = new System.Drawing.Point(393, 209);
            this.txtPasswordCliente.Name = "txtPasswordCliente";
            this.txtPasswordCliente.PasswordChar = '*';
            this.txtPasswordCliente.Size = new System.Drawing.Size(221, 22);
            this.txtPasswordCliente.TabIndex = 8;
            // 
            // txtEmailCliente
            // 
            this.txtEmailCliente.Location = new System.Drawing.Point(393, 162);
            this.txtEmailCliente.Name = "txtEmailCliente";
            this.txtEmailCliente.Size = new System.Drawing.Size(221, 22);
            this.txtEmailCliente.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Email";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(424, 496);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 106);
            this.button2.TabIndex = 10;
            this.button2.Text = "Voltar atrás";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAbrirRegisto
            // 
            this.btnAbrirRegisto.Location = new System.Drawing.Point(575, 333);
            this.btnAbrirRegisto.Name = "btnAbrirRegisto";
            this.btnAbrirRegisto.Size = new System.Drawing.Size(163, 106);
            this.btnAbrirRegisto.TabIndex = 11;
            this.btnAbrirRegisto.Text = "Registrar";
            this.btnAbrirRegisto.UseVisualStyleBackColor = true;
            // 
            // lblMensagemLoginCliente
            // 
            this.lblMensagemLoginCliente.AutoSize = true;
            this.lblMensagemLoginCliente.Location = new System.Drawing.Point(393, 272);
            this.lblMensagemLoginCliente.Name = "lblMensagemLoginCliente";
            this.lblMensagemLoginCliente.Size = new System.Drawing.Size(0, 16);
            this.lblMensagemLoginCliente.TabIndex = 12;
            // 
            // FormLoginCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 753);
            this.Controls.Add(this.lblMensagemLoginCliente);
            this.Controls.Add(this.btnAbrirRegisto);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLoginCliente);
            this.Controls.Add(this.txtPasswordCliente);
            this.Controls.Add(this.txtEmailCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormLoginCliente";
            this.Text = "FormLoginCliente";
            this.Load += new System.EventHandler(this.FormLoginCliente_Load);
            this.Click += new System.EventHandler(this.button2_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoginCliente;
        private System.Windows.Forms.TextBox txtPasswordCliente;
        private System.Windows.Forms.TextBox txtEmailCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAbrirRegisto;
        private System.Windows.Forms.Label lblMensagemLoginCliente;
    }
}
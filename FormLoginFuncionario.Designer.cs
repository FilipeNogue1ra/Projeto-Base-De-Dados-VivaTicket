namespace Projeto_Base_De_Dados_VivaTicket
{
    partial class FormLoginFuncionario
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmailFuncionario = new System.Windows.Forms.TextBox();
            this.txtPasswordFuncionario = new System.Windows.Forms.TextBox();
            this.btnLoginFuncionario = new System.Windows.Forms.Button();
            this.button_VoltarAtras = new System.Windows.Forms.Button();
            this.lblMensagemFunc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // txtEmailFuncionario
            // 
            this.txtEmailFuncionario.Location = new System.Drawing.Point(317, 141);
            this.txtEmailFuncionario.Name = "txtEmailFuncionario";
            this.txtEmailFuncionario.Size = new System.Drawing.Size(241, 22);
            this.txtEmailFuncionario.TabIndex = 2;
            this.txtEmailFuncionario.Text = "ana.silva@vivaticket.pt";
            // 
            // txtPasswordFuncionario
            // 
            this.txtPasswordFuncionario.Location = new System.Drawing.Point(317, 188);
            this.txtPasswordFuncionario.Name = "txtPasswordFuncionario";
            this.txtPasswordFuncionario.PasswordChar = '*';
            this.txtPasswordFuncionario.Size = new System.Drawing.Size(241, 22);
            this.txtPasswordFuncionario.TabIndex = 3;
            this.txtPasswordFuncionario.Text = "password_ana";
            // 
            // btnLoginFuncionario
            // 
            this.btnLoginFuncionario.Location = new System.Drawing.Point(226, 253);
            this.btnLoginFuncionario.Name = "btnLoginFuncionario";
            this.btnLoginFuncionario.Size = new System.Drawing.Size(184, 120);
            this.btnLoginFuncionario.TabIndex = 4;
            this.btnLoginFuncionario.Text = "Login";
            this.btnLoginFuncionario.UseVisualStyleBackColor = true;
            this.btnLoginFuncionario.Click += new System.EventHandler(this.btnLoginFuncionario_Click);
            // 
            // button_VoltarAtras
            // 
            this.button_VoltarAtras.Location = new System.Drawing.Point(494, 253);
            this.button_VoltarAtras.Name = "button_VoltarAtras";
            this.button_VoltarAtras.Size = new System.Drawing.Size(184, 120);
            this.button_VoltarAtras.TabIndex = 11;
            this.button_VoltarAtras.Text = "Voltar atrás";
            this.button_VoltarAtras.UseVisualStyleBackColor = true;
            this.button_VoltarAtras.Click += new System.EventHandler(this.button_VoltarAtras_Click);
            // 
            // lblMensagemFunc
            // 
            this.lblMensagemFunc.AutoSize = true;
            this.lblMensagemFunc.Location = new System.Drawing.Point(366, 431);
            this.lblMensagemFunc.Name = "lblMensagemFunc";
            this.lblMensagemFunc.Size = new System.Drawing.Size(44, 16);
            this.lblMensagemFunc.TabIndex = 12;
            this.lblMensagemFunc.Text = "label3";
            // 
            // FormLoginFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 753);
            this.Controls.Add(this.lblMensagemFunc);
            this.Controls.Add(this.button_VoltarAtras);
            this.Controls.Add(this.btnLoginFuncionario);
            this.Controls.Add(this.txtPasswordFuncionario);
            this.Controls.Add(this.txtEmailFuncionario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormLoginFuncionario";
            this.Text = "FormLoginFuncionario";
            this.Load += new System.EventHandler(this.FormLoginFuncionario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmailFuncionario;
        private System.Windows.Forms.TextBox txtPasswordFuncionario;
        private System.Windows.Forms.Button btnLoginFuncionario;
        private System.Windows.Forms.Button button_VoltarAtras;
        private System.Windows.Forms.Label lblMensagemFunc;
    }
}
namespace Projeto_Base_De_Dados_VivaTicket
{
    partial class FormVerCliente
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageVerClientes = new System.Windows.Forms.TabPage();
            this.btnRemoverClienteSelecionado = new System.Windows.Forms.Button();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.btnLimparBuscaClientes = new System.Windows.Forms.Button();
            this.btnBuscaGeralClientes = new System.Windows.Forms.Button();
            this.txtBuscaGeralClientes = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMensagemAdicionar = new System.Windows.Forms.Label();
            this.btnAdicionarNovoCliente = new System.Windows.Forms.Button();
            this.txtNovoEnderecoCliente = new System.Windows.Forms.TextBox();
            this.txtNovoTelefoneCliente = new System.Windows.Forms.TextBox();
            this.txtNovoNIFCliente = new System.Windows.Forms.TextBox();
            this.txtNovoPasswordCliente = new System.Windows.Forms.TextBox();
            this.txtNovoEmailCliente = new System.Windows.Forms.TextBox();
            this.txtNovoNomeCliente = new System.Windows.Forms.TextBox();
            this.tabPageEditarCliente = new System.Windows.Forms.TabPage();
            this.btnAbrirPopupEdicaoDaAbaEditar = new System.Windows.Forms.Button();
            this.dgvClientesParaEdicao = new System.Windows.Forms.DataGridView();
            this.btnLimparPesquisaEditarCliente = new System.Windows.Forms.Button();
            this.btnPesquisarEditarCliente = new System.Windows.Forms.Button();
            this.txtPesquisaEditarCliente = new System.Windows.Forms.TextBox();
            this.tabPageAuditoria = new System.Windows.Forms.TabPage();
            this.btnLimparFiltrosAuditoria = new System.Windows.Forms.Button();
            this.btnFiltrarAuditoria = new System.Windows.Forms.Button();
            this.dtpAuditoriaDataFim = new System.Windows.Forms.DateTimePicker();
            this.dtpAuditoriaDataInicio = new System.Windows.Forms.DateTimePicker();
            this.cmbAuditoriaTipoAcao = new System.Windows.Forms.ComboBox();
            this.txtAuditoriaIdFuncionario = new System.Windows.Forms.TextBox();
            this.txtAuditoriaIdCliente = new System.Windows.Forms.TextBox();
            this.dgvAuditoriaClientes = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPageVerClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPageEditarCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesParaEdicao)).BeginInit();
            this.tabPageAuditoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoriaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageVerClientes);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPageEditarCliente);
            this.tabControl1.Controls.Add(this.tabPageAuditoria);
            this.tabControl1.Location = new System.Drawing.Point(12, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1067, 688);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageVerClientes
            // 
            this.tabPageVerClientes.Controls.Add(this.btnRemoverClienteSelecionado);
            this.tabPageVerClientes.Controls.Add(this.dgvClientes);
            this.tabPageVerClientes.Controls.Add(this.btnLimparBuscaClientes);
            this.tabPageVerClientes.Controls.Add(this.btnBuscaGeralClientes);
            this.tabPageVerClientes.Controls.Add(this.txtBuscaGeralClientes);
            this.tabPageVerClientes.Location = new System.Drawing.Point(4, 25);
            this.tabPageVerClientes.Name = "tabPageVerClientes";
            this.tabPageVerClientes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVerClientes.Size = new System.Drawing.Size(1059, 659);
            this.tabPageVerClientes.TabIndex = 0;
            this.tabPageVerClientes.Text = "Ver Clientes";
            this.tabPageVerClientes.UseVisualStyleBackColor = true;
            this.tabPageVerClientes.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnRemoverClienteSelecionado
            // 
            this.btnRemoverClienteSelecionado.Location = new System.Drawing.Point(593, 39);
            this.btnRemoverClienteSelecionado.Name = "btnRemoverClienteSelecionado";
            this.btnRemoverClienteSelecionado.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverClienteSelecionado.TabIndex = 4;
            this.btnRemoverClienteSelecionado.Text = "Remover cliente";
            this.btnRemoverClienteSelecionado.UseVisualStyleBackColor = true;
            this.btnRemoverClienteSelecionado.Click += new System.EventHandler(this.btnRemoverClienteSelecionado_Click);
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(6, 138);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowHeadersWidth = 51;
            this.dgvClientes.RowTemplate.Height = 24;
            this.dgvClientes.Size = new System.Drawing.Size(948, 515);
            this.dgvClientes.TabIndex = 3;
            this.dgvClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientes_CellContentClick);
            // 
            // btnLimparBuscaClientes
            // 
            this.btnLimparBuscaClientes.Location = new System.Drawing.Point(417, 40);
            this.btnLimparBuscaClientes.Name = "btnLimparBuscaClientes";
            this.btnLimparBuscaClientes.Size = new System.Drawing.Size(75, 23);
            this.btnLimparBuscaClientes.TabIndex = 2;
            this.btnLimparBuscaClientes.Text = "Limpar";
            this.btnLimparBuscaClientes.UseVisualStyleBackColor = true;
            this.btnLimparBuscaClientes.Click += new System.EventHandler(this.btnLimparBuscaClientes_Click);
            // 
            // btnBuscaGeralClientes
            // 
            this.btnBuscaGeralClientes.Location = new System.Drawing.Point(272, 40);
            this.btnBuscaGeralClientes.Name = "btnBuscaGeralClientes";
            this.btnBuscaGeralClientes.Size = new System.Drawing.Size(75, 23);
            this.btnBuscaGeralClientes.TabIndex = 1;
            this.btnBuscaGeralClientes.Text = "Buscar";
            this.btnBuscaGeralClientes.UseVisualStyleBackColor = true;
            this.btnBuscaGeralClientes.Click += new System.EventHandler(this.btnBuscaGeralClientes_Click);
            // 
            // txtBuscaGeralClientes
            // 
            this.txtBuscaGeralClientes.Location = new System.Drawing.Point(114, 40);
            this.txtBuscaGeralClientes.Name = "txtBuscaGeralClientes";
            this.txtBuscaGeralClientes.Size = new System.Drawing.Size(100, 22);
            this.txtBuscaGeralClientes.TabIndex = 0;
            this.txtBuscaGeralClientes.TextChanged += new System.EventHandler(this.txtBuscaGeralClientes_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.lblMensagemAdicionar);
            this.tabPage2.Controls.Add(this.btnAdicionarNovoCliente);
            this.tabPage2.Controls.Add(this.txtNovoEnderecoCliente);
            this.tabPage2.Controls.Add(this.txtNovoTelefoneCliente);
            this.tabPage2.Controls.Add(this.txtNovoNIFCliente);
            this.tabPage2.Controls.Add(this.txtNovoPasswordCliente);
            this.tabPage2.Controls.Add(this.txtNovoEmailCliente);
            this.tabPage2.Controls.Add(this.txtNovoNomeCliente);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1059, 659);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Adicionar Clientes";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 428);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Endereço";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 357);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "nº de Telemovel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(209, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "NIF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nome";
            // 
            // lblMensagemAdicionar
            // 
            this.lblMensagemAdicionar.AutoSize = true;
            this.lblMensagemAdicionar.Location = new System.Drawing.Point(587, 303);
            this.lblMensagemAdicionar.Name = "lblMensagemAdicionar";
            this.lblMensagemAdicionar.Size = new System.Drawing.Size(0, 16);
            this.lblMensagemAdicionar.TabIndex = 7;
            // 
            // btnAdicionarNovoCliente
            // 
            this.btnAdicionarNovoCliente.Location = new System.Drawing.Point(277, 486);
            this.btnAdicionarNovoCliente.Name = "btnAdicionarNovoCliente";
            this.btnAdicionarNovoCliente.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarNovoCliente.TabIndex = 6;
            this.btnAdicionarNovoCliente.Text = "Adicionar Cliente";
            this.btnAdicionarNovoCliente.UseVisualStyleBackColor = true;
            this.btnAdicionarNovoCliente.Click += new System.EventHandler(this.btnAdicionarNovoCliente_Click);
            // 
            // txtNovoEnderecoCliente
            // 
            this.txtNovoEnderecoCliente.Location = new System.Drawing.Point(363, 428);
            this.txtNovoEnderecoCliente.Name = "txtNovoEnderecoCliente";
            this.txtNovoEnderecoCliente.Size = new System.Drawing.Size(100, 22);
            this.txtNovoEnderecoCliente.TabIndex = 5;
            // 
            // txtNovoTelefoneCliente
            // 
            this.txtNovoTelefoneCliente.Location = new System.Drawing.Point(363, 357);
            this.txtNovoTelefoneCliente.Name = "txtNovoTelefoneCliente";
            this.txtNovoTelefoneCliente.Size = new System.Drawing.Size(100, 22);
            this.txtNovoTelefoneCliente.TabIndex = 4;
            // 
            // txtNovoNIFCliente
            // 
            this.txtNovoNIFCliente.Location = new System.Drawing.Point(363, 298);
            this.txtNovoNIFCliente.Name = "txtNovoNIFCliente";
            this.txtNovoNIFCliente.Size = new System.Drawing.Size(100, 22);
            this.txtNovoNIFCliente.TabIndex = 3;
            // 
            // txtNovoPasswordCliente
            // 
            this.txtNovoPasswordCliente.Location = new System.Drawing.Point(363, 224);
            this.txtNovoPasswordCliente.Name = "txtNovoPasswordCliente";
            this.txtNovoPasswordCliente.Size = new System.Drawing.Size(100, 22);
            this.txtNovoPasswordCliente.TabIndex = 2;
            // 
            // txtNovoEmailCliente
            // 
            this.txtNovoEmailCliente.Location = new System.Drawing.Point(363, 153);
            this.txtNovoEmailCliente.Name = "txtNovoEmailCliente";
            this.txtNovoEmailCliente.Size = new System.Drawing.Size(100, 22);
            this.txtNovoEmailCliente.TabIndex = 1;
            // 
            // txtNovoNomeCliente
            // 
            this.txtNovoNomeCliente.Location = new System.Drawing.Point(363, 94);
            this.txtNovoNomeCliente.Name = "txtNovoNomeCliente";
            this.txtNovoNomeCliente.Size = new System.Drawing.Size(100, 22);
            this.txtNovoNomeCliente.TabIndex = 0;
            // 
            // tabPageEditarCliente
            // 
            this.tabPageEditarCliente.Controls.Add(this.btnAbrirPopupEdicaoDaAbaEditar);
            this.tabPageEditarCliente.Controls.Add(this.dgvClientesParaEdicao);
            this.tabPageEditarCliente.Controls.Add(this.btnLimparPesquisaEditarCliente);
            this.tabPageEditarCliente.Controls.Add(this.btnPesquisarEditarCliente);
            this.tabPageEditarCliente.Controls.Add(this.txtPesquisaEditarCliente);
            this.tabPageEditarCliente.Location = new System.Drawing.Point(4, 25);
            this.tabPageEditarCliente.Name = "tabPageEditarCliente";
            this.tabPageEditarCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEditarCliente.Size = new System.Drawing.Size(1059, 659);
            this.tabPageEditarCliente.TabIndex = 2;
            this.tabPageEditarCliente.Text = "Editar clientes";
            this.tabPageEditarCliente.UseVisualStyleBackColor = true;
            this.tabPageEditarCliente.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // btnAbrirPopupEdicaoDaAbaEditar
            // 
            this.btnAbrirPopupEdicaoDaAbaEditar.Location = new System.Drawing.Point(608, 67);
            this.btnAbrirPopupEdicaoDaAbaEditar.Name = "btnAbrirPopupEdicaoDaAbaEditar";
            this.btnAbrirPopupEdicaoDaAbaEditar.Size = new System.Drawing.Size(75, 23);
            this.btnAbrirPopupEdicaoDaAbaEditar.TabIndex = 4;
            this.btnAbrirPopupEdicaoDaAbaEditar.Text = "editar cliente";
            this.btnAbrirPopupEdicaoDaAbaEditar.UseVisualStyleBackColor = true;
            this.btnAbrirPopupEdicaoDaAbaEditar.Click += new System.EventHandler(this.btnAbrirPopupEdicaoDaAbaEditar_Click);
            // 
            // dgvClientesParaEdicao
            // 
            this.dgvClientesParaEdicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientesParaEdicao.Location = new System.Drawing.Point(6, 123);
            this.dgvClientesParaEdicao.Name = "dgvClientesParaEdicao";
            this.dgvClientesParaEdicao.RowHeadersWidth = 51;
            this.dgvClientesParaEdicao.RowTemplate.Height = 24;
            this.dgvClientesParaEdicao.Size = new System.Drawing.Size(1047, 530);
            this.dgvClientesParaEdicao.TabIndex = 3;
            // 
            // btnLimparPesquisaEditarCliente
            // 
            this.btnLimparPesquisaEditarCliente.Location = new System.Drawing.Point(482, 67);
            this.btnLimparPesquisaEditarCliente.Name = "btnLimparPesquisaEditarCliente";
            this.btnLimparPesquisaEditarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnLimparPesquisaEditarCliente.TabIndex = 2;
            this.btnLimparPesquisaEditarCliente.Text = "Limpar";
            this.btnLimparPesquisaEditarCliente.UseVisualStyleBackColor = true;
            this.btnLimparPesquisaEditarCliente.Click += new System.EventHandler(this.btnLimparPesquisaEditarCliente_Click);
            // 
            // btnPesquisarEditarCliente
            // 
            this.btnPesquisarEditarCliente.Location = new System.Drawing.Point(359, 66);
            this.btnPesquisarEditarCliente.Name = "btnPesquisarEditarCliente";
            this.btnPesquisarEditarCliente.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisarEditarCliente.TabIndex = 1;
            this.btnPesquisarEditarCliente.Text = "Pesquisar cliente";
            this.btnPesquisarEditarCliente.UseVisualStyleBackColor = true;
            this.btnPesquisarEditarCliente.Click += new System.EventHandler(this.btnPesquisarEditarCliente_Click);
            // 
            // txtPesquisaEditarCliente
            // 
            this.txtPesquisaEditarCliente.Location = new System.Drawing.Point(193, 67);
            this.txtPesquisaEditarCliente.Name = "txtPesquisaEditarCliente";
            this.txtPesquisaEditarCliente.Size = new System.Drawing.Size(100, 22);
            this.txtPesquisaEditarCliente.TabIndex = 0;
            // 
            // tabPageAuditoria
            // 
            this.tabPageAuditoria.Controls.Add(this.btnLimparFiltrosAuditoria);
            this.tabPageAuditoria.Controls.Add(this.btnFiltrarAuditoria);
            this.tabPageAuditoria.Controls.Add(this.dtpAuditoriaDataFim);
            this.tabPageAuditoria.Controls.Add(this.dtpAuditoriaDataInicio);
            this.tabPageAuditoria.Controls.Add(this.cmbAuditoriaTipoAcao);
            this.tabPageAuditoria.Controls.Add(this.txtAuditoriaIdFuncionario);
            this.tabPageAuditoria.Controls.Add(this.txtAuditoriaIdCliente);
            this.tabPageAuditoria.Controls.Add(this.dgvAuditoriaClientes);
            this.tabPageAuditoria.Location = new System.Drawing.Point(4, 25);
            this.tabPageAuditoria.Name = "tabPageAuditoria";
            this.tabPageAuditoria.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuditoria.Size = new System.Drawing.Size(1059, 659);
            this.tabPageAuditoria.TabIndex = 3;
            this.tabPageAuditoria.Text = "Registo de auditoria";
            this.tabPageAuditoria.UseVisualStyleBackColor = true;
            this.tabPageAuditoria.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // btnLimparFiltrosAuditoria
            // 
            this.btnLimparFiltrosAuditoria.Location = new System.Drawing.Point(513, 102);
            this.btnLimparFiltrosAuditoria.Name = "btnLimparFiltrosAuditoria";
            this.btnLimparFiltrosAuditoria.Size = new System.Drawing.Size(75, 23);
            this.btnLimparFiltrosAuditoria.TabIndex = 7;
            this.btnLimparFiltrosAuditoria.Text = "Limpar  filtros";
            this.btnLimparFiltrosAuditoria.UseVisualStyleBackColor = true;
            this.btnLimparFiltrosAuditoria.Click += new System.EventHandler(this.btnLimparFiltrosAuditoria_Click);
            // 
            // btnFiltrarAuditoria
            // 
            this.btnFiltrarAuditoria.Location = new System.Drawing.Point(410, 102);
            this.btnFiltrarAuditoria.Name = "btnFiltrarAuditoria";
            this.btnFiltrarAuditoria.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrarAuditoria.TabIndex = 6;
            this.btnFiltrarAuditoria.Text = "Filtrar";
            this.btnFiltrarAuditoria.UseVisualStyleBackColor = true;
            this.btnFiltrarAuditoria.Click += new System.EventHandler(this.btnFiltrarAuditoria_Click);
            // 
            // dtpAuditoriaDataFim
            // 
            this.dtpAuditoriaDataFim.Location = new System.Drawing.Point(612, 89);
            this.dtpAuditoriaDataFim.Name = "dtpAuditoriaDataFim";
            this.dtpAuditoriaDataFim.Size = new System.Drawing.Size(200, 22);
            this.dtpAuditoriaDataFim.TabIndex = 5;
            // 
            // dtpAuditoriaDataInicio
            // 
            this.dtpAuditoriaDataInicio.Location = new System.Drawing.Point(623, 26);
            this.dtpAuditoriaDataInicio.Name = "dtpAuditoriaDataInicio";
            this.dtpAuditoriaDataInicio.Size = new System.Drawing.Size(200, 22);
            this.dtpAuditoriaDataInicio.TabIndex = 4;
            // 
            // cmbAuditoriaTipoAcao
            // 
            this.cmbAuditoriaTipoAcao.FormattingEnabled = true;
            this.cmbAuditoriaTipoAcao.Location = new System.Drawing.Point(440, 26);
            this.cmbAuditoriaTipoAcao.Name = "cmbAuditoriaTipoAcao";
            this.cmbAuditoriaTipoAcao.Size = new System.Drawing.Size(121, 24);
            this.cmbAuditoriaTipoAcao.TabIndex = 3;
            // 
            // txtAuditoriaIdFuncionario
            // 
            this.txtAuditoriaIdFuncionario.Location = new System.Drawing.Point(290, 69);
            this.txtAuditoriaIdFuncionario.Name = "txtAuditoriaIdFuncionario";
            this.txtAuditoriaIdFuncionario.Size = new System.Drawing.Size(100, 22);
            this.txtAuditoriaIdFuncionario.TabIndex = 2;
            // 
            // txtAuditoriaIdCliente
            // 
            this.txtAuditoriaIdCliente.Location = new System.Drawing.Point(113, 69);
            this.txtAuditoriaIdCliente.Name = "txtAuditoriaIdCliente";
            this.txtAuditoriaIdCliente.Size = new System.Drawing.Size(100, 22);
            this.txtAuditoriaIdCliente.TabIndex = 1;
            // 
            // dgvAuditoriaClientes
            // 
            this.dgvAuditoriaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditoriaClientes.Location = new System.Drawing.Point(6, 150);
            this.dgvAuditoriaClientes.Name = "dgvAuditoriaClientes";
            this.dgvAuditoriaClientes.ReadOnly = true;
            this.dgvAuditoriaClientes.RowHeadersWidth = 51;
            this.dgvAuditoriaClientes.RowTemplate.Height = 24;
            this.dgvAuditoriaClientes.Size = new System.Drawing.Size(948, 503);
            this.dgvAuditoriaClientes.TabIndex = 0;
            // 
            // FormVerCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 753);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormVerCliente";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPageVerClientes.ResumeLayout(false);
            this.tabPageVerClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPageEditarCliente.ResumeLayout(false);
            this.tabPageEditarCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesParaEdicao)).EndInit();
            this.tabPageAuditoria.ResumeLayout(false);
            this.tabPageAuditoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoriaClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageVerClientes;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPageEditarCliente;
        private System.Windows.Forms.TabPage tabPageAuditoria;
        private System.Windows.Forms.Button btnRemoverClienteSelecionado;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Button btnLimparBuscaClientes;
        private System.Windows.Forms.Button btnBuscaGeralClientes;
        private System.Windows.Forms.TextBox txtBuscaGeralClientes;
        private System.Windows.Forms.Button btnAbrirPopupEdicaoDaAbaEditar;
        private System.Windows.Forms.DataGridView dgvClientesParaEdicao;
        private System.Windows.Forms.Button btnLimparPesquisaEditarCliente;
        private System.Windows.Forms.Button btnPesquisarEditarCliente;
        private System.Windows.Forms.TextBox txtPesquisaEditarCliente;
        private System.Windows.Forms.Button btnLimparFiltrosAuditoria;
        private System.Windows.Forms.Button btnFiltrarAuditoria;
        private System.Windows.Forms.DateTimePicker dtpAuditoriaDataFim;
        private System.Windows.Forms.DateTimePicker dtpAuditoriaDataInicio;
        private System.Windows.Forms.ComboBox cmbAuditoriaTipoAcao;
        private System.Windows.Forms.TextBox txtAuditoriaIdFuncionario;
        private System.Windows.Forms.TextBox txtAuditoriaIdCliente;
        private System.Windows.Forms.DataGridView dgvAuditoriaClientes;
        private System.Windows.Forms.Label lblMensagemAdicionar;
        private System.Windows.Forms.Button btnAdicionarNovoCliente;
        private System.Windows.Forms.TextBox txtNovoEnderecoCliente;
        private System.Windows.Forms.TextBox txtNovoTelefoneCliente;
        private System.Windows.Forms.TextBox txtNovoNIFCliente;
        private System.Windows.Forms.TextBox txtNovoPasswordCliente;
        private System.Windows.Forms.TextBox txtNovoEmailCliente;
        private System.Windows.Forms.TextBox txtNovoNomeCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
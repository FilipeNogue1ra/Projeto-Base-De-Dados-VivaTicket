namespace Projeto_Base_De_Dados_VivaTicket
{
    partial class FormGerirSalas
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabControlSalas = new System.Windows.Forms.TabPage();
            this.tabPageAdicionarSala = new System.Windows.Forms.TabPage();
            this.tabPageAuditoriaSalas = new System.Windows.Forms.TabPage();
            this.dgvSalas = new System.Windows.Forms.DataGridView();
            this.txtFiltroNomeSala = new System.Windows.Forms.TextBox();
            this.cmbFiltroTipoSala = new System.Windows.Forms.ComboBox();
            this.cmbFiltroStatusSala = new System.Windows.Forms.ComboBox();
            this.btnFiltrarSalas = new System.Windows.Forms.Button();
            this.btnLimparFiltrosSalas = new System.Windows.Forms.Button();
            this.btnEditarSalaSel = new System.Windows.Forms.Button();
            this.btnDesativarSalaSel = new System.Windows.Forms.Button();
            this.txtNovoNumeroLugares = new System.Windows.Forms.TextBox();
            this.txtNovaNomeSala = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNovaDescricaoSala = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNovaLocalizacaoSala = new System.Windows.Forms.TextBox();
            this.txtNovoPrecoDiaAluguer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNovoTipoSala = new System.Windows.Forms.ComboBox();
            this.cmbNovoStatusSala = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkNovaAlugavelPorCliente = new System.Windows.Forms.CheckBox();
            this.btnAdicionarNovaSala = new System.Windows.Forms.Button();
            this.lblMensagemAdicionarSala = new System.Windows.Forms.Label();
            this.dgvAuditoriaSalas = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAuditoriaIdSalaFiltro = new System.Windows.Forms.TextBox();
            this.txtAuditoriaIdFuncionarioFiltro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbAuditoriaTipoAcaoFiltro = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpAuditoriaDataInicioFiltro = new System.Windows.Forms.DateTimePicker();
            this.dtpAuditoriaDataFimFiltro = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrarAuditoriaSalas = new System.Windows.Forms.Button();
            this.btnLimparFiltrosAuditoriaSalas = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.tabControlSalas.SuspendLayout();
            this.tabPageAdicionarSala.SuspendLayout();
            this.tabPageAuditoriaSalas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoriaSalas)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabControlSalas);
            this.TabControl.Controls.Add(this.tabPageAdicionarSala);
            this.TabControl.Controls.Add(this.tabPageAuditoriaSalas);
            this.TabControl.Location = new System.Drawing.Point(-5, 108);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1075, 643);
            this.TabControl.TabIndex = 0;
            // 
            // tabControlSalas
            // 
            this.tabControlSalas.Controls.Add(this.btnDesativarSalaSel);
            this.tabControlSalas.Controls.Add(this.btnEditarSalaSel);
            this.tabControlSalas.Controls.Add(this.btnLimparFiltrosSalas);
            this.tabControlSalas.Controls.Add(this.btnFiltrarSalas);
            this.tabControlSalas.Controls.Add(this.cmbFiltroStatusSala);
            this.tabControlSalas.Controls.Add(this.cmbFiltroTipoSala);
            this.tabControlSalas.Controls.Add(this.txtFiltroNomeSala);
            this.tabControlSalas.Controls.Add(this.dgvSalas);
            this.tabControlSalas.Location = new System.Drawing.Point(4, 25);
            this.tabControlSalas.Name = "tabControlSalas";
            this.tabControlSalas.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlSalas.Size = new System.Drawing.Size(1067, 614);
            this.tabControlSalas.TabIndex = 0;
            this.tabControlSalas.Text = "Ver salas";
            this.tabControlSalas.UseVisualStyleBackColor = true;
            // 
            // tabPageAdicionarSala
            // 
            this.tabPageAdicionarSala.Controls.Add(this.lblMensagemAdicionarSala);
            this.tabPageAdicionarSala.Controls.Add(this.btnAdicionarNovaSala);
            this.tabPageAdicionarSala.Controls.Add(this.chkNovaAlugavelPorCliente);
            this.tabPageAdicionarSala.Controls.Add(this.cmbNovoStatusSala);
            this.tabPageAdicionarSala.Controls.Add(this.label7);
            this.tabPageAdicionarSala.Controls.Add(this.cmbNovoTipoSala);
            this.tabPageAdicionarSala.Controls.Add(this.txtNovaLocalizacaoSala);
            this.tabPageAdicionarSala.Controls.Add(this.txtNovoPrecoDiaAluguer);
            this.tabPageAdicionarSala.Controls.Add(this.label3);
            this.tabPageAdicionarSala.Controls.Add(this.label4);
            this.tabPageAdicionarSala.Controls.Add(this.txtNovaDescricaoSala);
            this.tabPageAdicionarSala.Controls.Add(this.label1);
            this.tabPageAdicionarSala.Controls.Add(this.label2);
            this.tabPageAdicionarSala.Controls.Add(this.txtNovoNumeroLugares);
            this.tabPageAdicionarSala.Controls.Add(this.txtNovaNomeSala);
            this.tabPageAdicionarSala.Controls.Add(this.label5);
            this.tabPageAdicionarSala.Controls.Add(this.label6);
            this.tabPageAdicionarSala.Location = new System.Drawing.Point(4, 25);
            this.tabPageAdicionarSala.Name = "tabPageAdicionarSala";
            this.tabPageAdicionarSala.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdicionarSala.Size = new System.Drawing.Size(1067, 614);
            this.tabPageAdicionarSala.TabIndex = 1;
            this.tabPageAdicionarSala.Text = "Adicionar salas";
            this.tabPageAdicionarSala.UseVisualStyleBackColor = true;
            this.tabPageAdicionarSala.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabPageAuditoriaSalas
            // 
            this.tabPageAuditoriaSalas.Controls.Add(this.btnLimparFiltrosAuditoriaSalas);
            this.tabPageAuditoriaSalas.Controls.Add(this.btnFiltrarAuditoriaSalas);
            this.tabPageAuditoriaSalas.Controls.Add(this.dtpAuditoriaDataFimFiltro);
            this.tabPageAuditoriaSalas.Controls.Add(this.dtpAuditoriaDataInicioFiltro);
            this.tabPageAuditoriaSalas.Controls.Add(this.label11);
            this.tabPageAuditoriaSalas.Controls.Add(this.label12);
            this.tabPageAuditoriaSalas.Controls.Add(this.cmbAuditoriaTipoAcaoFiltro);
            this.tabPageAuditoriaSalas.Controls.Add(this.label10);
            this.tabPageAuditoriaSalas.Controls.Add(this.txtAuditoriaIdFuncionarioFiltro);
            this.tabPageAuditoriaSalas.Controls.Add(this.label9);
            this.tabPageAuditoriaSalas.Controls.Add(this.txtAuditoriaIdSalaFiltro);
            this.tabPageAuditoriaSalas.Controls.Add(this.label8);
            this.tabPageAuditoriaSalas.Controls.Add(this.dgvAuditoriaSalas);
            this.tabPageAuditoriaSalas.Location = new System.Drawing.Point(4, 25);
            this.tabPageAuditoriaSalas.Name = "tabPageAuditoriaSalas";
            this.tabPageAuditoriaSalas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAuditoriaSalas.Size = new System.Drawing.Size(1067, 614);
            this.tabPageAuditoriaSalas.TabIndex = 3;
            this.tabPageAuditoriaSalas.Text = "Auditoria salas";
            this.tabPageAuditoriaSalas.UseVisualStyleBackColor = true;
            this.tabPageAuditoriaSalas.Click += new System.EventHandler(this.tabPageAuditoriaSalas_Click);
            // 
            // dgvSalas
            // 
            this.dgvSalas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalas.Location = new System.Drawing.Point(7, 67);
            this.dgvSalas.Name = "dgvSalas";
            this.dgvSalas.ReadOnly = true;
            this.dgvSalas.RowHeadersWidth = 51;
            this.dgvSalas.RowTemplate.Height = 24;
            this.dgvSalas.Size = new System.Drawing.Size(1054, 544);
            this.dgvSalas.TabIndex = 0;
            // 
            // txtFiltroNomeSala
            // 
            this.txtFiltroNomeSala.Location = new System.Drawing.Point(55, 22);
            this.txtFiltroNomeSala.Name = "txtFiltroNomeSala";
            this.txtFiltroNomeSala.Size = new System.Drawing.Size(100, 22);
            this.txtFiltroNomeSala.TabIndex = 1;
            // 
            // cmbFiltroTipoSala
            // 
            this.cmbFiltroTipoSala.FormattingEnabled = true;
            this.cmbFiltroTipoSala.Location = new System.Drawing.Point(178, 22);
            this.cmbFiltroTipoSala.Name = "cmbFiltroTipoSala";
            this.cmbFiltroTipoSala.Size = new System.Drawing.Size(121, 24);
            this.cmbFiltroTipoSala.TabIndex = 2;
            // 
            // cmbFiltroStatusSala
            // 
            this.cmbFiltroStatusSala.FormattingEnabled = true;
            this.cmbFiltroStatusSala.Location = new System.Drawing.Point(323, 22);
            this.cmbFiltroStatusSala.Name = "cmbFiltroStatusSala";
            this.cmbFiltroStatusSala.Size = new System.Drawing.Size(121, 24);
            this.cmbFiltroStatusSala.TabIndex = 3;
            // 
            // btnFiltrarSalas
            // 
            this.btnFiltrarSalas.Location = new System.Drawing.Point(486, 22);
            this.btnFiltrarSalas.Name = "btnFiltrarSalas";
            this.btnFiltrarSalas.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrarSalas.TabIndex = 4;
            this.btnFiltrarSalas.Text = "Pesquisar";
            this.btnFiltrarSalas.UseVisualStyleBackColor = true;
            this.btnFiltrarSalas.Click += new System.EventHandler(this.btnFiltrarSalas_Click);
            // 
            // btnLimparFiltrosSalas
            // 
            this.btnLimparFiltrosSalas.Location = new System.Drawing.Point(588, 23);
            this.btnLimparFiltrosSalas.Name = "btnLimparFiltrosSalas";
            this.btnLimparFiltrosSalas.Size = new System.Drawing.Size(75, 23);
            this.btnLimparFiltrosSalas.TabIndex = 5;
            this.btnLimparFiltrosSalas.Text = "Limpar filtros";
            this.btnLimparFiltrosSalas.UseVisualStyleBackColor = true;
            this.btnLimparFiltrosSalas.Click += new System.EventHandler(this.btnLimparFiltrosSalas_Click);
            // 
            // btnEditarSalaSel
            // 
            this.btnEditarSalaSel.Location = new System.Drawing.Point(699, 21);
            this.btnEditarSalaSel.Name = "btnEditarSalaSel";
            this.btnEditarSalaSel.Size = new System.Drawing.Size(75, 23);
            this.btnEditarSalaSel.TabIndex = 6;
            this.btnEditarSalaSel.Text = "Editar sala";
            this.btnEditarSalaSel.UseVisualStyleBackColor = true;
            this.btnEditarSalaSel.Click += new System.EventHandler(this.btnEditarSalaSel_Click);
            // 
            // btnDesativarSalaSel
            // 
            this.btnDesativarSalaSel.Location = new System.Drawing.Point(799, 22);
            this.btnDesativarSalaSel.Name = "btnDesativarSalaSel";
            this.btnDesativarSalaSel.Size = new System.Drawing.Size(75, 23);
            this.btnDesativarSalaSel.TabIndex = 7;
            this.btnDesativarSalaSel.Text = "Desativar";
            this.btnDesativarSalaSel.UseVisualStyleBackColor = true;
            this.btnDesativarSalaSel.Click += new System.EventHandler(this.btnDesativarSalaSel_Click);
            // 
            // txtNovoNumeroLugares
            // 
            this.txtNovoNumeroLugares.Location = new System.Drawing.Point(232, 94);
            this.txtNovoNumeroLugares.Name = "txtNovoNumeroLugares";
            this.txtNovoNumeroLugares.Size = new System.Drawing.Size(121, 22);
            this.txtNovoNumeroLugares.TabIndex = 16;
            // 
            // txtNovaNomeSala
            // 
            this.txtNovaNomeSala.Location = new System.Drawing.Point(232, 51);
            this.txtNovaNomeSala.Name = "txtNovaNomeSala";
            this.txtNovaNomeSala.Size = new System.Drawing.Size(121, 22);
            this.txtNovaNomeSala.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Numero de lugares";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nome da sala";
            // 
            // txtNovaDescricaoSala
            // 
            this.txtNovaDescricaoSala.Location = new System.Drawing.Point(243, 207);
            this.txtNovaDescricaoSala.Name = "txtNovaDescricaoSala";
            this.txtNovaDescricaoSala.Size = new System.Drawing.Size(121, 22);
            this.txtNovaDescricaoSala.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Descrição Detalhada";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Tipo de Sala";
            // 
            // txtNovaLocalizacaoSala
            // 
            this.txtNovaLocalizacaoSala.Location = new System.Drawing.Point(243, 310);
            this.txtNovaLocalizacaoSala.Name = "txtNovaLocalizacaoSala";
            this.txtNovaLocalizacaoSala.Size = new System.Drawing.Size(121, 22);
            this.txtNovaLocalizacaoSala.TabIndex = 24;
            // 
            // txtNovoPrecoDiaAluguer
            // 
            this.txtNovoPrecoDiaAluguer.Location = new System.Drawing.Point(243, 267);
            this.txtNovoPrecoDiaAluguer.Name = "txtNovoPrecoDiaAluguer";
            this.txtNovoPrecoDiaAluguer.Size = new System.Drawing.Size(121, 22);
            this.txtNovoPrecoDiaAluguer.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Localização Detalhada";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Preço Por Dia Aluguer";
            // 
            // cmbNovoTipoSala
            // 
            this.cmbNovoTipoSala.FormattingEnabled = true;
            this.cmbNovoTipoSala.Location = new System.Drawing.Point(217, 158);
            this.cmbNovoTipoSala.Name = "cmbNovoTipoSala";
            this.cmbNovoTipoSala.Size = new System.Drawing.Size(121, 24);
            this.cmbNovoTipoSala.TabIndex = 25;
            // 
            // cmbNovoStatusSala
            // 
            this.cmbNovoStatusSala.FormattingEnabled = true;
            this.cmbNovoStatusSala.Location = new System.Drawing.Point(217, 366);
            this.cmbNovoStatusSala.Name = "cmbNovoStatusSala";
            this.cmbNovoStatusSala.Size = new System.Drawing.Size(121, 24);
            this.cmbNovoStatusSala.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 375);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "Status da Sala";
            // 
            // chkNovaAlugavelPorCliente
            // 
            this.chkNovaAlugavelPorCliente.AutoSize = true;
            this.chkNovaAlugavelPorCliente.Location = new System.Drawing.Point(114, 417);
            this.chkNovaAlugavelPorCliente.Name = "chkNovaAlugavelPorCliente";
            this.chkNovaAlugavelPorCliente.Size = new System.Drawing.Size(223, 20);
            this.chkNovaAlugavelPorCliente.TabIndex = 28;
            this.chkNovaAlugavelPorCliente.Text = "Alugável por Clientes Individuais";
            this.chkNovaAlugavelPorCliente.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarNovaSala
            // 
            this.btnAdicionarNovaSala.Location = new System.Drawing.Point(511, 135);
            this.btnAdicionarNovaSala.Name = "btnAdicionarNovaSala";
            this.btnAdicionarNovaSala.Size = new System.Drawing.Size(111, 37);
            this.btnAdicionarNovaSala.TabIndex = 29;
            this.btnAdicionarNovaSala.Text = "Adicionar";
            this.btnAdicionarNovaSala.UseVisualStyleBackColor = true;
            this.btnAdicionarNovaSala.Click += new System.EventHandler(this.btnAdicionarNovaSala_Click);
            // 
            // lblMensagemAdicionarSala
            // 
            this.lblMensagemAdicionarSala.AutoSize = true;
            this.lblMensagemAdicionarSala.Location = new System.Drawing.Point(508, 235);
            this.lblMensagemAdicionarSala.Name = "lblMensagemAdicionarSala";
            this.lblMensagemAdicionarSala.Size = new System.Drawing.Size(0, 16);
            this.lblMensagemAdicionarSala.TabIndex = 30;
            // 
            // dgvAuditoriaSalas
            // 
            this.dgvAuditoriaSalas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditoriaSalas.Location = new System.Drawing.Point(0, 125);
            this.dgvAuditoriaSalas.Name = "dgvAuditoriaSalas";
            this.dgvAuditoriaSalas.ReadOnly = true;
            this.dgvAuditoriaSalas.RowHeadersWidth = 51;
            this.dgvAuditoriaSalas.RowTemplate.Height = 24;
            this.dgvAuditoriaSalas.Size = new System.Drawing.Size(1071, 486);
            this.dgvAuditoriaSalas.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Id sala afetada";
            // 
            // txtAuditoriaIdSalaFiltro
            // 
            this.txtAuditoriaIdSalaFiltro.Location = new System.Drawing.Point(143, 32);
            this.txtAuditoriaIdSalaFiltro.Name = "txtAuditoriaIdSalaFiltro";
            this.txtAuditoriaIdSalaFiltro.Size = new System.Drawing.Size(100, 22);
            this.txtAuditoriaIdSalaFiltro.TabIndex = 2;
            // 
            // txtAuditoriaIdFuncionarioFiltro
            // 
            this.txtAuditoriaIdFuncionarioFiltro.Location = new System.Drawing.Point(143, 83);
            this.txtAuditoriaIdFuncionarioFiltro.Name = "txtAuditoriaIdFuncionarioFiltro";
            this.txtAuditoriaIdFuncionarioFiltro.Size = new System.Drawing.Size(100, 22);
            this.txtAuditoriaIdFuncionarioFiltro.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(-3, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "Id funcionario executor";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(236, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "Tipode de ação";
            // 
            // cmbAuditoriaTipoAcaoFiltro
            // 
            this.cmbAuditoriaTipoAcaoFiltro.FormattingEnabled = true;
            this.cmbAuditoriaTipoAcaoFiltro.Location = new System.Drawing.Point(346, 51);
            this.cmbAuditoriaTipoAcaoFiltro.Name = "cmbAuditoriaTipoAcaoFiltro";
            this.cmbAuditoriaTipoAcaoFiltro.Size = new System.Drawing.Size(121, 24);
            this.cmbAuditoriaTipoAcaoFiltro.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(523, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 8;
            this.label11.Text = "Data fim";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(523, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 16);
            this.label12.TabIndex = 7;
            this.label12.Text = "Data inicio";
            // 
            // dtpAuditoriaDataInicioFiltro
            // 
            this.dtpAuditoriaDataInicioFiltro.Checked = false;
            this.dtpAuditoriaDataInicioFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAuditoriaDataInicioFiltro.Location = new System.Drawing.Point(608, 26);
            this.dtpAuditoriaDataInicioFiltro.Name = "dtpAuditoriaDataInicioFiltro";
            this.dtpAuditoriaDataInicioFiltro.ShowCheckBox = true;
            this.dtpAuditoriaDataInicioFiltro.Size = new System.Drawing.Size(200, 22);
            this.dtpAuditoriaDataInicioFiltro.TabIndex = 9;
            // 
            // dtpAuditoriaDataFimFiltro
            // 
            this.dtpAuditoriaDataFimFiltro.Checked = false;
            this.dtpAuditoriaDataFimFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAuditoriaDataFimFiltro.Location = new System.Drawing.Point(608, 74);
            this.dtpAuditoriaDataFimFiltro.Name = "dtpAuditoriaDataFimFiltro";
            this.dtpAuditoriaDataFimFiltro.ShowCheckBox = true;
            this.dtpAuditoriaDataFimFiltro.Size = new System.Drawing.Size(200, 22);
            this.dtpAuditoriaDataFimFiltro.TabIndex = 10;
            // 
            // btnFiltrarAuditoriaSalas
            // 
            this.btnFiltrarAuditoriaSalas.Location = new System.Drawing.Point(863, 15);
            this.btnFiltrarAuditoriaSalas.Name = "btnFiltrarAuditoriaSalas";
            this.btnFiltrarAuditoriaSalas.Size = new System.Drawing.Size(133, 49);
            this.btnFiltrarAuditoriaSalas.TabIndex = 11;
            this.btnFiltrarAuditoriaSalas.Text = "Filtrar";
            this.btnFiltrarAuditoriaSalas.UseVisualStyleBackColor = true;
            this.btnFiltrarAuditoriaSalas.Click += new System.EventHandler(this.btnFiltrarAuditoriaSalas_Click);
            // 
            // btnLimparFiltrosAuditoriaSalas
            // 
            this.btnLimparFiltrosAuditoriaSalas.Location = new System.Drawing.Point(863, 70);
            this.btnLimparFiltrosAuditoriaSalas.Name = "btnLimparFiltrosAuditoriaSalas";
            this.btnLimparFiltrosAuditoriaSalas.Size = new System.Drawing.Size(133, 49);
            this.btnLimparFiltrosAuditoriaSalas.TabIndex = 12;
            this.btnLimparFiltrosAuditoriaSalas.Text = "Limpar filtros";
            this.btnLimparFiltrosAuditoriaSalas.UseVisualStyleBackColor = true;
            this.btnLimparFiltrosAuditoriaSalas.Click += new System.EventHandler(this.btnLimparFiltrosAuditoriaSalas_Click);
            // 
            // FormGerirSalas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 753);
            this.Controls.Add(this.TabControl);
            this.Name = "FormGerirSalas";
            this.Text = "FormGerirSalas";
            this.Load += new System.EventHandler(this.FormGerirSalas_Load);
            this.TabControl.ResumeLayout(false);
            this.tabControlSalas.ResumeLayout(false);
            this.tabControlSalas.PerformLayout();
            this.tabPageAdicionarSala.ResumeLayout(false);
            this.tabPageAdicionarSala.PerformLayout();
            this.tabPageAuditoriaSalas.ResumeLayout(false);
            this.tabPageAuditoriaSalas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoriaSalas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabControlSalas;
        private System.Windows.Forms.TabPage tabPageAdicionarSala;
        private System.Windows.Forms.TabPage tabPageAuditoriaSalas;
        private System.Windows.Forms.Button btnEditarSalaSel;
        private System.Windows.Forms.Button btnLimparFiltrosSalas;
        private System.Windows.Forms.Button btnFiltrarSalas;
        private System.Windows.Forms.ComboBox cmbFiltroStatusSala;
        private System.Windows.Forms.ComboBox cmbFiltroTipoSala;
        private System.Windows.Forms.TextBox txtFiltroNomeSala;
        private System.Windows.Forms.DataGridView dgvSalas;
        private System.Windows.Forms.Button btnDesativarSalaSel;
        private System.Windows.Forms.TextBox txtNovaLocalizacaoSala;
        private System.Windows.Forms.TextBox txtNovoPrecoDiaAluguer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNovaDescricaoSala;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNovoNumeroLugares;
        private System.Windows.Forms.TextBox txtNovaNomeSala;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbNovoTipoSala;
        private System.Windows.Forms.Label lblMensagemAdicionarSala;
        private System.Windows.Forms.Button btnAdicionarNovaSala;
        private System.Windows.Forms.CheckBox chkNovaAlugavelPorCliente;
        private System.Windows.Forms.ComboBox cmbNovoStatusSala;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvAuditoriaSalas;
        private System.Windows.Forms.Button btnLimparFiltrosAuditoriaSalas;
        private System.Windows.Forms.Button btnFiltrarAuditoriaSalas;
        private System.Windows.Forms.DateTimePicker dtpAuditoriaDataFimFiltro;
        private System.Windows.Forms.DateTimePicker dtpAuditoriaDataInicioFiltro;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbAuditoriaTipoAcaoFiltro;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAuditoriaIdFuncionarioFiltro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAuditoriaIdSalaFiltro;
        private System.Windows.Forms.Label label8;
    }
}
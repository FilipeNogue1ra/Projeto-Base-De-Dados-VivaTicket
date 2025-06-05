namespace Projeto_Base_De_Dados_VivaTicket
{
    partial class FormGerirEspetaculos
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
            this.tabControlEspetaculos = new System.Windows.Forms.TabControl();
            this.tabPageListarEspetaculos = new System.Windows.Forms.TabPage();
            this.btnCancelarEspetaculoSel = new System.Windows.Forms.Button();
            this.btnEditarEspetaculoSel = new System.Windows.Forms.Button();
            this.dgvEspetaculos = new System.Windows.Forms.DataGridView();
            this.btnLimparFiltrosEspetaculos = new System.Windows.Forms.Button();
            this.btnFiltrarEspetaculos = new System.Windows.Forms.Button();
            this.cmbFiltroSala = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFiltroTipoEspetaculo = new System.Windows.Forms.ComboBox();
            this.txtFiltroNomeEspetaculo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNovoNomeEspetaculo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numNovaDuracao = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpNovaDataHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpNovaDataHoraFim = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbNovaSala = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbNovaReservaEmpresa = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNovoPrecoBilhete = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNovaImagemURL = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbNovoStatusEspetaculo = new System.Windows.Forms.ComboBox();
            this.btnAdicionarNovoEspetaculo = new System.Windows.Forms.Button();
            this.lblMensagemAdicionarEspetaculo = new System.Windows.Forms.Label();
            this.tabPageAdicionarEspetaculo = new System.Windows.Forms.TabPage();
            this.txtNovaDescricaoEspetaculo = new System.Windows.Forms.TextBox();
            this.cmbNovoTipoEspetaculo = new System.Windows.Forms.ComboBox();
            this.tabControlEspetaculos.SuspendLayout();
            this.tabPageListarEspetaculos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspetaculos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNovaDuracao)).BeginInit();
            this.tabPageAdicionarEspetaculo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEspetaculos
            // 
            this.tabControlEspetaculos.Controls.Add(this.tabPageListarEspetaculos);
            this.tabControlEspetaculos.Controls.Add(this.tabPageAdicionarEspetaculo);
            this.tabControlEspetaculos.Controls.Add(this.tabPage3);
            this.tabControlEspetaculos.Controls.Add(this.tabPage4);
            this.tabControlEspetaculos.Location = new System.Drawing.Point(3, 101);
            this.tabControlEspetaculos.Name = "tabControlEspetaculos";
            this.tabControlEspetaculos.SelectedIndex = 0;
            this.tabControlEspetaculos.Size = new System.Drawing.Size(1077, 654);
            this.tabControlEspetaculos.TabIndex = 0;
            // 
            // tabPageListarEspetaculos
            // 
            this.tabPageListarEspetaculos.Controls.Add(this.btnCancelarEspetaculoSel);
            this.tabPageListarEspetaculos.Controls.Add(this.btnEditarEspetaculoSel);
            this.tabPageListarEspetaculos.Controls.Add(this.dgvEspetaculos);
            this.tabPageListarEspetaculos.Controls.Add(this.btnLimparFiltrosEspetaculos);
            this.tabPageListarEspetaculos.Controls.Add(this.btnFiltrarEspetaculos);
            this.tabPageListarEspetaculos.Controls.Add(this.cmbFiltroSala);
            this.tabPageListarEspetaculos.Controls.Add(this.label3);
            this.tabPageListarEspetaculos.Controls.Add(this.cmbFiltroTipoEspetaculo);
            this.tabPageListarEspetaculos.Controls.Add(this.txtFiltroNomeEspetaculo);
            this.tabPageListarEspetaculos.Controls.Add(this.label2);
            this.tabPageListarEspetaculos.Controls.Add(this.label1);
            this.tabPageListarEspetaculos.Location = new System.Drawing.Point(4, 25);
            this.tabPageListarEspetaculos.Name = "tabPageListarEspetaculos";
            this.tabPageListarEspetaculos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListarEspetaculos.Size = new System.Drawing.Size(1069, 625);
            this.tabPageListarEspetaculos.TabIndex = 0;
            this.tabPageListarEspetaculos.Text = "Ver/Listar Espetáculos";
            this.tabPageListarEspetaculos.UseVisualStyleBackColor = true;
            this.tabPageListarEspetaculos.Click += new System.EventHandler(this.tabPageListarEspetaculos_Click);
            // 
            // btnCancelarEspetaculoSel
            // 
            this.btnCancelarEspetaculoSel.Location = new System.Drawing.Point(750, 67);
            this.btnCancelarEspetaculoSel.Name = "btnCancelarEspetaculoSel";
            this.btnCancelarEspetaculoSel.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarEspetaculoSel.TabIndex = 10;
            this.btnCancelarEspetaculoSel.Text = "Cancelar";
            this.btnCancelarEspetaculoSel.UseVisualStyleBackColor = true;
            this.btnCancelarEspetaculoSel.Click += new System.EventHandler(this.btnCancelarEspetaculoSel_Click);
            // 
            // btnEditarEspetaculoSel
            // 
            this.btnEditarEspetaculoSel.Location = new System.Drawing.Point(579, 67);
            this.btnEditarEspetaculoSel.Name = "btnEditarEspetaculoSel";
            this.btnEditarEspetaculoSel.Size = new System.Drawing.Size(75, 23);
            this.btnEditarEspetaculoSel.TabIndex = 9;
            this.btnEditarEspetaculoSel.Text = "Editar";
            this.btnEditarEspetaculoSel.UseVisualStyleBackColor = true;
            this.btnEditarEspetaculoSel.Click += new System.EventHandler(this.btnEditarEspetaculoSel_Click);
            // 
            // dgvEspetaculos
            // 
            this.dgvEspetaculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspetaculos.Location = new System.Drawing.Point(0, 181);
            this.dgvEspetaculos.Name = "dgvEspetaculos";
            this.dgvEspetaculos.ReadOnly = true;
            this.dgvEspetaculos.RowHeadersWidth = 51;
            this.dgvEspetaculos.RowTemplate.Height = 24;
            this.dgvEspetaculos.Size = new System.Drawing.Size(1069, 444);
            this.dgvEspetaculos.TabIndex = 8;
            // 
            // btnLimparFiltrosEspetaculos
            // 
            this.btnLimparFiltrosEspetaculos.Location = new System.Drawing.Point(386, 85);
            this.btnLimparFiltrosEspetaculos.Name = "btnLimparFiltrosEspetaculos";
            this.btnLimparFiltrosEspetaculos.Size = new System.Drawing.Size(75, 23);
            this.btnLimparFiltrosEspetaculos.TabIndex = 7;
            this.btnLimparFiltrosEspetaculos.Text = "Limpar Filtros";
            this.btnLimparFiltrosEspetaculos.UseVisualStyleBackColor = true;
            this.btnLimparFiltrosEspetaculos.Click += new System.EventHandler(this.btnLimparFiltrosEspetaculos_Click);
            // 
            // btnFiltrarEspetaculos
            // 
            this.btnFiltrarEspetaculos.Location = new System.Drawing.Point(386, 38);
            this.btnFiltrarEspetaculos.Name = "btnFiltrarEspetaculos";
            this.btnFiltrarEspetaculos.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrarEspetaculos.TabIndex = 6;
            this.btnFiltrarEspetaculos.Text = "Pesquisar";
            this.btnFiltrarEspetaculos.UseVisualStyleBackColor = true;
            this.btnFiltrarEspetaculos.Click += new System.EventHandler(this.btnFiltrarEspetaculos_Click);
            // 
            // cmbFiltroSala
            // 
            this.cmbFiltroSala.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFiltroSala.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFiltroSala.FormattingEnabled = true;
            this.cmbFiltroSala.Location = new System.Drawing.Point(223, 126);
            this.cmbFiltroSala.Name = "cmbFiltroSala";
            this.cmbFiltroSala.Size = new System.Drawing.Size(121, 24);
            this.cmbFiltroSala.TabIndex = 5;
            this.cmbFiltroSala.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sala";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cmbFiltroTipoEspetaculo
            // 
            this.cmbFiltroTipoEspetaculo.FormattingEnabled = true;
            this.cmbFiltroTipoEspetaculo.Location = new System.Drawing.Point(223, 84);
            this.cmbFiltroTipoEspetaculo.Name = "cmbFiltroTipoEspetaculo";
            this.cmbFiltroTipoEspetaculo.Size = new System.Drawing.Size(121, 24);
            this.cmbFiltroTipoEspetaculo.TabIndex = 3;
            // 
            // txtFiltroNomeEspetaculo
            // 
            this.txtFiltroNomeEspetaculo.Location = new System.Drawing.Point(223, 35);
            this.txtFiltroNomeEspetaculo.Name = "txtFiltroNomeEspetaculo";
            this.txtFiltroNomeEspetaculo.Size = new System.Drawing.Size(121, 22);
            this.txtFiltroNomeEspetaculo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo espetaculo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome Espetaculo";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1069, 625);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1069, 625);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Nome";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Descriçao";
            // 
            // txtNovoNomeEspetaculo
            // 
            this.txtNovoNomeEspetaculo.Location = new System.Drawing.Point(251, 47);
            this.txtNovoNomeEspetaculo.Name = "txtNovoNomeEspetaculo";
            this.txtNovoNomeEspetaculo.Size = new System.Drawing.Size(121, 22);
            this.txtNovoNomeEspetaculo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "tipo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(457, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Nome";
            // 
            // numNovaDuracao
            // 
            this.numNovaDuracao.Location = new System.Drawing.Point(541, 53);
            this.numNovaDuracao.Name = "numNovaDuracao";
            this.numNovaDuracao.Size = new System.Drawing.Size(120, 22);
            this.numNovaDuracao.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(457, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Nome";
            // 
            // dtpNovaDataHoraInicio
            // 
            this.dtpNovaDataHoraInicio.Location = new System.Drawing.Point(541, 96);
            this.dtpNovaDataHoraInicio.Name = "dtpNovaDataHoraInicio";
            this.dtpNovaDataHoraInicio.Size = new System.Drawing.Size(200, 22);
            this.dtpNovaDataHoraInicio.TabIndex = 16;
            // 
            // dtpNovaDataHoraFim
            // 
            this.dtpNovaDataHoraFim.Location = new System.Drawing.Point(541, 156);
            this.dtpNovaDataHoraFim.Name = "dtpNovaDataHoraFim";
            this.dtpNovaDataHoraFim.Size = new System.Drawing.Size(200, 22);
            this.dtpNovaDataHoraFim.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(457, 156);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Nome";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(127, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Sala";
            // 
            // cmbNovaSala
            // 
            this.cmbNovaSala.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbNovaSala.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNovaSala.FormattingEnabled = true;
            this.cmbNovaSala.Location = new System.Drawing.Point(245, 190);
            this.cmbNovaSala.Name = "cmbNovaSala";
            this.cmbNovaSala.Size = new System.Drawing.Size(121, 24);
            this.cmbNovaSala.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(127, 253);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "Empre Ass";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // cmbNovaReservaEmpresa
            // 
            this.cmbNovaReservaEmpresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbNovaReservaEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNovaReservaEmpresa.FormattingEnabled = true;
            this.cmbNovaReservaEmpresa.Location = new System.Drawing.Point(245, 245);
            this.cmbNovaReservaEmpresa.Name = "cmbNovaReservaEmpresa";
            this.cmbNovaReservaEmpresa.Size = new System.Drawing.Size(121, 24);
            this.cmbNovaReservaEmpresa.TabIndex = 22;
            this.cmbNovaReservaEmpresa.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(94, 319);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "Preço base bilhete";
            // 
            // txtNovoPrecoBilhete
            // 
            this.txtNovoPrecoBilhete.Location = new System.Drawing.Point(251, 316);
            this.txtNovoPrecoBilhete.Name = "txtNovoPrecoBilhete";
            this.txtNovoPrecoBilhete.Size = new System.Drawing.Size(121, 22);
            this.txtNovoPrecoBilhete.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(94, 383);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 16);
            this.label13.TabIndex = 25;
            this.label13.Text = "Cartaz";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // txtNovaImagemURL
            // 
            this.txtNovaImagemURL.Location = new System.Drawing.Point(251, 377);
            this.txtNovaImagemURL.Name = "txtNovaImagemURL";
            this.txtNovaImagemURL.Size = new System.Drawing.Size(121, 22);
            this.txtNovaImagemURL.TabIndex = 26;
            this.txtNovaImagemURL.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(96, 432);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 16);
            this.label14.TabIndex = 27;
            this.label14.Text = "Status";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // cmbNovoStatusEspetaculo
            // 
            this.cmbNovoStatusEspetaculo.FormattingEnabled = true;
            this.cmbNovoStatusEspetaculo.Location = new System.Drawing.Point(214, 424);
            this.cmbNovoStatusEspetaculo.Name = "cmbNovoStatusEspetaculo";
            this.cmbNovoStatusEspetaculo.Size = new System.Drawing.Size(121, 24);
            this.cmbNovoStatusEspetaculo.TabIndex = 28;
            this.cmbNovoStatusEspetaculo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_2);
            // 
            // btnAdicionarNovoEspetaculo
            // 
            this.btnAdicionarNovoEspetaculo.Location = new System.Drawing.Point(460, 253);
            this.btnAdicionarNovoEspetaculo.Name = "btnAdicionarNovoEspetaculo";
            this.btnAdicionarNovoEspetaculo.Size = new System.Drawing.Size(142, 66);
            this.btnAdicionarNovoEspetaculo.TabIndex = 29;
            this.btnAdicionarNovoEspetaculo.Text = "Adicionar";
            this.btnAdicionarNovoEspetaculo.UseVisualStyleBackColor = true;
            this.btnAdicionarNovoEspetaculo.Click += new System.EventHandler(this.btnAdicionarNovoEspetaculo_Click);
            // 
            // lblMensagemAdicionarEspetaculo
            // 
            this.lblMensagemAdicionarEspetaculo.AutoSize = true;
            this.lblMensagemAdicionarEspetaculo.Location = new System.Drawing.Point(579, 383);
            this.lblMensagemAdicionarEspetaculo.Name = "lblMensagemAdicionarEspetaculo";
            this.lblMensagemAdicionarEspetaculo.Size = new System.Drawing.Size(0, 16);
            this.lblMensagemAdicionarEspetaculo.TabIndex = 30;
            // 
            // tabPageAdicionarEspetaculo
            // 
            this.tabPageAdicionarEspetaculo.Controls.Add(this.cmbNovoTipoEspetaculo);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.lblMensagemAdicionarEspetaculo);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.btnAdicionarNovoEspetaculo);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.cmbNovoStatusEspetaculo);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.label14);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.txtNovaImagemURL);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.label13);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.txtNovoPrecoBilhete);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.label12);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.cmbNovaReservaEmpresa);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.label11);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.cmbNovaSala);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.label10);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.label9);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.dtpNovaDataHoraFim);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.dtpNovaDataHoraInicio);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.label8);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.numNovaDuracao);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.label7);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.txtNovaDescricaoEspetaculo);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.label4);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.txtNovoNomeEspetaculo);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.label5);
            this.tabPageAdicionarEspetaculo.Controls.Add(this.label6);
            this.tabPageAdicionarEspetaculo.Location = new System.Drawing.Point(4, 25);
            this.tabPageAdicionarEspetaculo.Name = "tabPageAdicionarEspetaculo";
            this.tabPageAdicionarEspetaculo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdicionarEspetaculo.Size = new System.Drawing.Size(1069, 625);
            this.tabPageAdicionarEspetaculo.TabIndex = 1;
            this.tabPageAdicionarEspetaculo.Text = "Adicionar espetaculo";
            this.tabPageAdicionarEspetaculo.UseVisualStyleBackColor = true;
            this.tabPageAdicionarEspetaculo.Click += new System.EventHandler(this.tabPageAdicionarEspetaculo_Click);
            // 
            // txtNovaDescricaoEspetaculo
            // 
            this.txtNovaDescricaoEspetaculo.Location = new System.Drawing.Point(251, 90);
            this.txtNovaDescricaoEspetaculo.Name = "txtNovaDescricaoEspetaculo";
            this.txtNovaDescricaoEspetaculo.Size = new System.Drawing.Size(121, 22);
            this.txtNovaDescricaoEspetaculo.TabIndex = 12;
            // 
            // cmbNovoTipoEspetaculo
            // 
            this.cmbNovoTipoEspetaculo.AllowDrop = true;
            this.cmbNovoTipoEspetaculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNovoTipoEspetaculo.FormattingEnabled = true;
            this.cmbNovoTipoEspetaculo.Location = new System.Drawing.Point(245, 138);
            this.cmbNovoTipoEspetaculo.Name = "cmbNovoTipoEspetaculo";
            this.cmbNovoTipoEspetaculo.Size = new System.Drawing.Size(121, 24);
            this.cmbNovoTipoEspetaculo.TabIndex = 31;
            // 
            // FormGerirEspetaculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 753);
            this.Controls.Add(this.tabControlEspetaculos);
            this.Name = "FormGerirEspetaculos";
            this.Text = "FormGerirEspetaculos";
            this.tabControlEspetaculos.ResumeLayout(false);
            this.tabPageListarEspetaculos.ResumeLayout(false);
            this.tabPageListarEspetaculos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspetaculos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNovaDuracao)).EndInit();
            this.tabPageAdicionarEspetaculo.ResumeLayout(false);
            this.tabPageAdicionarEspetaculo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlEspetaculos;
        private System.Windows.Forms.TabPage tabPageListarEspetaculos;
        private System.Windows.Forms.ComboBox cmbFiltroTipoEspetaculo;
        private System.Windows.Forms.TextBox txtFiltroNomeEspetaculo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox cmbFiltroSala;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvEspetaculos;
        private System.Windows.Forms.Button btnLimparFiltrosEspetaculos;
        private System.Windows.Forms.Button btnFiltrarEspetaculos;
        private System.Windows.Forms.Button btnCancelarEspetaculoSel;
        private System.Windows.Forms.Button btnEditarEspetaculoSel;
        private System.Windows.Forms.TabPage tabPageAdicionarEspetaculo;
        private System.Windows.Forms.ComboBox cmbNovoTipoEspetaculo;
        private System.Windows.Forms.Label lblMensagemAdicionarEspetaculo;
        private System.Windows.Forms.Button btnAdicionarNovoEspetaculo;
        private System.Windows.Forms.ComboBox cmbNovoStatusEspetaculo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNovaImagemURL;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtNovoPrecoBilhete;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbNovaReservaEmpresa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbNovaSala;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpNovaDataHoraFim;
        private System.Windows.Forms.DateTimePicker dtpNovaDataHoraInicio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numNovaDuracao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNovaDescricaoEspetaculo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNovoNomeEspetaculo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
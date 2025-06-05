using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projeto_Base_De_Dados_VivaTicket
{
    public partial class FormGerirSalas : Form
    {
        private string connectionString = "Server=mednat.ieeta.pt\\SQLSERVER,8101;Database=p6g2;User ID=p6g2;Password=Andre.Filipe;";
        private int _idFuncionarioLogado;

        // Classe auxiliar para ComboBoxes
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString() => Text;
        }

        public FormGerirSalas(int idFuncionario)
        {
            InitializeComponent();
            _idFuncionarioLogado = idFuncionario;
            SessaoSistema.IdFuncionarioLogado = idFuncionario;
            this.Text = $"Gerir Salas (Funcionário ID: {_idFuncionarioLogado})";
        }

        public FormGerirSalas()
        {
            InitializeComponent();
            if (SessaoSistema.IdFuncionarioLogado > 0)
            {
                _idFuncionarioLogado = SessaoSistema.IdFuncionarioLogado;
            }
            else if (System.Diagnostics.Debugger.IsAttached && _idFuncionarioLogado == 0)
            {
                _idFuncionarioLogado = 1;
                MessageBox.Show($"AVISO DE DESENVOLVIMENTO:\n_idFuncionarioLogado foi definido para TESTE como: {_idFuncionarioLogado}\nEste valor deve vir do login na versão final.", "Aviso de Teste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Text = $"Gerir Salas (Funcionário ID: {_idFuncionarioLogado})";
        }

        private void FormGerirSalas_Load(object sender, EventArgs e)
        {
            CarregarComboBoxes();
            CarregarComboBoxAuditoriaTipoAcao();
            // Carrega dados da tab ativa
            if (TabControl != null && TabControl.SelectedTab != null)
            {
                if (TabControl.SelectedTab == tabControlSalas)
                {
                    CarregarSalasNaGrelha();
                }
                else if (TabControl.SelectedTab == tabPageAdicionarSala)
                {
                    LimparCamposAdicionarSala();
                }
                else if (TabControl.SelectedTab == tabPageAuditoriaSalas)
                {
                    CarregarAuditoriaSalas();
                }
            }
            else if (dgvSalas != null)
            {
                CarregarSalasNaGrelha();
            }
        }

        private void CarregarComboBoxes()
        {
            string[] tiposSala = { "Auditório", "Estúdio de Ensaio", "Sala de Aula", "Sala de Conferência", "Anfiteatro Pequeno", "Outro" };
            PopulateGenericComboBox(cmbFiltroTipoSala, tiposSala, "Todos os Tipos");
            PopulateGenericComboBox(cmbNovoTipoSala, tiposSala, null);

            string[] statusSala = { "Disponível", "Confirmada/Ocupada", "Pendente Confirmação", "Em Manutenção", "Inativa", "Em Desuso" };
            PopulateGenericComboBox(cmbFiltroStatusSala, statusSala, "Todos os Status");
            PopulateGenericComboBox(cmbNovoStatusSala, statusSala, null);
            if (cmbNovoStatusSala != null && cmbNovoStatusSala.Items.Count > 0) cmbNovoStatusSala.SelectedItem = "Disponível";
        }

        private void PopulateGenericComboBox(ComboBox comboBox, string[] items, string todosOptionText)
        {
            if (comboBox == null) return;
            object previousSelection = comboBox.SelectedItem;
            comboBox.Items.Clear();
            if (!string.IsNullOrEmpty(todosOptionText))
            {
                comboBox.Items.Add(todosOptionText);
            }
            foreach (string item in items)
            {
                comboBox.Items.Add(item);
            }
            if (previousSelection != null && comboBox.Items.Contains(previousSelection))
            {
                comboBox.SelectedItem = previousSelection;
            }
            else if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        // --- ABA AUDITORIA SALAS ---
        private void CarregarComboBoxAuditoriaTipoAcao()
        {
            if (cmbAuditoriaTipoAcaoFiltro != null)
            {
                cmbAuditoriaTipoAcaoFiltro.Items.Clear();
                cmbAuditoriaTipoAcaoFiltro.Items.Add("Todos"); // valor padrão
                cmbAuditoriaTipoAcaoFiltro.Items.Add("Inserção");
                cmbAuditoriaTipoAcaoFiltro.Items.Add("Edição");
                cmbAuditoriaTipoAcaoFiltro.Items.Add("Desativação");
                cmbAuditoriaTipoAcaoFiltro.Items.Add("Outro");
                cmbAuditoriaTipoAcaoFiltro.SelectedIndex = 0;
            }
        }

        private void CarregarAuditoriaSalas()
        {
            DataTable dtAuditoria = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ListarAuditoriaSalas", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Adiciona filtros se existirem
                        cmd.Parameters.AddWithValue("@IdSalaAfetada", string.IsNullOrWhiteSpace(txtAuditoriaIdSalaFiltro?.Text) ? (object)DBNull.Value : txtAuditoriaIdSalaFiltro.Text.Trim());
                        cmd.Parameters.AddWithValue("@IdFuncionario", string.IsNullOrWhiteSpace(txtAuditoriaIdFuncionarioFiltro?.Text) ? (object)DBNull.Value : txtAuditoriaIdFuncionarioFiltro.Text.Trim());

                        string tipoAcaoSel = cmbAuditoriaTipoAcaoFiltro?.SelectedItem?.ToString();
                        cmd.Parameters.AddWithValue("@TipoAcao", (tipoAcaoSel == "Todos" || string.IsNullOrEmpty(tipoAcaoSel)) ? (object)DBNull.Value : tipoAcaoSel);

                        if (dtpAuditoriaDataInicioFiltro != null && dtpAuditoriaDataInicioFiltro.Checked)
                            cmd.Parameters.AddWithValue("@DataInicio", dtpAuditoriaDataInicioFiltro.Value.Date);
                        else
                            cmd.Parameters.AddWithValue("@DataInicio", DBNull.Value);

                        if (dtpAuditoriaDataFimFiltro != null && dtpAuditoriaDataFimFiltro.Checked)
                            cmd.Parameters.AddWithValue("@DataFim", dtpAuditoriaDataFimFiltro.Value.Date);
                        else
                            cmd.Parameters.AddWithValue("@DataFim", DBNull.Value);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtAuditoria);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar auditoria: " + ex.Message, "Erro BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (dgvAuditoriaSalas != null)
            {
                dgvAuditoriaSalas.DataSource = dtAuditoria;
                // Configuração de colunas (adaptar aos nomes reais das colunas do resultado da SP)
                if (dgvAuditoriaSalas.Columns.Contains("IdSalaAfetada")) dgvAuditoriaSalas.Columns["IdSalaAfetada"].HeaderText = "ID Sala";
                if (dgvAuditoriaSalas.Columns.Contains("IdFuncionario")) dgvAuditoriaSalas.Columns["IdFuncionario"].HeaderText = "ID Funcionário";
                if (dgvAuditoriaSalas.Columns.Contains("TipoAcao")) dgvAuditoriaSalas.Columns["TipoAcao"].HeaderText = "Tipo de Ação";
                if (dgvAuditoriaSalas.Columns.Contains("DataAcao")) dgvAuditoriaSalas.Columns["DataAcao"].HeaderText = "Data";
                if (dgvAuditoriaSalas.Columns.Contains("DescricaoAcao")) dgvAuditoriaSalas.Columns["DescricaoAcao"].HeaderText = "Descrição";
                // Ajustar mais colunas conforme necessário
            }
        }

        private void btnFiltrarAuditoriaSalas_Click(object sender, EventArgs e)
        {
            CarregarAuditoriaSalas();
        }

        private void btnLimparFiltrosAuditoriaSalas_Click(object sender, EventArgs e)
        {
            if (txtAuditoriaIdSalaFiltro != null) txtAuditoriaIdSalaFiltro.Text = "";
            if (txtAuditoriaIdFuncionarioFiltro != null) txtAuditoriaIdFuncionarioFiltro.Text = "";
            if (cmbAuditoriaTipoAcaoFiltro != null && cmbAuditoriaTipoAcaoFiltro.Items.Count > 0) cmbAuditoriaTipoAcaoFiltro.SelectedIndex = 0;
            if (dtpAuditoriaDataInicioFiltro != null) { dtpAuditoriaDataInicioFiltro.Value = DateTime.Now; dtpAuditoriaDataInicioFiltro.Checked = false; }
            if (dtpAuditoriaDataFimFiltro != null) { dtpAuditoriaDataFimFiltro.Value = DateTime.Now; dtpAuditoriaDataFimFiltro.Checked = false; }
            CarregarAuditoriaSalas();
        }

        // --- OUTRAS ABAS (deixar igual ao teu código anterior) ---
        private void CarregarSalasNaGrelha(string nomeSalaFiltro = null, string tipoSalaFiltro = null, string statusSalaFiltro = null)
        {
            DataTable dtSalas = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ListarSalas", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NomeSalaFiltro", string.IsNullOrWhiteSpace(nomeSalaFiltro) ? (object)DBNull.Value : nomeSalaFiltro);
                        cmd.Parameters.AddWithValue("@TipoSalaFiltro", (tipoSalaFiltro == "Todos os Tipos" || string.IsNullOrWhiteSpace(tipoSalaFiltro)) ? (object)DBNull.Value : tipoSalaFiltro);
                        cmd.Parameters.AddWithValue("@StatusSalaFiltro", (statusSalaFiltro == "Todos os Status" || string.IsNullOrWhiteSpace(statusSalaFiltro)) ? (object)DBNull.Value : statusSalaFiltro);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtSalas);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar salas: " + ex.Message, "Erro BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (dgvSalas != null)
            {
                dgvSalas.DataSource = dtSalas;
                if (dgvSalas.Columns.Contains("idSala")) dgvSalas.Columns["idSala"].HeaderText = "ID";
                if (dgvSalas.Columns.Contains("NomeSala")) dgvSalas.Columns["NomeSala"].Width = 150;
                if (dgvSalas.Columns.Contains("TipoSala")) dgvSalas.Columns["TipoSala"].Width = 120;
                if (dgvSalas.Columns.Contains("NumeroDeLugares")) dgvSalas.Columns["NumeroDeLugares"].HeaderText = "Lugares";
                if (dgvSalas.Columns.Contains("PrecoPorDiaAluguer")) dgvSalas.Columns["PrecoPorDiaAluguer"].HeaderText = "Preço/Dia";
                if (dgvSalas.Columns.Contains("StatusSala")) dgvSalas.Columns["StatusSala"].HeaderText = "Status";
                if (dgvSalas.Columns.Contains("AlugavelPorCliente")) dgvSalas.Columns["AlugavelPorCliente"].HeaderText = "Alug. Cliente?";
                if (dgvSalas.Columns.Contains("DescricaoDetalhadaSala")) dgvSalas.Columns["DescricaoDetalhadaSala"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnFiltrarSalas_Click(object sender, EventArgs e)
        {
            string nome = txtFiltroNomeSala?.Text.Trim();
            string tipo = cmbFiltroTipoSala?.SelectedItem?.ToString();
            string status = cmbFiltroStatusSala?.SelectedItem?.ToString();
            CarregarSalasNaGrelha(nome, tipo, status);
        }

        private void btnLimparFiltrosSalas_Click(object sender, EventArgs e)
        {
            if (txtFiltroNomeSala != null) txtFiltroNomeSala.Text = "";
            if (cmbFiltroTipoSala != null && cmbFiltroTipoSala.Items.Count > 0) cmbFiltroTipoSala.SelectedIndex = 0;
            if (cmbFiltroStatusSala != null && cmbFiltroStatusSala.Items.Count > 0) cmbFiltroStatusSala.SelectedIndex = 0;
            CarregarSalasNaGrelha();
        }

        private void btnAdicionarNovaSala_Click(object sender, EventArgs e)
        {
            if (txtNovaNomeSala == null || txtNovoNumeroLugares == null || cmbNovoTipoSala == null ||
                txtNovoPrecoDiaAluguer == null || cmbNovoStatusSala == null || chkNovaAlugavelPorCliente == null)
            {
                MessageBox.Show("Controlos do formulário de adicionar sala não foram inicializados. Verifique o designer.", "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nomeSala = txtNovaNomeSala.Text.Trim();
            string tipoSala = cmbNovoTipoSala.SelectedItem?.ToString();
            string statusSala = cmbNovoStatusSala.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(nomeSala) ||
                string.IsNullOrWhiteSpace(txtNovoNumeroLugares.Text) ||
                string.IsNullOrEmpty(tipoSala) ||
                string.IsNullOrWhiteSpace(txtNovoPrecoDiaAluguer.Text) ||
                string.IsNullOrEmpty(statusSala))
            {
                MessageBox.Show("Campos Nome da Sala, Nº Lugares, Tipo de Sala, Preço/Dia e Status são obrigatórios.", "Dados em Falta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtNovoNumeroLugares.Text, out int numLugares) || numLugares < 0)
            {
                MessageBox.Show("Número de lugares inválido.", "Input Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txtNovoPrecoDiaAluguer.Text, out decimal precoDia) || precoDia < 0)
            {
                MessageBox.Show("Preço por dia inválido.", "Input Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_idFuncionarioLogado <= 0)
            {
                MessageBox.Show("Não foi possível identificar o funcionário executor. Ação cancelada.", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool alugavelCliente = chkNovaAlugavelPorCliente.Checked;
            string descricao = string.IsNullOrWhiteSpace(txtNovaDescricaoSala?.Text) ? null : txtNovaDescricaoSala.Text.Trim();
            string localizacao = string.IsNullOrWhiteSpace(txtNovaLocalizacaoSala?.Text) ? null : txtNovaLocalizacaoSala.Text.Trim();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_AdicionarSala", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NomeSala", nomeSala);
                        cmd.Parameters.AddWithValue("@NumeroDeLugares", numLugares);
                        cmd.Parameters.AddWithValue("@TipoSala", tipoSala);
                        cmd.Parameters.AddWithValue("@AlugavelPorCliente", alugavelCliente);
                        cmd.Parameters.AddWithValue("@DescricaoDetalhadaSala", (object)descricao ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@PrecoPorDiaAluguer", precoDia);
                        cmd.Parameters.AddWithValue("@LocalizacaoDetalhada", (object)localizacao ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@StatusSala", statusSala);
                        cmd.Parameters.AddWithValue("@idFuncionarioExecutor", _idFuncionarioLogado);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idGerada = Convert.ToInt32(reader["idSalaGerada"]);
                                string msg = reader["Mensagem"].ToString();
                                if (idGerada > 0)
                                {
                                    MessageBox.Show(msg, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LimparCamposAdicionarSala();
                                    CarregarSalasNaGrelha();
                                    if (TabControl != null && TabControl.TabPages.Contains(tabControlSalas))
                                        TabControl.SelectedTab = tabControlSalas;
                                }
                                else
                                {
                                    MessageBox.Show(msg, "Erro ao Adicionar Sala", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar sala: " + ex.Message, "Erro BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimparCamposAdicionarSala()
        {
            if (txtNovaNomeSala != null) txtNovaNomeSala.Clear();
            if (txtNovoNumeroLugares != null) txtNovoNumeroLugares.Clear();
            if (cmbNovoTipoSala != null && cmbNovoTipoSala.Items.Count > 0) cmbNovoTipoSala.SelectedIndex = 0;
            if (chkNovaAlugavelPorCliente != null) chkNovaAlugavelPorCliente.Checked = false;
            if (txtNovaDescricaoSala != null) txtNovaDescricaoSala.Clear();
            if (txtNovoPrecoDiaAluguer != null) txtNovoPrecoDiaAluguer.Clear();
            if (txtNovaLocalizacaoSala != null) txtNovaLocalizacaoSala.Clear();
            if (cmbNovoStatusSala != null && cmbNovoStatusSala.Items.Count > 0) cmbNovoStatusSala.SelectedItem = "Disponível";
            if (lblMensagemAdicionarSala != null) lblMensagemAdicionarSala.Text = "";
        }

        // --- RESTANTE LÓGICA IGUAL AO TEU CÓDIGO ANTERIOR ---
        // (editar sala, desativar sala, mudança de abas, etc.)

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl != null && TabControl.SelectedTab != null)
            {
                if (TabControl.SelectedTab == tabControlSalas)
                {
                    CarregarSalasNaGrelha();
                }
                else if (TabControl.SelectedTab == tabPageAdicionarSala)
                {
                    LimparCamposAdicionarSala();
                }
                else if (TabControl.SelectedTab == tabPageAuditoriaSalas)
                {
                    CarregarAuditoriaSalas();
                }
            }
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
            // Evento não implementado, pode deixar vazio ou remover do designer se não usar
        }

        private void tabPageAuditoriaSalas_Click(object sender, EventArgs e)
        {
            // Evento não implementado, pode deixar vazio ou remover do designer se não usar
        }

        private void btnEditarSalaSel_Click(object sender, EventArgs e)
        {
            // Implementa a lógica de editar sala aqui
            MessageBox.Show("Função de editar sala chamada!");
        }

        private void btnDesativarSalaSel_Click(object sender, EventArgs e)
        {
            // Implementa a lógica de desativar sala aqui
            MessageBox.Show("Função de desativar sala chamada!");
        }
    }
}
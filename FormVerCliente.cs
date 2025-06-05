using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
// Se voltares a usar hashing, vais precisar de:
// using System.Security.Cryptography;
// using System.Text;

namespace Projeto_Base_De_Dados_VivaTicket
{
    public partial class FormVerCliente : Form // O nome da tua classe é FormVerCliente
    {
        private string connectionString = "Server=mednat.ieeta.pt\\SQLSERVER,8101;Database=p6g2;User ID=p6g2;Password=Andre.Filipe;";
        private int _idFuncionarioLogadoAtual;

        // Construtor padrão
        public FormVerCliente()
        {
            InitializeComponent();
            InicializarDadosFuncionario(); // Tenta obter o ID do funcionário
            // Carrega dados na aba que estiver selecionada ao iniciar
            CarregarDadosDaAbaSelecionada();
            PopularComboBoxAuditoria();
        }

        // Construtor para receber o ID do funcionário logado
        public FormVerCliente(int idFuncionarioLogado)
        {
            InitializeComponent();
            _idFuncionarioLogadoAtual = idFuncionarioLogado;
            SessaoSistema.IdFuncionarioLogado = idFuncionarioLogado; // Atualiza a sessão global
            this.Text = $"Gestão de Clientes (Funcionário ID: {_idFuncionarioLogadoAtual})";
            // Carrega dados na aba que estiver selecionada ao iniciar
            CarregarDadosDaAbaSelecionada();
            PopularComboBoxAuditoria();
        }

        private void InicializarDadosFuncionario()
        {
            if (SessaoSistema.IdFuncionarioLogado > 0)
            {
                _idFuncionarioLogadoAtual = SessaoSistema.IdFuncionarioLogado;
            }
            else if (System.Diagnostics.Debugger.IsAttached && _idFuncionarioLogadoAtual == 0)
            {
                _idFuncionarioLogadoAtual = 1; // EXEMPLO PARA TESTE - ESCOLHE UM ID VÁLIDO DA TUA BD VT_Funcionarios!
                MessageBox.Show($"AVISO DE DESENVOLVIMENTO:\n_idFuncionarioLogadoAtual foi definido para TESTE como: {_idFuncionarioLogadoAtual}\nEste valor deve vir do login na versão final.", "Aviso de Teste", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PopularComboBoxAuditoria()
        {
            if (cmbAuditoriaTipoAcao != null)
            {
                cmbAuditoriaTipoAcao.Items.Clear();
                cmbAuditoriaTipoAcao.Items.Add("Todos");
                cmbAuditoriaTipoAcao.Items.Add("Cliente Adicionado");
                cmbAuditoriaTipoAcao.Items.Add("Cliente Removido");
                cmbAuditoriaTipoAcao.Items.Add("Cliente Editado");
                if (cmbAuditoriaTipoAcao.Items.Count > 0) cmbAuditoriaTipoAcao.SelectedIndex = 0;
            }
        }

        private void CarregarDadosDaAbaSelecionada()
        {
            if (tabControl1 != null && tabControl1.SelectedTab != null)
            {
                // Assume que as TabPages têm NOMES definidos no designer
                // Ex: tabPageVerClientes, tabPageAdicionarCliente, tabPageEditarCliente, tabPageAuditoria
                if (tabControl1.SelectedTab.Name == "tabPageVerClientes")
                {
                    CarregarClientesNaGrelhaPrincipal();
                }
                else if (tabControl1.SelectedTab.Name == "tabPageEditarCliente")
                {
                    CarregarClientesParaEdicao();
                }
                else if (tabControl1.SelectedTab.Name == "tabPageAuditoria")
                {
                    CarregarAuditoriaClientes();
                }
            }
            else
            {
                CarregarClientesNaGrelhaPrincipal(); // Fallback se não houver TabControl ou aba selecionada
            }
        }


        // --- MÉTODO PARA CARREGAR DADOS NA GRELHA DA ABA "VER CLIENTES" (dgvClientes) ---
        private void CarregarClientesNaGrelhaPrincipal(string termoPesquisa = null)
        {
            DataTable dtClientes = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ListarClientes", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TermoPesquisa", string.IsNullOrWhiteSpace(termoPesquisa) ? (object)DBNull.Value : termoPesquisa);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtClientes);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar clientes (aba principal): " + ex.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Certifica-te que o DataGridView da tua PRIMEIRA aba se chama dgvClientes
            if (dgvClientes != null)
            {
                dgvClientes.DataSource = dtClientes;
                // Configurações de coluna dgvClientes
                if (dgvClientes.Columns.Contains("idCliente")) dgvClientes.Columns["idCliente"].HeaderText = "ID";
                if (dgvClientes.Columns.Contains("Nome")) dgvClientes.Columns["Nome"].Width = 180;
                if (dgvClientes.Columns.Contains("Email")) dgvClientes.Columns["Email"].Width = 220;
                if (dgvClientes.Columns.Contains("NIF")) dgvClientes.Columns["NIF"].Width = 80;
                if (dgvClientes.Columns.Contains("Telefone")) dgvClientes.Columns["Telefone"].Width = 100;
                if (dgvClientes.Columns.Contains("Endereco")) dgvClientes.Columns["Endereco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (dgvClientes.Columns.Contains("DataRegisto"))
                {
                    dgvClientes.Columns["DataRegisto"].HeaderText = "Data de Registo";
                    dgvClientes.Columns["DataRegisto"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvClientes.Columns["DataRegisto"].Width = 120;
                }
            }
        }

        // --- MÉTODO PARA CARREGAR DADOS NA GRELHA DA ABA "EDITAR CLIENTES" (dgvClientesParaEdicao) ---
        private void CarregarClientesParaEdicao(string termoPesquisa = null)
        {
            DataTable dtClientesEdicao = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ListarClientes", conn)) // Reutiliza a SP
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TermoPesquisa", string.IsNullOrWhiteSpace(termoPesquisa) ? (object)DBNull.Value : termoPesquisa);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtClientesEdicao);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar clientes para edição: " + ex.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Certifica-te que o DataGridView da tua TERCEIRA aba ("Editar Clientes") se chama dgvClientesParaEdicao
            if (dgvClientesParaEdicao != null)
            {
                dgvClientesParaEdicao.DataSource = dtClientesEdicao;
                // Configurações de coluna dgvClientesParaEdicao
                if (dgvClientesParaEdicao.Columns.Contains("idCliente")) dgvClientesParaEdicao.Columns["idCliente"].HeaderText = "ID";
                if (dgvClientesParaEdicao.Columns.Contains("Nome")) dgvClientesParaEdicao.Columns["Nome"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (dgvClientesParaEdicao.Columns.Contains("Email")) dgvClientesParaEdicao.Columns["Email"].Width = 200;
                if (dgvClientesParaEdicao.Columns.Contains("NIF")) dgvClientesParaEdicao.Columns["NIF"].Width = 80;
            }
        }

        private void FormVerCliente_Load(object sender, EventArgs e)
        {
            // O método CarregarDadosDaAbaSelecionada() já é chamado nos construtores.
            // A população do ComboBox também foi movida para lá.
            // Se quiseres garantir que a primeira aba é sempre carregada ao iniciar,
            // podes chamar CarregarClientesNaGrelhaPrincipal() aqui explicitamente,
            // mas a lógica no construtor e no SelectedIndexChanged deve cobrir.
            CarregarDadosDaAbaSelecionada(); // Garante que a aba ativa é carregada
        }

        // --- Eventos para a Aba "VER CLIENTES" ---
        private void btnBuscaGeralClientes_Click(object sender, EventArgs e)
        {
            // Certifica-te que o TextBox se chama txtBuscaGeralClientes
            if (txtBuscaGeralClientes != null) CarregarClientesNaGrelhaPrincipal(txtBuscaGeralClientes.Text.Trim());
        }

        private void btnLimparBuscaClientes_Click(object sender, EventArgs e)
        {
            if (txtBuscaGeralClientes != null) txtBuscaGeralClientes.Text = "";
            CarregarClientesNaGrelhaPrincipal();
        }

        // --- Eventos para a Aba "ADICIONAR CLIENTES" (Anteriormente "Add/Remover cliente") ---
        private void btnAdicionarNovoCliente_Click(object sender, EventArgs e)
        {
            // Certifica-te que os TextBoxes se chamam txtNovoNomeCliente, etc.
            string nome = txtNovoNomeCliente.Text.Trim();
            string email = txtNovoEmailCliente.Text.Trim();
            string passwordTextoSimples = txtNovoPasswordCliente.Text;
            string nif = string.IsNullOrWhiteSpace(txtNovoNIFCliente.Text) ? null : txtNovoNIFCliente.Text.Trim();
            string telefone = string.IsNullOrWhiteSpace(txtNovoTelefoneCliente.Text) ? null : txtNovoTelefoneCliente.Text.Trim();
            string endereco = string.IsNullOrWhiteSpace(txtNovoEnderecoCliente.Text) ? null : txtNovoEnderecoCliente.Text.Trim();

            if (lblMensagemAdicionar != null) lblMensagemAdicionar.Text = "";

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(passwordTextoSimples))
            {
                MessageBox.Show("Os campos Nome, Email e Password são obrigatórios.", "Dados em Falta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (lblMensagemAdicionar != null) lblMensagemAdicionar.Text = "Nome, Email e Password são obrigatórios.";
                return;
            }

            if (_idFuncionarioLogadoAtual <= 0)
            {
                MessageBox.Show("Não foi possível identificar o funcionário executor. Ação cancelada.", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_AdicionarCliente", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PasswordTextoSimples", passwordTextoSimples);
                        cmd.Parameters.AddWithValue("@NIF", (object)nif ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Telefone", (object)telefone ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Endereco", (object)endereco ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@idFuncionarioExecutor", _idFuncionarioLogadoAtual);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idClienteGerado = Convert.ToInt32(reader["idClienteGerado"]);
                                string mensagem = reader["Mensagem"].ToString();
                                if (idClienteGerado > 0)
                                {
                                    MessageBox.Show(mensagem + "\nID: " + idClienteGerado, "Cliente Adicionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (lblMensagemAdicionar != null) lblMensagemAdicionar.Text = mensagem;
                                    txtNovoNomeCliente.Clear(); txtNovoEmailCliente.Clear(); txtNovoPasswordCliente.Clear();
                                    txtNovoNIFCliente.Clear(); txtNovoTelefoneCliente.Clear(); txtNovoEnderecoCliente.Clear();
                                    CarregarClientesNaGrelhaPrincipal();
                                    CarregarClientesParaEdicao();
                                    CarregarAuditoriaClientes();
                                }
                                else
                                {
                                    MessageBox.Show(mensagem, "Erro ao Adicionar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    if (lblMensagemAdicionar != null) lblMensagemAdicionar.Text = mensagem;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar cliente: " + ex.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- BOTÃO REMOVER CLIENTE (Pode estar na Aba "Ver Clientes" ou "Add/Remover") ---
        private void btnRemoverClienteSelecionado_Click(object sender, EventArgs e)
        {
            // Este botão deve operar sobre a dgvClientes (da aba "Ver Clientes")
            if (dgvClientes == null || (dgvClientes.SelectedRows.Count == 0 && dgvClientes.CurrentRow == null))
            {
                MessageBox.Show("Selecione um cliente na lista da aba 'Ver Clientes' para remover.", "Nenhum Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int idClienteParaRemover = -1; string nomeClienteParaRemover = "";
            DataGridViewRow linhaSelecionada = dgvClientes.SelectedRows.Count > 0 ? dgvClientes.SelectedRows[0] : dgvClientes.CurrentRow;

            if (linhaSelecionada != null && linhaSelecionada.Cells["idCliente"]?.Value != null && linhaSelecionada.Cells["Nome"]?.Value != null)
            {
                idClienteParaRemover = Convert.ToInt32(linhaSelecionada.Cells["idCliente"].Value);
                nomeClienteParaRemover = linhaSelecionada.Cells["Nome"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Não foi possível obter dados do cliente selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_idFuncionarioLogadoAtual <= 0)
            {
                MessageBox.Show("Não foi possível identificar o funcionário executor. Ação cancelada.", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmacao = MessageBox.Show($"Remover '{nomeClienteParaRemover}' (ID: {idClienteParaRemover})?", "Confirmar Remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacao == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_RemoverCliente", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idCliente", idClienteParaRemover);
                            cmd.Parameters.AddWithValue("@idFuncionarioExecutor", _idFuncionarioLogadoAtual);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    bool sucesso = Convert.ToBoolean(reader["Sucesso"]);
                                    string mensagem = reader["Mensagem"].ToString();
                                    if (sucesso)
                                    {
                                        MessageBox.Show(mensagem, "Cliente Removido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        CarregarClientesNaGrelhaPrincipal();
                                        CarregarClientesParaEdicao();
                                        CarregarAuditoriaClientes();
                                    }
                                    else
                                    {
                                        MessageBox.Show(mensagem, "Erro ao Remover", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao remover cliente: " + ex.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // --- MÉTODOS PARA A ABA "EDITAR CLIENTES" (Tab3) ---
        // Evento Click do Botão "Pesquisar" na aba de Edição
        // Certifica-te que o botão no designer se chama btnPesquisarEditarCliente
        private void btnPesquisarEditarCliente_Click(object sender, EventArgs e)
        {
            // Assume que o TextBox de pesquisa na aba de edição se chama txtPesquisaEditarCliente
            if (txtPesquisaEditarCliente != null) CarregarClientesParaEdicao(txtPesquisaEditarCliente.Text.Trim());
        }

        // Evento Click do Botão "Limpar Pesquisa" na aba de Edição
        // Certifica-te que o botão no designer se chama btnLimparPesquisaEditarCliente
        private void btnLimparPesquisaEditarCliente_Click(object sender, EventArgs e)
        {
            if (txtPesquisaEditarCliente != null) txtPesquisaEditarCliente.Text = "";
            CarregarClientesParaEdicao(); // Carrega todos na grelha de edição
        }

        // Evento Click do botão "Editar Cliente Selecionado" (o que está na aba de edição)
        // Certifica-te que o nome do botão no designer é, por exemplo, btnAbrirPopupEdicaoDaAbaEditar
        private void btnAbrirPopupEdicaoDaAbaEditar_Click(object sender, EventArgs e)
        {
            // Agora usa dgvClientesParaEdicao
            if (dgvClientesParaEdicao == null || dgvClientesParaEdicao.CurrentRow == null || dgvClientesParaEdicao.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Por favor, selecione um cliente na lista acima para editar.", "Nenhum Cliente Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_idFuncionarioLogadoAtual <= 0)
            {
                MessageBox.Show("Não foi possível identificar o funcionário executor. Ação cancelada.", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataRowView drv = (DataRowView)dgvClientesParaEdicao.CurrentRow.DataBoundItem;
                int idCliente = Convert.ToInt32(drv["idCliente"]);
                string nome = drv["Nome"].ToString();
                string email = drv["Email"].ToString();
                string nif = drv["NIF"]?.ToString();
                string telefone = drv["Telefone"]?.ToString();
                string endereco = drv["Endereco"]?.ToString();

                // Passamos uma string vazia para passwordAtual, pois o pop-up não a mostrará
                // e a SP sp_EditarCliente (versão ajustada) saberá não alterar a password se receber NULL ou "" para nova password.
                using (FormEditarClientePopUp frmEditarPopUp = new FormEditarClientePopUp(idCliente, nome, email, "", nif, telefone, endereco, _idFuncionarioLogadoAtual))
                {
                    DialogResult resultado = frmEditarPopUp.ShowDialog(this);

                    if (resultado == DialogResult.OK && frmEditarPopUp.EdicaoBemSucedida)
                    {
                        CarregarClientesNaGrelhaPrincipal();
                        CarregarClientesParaEdicao();
                        CarregarAuditoriaClientes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preparar dados para edição: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- MÉTODOS PARA A ABA "REGISTO DE ALTERAÇÕES" (Tab4) ---
        private void CarregarAuditoriaClientes(int? idClienteFiltro = null, int? idFuncionarioFiltro = null, string tipoAcaoFiltro = null, DateTime? dataInicioFiltro = null, DateTime? dataFimFiltro = null)
        {
            DataTable dtAuditoria = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ListarAuditoriaClientes", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idClienteAfetado", idClienteFiltro.HasValue ? (object)idClienteFiltro.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@idFuncionarioExecutor", idFuncionarioFiltro.HasValue ? (object)idFuncionarioFiltro.Value : DBNull.Value);
                        if (tipoAcaoFiltro == "Todos" || string.IsNullOrWhiteSpace(tipoAcaoFiltro))
                            cmd.Parameters.AddWithValue("@TipoAcao", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@TipoAcao", tipoAcaoFiltro);
                        cmd.Parameters.AddWithValue("@DataInicio", dataInicioFiltro.HasValue ? (object)dataInicioFiltro.Value.Date : DBNull.Value);
                        cmd.Parameters.AddWithValue("@DataFim", dataFimFiltro.HasValue ? (object)dataFimFiltro.Value.Date : DBNull.Value);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtAuditoria);
                    }
                }
                catch (Exception ex) { MessageBox.Show("Erro ao carregar auditoria: " + ex.Message, "Erro BD", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            if (dgvAuditoriaClientes != null)
            { // Certifica-te que este é o DataGridView da tua aba de auditoria
                dgvAuditoriaClientes.DataSource = dtAuditoria;
                // Configurações de coluna para dgvAuditoriaClientes...
                if (dgvAuditoriaClientes.Columns.Contains("idAuditoria")) dgvAuditoriaClientes.Columns["idAuditoria"].HeaderText = "ID Audit.";
                if (dgvAuditoriaClientes.Columns.Contains("DataHoraAcao"))
                {
                    dgvAuditoriaClientes.Columns["DataHoraAcao"].HeaderText = "Data/Hora";
                    dgvAuditoriaClientes.Columns["DataHoraAcao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                    dgvAuditoriaClientes.Columns["DataHoraAcao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                if (dgvAuditoriaClientes.Columns.Contains("TipoAcao")) dgvAuditoriaClientes.Columns["TipoAcao"].HeaderText = "Ação";
                if (dgvAuditoriaClientes.Columns.Contains("NomeFuncionarioExecutor")) dgvAuditoriaClientes.Columns["NomeFuncionarioExecutor"].HeaderText = "Funcionário";
                if (dgvAuditoriaClientes.Columns.Contains("idClienteAfetado")) dgvAuditoriaClientes.Columns["idClienteAfetado"].HeaderText = "ID Cliente";
                if (dgvAuditoriaClientes.Columns.Contains("NomeClienteAfetado")) dgvAuditoriaClientes.Columns["NomeClienteAfetado"].HeaderText = "Nome Cliente";
                if (dgvAuditoriaClientes.Columns.Contains("DetalhesAntigos"))
                {
                    dgvAuditoriaClientes.Columns["DetalhesAntigos"].HeaderText = "Detalhes Antigos";
                    dgvAuditoriaClientes.Columns["DetalhesAntigos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                if (dgvAuditoriaClientes.Columns.Contains("DetalhesNovos"))
                {
                    dgvAuditoriaClientes.Columns["DetalhesNovos"].HeaderText = "Detalhes Novos";
                    dgvAuditoriaClientes.Columns["DetalhesNovos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void btnFiltrarAuditoria_Click(object sender, EventArgs e)
        {
            int? idCliente = null;
            // Certifica-te que o TextBox se chama txtAuditoriaIdCliente
            if (txtAuditoriaIdCliente != null && !string.IsNullOrWhiteSpace(txtAuditoriaIdCliente.Text) && int.TryParse(txtAuditoriaIdCliente.Text, out int parsedIdCliente))
                idCliente = parsedIdCliente;

            int? idFunc = null;
            // Certifica-te que o TextBox se chama txtAuditoriaIdFuncionario
            if (txtAuditoriaIdFuncionario != null && !string.IsNullOrWhiteSpace(txtAuditoriaIdFuncionario.Text) && int.TryParse(txtAuditoriaIdFuncionario.Text, out int parsedIdFunc))
                idFunc = parsedIdFunc;

            // Certifica-te que o ComboBox se chama cmbAuditoriaTipoAcao
            string tipoAcao = cmbAuditoriaTipoAcao?.SelectedItem?.ToString();
            if (cmbAuditoriaTipoAcao != null && (cmbAuditoriaTipoAcao.SelectedIndex == 0 || tipoAcao == "Todos")) tipoAcao = null;

            // Certifica-te que os DateTimePickers se chamam dtpAuditoriaDataInicio e dtpAuditoriaDataFim
            DateTime? dataInicio = (dtpAuditoriaDataInicio != null && dtpAuditoriaDataInicio.Checked) ? (DateTime?)dtpAuditoriaDataInicio.Value.Date : null;
            DateTime? dataFim = (dtpAuditoriaDataFim != null && dtpAuditoriaDataFim.Checked) ? (DateTime?)dtpAuditoriaDataFim.Value.Date : null;

            CarregarAuditoriaClientes(idCliente, idFunc, tipoAcao, dataInicio, dataFim);
        }

        private void btnLimparFiltrosAuditoria_Click(object sender, EventArgs e)
        {
            if (txtAuditoriaIdCliente != null) txtAuditoriaIdCliente.Clear();
            if (txtAuditoriaIdFuncionario != null) txtAuditoriaIdFuncionario.Clear();
            if (cmbAuditoriaTipoAcao != null && cmbAuditoriaTipoAcao.Items.Count > 0) cmbAuditoriaTipoAcao.SelectedIndex = 0;
            if (dtpAuditoriaDataInicio != null) dtpAuditoriaDataInicio.Checked = false;
            if (dtpAuditoriaDataFim != null) dtpAuditoriaDataFim.Checked = false;
            CarregarAuditoriaClientes();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Certifica-te que tabControl1 e os NOMES das TabPages (tabPageVerClientes, tabPageEditarCliente, tabPageAuditoria) estão corretos
            if (this.Controls.ContainsKey("tabControl1"))
            {
                TabControl tc = this.Controls["tabControl1"] as TabControl;
                if (tc != null && tc.SelectedTab != null)
                {
                    if (tc.SelectedTab.Name == "tabPageVerClientes")
                    {
                        CarregarClientesNaGrelhaPrincipal();
                    }
                    else if (tc.SelectedTab.Name == "tabPageEditarCliente")
                    {
                        CarregarClientesParaEdicao();
                    }
                    else if (tc.SelectedTab.Name == "tabPageAuditoria")
                    {
                        CarregarAuditoriaClientes();
                    }
                }
            }
        }

        // --- MÉTODOS VAZIOS QUE JÁ TINHAS (PODEM SER REMOVIDOS SE NÃO ESTIVEREM LIGADOS A EVENTOS NO DESIGNER) ---
        private void label1_Click(object sender, EventArgs e) { /* Vazio */ }
        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e) { /* Vazio */ }
        private void txtBuscaGeralClientes_TextChanged(object sender, EventArgs e) { /* Vazio */ }
        private void button1_Click_1(object sender, EventArgs e) { /* Vazio */ }
        private void tabPage2_Click(object sender, EventArgs e) { /* Vazio */ }
        private void label2_Click(object sender, EventArgs e) { /* Vazio */ }
        private void textBox5_TextChanged(object sender, EventArgs e) { /* Vazio */ }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            // Vazio: apenas para evitar erro de referência no designer
        }
        private void tabPage3_Click(object sender, EventArgs e)
        {
            // Vazio: apenas para evitar erro de referência no designer
        }
        private void tabPage4_Click(object sender, EventArgs e)
        {
            // Vazio: apenas para evitar erro de referência no designer
        }
    }
}

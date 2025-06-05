using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic; // Para Interaction.InputBox (usado em btnCancelarEspetaculoSel_Click)
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics; // Adicionado explicitamente para Debug.WriteLine

namespace Projeto_Base_De_Dados_VivaTicket
{
    public partial class FormGerirEspetaculos : Form
    {
        private string connectionString = "Server=mednat.ieeta.pt\\SQLSERVER,8101;Database=p6g2;User ID=p6g2;Password=Andre.Filipe;";
        private int _idFuncionarioLogado;

        public FormGerirEspetaculos(int idFuncionario)
        {
            try
            {
                Debug.WriteLine("DEBUG: Construtor FormGerirEspetaculos - Antes de InitializeComponent()");
                InitializeComponent(); // Esta deve ser a primeira chamada no construtor.
                Debug.WriteLine("DEBUG: Construtor FormGerirEspetaculos - Depois de InitializeComponent()");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERRO CRÍTICO em InitializeComponent(): {ex.ToString()}");
                MessageBox.Show($"Erro crítico ao inicializar os componentes do formulário: {ex.Message}\n\nVerifique o ficheiro Designer.cs ou os logs de depuração.", "Erro de Inicialização", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Considerar fechar a aplicação ou o formulário se InitializeComponent falhar
                this.Load += (s, e) => this.Close(); // Adia o fecho para depois da construção completa
                return;
            }

            _idFuncionarioLogado = idFuncionario;
            SessaoSistema.IdFuncionarioLogado = idFuncionario;
            this.Text = $"Gerir Espetáculos (Funcionário ID: {_idFuncionarioLogado})";
            Debug.WriteLine($"DEBUG: FormGerirEspetaculos instanciado para Funcionário ID: {idFuncionario}");
        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString() => Text;
        }

        private void FormGerirEspetaculos_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("DEBUG: FormGerirEspetaculos_Load iniciado.");

            // Verificações cruciais de nulidade dos controlos
            if (!VerificarControlosCriticos()) return;

            PopularComboBoxTipo();
            PopularComboBoxSala();
            PopularComboBoxEmpresa();
            PopularComboBoxStatus();
            PopularComboBoxFiltroSala();
            CarregarEspetaculosNaGrelha();
            PopularComboBoxFiltroTipo();
            Debug.WriteLine("DEBUG: FormGerirEspetaculos_Load concluído.");
        }

        private bool VerificarControlosCriticos()
        {
            Debug.WriteLine("DEBUG: VerificarControlosCriticos - Iniciando.");
            string erroMsg = string.Empty;

            if (this.cmbNovoTipoEspetaculo == null) erroMsg += "cmbNovoTipoEspetaculo não foi inicializado.\n";
            if (this.cmbNovaSala == null) erroMsg += "cmbNovaSala não foi inicializado.\n";
            if (this.cmbNovaReservaEmpresa == null) erroMsg += "cmbNovaReservaEmpresa não foi inicializado.\n";
            if (this.cmbNovoStatusEspetaculo == null) erroMsg += "cmbNovoStatusEspetaculo não foi inicializado.\n";
            if (this.txtNovoNomeEspetaculo == null) erroMsg += "txtNovoNomeEspetaculo não foi inicializado.\n";
            // Adicione aqui outros controlos que são essenciais para o funcionamento do formulário
            // Ex: if (this.numNovaDuracao == null) erroMsg += "numNovaDuracao não foi inicializado.\n";


            if (!string.IsNullOrEmpty(erroMsg))
            {
                erroMsg = "ERRO CRÍTICO - Os seguintes controlos não foram inicializados:\n" + erroMsg +
                          "\nVerifique o ficheiro Designer.cs ou o nome dos controlos no formulário.";
                Debug.WriteLine($"ERRO CRÍTICO em VerificarControlosCriticos: {erroMsg.Replace("\n", " ")}");
                MessageBox.Show(erroMsg, "Erro de Controlo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            Debug.WriteLine("DEBUG: VerificarControlosCriticos - Todos os controlos verificados parecem estar OK.");
            return true;
        }


        private void PopularComboBoxTipo()
        {
            Debug.WriteLine("DEBUG: PopularComboBoxTipo - Iniciando preenchimento.");
            if (this.cmbNovoTipoEspetaculo == null)
            {
                Debug.WriteLine("ERRO GRAVE: cmbNovoTipoEspetaculo é NULL em PopularComboBoxTipo! Não é possível preencher.");
                return;
            }

            try
            {
                cmbNovoTipoEspetaculo.BeginUpdate(); // Otimização para adicionar múltiplos itens

                if (cmbNovoTipoEspetaculo.DataSource != null)
                {
                    Debug.WriteLine("DEBUG: PopularComboBoxTipo - Limpando DataSource existente.");
                    cmbNovoTipoEspetaculo.DataSource = null;
                }

                Debug.WriteLine($"DEBUG: PopularComboBoxTipo - Antes de Items.Clear(). Count atual: {cmbNovoTipoEspetaculo.Items.Count}");
                cmbNovoTipoEspetaculo.Items.Clear();
                Debug.WriteLine($"DEBUG: PopularComboBoxTipo - Depois de Items.Clear(). Count atual: {cmbNovoTipoEspetaculo.Items.Count}");

                cmbNovoTipoEspetaculo.DropDownStyle = ComboBoxStyle.DropDownList;

                var tipos = new List<string>
                {
                    "Concerto", "Teatro", "Dança", "Stand-up Comedy", "Workshop", "Cinema Especial", "Outro"
                };
                Debug.WriteLine($"DEBUG: PopularComboBoxTipo - Adicionando {tipos.Count} tipos.");

                foreach (var tipo in tipos)
                {
                    cmbNovoTipoEspetaculo.Items.Add(tipo);
                }
                Debug.WriteLine($"DEBUG: PopularComboBoxTipo - Depois de adicionar itens. Count atual: {cmbNovoTipoEspetaculo.Items.Count}");


                if (cmbNovoTipoEspetaculo.Items.Count > 0)
                {
                    cmbNovoTipoEspetaculo.SelectedIndex = 0;
                    Debug.WriteLine($"DEBUG: PopularComboBoxTipo - SelectedIndex definido para 0. Item selecionado: {cmbNovoTipoEspetaculo.SelectedItem}");
                }
                else
                {
                    Debug.WriteLine("ALERTA: cmbNovoTipoEspetaculo NÃO foi preenchido com itens!");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERRO em PopularComboBoxTipo: {ex.ToString()}");
                MessageBox.Show($"Ocorreu um erro ao preencher os tipos de espetáculo: {ex.Message}", "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (this.cmbNovoTipoEspetaculo != null) // Verifica novamente, caso tenha sido disposed por erro grave
                {
                    cmbNovoTipoEspetaculo.EndUpdate();
                }
                Debug.WriteLine($"DEBUG: PopularComboBoxTipo CONCLUÍDO - Items: {cmbNovoTipoEspetaculo?.Items.Count}, SelectedIndex: {cmbNovoTipoEspetaculo?.SelectedIndex}, SelectedItem: {(cmbNovoTipoEspetaculo?.SelectedItem?.ToString() ?? "null")}");
            }
        }

        private void PopularComboBoxSala()
        {
            Debug.WriteLine("DEBUG: PopularComboBoxSala - Iniciando preenchimento.");
            if (this.cmbNovaSala == null) { Debug.WriteLine("ERRO GRAVE: cmbNovaSala é NULL."); return; }

            try
            {
                cmbNovaSala.BeginUpdate();
                if (cmbNovaSala.DataSource != null) cmbNovaSala.DataSource = null;
                cmbNovaSala.Items.Clear();
                cmbNovaSala.DropDownStyle = ComboBoxStyle.DropDownList;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT idSala, NomeSala FROM VT_Salas ORDER BY NomeSala", conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbNovaSala.Items.Add(new ComboBoxItem
                            {
                                Text = dr["NomeSala"].ToString(),
                                Value = dr["idSala"]
                            });
                        }
                    }
                }
                if (cmbNovaSala.Items.Count > 0)
                    cmbNovaSala.SelectedIndex = 0;
                else
                    Debug.WriteLine("ALERTA: cmbNovaSala NÃO foi preenchido com itens da BD!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERRO em PopularComboBoxSala: {ex.ToString()}");
                MessageBox.Show($"Erro ao carregar salas: {ex.Message}", "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (this.cmbNovaSala != null) cmbNovaSala.EndUpdate();
                Debug.WriteLine($"DEBUG: PopularComboBoxSala CONCLUÍDO - Items: {cmbNovaSala?.Items.Count}, SelectedIndex: {cmbNovaSala?.SelectedIndex}");
            }
        }

        private void PopularComboBoxEmpresa()
        {
            Debug.WriteLine("DEBUG: PopularComboBoxEmpresa - Iniciando preenchimento.");
            if (this.cmbNovaReservaEmpresa == null) { Debug.WriteLine("ERRO GRAVE: cmbNovaReservaEmpresa é NULL."); return; }

            try
            {
                cmbNovaReservaEmpresa.BeginUpdate();
                if (cmbNovaReservaEmpresa.DataSource != null) cmbNovaReservaEmpresa.DataSource = null;
                cmbNovaReservaEmpresa.Items.Clear();
                cmbNovaReservaEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbNovaReservaEmpresa.Items.Add(new ComboBoxItem { Text = "(Nenhuma - Produção Interna)", Value = DBNull.Value });

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT idEmpresa, NomeEmpresa FROM VT_Empresas ORDER BY NomeEmpresa", conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbNovaReservaEmpresa.Items.Add(new ComboBoxItem
                            {
                                Text = dr["NomeEmpresa"].ToString(),
                                Value = dr["idEmpresa"]
                            });
                        }
                    }
                }
                if (cmbNovaReservaEmpresa.Items.Count > 0)
                    cmbNovaReservaEmpresa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERRO em PopularComboBoxEmpresa: {ex.ToString()}");
                MessageBox.Show($"Erro ao carregar empresas: {ex.Message}", "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (this.cmbNovaReservaEmpresa != null) cmbNovaReservaEmpresa.EndUpdate();
                Debug.WriteLine($"DEBUG: PopularComboBoxEmpresa CONCLUÍDO - Items: {cmbNovaReservaEmpresa?.Items.Count}, SelectedIndex: {cmbNovaReservaEmpresa?.SelectedIndex}");
            }
        }

        private void PopularComboBoxStatus()
        {
            Debug.WriteLine("DEBUG: PopularComboBoxStatus - Iniciando preenchimento.");
            if (this.cmbNovoStatusEspetaculo == null) { Debug.WriteLine("ERRO GRAVE: cmbNovoStatusEspetaculo é NULL."); return; }

            try
            {
                cmbNovoStatusEspetaculo.BeginUpdate();
                if (cmbNovoStatusEspetaculo.DataSource != null) cmbNovoStatusEspetaculo.DataSource = null;
                cmbNovoStatusEspetaculo.Items.Clear();
                cmbNovoStatusEspetaculo.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbNovoStatusEspetaculo.Items.AddRange(new object[]
                {
                    "Agendado", "Realizado", "Cancelado"
                });
                if (cmbNovoStatusEspetaculo.Items.Count > 0)
                    cmbNovoStatusEspetaculo.SelectedIndex = 0;
                else
                    Debug.WriteLine("ALERTA: cmbNovoStatusEspetaculo NÃO foi preenchido com itens!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERRO em PopularComboBoxStatus: {ex.ToString()}");
                MessageBox.Show($"Ocorreu um erro ao preencher os status: {ex.Message}", "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (this.cmbNovoStatusEspetaculo != null) cmbNovoStatusEspetaculo.EndUpdate();
                Debug.WriteLine($"DEBUG: PopularComboBoxStatus CONCLUÍDO - Items: {cmbNovoStatusEspetaculo?.Items.Count}, SelectedIndex: {cmbNovoStatusEspetaculo?.SelectedIndex}");
            }
        }

        private void CarregarEspetaculosNaGrelha(string nome = null, string tipo = null, object idSala = null)
        {
            Debug.WriteLine($"DEBUG: CarregarEspetaculosNaGrelha - Filtros: Nome='{nome}', Tipo='{tipo}', idSala='{idSala}'");
            DataTable dtEspetaculos = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ListarEspetaculos", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NomeEspetaculo", string.IsNullOrWhiteSpace(nome) ? (object)DBNull.Value : nome);
                        cmd.Parameters.AddWithValue("@TipoEspetaculo", (tipo == "Todos" || string.IsNullOrWhiteSpace(tipo)) ? (object)DBNull.Value : tipo);

                        object salaParamValue = DBNull.Value;
                        if (idSala != null && idSala != DBNull.Value)
                        {
                            if (int.TryParse(idSala.ToString(), out int parsedIdSala) && parsedIdSala != 0)
                            {
                                salaParamValue = parsedIdSala;
                            }
                        }
                        cmd.Parameters.AddWithValue("@idSala", salaParamValue);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtEspetaculos);
                    }
                }

                if (dgvEspetaculos != null)
                {
                    dgvEspetaculos.DataSource = dtEspetaculos;
                    if (dgvEspetaculos.Columns.Contains("idEspetaculo")) dgvEspetaculos.Columns["idEspetaculo"].HeaderText = "ID";
                    if (dgvEspetaculos.Columns.Contains("Nome")) dgvEspetaculos.Columns["Nome"].Width = 200;
                    // ... (restante da configuração de colunas)
                }
                Debug.WriteLine($"DEBUG: CarregarEspetaculosNaGrelha - {dtEspetaculos.Rows.Count} linhas carregadas.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERRO em CarregarEspetaculosNaGrelha: {ex.ToString()}");
                MessageBox.Show($"Erro ao carregar espetáculos: {ex.Message}", "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrarEspetaculos_Click(object sender, EventArgs e)
        {
            string nome = txtFiltroNomeEspetaculo?.Text.Trim();
            string tipo = cmbFiltroTipoEspetaculo?.SelectedItem?.ToString();
            object salaValue = (cmbFiltroSala?.SelectedItem as ComboBoxItem)?.Value;
            CarregarEspetaculosNaGrelha(nome, tipo, salaValue);
        }

        private void btnLimparFiltrosEspetaculos_Click(object sender, EventArgs e)
        {
            if (txtFiltroNomeEspetaculo != null) txtFiltroNomeEspetaculo.Text = "";
            if (cmbFiltroTipoEspetaculo != null && cmbFiltroTipoEspetaculo.Items.Count > 0) cmbFiltroTipoEspetaculo.SelectedIndex = 0;
            if (cmbFiltroSala != null && cmbFiltroSala.Items.Count > 0) cmbFiltroSala.SelectedIndex = 0;
            CarregarEspetaculosNaGrelha();
        }

        private void btnAdicionarNovoEspetaculo_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("DEBUG: btnAdicionarNovoEspetaculo_Click - Iniciando validações.");
            if (this.cmbNovoTipoEspetaculo == null) // Verificação adicional
            {
                Debug.WriteLine("ERRO GRAVE: cmbNovoTipoEspetaculo é NULL em btnAdicionarNovoEspetaculo_Click!");
                MessageBox.Show("Erro interno: Controlo de Tipo de Espetáculo não encontrado.", "Erro Crítico", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            Debug.WriteLine($"DEBUG: cmbNovoTipoEspetaculo no início do Click - Items: {cmbNovoTipoEspetaculo.Items.Count}, SelectedIndex: {cmbNovoTipoEspetaculo.SelectedIndex}, SelectedItem: {(cmbNovoTipoEspetaculo.SelectedItem?.ToString() ?? "null")}");


            if (string.IsNullOrWhiteSpace(txtNovoNomeEspetaculo.Text) || txtNovoNomeEspetaculo.Text.Trim().Length < 2)
            {
                MessageBox.Show("O campo 'Nome' é obrigatório e deve ter pelo menos 2 caracteres.", "Erro no Nome", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNovoNomeEspetaculo.Focus();
                return;
            }

            if (cmbNovoTipoEspetaculo.SelectedIndex < 0)
            {
                Debug.WriteLine($"FALHA NA VALIDAÇÃO: cmbNovoTipoEspetaculo.SelectedIndex é {cmbNovoTipoEspetaculo.SelectedIndex}. Items.Count: {cmbNovoTipoEspetaculo.Items.Count}");
                MessageBox.Show($"Selecione um 'Tipo' de espetáculo válido. (Itens atuais no ComboBox: {cmbNovoTipoEspetaculo.Items.Count})", "Erro no Tipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbNovoTipoEspetaculo.Focus();
                return;
            }
            // ... (restante das validações e lógica do botão Adicionar) ...

            var salaItem = cmbNovaSala.SelectedItem as ComboBoxItem;
            if (cmbNovaSala.SelectedIndex < 0 || salaItem == null || salaItem.Value == null || salaItem.Value == DBNull.Value)
            {
                MessageBox.Show("Selecione uma 'Sala' válida.", "Erro na Sala", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbNovaSala.Focus();
                return;
            }

            if (cmbNovoStatusEspetaculo.SelectedIndex < 0)
            {
                MessageBox.Show("Selecione um 'Status' válido.", "Erro no Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbNovoStatusEspetaculo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNovoPrecoBilhete.Text))
            {
                MessageBox.Show("O campo 'Preço base bilhete' é obrigatório.", "Erro no Preço Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNovoPrecoBilhete.Focus();
                return;
            }

            string precoStr = txtNovoPrecoBilhete.Text.Trim().Replace('.', ',');
            decimal preco;
            if (!decimal.TryParse(precoStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out preco) &&
                !decimal.TryParse(precoStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out preco) || preco < 0)
            {
                MessageBox.Show("O campo 'Preço base bilhete' deve ser um valor numérico positivo. Use vírgula ou ponto como separador decimal.", "Erro no Preço Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNovoPrecoBilhete.Focus();
                return;
            }

            DateTime inicio = dtpNovaDataHoraInicio.Value;
            DateTime fim = dtpNovaDataHoraFim.Value;
            if (fim <= inicio)
            {
                MessageBox.Show("A Data/Hora de Fim deve ser posterior à Data/Hora de Início.", "Erro nas Datas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNovaDataHoraFim.Focus();
                return;
            }

            int? duracao = null;
            if (!string.IsNullOrWhiteSpace(numNovaDuracao.Text))
            {
                if (int.TryParse(numNovaDuracao.Text, out int d))
                {
                    if (d > 0) duracao = d;
                    else if (d < 0)
                    {
                        MessageBox.Show("A 'Duração Estimada' não pode ser negativa.", "Erro na Duração", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        numNovaDuracao.Focus(); return;
                    }
                }
                else
                {
                    MessageBox.Show("A 'Duração Estimada' deve ser um valor numérico inteiro.", "Erro na Duração", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    numNovaDuracao.Focus(); return;
                }
            }

            if (_idFuncionarioLogado <= 0)
            {
                MessageBox.Show("Não foi possível identificar o funcionário executor. Ação cancelada.", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var reservaItem = cmbNovaReservaEmpresa.SelectedItem as ComboBoxItem;
            object reservaValue = reservaItem?.Value ?? DBNull.Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_AdicionarEspetaculo", conn))
                    {
                        // ... (parâmetros como no original) ...
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nome", txtNovoNomeEspetaculo.Text.Trim());
                        cmd.Parameters.AddWithValue("@DescricaoDetalhada", string.IsNullOrWhiteSpace(txtNovaDescricaoEspetaculo.Text) ? (object)DBNull.Value : txtNovaDescricaoEspetaculo.Text.Trim());
                        cmd.Parameters.AddWithValue("@TipoEspetaculo", cmbNovoTipoEspetaculo.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@DuracaoEstimadaMinutos", duracao.HasValue ? (object)duracao.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@DataHoraInicio", inicio);
                        cmd.Parameters.AddWithValue("@DataHoraFim", fim);
                        cmd.Parameters.AddWithValue("@idSala", salaItem.Value);
                        cmd.Parameters.AddWithValue("@idReservaSalaEmpresaAssociada", reservaValue);
                        cmd.Parameters.AddWithValue("@PrecoBaseBilhete", preco);
                        cmd.Parameters.AddWithValue("@ImagemCartazURL", string.IsNullOrWhiteSpace(txtNovaImagemURL.Text) ? (object)DBNull.Value : txtNovaImagemURL.Text.Trim());
                        cmd.Parameters.AddWithValue("@StatusEspetaculo", cmbNovoStatusEspetaculo.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@idFuncionarioExecutor", _idFuncionarioLogado);


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idGerado = Convert.ToInt32(reader["idEspetaculoGerado"]);
                                string msg = reader["Mensagem"].ToString();
                                if (idGerado > 0)
                                {
                                    MessageBox.Show(msg, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LimparCamposAdicionarEspetaculo();
                                    CarregarEspetaculosNaGrelha();
                                    if (tabControlEspetaculos != null && tabControlEspetaculos.TabPages.ContainsKey("tabPageListarEspetaculos"))
                                        tabControlEspetaculos.SelectedTab = tabControlEspetaculos.TabPages["tabPageListarEspetaculos"];
                                }
                                else
                                {
                                    MessageBox.Show(msg, "Erro ao Adicionar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"ERRO CRÍTICO em btnAdicionarNovoEspetaculo_Click (DB): {ex.ToString()}");
                    MessageBox.Show("Erro ao adicionar espetáculo: " + ex.Message, "Erro BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimparCamposAdicionarEspetaculo()
        {
            Debug.WriteLine("DEBUG: LimparCamposAdicionarEspetaculo - Iniciando.");
            txtNovoNomeEspetaculo?.Clear();
            txtNovaDescricaoEspetaculo?.Clear();

            if (cmbNovoTipoEspetaculo != null)
            {
                if (cmbNovoTipoEspetaculo.Items.Count > 0)
                    cmbNovoTipoEspetaculo.SelectedIndex = 0;
                else
                    Debug.WriteLine("ALERTA: cmbNovoTipoEspetaculo está definido mas não tem itens ao tentar limpar/redefinir índice.");
            }
            else { Debug.WriteLine("ALERTA: cmbNovoTipoEspetaculo é NULL em LimparCamposAdicionarEspetaculo."); }


            if (numNovaDuracao != null) numNovaDuracao.Text = "0";

            dtpNovaDataHoraInicio.Value = DateTime.Now.Date.AddHours(DateTime.Now.Hour + 1);
            dtpNovaDataHoraFim.Value = DateTime.Now.Date.AddHours(DateTime.Now.Hour + 3);

            if (cmbNovaSala != null && cmbNovaSala.Items.Count > 0) cmbNovaSala.SelectedIndex = 0;
            if (cmbNovaReservaEmpresa != null && cmbNovaReservaEmpresa.Items.Count > 0) cmbNovaReservaEmpresa.SelectedIndex = 0;
            txtNovoPrecoBilhete?.Clear();
            txtNovaImagemURL?.Clear();
            if (cmbNovoStatusEspetaculo != null && cmbNovoStatusEspetaculo.Items.Count > 0) cmbNovoStatusEspetaculo.SelectedIndex = 0;

            Debug.WriteLine("DEBUG: LimparCamposAdicionarEspetaculo - Concluído.");
            if (cmbNovoTipoEspetaculo != null)
            {
                Debug.WriteLine($"DEBUG: cmbNovoTipoEspetaculo após Limpar - Items: {cmbNovoTipoEspetaculo.Items.Count}, SelectedIndex: {cmbNovoTipoEspetaculo.SelectedIndex}");
            }
        }

        private void btnEditarEspetaculoSel_Click(object sender, EventArgs e)
        {
            // ... (código como no original, adicionar Debug.WriteLine se necessário) ...
            if (dgvEspetaculos == null || dgvEspetaculos.CurrentRow == null || dgvEspetaculos.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Selecione um espetáculo na lista para editar.", "Nenhum Espetáculo Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_idFuncionarioLogado <= 0)
            {
                MessageBox.Show("Não foi possível identificar o funcionário executor.", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataRowView drv = (DataRowView)dgvEspetaculos.CurrentRow.DataBoundItem;
                int idEspetaculo = Convert.ToInt32(drv["idEspetaculo"]);

                using (var frmEditar = new FormEditarEspetaculoPopUp(idEspetaculo, _idFuncionarioLogado))
                {
                    var resultado = frmEditar.ShowDialog(this);
                    if (resultado == DialogResult.OK)
                    {
                        CarregarEspetaculosNaGrelha();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao preparar para editar espetáculo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopularComboBoxFiltroTipo()
        {
            Debug.WriteLine("DEBUG: Iniciando PopularComboBoxFiltroTipo.");
            // CONFIRME ESTE NOME: Este deve ser o nome da ComboBox "Tipo espetaculo" na aba de filtro
            ComboBox comboBoxAlvo = this.cmbFiltroTipoEspetaculo;

            if (comboBoxAlvo == null)
            {
                Debug.WriteLine("ERRO CRÍTICO: cmbFiltroTipoEspetaculo não foi encontrado (é NULL). Verifique o nome no ficheiro Designer.cs.");
                MessageBox.Show("Erro interno: O controlo para filtrar tipo de espetáculo não foi encontrado.", "Erro de Controlo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                comboBoxAlvo.BeginUpdate();
                comboBoxAlvo.Items.Clear(); // Limpa quaisquer itens existentes (do designer, por exemplo)
                comboBoxAlvo.DropDownStyle = ComboBoxStyle.DropDownList; // Garante que o utilizador só pode selecionar

                // Adicionar uma opção para "Todos" os tipos, que não aplicará filtro por tipo
                comboBoxAlvo.Items.Add("Todos");

                var tipos = new List<string>
        {
            "Concerto", "Teatro", "Dança", "Stand-up Comedy", "Workshop", "Cinema Especial", "Outro"
        };
                Debug.WriteLine($"DEBUG: PopularComboBoxFiltroTipo - Adicionando {tipos.Count} tipos à ComboBox '{comboBoxAlvo.Name}'.");

                foreach (var tipo in tipos)
                {
                    comboBoxAlvo.Items.Add(tipo);
                }

                if (comboBoxAlvo.Items.Count > 0)
                {
                    comboBoxAlvo.SelectedIndex = 0; // Seleciona "Todos" por defeito
                    Debug.WriteLine($"DEBUG: PopularComboBoxFiltroTipo - '{comboBoxAlvo.Name}' populada. {comboBoxAlvo.Items.Count} itens. Selecionado: '{comboBoxAlvo.SelectedItem}'.");
                }
                else
                {
                    Debug.WriteLine($"ALERTA: PopularComboBoxFiltroTipo - Nenhum item foi adicionado a '{comboBoxAlvo.Name}'.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERRO em PopularComboBoxFiltroTipo: {ex.ToString()}");
                MessageBox.Show($"Ocorreu um erro ao preencher os tipos de filtro: {ex.Message}", "Erro Inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (comboBoxAlvo != null) comboBoxAlvo.EndUpdate();
            }
        }

        private void PopularComboBoxFiltroSala()
        {
            Debug.WriteLine("DEBUG: Iniciando PopularComboBoxFiltroSala.");
            // CONFIRME ESTE NOME: Este deve ser o nome da ComboBox "Sala" na aba de filtro
            ComboBox comboBoxAlvo = this.cmbFiltroSala;

            if (comboBoxAlvo == null)
            {
                Debug.WriteLine("ERRO CRÍTICO: cmbFiltroSala não foi encontrado (é NULL). Verifique o nome no ficheiro Designer.cs.");
                MessageBox.Show("Erro interno: O controlo para filtrar sala não foi encontrado.", "Erro de Controlo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                comboBoxAlvo.BeginUpdate();
                comboBoxAlvo.Items.Clear(); // Limpa quaisquer itens existentes
                comboBoxAlvo.DisplayMember = "Text"; // Importante para a classe ComboBoxItem
                comboBoxAlvo.ValueMember = "Value";   // Importante para a classe ComboBoxItem
                comboBoxAlvo.DropDownStyle = ComboBoxStyle.DropDownList;

                // Adicionar uma opção para "Todas as Salas", que não aplicará filtro por sala
                comboBoxAlvo.Items.Add(new ComboBoxItem { Text = "Todas as Salas", Value = DBNull.Value }); // Ou 0, se o seu SP tratar 0 como "todos"

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Adapte a query se necessário
                    using (SqlCommand cmd = new SqlCommand("SELECT idSala, NomeSala FROM VT_Salas ORDER BY NomeSala", conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            comboBoxAlvo.Items.Add(new ComboBoxItem
                            {
                                Text = dr["NomeSala"].ToString(),
                                Value = dr["idSala"]
                            });
                        }
                    }
                }

                if (comboBoxAlvo.Items.Count > 0)
                {
                    comboBoxAlvo.SelectedIndex = 0; // Seleciona "Todas as Salas" por defeito
                    Debug.WriteLine($"DEBUG: PopularComboBoxFiltroSala - '{comboBoxAlvo.Name}' populada. {comboBoxAlvo.Items.Count} itens. Selecionado: '{(comboBoxAlvo.SelectedItem as ComboBoxItem)?.Text}'.");

                }
                else
                {
                    Debug.WriteLine($"ALERTA: PopularComboBoxFiltroSala - Nenhum item foi adicionado a '{comboBoxAlvo.Name}'.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERRO em PopularComboBoxFiltroSala: {ex.ToString()}");
                MessageBox.Show($"Erro ao carregar salas para filtro: {ex.Message}", "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (comboBoxAlvo != null) comboBoxAlvo.EndUpdate();
            }
        }



        private void btnCancelarEspetaculoSel_Click(object sender, EventArgs e)
        {
            // ... (código como no original, adicionar Debug.WriteLine se necessário) ...
            if (dgvEspetaculos == null || dgvEspetaculos.CurrentRow == null || dgvEspetaculos.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Selecione um espetáculo na lista para cancelar/remover.", "Nenhum Espetáculo Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_idFuncionarioLogado <= 0)
            {
                MessageBox.Show("Não foi possível identificar o funcionário executor.", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataRowView drv = (DataRowView)dgvEspetaculos.CurrentRow.DataBoundItem;
                int idEspetaculo = Convert.ToInt32(drv["idEspetaculo"]);
                string nomeEspetaculo = drv["Nome"].ToString();

                DialogResult confirm = MessageBox.Show($"Tem a certeza que deseja cancelar/remover o espetáculo '{nomeEspetaculo}' (ID: {idEspetaculo})?",
                                                      "Confirmar Ação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    string motivo = Interaction.InputBox("Motivo do Cancelamento/Remoção (opcional):", "Motivo", "");

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_CancelarRemoverEspetaculo", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idEspetaculo", idEspetaculo);
                            cmd.Parameters.AddWithValue("@idFuncionarioExecutor", _idFuncionarioLogado);
                            cmd.Parameters.AddWithValue("@MotivoCancelamento", string.IsNullOrWhiteSpace(motivo) ? (object)DBNull.Value : motivo);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    bool sucesso = Convert.ToBoolean(reader["Sucesso"]);
                                    string msg = reader["Mensagem"].ToString();
                                    MessageBox.Show(msg, sucesso ? "Sucesso" : "Erro", MessageBoxButtons.OK, sucesso ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                                    if (sucesso)
                                    {
                                        CarregarEspetaculosNaGrelha();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { Debug.WriteLine($"ERRO em btnCancelarEspetaculoSel_Click: {ex.ToString()}"); MessageBox.Show("Erro ao cancelar/remover espetáculo: " + ex.Message, "Erro BD", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void tabControlEspetaculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlEspetaculos != null && tabControlEspetaculos.SelectedTab != null)
            {
                Debug.WriteLine($"DEBUG: Tab alterada para: {tabControlEspetaculos.SelectedTab.Name}");
                if (tabControlEspetaculos.SelectedTab.Name == "tabPageListarEspetaculos")
                {
                    CarregarEspetaculosNaGrelha();
                }
                else if (tabControlEspetaculos.SelectedTab.Name == "tabPageAdicionarEspetaculo")
                {
                    Debug.WriteLine($"DEBUG: cmbNovoTipoEspetaculo ANTES de popular na mudança de tab - Items: {cmbNovoTipoEspetaculo?.Items.Count}, SelectedIndex: {cmbNovoTipoEspetaculo?.SelectedIndex}");
                    PopularComboBoxTipo();
                    PopularComboBoxSala();
                    PopularComboBoxEmpresa();
                    PopularComboBoxStatus();
                    PopularComboBoxFiltroSala();
                    PopularComboBoxFiltroTipo();

                    Debug.WriteLine($"DEBUG: cmbNovoTipoEspetaculo DEPOIS de popular e ANTES de limpar campos na mudança de tab - Items: {cmbNovoTipoEspetaculo?.Items.Count}, SelectedIndex: {cmbNovoTipoEspetaculo?.SelectedIndex}");
                    LimparCamposAdicionarEspetaculo();
                    Debug.WriteLine($"DEBUG: cmbNovoTipoEspetaculo DEPOIS de limpar campos na mudança de tab - Items: {cmbNovoTipoEspetaculo?.Items.Count}, SelectedIndex: {cmbNovoTipoEspetaculo?.SelectedIndex}");
                }
            }
        }

        // Métodos vazios do designer. Verifique se algum deles está inadvertidamente ligado a eventos.
        private void tabPageAdicionarEspetaculo_Click(object sender, EventArgs e) { Debug.WriteLine("TRACE: tabPageAdicionarEspetaculo_Click"); }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { Debug.WriteLine("TRACE: comboBox1_SelectedIndexChanged (nome genérico)"); }
        private void label3_Click(object sender, EventArgs e) { Debug.WriteLine("TRACE: label3_Click"); }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e) { Debug.WriteLine("TRACE: comboBox1_SelectedIndexChanged_1 (nome genérico)"); }
        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e) { Debug.WriteLine("TRACE: comboBox1_SelectedIndexChanged_2 (nome genérico)"); }
        private void label11_Click(object sender, EventArgs e) { Debug.WriteLine("TRACE: label11_Click"); }
        private void textBox1_TextChanged(object sender, EventArgs e) { Debug.WriteLine("TRACE: textBox1_TextChanged (nome genérico)"); }
        private void label13_Click(object sender, EventArgs e) { Debug.WriteLine("TRACE: label13_Click"); }
        private void label14_Click(object sender, EventArgs e) { Debug.WriteLine("TRACE: label14_Click"); }
        private void tabPageListarEspetaculos_Click(object sender, EventArgs e) { Debug.WriteLine("TRACE: tabPageListarEspetaculos_Click"); }
    }

    // Certifique-se que a classe SessaoSistema está definida CORRETAMENTE e APENAS UMA VEZ no seu projeto.
    // Exemplo (se não existir):
    // public static class SessaoSistema
    // {
    //    public static int IdFuncionarioLogado { get; set; }
    // }

    // Certifique-se que o formulário FormEditarEspetaculoPopUp existe no seu projeto.
    // Exemplo (se não existir):
    // public class FormEditarEspetaculoPopUp : Form
    // {
    //    public FormEditarEspetaculoPopUp(int idEspetaculo, int idFuncionarioLogado)
    //    {
    //        // Construtor de exemplo
    //        this.Text = "Editar Espetáculo (PopUp)";
    //        // Adicione os seus controlos e lógica aqui
    //    }
    // }
}

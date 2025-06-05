using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projeto_Base_De_Dados_VivaTicket
{
    public partial class FormEditarEspetaculoPopUp : Form
    {
        private string connectionString = "Server=mednat.ieeta.pt\\SQLSERVER,8101;Database=p6g2;User ID=p6g2;Password=Andre.Filipe;";
        private int _idEspetaculo;
        private int _idFuncionarioLogado;

        // Classe auxiliar para ComboBoxes
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString() => Text;
        }

        public FormEditarEspetaculoPopUp(int idEspetaculo, int idFuncionario)
        {
            InitializeComponent();
            _idEspetaculo = idEspetaculo;
            _idFuncionarioLogado = idFuncionario;
        }

        private void FormEditarEspetaculoPopUp_Load(object sender, EventArgs e)
        {
            CarregarComboBoxes();
            CarregarDadosEspetaculo();
        }

        // Carregar os ComboBoxes
        private void CarregarComboBoxes()
        {
            // Tipos de Espetáculo
            cmbEditTipoEspetaculo.Items.Clear();
            cmbEditTipoEspetaculo.Items.AddRange(new string[] {
                "Concerto", "Teatro", "Dança", "Stand-up Comedy", "Workshop", "Cinema Especial", "Outro"
            });

            // Status possíveis
            cmbEditStatusEspetaculo.Items.Clear();
            cmbEditStatusEspetaculo.Items.AddRange(new string[] {
                "Ativo", "Cancelado", "Esgotado", "Realizado"
            });

            // Salas
            cmbEditSala.Items.Clear();
            cmbEditSala.DisplayMember = "Text";
            cmbEditSala.ValueMember = "Value";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT idSala, NomeSala FROM VT_Salas ORDER BY NomeSala", conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbEditSala.Items.Add(new ComboBoxItem
                            {
                                Text = dr["NomeSala"].ToString(),
                                Value = dr["idSala"]
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar salas: " + ex.Message, "Erro BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Reservas Empresa
            cmbEditReservaEmpresa.Items.Clear();
            cmbEditReservaEmpresa.DisplayMember = "Text";
            cmbEditReservaEmpresa.ValueMember = "Value";
            cmbEditReservaEmpresa.Items.Add(new ComboBoxItem { Text = "(Nenhuma - Produção Interna)", Value = DBNull.Value });

            string query = @"SELECT RSE.idReservaSalaEmpresa, 
                                    E.NomeEmpresa + ' - ' + S.NomeSala + 
                                    ' (Início: ' + CONVERT(NVARCHAR,RSE.DataInicioReserva,103) + 
                                    ', Dias: ' + CONVERT(NVARCHAR, RSE.NumeroDiasReserva) + ')' AS InfoReserva
                             FROM VT_ReservasDeSalaEmpresa RSE
                             JOIN VT_Empresas E ON RSE.idEmpresa = E.idEmpresa
                             JOIN VT_Salas S ON RSE.idSala = S.idSala
                             WHERE RSE.StatusReserva IN (N'Confirmada / Paga', N'Aprovada / Aguardando Pagamento') 
                             ORDER BY RSE.DataInicioReserva DESC";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cmbEditReservaEmpresa.Items.Add(new ComboBoxItem
                            {
                                Text = dr["InfoReserva"].ToString(),
                                Value = dr["idReservaSalaEmpresa"]
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar reservas de empresa: " + ex.Message, "Erro BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Carregar os dados do espetáculo selecionado
        private void CarregarDadosEspetaculo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM VT_Espetaculos WHERE idEspetaculo = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _idEspetaculo);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                txtEditEspetaculoID.Text = dr["idEspetaculo"].ToString();
                                txtEditNomeEspetaculo.Text = dr["Nome"].ToString();
                                txtEditDescricaoEspetaculo.Text = dr["DescricaoDetalhada"].ToString();
                                cmbEditTipoEspetaculo.SelectedItem = dr["TipoEspetaculo"].ToString();
                                txtEditDuracao.Text = dr["DuracaoEstimadaMinutos"] == DBNull.Value ? "" : dr["DuracaoEstimadaMinutos"].ToString();

                                dtpEditDataHoraInicio.Value = dr["DataHoraInicio"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["DataHoraInicio"]);
                                dtpEditDataHoraFim.Value = dr["DataHoraFim"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["DataHoraFim"]);

                                // Preenche Sala
                                int idSala = dr["idSala"] == DBNull.Value ? -1 : Convert.ToInt32(dr["idSala"]);
                                foreach (ComboBoxItem item in cmbEditSala.Items)
                                {
                                    if (item.Value != null && item.Value != DBNull.Value && (int)item.Value == idSala)
                                    {
                                        cmbEditSala.SelectedItem = item;
                                        break;
                                    }
                                }

                                // Preenche Reserva
                                if (dr["idReservaSalaEmpresaAssociada"] != DBNull.Value)
                                {
                                    int idReserva = Convert.ToInt32(dr["idReservaSalaEmpresaAssociada"]);
                                    foreach (ComboBoxItem item in cmbEditReservaEmpresa.Items)
                                    {
                                        if (item.Value != null && item.Value != DBNull.Value && (int)item.Value == idReserva)
                                        {
                                            cmbEditReservaEmpresa.SelectedItem = item;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    cmbEditReservaEmpresa.SelectedIndex = 0;
                                }

                                txtEditPrecoBilhete.Text = dr["PrecoBaseBilhete"] == DBNull.Value ? "" : dr["PrecoBaseBilhete"].ToString();
                                txtEditImagemURL.Text = dr["ImagemCartazURL"] == DBNull.Value ? "" : dr["ImagemCartazURL"].ToString();

                                // Status
                                cmbEditStatusEspetaculo.SelectedItem = dr["StatusEspetaculo"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados do espetáculo: " + ex.Message, "Erro BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardarEdicaoEspetaculo_Click(object sender, EventArgs e)
        {
            // Validação básica
            if (string.IsNullOrWhiteSpace(txtEditNomeEspetaculo.Text) ||
                cmbEditTipoEspetaculo.SelectedItem == null ||
                cmbEditSala.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtEditPrecoBilhete.Text))
            {
                lblMensagemEditarEspetaculo.Text = "Preencha todos os campos obrigatórios (Nome, Tipo, Sala, Preço).";
                return;
            }

            decimal preco;
            if (!decimal.TryParse(txtEditPrecoBilhete.Text, out preco) || preco < 0)
            {
                lblMensagemEditarEspetaculo.Text = "Preço base inválido.";
                return;
            }

            int? duracao = null;
            if (!string.IsNullOrWhiteSpace(txtEditDuracao.Text) && int.TryParse(txtEditDuracao.Text, out int d))
            {
                if (d > 0) duracao = d;
            }

            DateTime inicio = dtpEditDataHoraInicio.Value;
            DateTime fim = dtpEditDataHoraFim.Value;
            if (fim <= inicio)
            {
                lblMensagemEditarEspetaculo.Text = "A Data/Hora de Fim deve ser posterior à de início.";
                return;
            }

            if (cmbEditSala.SelectedItem == null)
            {
                lblMensagemEditarEspetaculo.Text = "Selecione uma sala válida.";
                return;
            }

            var salaItem = cmbEditSala.SelectedItem as ComboBoxItem;
            var reservaItem = cmbEditReservaEmpresa.SelectedItem as ComboBoxItem;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_EditarEspetaculo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idEspetaculo", _idEspetaculo);
                        cmd.Parameters.AddWithValue("@Novonome", txtEditNomeEspetaculo.Text.Trim());
                        cmd.Parameters.AddWithValue("@NovaDescricaoDetalhada", string.IsNullOrWhiteSpace(txtEditDescricaoEspetaculo.Text) ? (object)DBNull.Value : txtEditDescricaoEspetaculo.Text.Trim());
                        cmd.Parameters.AddWithValue("@NovoTipoEspetaculo", cmbEditTipoEspetaculo.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@NovaDuracaoEstimadaMinutos", duracao.HasValue ? (object)duracao.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@NovaDataHoraInicio", inicio);
                        cmd.Parameters.AddWithValue("@NovaDataHoraFim", fim);
                        cmd.Parameters.AddWithValue("@NovaidSala", salaItem.Value);
                        cmd.Parameters.AddWithValue("@NovaidReservaSalaEmpresaAssociada", (reservaItem?.Value ?? DBNull.Value));
                        cmd.Parameters.AddWithValue("@NovoPrecoBaseBilhete", preco);
                        cmd.Parameters.AddWithValue("@NovaImagemCartazURL", string.IsNullOrWhiteSpace(txtEditImagemURL.Text) ? (object)DBNull.Value : txtEditImagemURL.Text.Trim());
                        cmd.Parameters.AddWithValue("@NovoStatusEspetaculo", cmbEditStatusEspetaculo.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@idFuncionarioExecutor", _idFuncionarioLogado);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool sucesso = Convert.ToBoolean(reader["Sucesso"]);
                                string msg = reader["Mensagem"].ToString();
                                lblMensagemEditarEspetaculo.Text = msg;
                                if (sucesso)
                                {
                                    MessageBox.Show("Espetáculo atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao guardar alterações: " + ex.Message, "Erro BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelarEdicaoEspetaculo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
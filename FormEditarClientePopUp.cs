using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Projeto_Base_De_Dados_VivaTicket
{
    public partial class FormEditarClientePopUp : Form
    {
        private readonly string connectionString = "Server=mednat.ieeta.pt\\SQLSERVER,8101;Database=p6g2;User ID=p6g2;Password=Andre.Filipe;";
        private readonly int _idClienteParaEditar;
        private readonly int _idFuncionarioExecutor; // ID do funcionário que está a fazer a edição


        // Propriedade para o FormVerClientes saber se a edição foi bem-sucedida
        public bool EdicaoBemSucedida { get; private set; } = false;

        public FormEditarClientePopUp(int idCliente, string nome, string email, string passwordAtualTextoSimples, string nif, string telefone, string endereco, int idFuncionario)
        {
            InitializeComponent();

            _idClienteParaEditar = idCliente;
            _idFuncionarioExecutor = idFuncionario;

            // Preencher os campos com os dados do cliente
            txtEditPopUpIdCliente.Text = idCliente.ToString();
            txtEditPopUpNome.Text = nome;
            txtEditPopUpEmail.Text = email;
            // Não preenchemos o campo da password por defeito. Se o utilizador quiser mudar, ele digita uma nova.
            // Se quiseres mostrar a password atual (texto simples do teu teste), descomenta a linha abaixo:
            // txtEditPopUpPassword.Text = passwordAtualTextoSimples; 
            txtEditPopUpNIF.Text = nif;
            txtEditPopUpTelefone.Text = telefone;
            txtEditPopUpEndereco.Text = endereco;
        }

        private void FormEditarClientePopUp_Load(object sender, EventArgs e)
        {
            // Alguma lógica ao carregar, se necessário
        }

        private void btnGuardarEdicaoPopUp_Click(object sender, EventArgs e)
        {
            // Obter os novos dados dos TextBoxes
            string novoNome = txtEditPopUpNome.Text.Trim();
            string novoEmail = txtEditPopUpEmail.Text.Trim();
            // Se o campo da password estiver vazio, passamos NULL para a SP, indicando para não alterar.
            string novaPasswordTextoSimples = string.IsNullOrWhiteSpace(txtEditPopUpPassword.Text) ? null : txtEditPopUpPassword.Text;
            string novoNIF = string.IsNullOrWhiteSpace(txtEditPopUpNIF.Text) ? null : txtEditPopUpNIF.Text.Trim();
            string novoTelefone = string.IsNullOrWhiteSpace(txtEditPopUpTelefone.Text) ? null : txtEditPopUpTelefone.Text.Trim();
            string novoEndereco = string.IsNullOrWhiteSpace(txtEditPopUpEndereco.Text) ? null : txtEditPopUpEndereco.Text.Trim();

            if (lblMensagemEditarPopUp != null) lblMensagemEditarPopUp.Text = "";

            if (string.IsNullOrWhiteSpace(novoNome) || string.IsNullOrWhiteSpace(novoEmail))
            {
                MessageBox.Show("Nome e Email são obrigatórios.", "Dados em Falta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (lblMensagemEditarPopUp != null) lblMensagemEditarPopUp.Text = "Nome e Email são obrigatórios.";
                return;
            }

            if (_idFuncionarioExecutor <= 0)
            {
                MessageBox.Show("Não foi possível identificar o funcionário executor. Ação cancelada.", "Erro de Autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_EditarCliente", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idCliente", _idClienteParaEditar);
                        cmd.Parameters.AddWithValue("@NovoNome", novoNome);
                        cmd.Parameters.AddWithValue("@NovoEmail", novoEmail);
                        // Passar DBNull.Value se a string da password for nula ou vazia, para a SP não alterar
                        cmd.Parameters.AddWithValue("@NovaPasswordTextoSimples", (object)novaPasswordTextoSimples ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@NovoNIF", (object)novoNIF ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@NovoTelefone", (object)novoTelefone ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@NovoEndereco", (object)novoEndereco ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@idFuncionarioExecutor", _idFuncionarioExecutor);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool sucesso = Convert.ToBoolean(reader["Sucesso"]);
                                string mensagem = reader["Mensagem"].ToString();

                                if (sucesso)
                                {
                                    MessageBox.Show(mensagem, "Cliente Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    EdicaoBemSucedida = true; // Indica que a edição teve sucesso
                                    this.DialogResult = DialogResult.OK; // Define o resultado do diálogo
                                    this.Close(); // Fecha o pop-up
                                }
                                else
                                {
                                    MessageBox.Show(mensagem, "Erro ao Atualizar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    if (lblMensagemEditarPopUp != null) lblMensagemEditarPopUp.Text = mensagem;
                                    EdicaoBemSucedida = false;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar cliente: " + ex.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EdicaoBemSucedida = false;
                }
            }
        }

        private void btnCancelarPopUp_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // Fecha o pop-up sem guardar
        }
    }
}

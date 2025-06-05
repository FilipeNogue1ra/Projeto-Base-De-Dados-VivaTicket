using System;
using System.Data; // Para CommandType
using System.Data.SqlClient; // Para os objetos do SQL Server
using System.Security.Cryptography;

using System.Text;

// using System.Security.Cryptography; // Necessário se voltares a usar GerarHashSHA256
// using System.Text; // Necessário se voltares a usar GerarHashSHA256
using System.Windows.Forms;

// Certifica-te que o namespace corresponde ao do teu projeto
namespace Projeto_Base_De_Dados_VivaTicket
{
    public partial class FormLoginFuncionario : Form
    {
        public FormLoginFuncionario()
        {
            InitializeComponent();
        }

        private void FormLoginFuncionario_Load(object sender, EventArgs e)
        {
            // Código a executar quando o formulário carrega (se necessário)
        }

        // Se este botão não tem funcionalidade no teu formulário, 
        // podes remover este método e a sua ligação no designer.
        private void button1_Click(object sender, EventArgs e)
        {
            // Vazio, conforme o teu código anterior
        }

        // Evento de clique para o botão "Voltar Atrás"
        private void button_VoltarAtras_Click(object sender, EventArgs e)
        {
            FormInicial formInicial = new FormInicial();
            formInicial.Show();
            this.Close();
        }

        // Evento de clique para o botão de Login do Funcionário
        private void btnLoginFuncionario_Click(object sender, EventArgs e)
        {
            // Certifica-te que os nomes txtEmailFuncionario, txtPasswordFuncionario e (opcional) lblMensagemFunc
            // correspondem aos nomes dos teus controlos no designer.
            string emailInserido = txtEmailFuncionario.Text.Trim();
            string passwordInserida = txtPasswordFuncionario.Text; // Password em texto simples do TextBox

            if (lblMensagemFunc != null) lblMensagemFunc.Text = "";

            if (string.IsNullOrWhiteSpace(emailInserido) || string.IsNullOrWhiteSpace(passwordInserida))
            {
                if (lblMensagemFunc != null) lblMensagemFunc.Text = "Por favor, insira o email e a password.";
                MessageBox.Show("Por favor, insira o email e a password.", "Input Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // A parte do hashing está comentada para o teu teste atual
            // string passwordInseridaHash = GerarHashSHA256(passwordInserida);

            string connectionString = "Server=mednat.ieeta.pt\\SQLSERVER,8101;Database=p6g2;User ID=p6g2;Password=Andre.Filipe;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ObterCredenciaisFuncionarioPorEmail", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Email", emailInserido);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Funcionário encontrado
                            {
                                string passwordDaBD_TextoSimples = reader["PasswordHash"].ToString(); // Contém texto simples para teste
                                bool ativo = Convert.ToBoolean(reader["Ativo"]);
                                string nomeFuncionario = reader["Nome"].ToString();
                                int idFuncionario = Convert.ToInt32(reader["idFuncionario"]);

                                // Comparação direta das passwords em texto simples (APENAS PARA TESTE)
                                if (passwordInserida == passwordDaBD_TextoSimples)
                                {
                                    if (ativo)
                                    {
                                        if (lblMensagemFunc != null) lblMensagemFunc.Text = $"Login bem-sucedido! Bem-vindo, {nomeFuncionario}!";
                                        MessageBox.Show($"Login bem-sucedido! Bem-vindo, {nomeFuncionario} (ID: {idFuncionario})", "Sucesso no Login (TESTE SEM HASH)", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        // --- ALTERAÇÃO AQUI: Passar dados para o FormDashboardFuncionario ---
                                        // E guardar na classe de Sessão
                                        SessaoSistema.IdFuncionarioLogado = idFuncionario;
                                        SessaoSistema.NomeFuncionarioLogado = nomeFuncionario;

                                        FormDashboardFuncionario formDashboard = new FormDashboardFuncionario(idFuncionario, nomeFuncionario);
                                        formDashboard.Show();
                                        this.Close(); // Fecha o formulário de login atual
                                    }
                                    else
                                    {
                                        if (lblMensagemFunc != null) lblMensagemFunc.Text = "Conta de funcionário inativa.";
                                        MessageBox.Show("A sua conta de funcionário está inativa. Contacte o administrador.", "Login Falhou", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else // Password incorreta
                                {
                                    if (lblMensagemFunc != null) lblMensagemFunc.Text = "Email ou password inválidos.";
                                    MessageBox.Show("Email ou password inválidos.", "Login Falhou", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else // Email não encontrado
                            {
                                if (lblMensagemFunc != null) lblMensagemFunc.Text = "Email ou password inválidos.";
                                MessageBox.Show("Email ou password inválidos. (Email não encontrado)", "Login Falhou", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Erro ao comunicar com a base de dados: " + sqlEx.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (lblMensagemFunc != null) lblMensagemFunc.Text = "Erro de sistema. Tente mais tarde.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (lblMensagemFunc != null) lblMensagemFunc.Text = "Erro de sistema. Tente mais tarde.";
                }
            }
        }

        // A função GerarHashSHA256 ainda está aqui, mas não está a ser chamada.
        // Mantém-na para quando voltares a implementar o hashing.
        private string GerarHashSHA256(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

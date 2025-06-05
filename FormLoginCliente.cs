using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
// using System.Security.Cryptography; // Para quando implementares hashing
// using System.Text; // Para quando implementares hashing

namespace Projeto_Base_De_Dados_VivaTicket
{
    public partial class FormLoginCliente : Form
    {
        private string connectionString = "Server=mednat.ieeta.pt\\SQLSERVER,8101;Database=p6g2;User ID=p6g2;Password=Andre.Filipe;";

        public FormLoginCliente()
        {
            InitializeComponent();
        }

        private void FormLoginCliente_Load(object sender, EventArgs e)
        {
            // Código a executar quando o formulário carrega, se necessário
        }

        // Evento para o BOTÃO DE LOGIN
        // Certifica-te que o teu botão "Login" no designer está ligado a este evento.
        // Se o nome do botão no designer for 'btnLoginCliente', o método deve chamar-se btnLoginCliente_Click.
        // Se o teu botão de login ainda estiver ligado a 'button1_Click' e não houver um 'button1' visível,
        // deves corrigir a ligação no designer ou renomear este método.
        // Vou assumir que se chama btnLoginCliente.
        private void btnLoginCliente_Click(object sender, EventArgs e)
        {
            // Certifica-te que os TextBoxes se chamam txtEmailCliente e txtPasswordCliente
            // e a Label de mensagens (opcional) lblMensagemLoginCliente
            if (txtEmailCliente == null || txtPasswordCliente == null)
            {
                MessageBox.Show("Controlos de email ou password não encontrados no formulário. Verifique o designer.", "Erro de Interface", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string emailInserido = txtEmailCliente.Text.Trim();
            string passwordInserida = txtPasswordCliente.Text; // Password em texto simples

            if (lblMensagemLoginCliente != null) lblMensagemLoginCliente.Text = "";

            if (string.IsNullOrWhiteSpace(emailInserido) || string.IsNullOrWhiteSpace(passwordInserida))
            {
                MessageBox.Show("Por favor, insira o email e a password.", "Input Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (lblMensagemLoginCliente != null) lblMensagemLoginCliente.Text = "Email e password são obrigatórios.";
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ObterCredenciaisClientePorEmail", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Email", emailInserido);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Cliente encontrado
                            {
                                string passwordDaBD_TextoSimples = reader["PasswordHash"].ToString(); // Contém texto simples para teste
                                string nomeCliente = reader["Nome"].ToString();
                                int idCliente = Convert.ToInt32(reader["idCliente"]);

                                // Compara diretamente as passwords em texto simples (APENAS PARA TESTE)
                                if (passwordInserida == passwordDaBD_TextoSimples)
                                {
                                    MessageBox.Show($"Login bem-sucedido! Bem-vindo(a), {nomeCliente} (ID: {idCliente})", "Sucesso no Login (TESTE SEM HASH)", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    SessaoSistema.IdClienteLogado = idCliente;
                                    SessaoSistema.NomeClienteLogado = nomeCliente;

                                    // TODO: Abrir o formulário principal do cliente aqui
                                    // Exemplo:
                                    // FormPainelCliente formPainelCli = new FormPainelCliente(idCliente, nomeCliente);
                                    // formPainelCli.Show();
                                    // this.Close(); 
                                }
                                else // Password incorreta
                                {
                                    if (lblMensagemLoginCliente != null) lblMensagemLoginCliente.Text = "Email ou password inválidos.";
                                    MessageBox.Show("Email ou password inválidos.", "Login Falhou", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else // Email não encontrado
                            {
                                if (lblMensagemLoginCliente != null) lblMensagemLoginCliente.Text = "Email ou password inválidos.";
                                MessageBox.Show("Email ou password inválidos. (Email não encontrado)", "Login Falhou", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Erro ao comunicar com a base de dados: " + sqlEx.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (lblMensagemLoginCliente != null) lblMensagemLoginCliente.Text = "Erro de sistema.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro inesperado: " + ex.Message, "Erro Geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (lblMensagemLoginCliente != null) lblMensagemLoginCliente.Text = "Erro inesperado.";
                }
            }
        }

        // Evento para o teu botão "Voltar atrás"
        // Se o botão no designer se chama 'button2', este método é o correto.
        private void button2_Click(object sender, EventArgs e)
        {
            FormInicial formInicial = new FormInicial();
            formInicial.Show();
            this.Close();
        }

        // Evento para o NOVO botão "Registar"
        // Certifica-te que o botão no designer se chama btnAbrirRegisto e está ligado a este evento
        private void btnAbrirRegisto_Click(object sender, EventArgs e)
        {
            // Cria uma instância do FormRegistoCliente
            // Certifica-te que FormRegistoCliente.cs existe no teu projeto
            FormRegistoCliente frmRegisto = new FormRegistoCliente();

            // Mostra como um diálogo modal. O código aqui espera até que frmRegisto seja fechado.
            frmRegisto.ShowDialog(this);

            // Opcional: Esconder o formulário de login enquanto o de registo está aberto
            // this.Hide();
            // Se esconderes, precisas de uma forma de o FormRegistoCliente te notificar para te mostrares de novo,
            // ou simplesmente não o escondas e o utilizador pode fechar o de registo e voltar ao de login.
            // ShowDialog() já bloqueia este formulário, o que é geralmente o comportamento desejado.
        }
    }
}

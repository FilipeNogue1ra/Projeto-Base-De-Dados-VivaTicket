using System;
// using System.Collections.Generic; // Não usado neste exemplo simples
// using System.ComponentModel; // Não usado neste exemplo simples
// using System.Data; // Não usado neste exemplo simples
// using System.Drawing; // Não usado neste exemplo simples
// using System.Linq; // Não usado neste exemplo simples
// using System.Text; // Não usado neste exemplo simples
// using System.Threading.Tasks; // Não usado neste exemplo simples
using System.Windows.Forms;

namespace Projeto_Base_De_Dados_VivaTicket
{
    public partial class FormDashboardFuncionario : Form
    {
        // Variáveis para guardar a informação do funcionário logado
        private readonly int _idFuncionarioLogado;
        private readonly string _nomeFuncionarioLogado;

        // Construtor padrão (o Visual Studio pode precisar disto para o designer)
        // É boa prática mantê-lo, mas o que recebe parâmetros será mais usado.
        public FormDashboardFuncionario()
        {
            InitializeComponent();
            // Se abrires este formulário diretamente no designer e precisares de valores de teste
            // para _idFuncionarioLogado ou _nomeFuncionarioLogado em algum evento de Load,
            // poderias inicializá-los aqui condicionalmente (ex: if Debugger.IsAttached).
            // Mas, idealmente, os valores vêm do login.
        }

        // NOVO CONSTRUTOR: Para receber o ID e nome do funcionário do FormLoginFuncionario
        public FormDashboardFuncionario(int idFuncionario, string nomeFuncionario)
        {
            InitializeComponent();
            _idFuncionarioLogado = idFuncionario;
            _nomeFuncionarioLogado = nomeFuncionario;

            // Exemplo: Personalizar o título da janela ou uma Label no dashboard
            this.Text = $"Dashboard - Bem-vindo, {_nomeFuncionarioLogado} (ID: {_idFuncionarioLogado})";
            // Se tiveres uma label no dashboard para mostrar o nome:
            // lblNomeFuncionarioDashboard.Text = $"Utilizador: {_nomeFuncionarioLogado}";
        }

        private void FormDashboardFuncionario_Load(object sender, EventArgs e)
        {
            // Podes adicionar código aqui se precisares de fazer algo quando o dashboard carrega,
            // por exemplo, carregar algumas informações iniciais usando _idFuncionarioLogado.
        }

        // Evento do teu botão que abre o FormVerClientes
        // (Assumindo que é o button1 e que o nomeaste no designer ou que este evento está ligado a ele)
        private void button1_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do formulário FormVerClientes,
            // passando o ID e o nome do funcionário logado.
            // Certifica-te que FormVerClientes tem um construtor que aceita estes parâmetros.
            FormVerCliente formVerClientes = new FormVerCliente(_idFuncionarioLogado); // Passa o ID do funcionário
            // Se o construtor do FormVerClientes também aceitar o nome:
            // FormVerClientes formVerClientes = new FormVerClientes(_idFuncionarioLogado, _nomeFuncionarioLogado);


            // Mostra o formulário FormVerClientes
            formVerClientes.Show();

            // Decides o que fazer com o FormDashboardFuncionario:
            // Opção 1: Fechar o Dashboard
            // this.Close(); 

            // Opção 2: Esconder o Dashboard (para poder voltar a ele depois)
            // this.Hide(); 
            // Se esconderes, precisarás de uma forma de o FormVerClientes (ou outros)
            // poderem mostrar o Dashboard novamente quando forem fechados, ou um botão "Voltar ao Dashboard".
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormGerirEspetaculos formGerirEspetaculos = new FormGerirEspetaculos(_idFuncionarioLogado);
            formGerirEspetaculos.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormGerirSalas formGerirSalas = new FormGerirSalas(_idFuncionarioLogado);
            formGerirSalas.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Base_De_Dados_VivaTicket
{
    public partial class FormInicial: Form
    {
        public FormInicial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do formulário de login do cliente
            FormLoginCliente frmLoginCli = new FormLoginCliente();

            // Mostra o formulário de login do cliente
            frmLoginCli.Show();

            // Opcional: Se quiseres esconder o formulário inicial depois de abrir o de login
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cria uma nova instância do formulário de login do funcionário
            FormLoginFuncionario frmLoginFunc = new FormLoginFuncionario();

            // Mostra o formulário de login do funcionário
            frmLoginFunc.Show();

            // Opcional: Se quiseres esconder o formulário inicial
            this.Hide();
        }
        

        private void FormInicial_Load(object sender, EventArgs e)
        {

        }
    }
}

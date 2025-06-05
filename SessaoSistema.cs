// Ficheiro: SessaoSistema.cs
namespace Projeto_Base_De_Dados_VivaTicket // Garante que o namespace é o mesmo do teu projeto
{
    public static class SessaoSistema
    {
        public static int IdFuncionarioLogado { get; set; }
        public static string NomeFuncionarioLogado { get; set; }

        // Adiciona estas propriedades se também quiseres guardar info do cliente logado globalmente
        public static int IdClienteLogado { get; set; }
        public static string NomeClienteLogado { get; set; }
    }
}

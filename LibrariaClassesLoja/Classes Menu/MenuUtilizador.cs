namespace LibrariaClassesLoja
{
    public class MenuUtilizador
    {
        private Utilizador utilizador;
        public MenuUtilizador(Utilizador utilizador)
        {
            this.utilizador = utilizador;
        }
        public bool Mostrar()
        {
            Console.WriteLine($"Bem-vindo {utilizador.Nome}!");
            while (true)
            {
                Console.WriteLine("0 - Logout");
                Console.WriteLine("Escolha uma opção:");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        Console.WriteLine("Logout efetuado.");
                        return false;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}
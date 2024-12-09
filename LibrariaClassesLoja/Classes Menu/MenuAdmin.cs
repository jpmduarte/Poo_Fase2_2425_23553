namespace LibrariaClassesLoja
{
    public class MenuAdmin
    {
        private Administrador administrador;
        public MenuAdmin(Administrador administrador)
        {
            this.administrador = administrador;
        }
        public bool Mostrar()
        {
            Console.WriteLine($"Bem-vindo {administrador.Nome}!");
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
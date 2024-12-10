namespace LibrariaClassesLoja
{
    public class MenuPrincipal
    {
        private RepositorioUtilizador utilizadoresRepositorio;

        private HistoricoCompras historicoCompras;
        private RepositorioAdministrador administradoresRepositorio;
        private RepositorioProduto repositorioProdutos;
        private GestorStock gestorStock;
        private ServicoAutenticacao servicoAutenticacao;

        public MenuPrincipal(RepositorioUtilizador utilizadoresRepositorio, RepositorioAdministrador administradoresRepositorio, RepositorioProduto repositorioProduto, GestorStock gestorStock, HistoricoCompras historicoCompras)
        {
            this.utilizadoresRepositorio = utilizadoresRepositorio;
            this.administradoresRepositorio = administradoresRepositorio;
            this.repositorioProdutos = repositorioProduto;
            this.gestorStock = gestorStock;
            this.historicoCompras = historicoCompras;
            servicoAutenticacao = new ServicoAutenticacao(utilizadoresRepositorio, administradoresRepositorio);
        }

        public void Mostrar()
        {
            while (true)
            {
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Registar");
                Console.WriteLine("3 - Sair");
                Console.WriteLine("Escolha uma opção:");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        var utilizadorOuAdmin = Login();
                        if (utilizadorOuAdmin != null)
                        {
                            // Se for um admin
                            if (utilizadorOuAdmin is Administrador admin)
                            {
                                MenuAdmin menuAdmin = new MenuAdmin(admin,repositorioProdutos,gestorStock,utilizadoresRepositorio,historicoCompras);  // Redireciona para o menu do Admin
                                bool continueToMenuPrincipal = menuAdmin.Mostrar();
                                if (!continueToMenuPrincipal) // Após logout
                                {
                                    continue;
                                }
                            }
                            // Se for um utilizador comum
                            else if (utilizadorOuAdmin is Utilizador utilizador)
                            {
                                MenuUtilizador menuUtilizador = new MenuUtilizador(utilizador,historicoCompras, repositorioProdutos, gestorStock);  // Redireciona para o menu do Utilizador
                                bool continueToMenuPrincipal = menuUtilizador.Mostrar();
                                if (!continueToMenuPrincipal) // Após logout
                                {
                                    continue;
                                }
                            }
                        }
                        break;
                    case "2":
                        Utilizador utilizadoraRegistar = Registar();
                        if (utilizadoraRegistar != null)
                        {
                            MenuUtilizador menuUtilizador = new MenuUtilizador(utilizadoraRegistar, historicoCompras, repositorioProdutos, gestorStock);  // Redireciona para o menu do Utilizador
                            bool continueToMenuPrincipal = menuUtilizador.Mostrar();
                            if (!continueToMenuPrincipal) // Após logout
                            {
                                continue;
                            }
                        }
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }

        public object Login()
        {
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            while (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Email inválido, insira um email válido:");
                email = Console.ReadLine();
            }
            Console.WriteLine("Password:");
            string password = Console.ReadLine();
            while (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password inválida, insira uma password válida:");
                password = Console.ReadLine();
            }

            // Primeiro tenta autenticar como Administrador
            var admin = servicoAutenticacao.AutenticarAdministrador(email, password);
            if (admin != null)
            {
                Console.WriteLine("Login efetuado com sucesso como administrador.");
                return admin;  // Retorna o administrador
            }

            // Se não for administrador, tenta autenticar como utilizador comum
            var utilizador = servicoAutenticacao.AutenticarUtilizador(email, password);
            if (utilizador != null)
            {
                Console.WriteLine("Login efetuado com sucesso como utilizador.");
                return utilizador;  // Retorna o utilizador comum
            }

            Console.WriteLine("Email ou senha inválidos");
            return null;
        }

        public Utilizador Registar()
        {
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            while (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Nome inválido. Insira um nome válido:");
                nome = Console.ReadLine();
            }

            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            while (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                Console.WriteLine("Email inválido. Insira um email válido:");
                email = Console.ReadLine();
            }

            Console.WriteLine("Password:");
            string password = Console.ReadLine();
            while (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password inválida. Deve conter pelo menos 8 caracteres, um número, um caracter especial e um caracter maíusculo:");
                password = Console.ReadLine();
            }
            if (utilizadoresRepositorio.ObterPorEmail(email) != null)
            {
                Console.WriteLine("Email já registado");
                return null;
            }

            try
            {
                utilizadoresRepositorio.Adicionar(new Utilizador(nome, password, email));
                Console.WriteLine("Registo efetuado com sucesso");
                return utilizadoresRepositorio.ObterPorEmail(email);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao registar utilizador: {e.Message}");
                return null;
            }
        }
    }
}





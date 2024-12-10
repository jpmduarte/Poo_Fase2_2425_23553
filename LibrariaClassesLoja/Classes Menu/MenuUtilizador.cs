namespace LibrariaClassesLoja
{
    public class MenuUtilizador
    {
        private Utilizador utilizador;
        private HistoricoCompras historicoCompras;
        private RepositorioProduto repositorioProdutos;
        private GestorStock gestorStock;
        private CarrinhoCompras carrinhoCompras;


        public MenuUtilizador(Utilizador utilizador, HistoricoCompras historicoCompras, RepositorioProduto repositorioProdutos, GestorStock gestorStock)
        {
            this.utilizador = utilizador;
            this.historicoCompras = historicoCompras;
            this.repositorioProdutos = repositorioProdutos;
            this.gestorStock = gestorStock;
            carrinhoCompras = new CarrinhoCompras(gestorStock, repositorioProdutos);
        }

        public bool Mostrar()
        {
            Console.WriteLine($"Bem-vindo {utilizador.Nome}!");
            while (true)
            {
                Console.WriteLine("1 - Ver produtos");
                Console.WriteLine("2 - Adicionar produto ao carrinho");
                Console.WriteLine("3 - Ver carrinho");
                Console.WriteLine("4 - Remover produto do carrinho");
                Console.WriteLine("5 - Comprar");
                Console.WriteLine("6 - Ver saldo");
                Console.WriteLine("7 - Adicionar saldo");
                Console.WriteLine("0 - Logout");
                Console.WriteLine("Escolha uma opção:");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        foreach (var produto in repositorioProdutos.ObterTodos())
                        {
                            Console.WriteLine(produto);
                        }
                        break;

                    case "2":
                        Console.WriteLine("Insira o ID do produto:");
                        int id = int.Parse(Console.ReadLine());
                        var produtoAdicionar = repositorioProdutos.ObterPorID(id);
                        if (produtoAdicionar == null)
                        {
                            Console.WriteLine("Produto não encontrado.");
                            break;
                        }
                        try
                        {
                            carrinhoCompras.AdicionarProduto(produtoAdicionar);
                            Console.WriteLine("Produto adicionado ao carrinho.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "3":
                        foreach (var produto in carrinhoCompras.ObterProdutos())
                        {
                            Console.WriteLine(produto);
                        }
                        break;

                    case "4":
                        Console.WriteLine("Insira o ID do produto:");
                        int idRemover = int.Parse(Console.ReadLine());
                        var produtoRemover = repositorioProdutos.ObterPorID(idRemover);
                        if (produtoRemover == null)
                        {
                            Console.WriteLine("Produto não encontrado.");
                            break;
                        }
                        try
                        {
                            carrinhoCompras.RemoverProdutoCarrinho(produtoRemover);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "5":
                        try
                        {
                            double precoTotal = carrinhoCompras.precoTotal();
                            if (precoTotal == 0)
                            {
                                Console.WriteLine("Carrinho vazio.");
                                break;
                            }
                            Console.WriteLine($"Preço total: {precoTotal}");
                            Console.WriteLine("Deseja comprar? (s/n)");
                            string resposta = Console.ReadLine();
                            if (resposta == "s")
                            {
                                if (utilizador.Saldo < precoTotal)
                                {
                                    Console.WriteLine("Saldo insuficiente.");
                                    break;
                                }
                                utilizador.Saldo -= precoTotal;
                                Compra compra = new Compra(utilizador, carrinhoCompras);
                                historicoCompras.Adicionar(compra);
                                foreach (var produto in carrinhoCompras.ObterProdutos())
                                {
                                    gestorStock.RemoverStock(produto.Id, 1);
                                }
                                carrinhoCompras.LimparCarrinho();
                                Console.WriteLine("Compra efetuada com sucesso.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "6":
                        Console.WriteLine($"Saldo: {utilizador.Saldo}");
                        break;
                    case "7":
                        Console.WriteLine("Insira o valor a adicionar:");
                        double valor = double.Parse(Console.ReadLine());
                        utilizador.Saldo += valor;
                        Console.WriteLine("Saldo adicionado com sucesso.");
                        break;
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
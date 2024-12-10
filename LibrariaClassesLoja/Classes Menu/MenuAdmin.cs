namespace LibrariaClassesLoja
{
    public class MenuAdmin
    {
        private Administrador administrador;
        private GestorStock gestorStocks;

        HistoricoCompras historicoCompras;
        private RepositorioProduto repositorioProdutos;
        private RepositorioUtilizador repositorioUtilizador;
        public MenuAdmin(Administrador administrador, RepositorioProduto repositorioProdutos, GestorStock gestorStock, RepositorioUtilizador repositorioUtilizadores, HistoricoCompras historicoCompras)
        {
            this.historicoCompras = historicoCompras;
            this.administrador = administrador;
            this.repositorioProdutos = repositorioProdutos;
            this.gestorStocks = gestorStock;
            this.repositorioUtilizador = repositorioUtilizadores;
        }
        public bool Mostrar()
        {
            Console.WriteLine($"Bem-vindo {administrador.Nome}!");
            while (true)
            {
                Console.WriteLine("1 - Adicionar Produto");
                Console.WriteLine("2 - Adicionar Stock");
                Console.WriteLine("3 - Remover Produto");
                Console.WriteLine("4 - Remover Stock");
                Console.WriteLine("5 - Listar Produtos");
                Console.WriteLine("6 - Listar Stock");
                Console.WriteLine("7 - Atualizar produto");
                Console.WriteLine("8 - Listar Utilizadores");
                Console.WriteLine("9 - Criar Utilizador");
                Console.WriteLine("10 - Remover Utilizador");
                Console.WriteLine("11 - Atualizar Utilizador");
                Console.WriteLine("12 - Estatísticas de vendas por utilizador");
                Console.WriteLine("13 - Estatísticas de vendas por produto");
                Console.WriteLine("14 - Estatísticas de vendas por Data");
                Console.WriteLine("0 - Logout");
                Console.WriteLine("Escolha uma opção:");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Adicionar Produto:");

                        string nome;
                        do
                        {
                            Console.WriteLine("Nome:");
                            nome = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(nome))
                            {
                                Console.WriteLine("Nome inválido. Por favor, insira um nome.");
                            }
                        } while (string.IsNullOrWhiteSpace(nome));

                        double preco;
                        while (true)
                        {
                            Console.WriteLine("Preço:");
                            string inputPreco = Console.ReadLine();
                            if (double.TryParse(inputPreco, out preco) && preco > 0)
                            {
                                break; // Entrada válida
                            }
                            Console.WriteLine("Preço inválido. Por favor, insira um valor numérico positivo.");
                        }

                        string descricao;
                        do
                        {
                            Console.WriteLine("Descrição:");
                            descricao = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(descricao))
                            {
                                Console.WriteLine("Descrição inválida. Por favor, insira uma descrição.");
                            }
                        } while (string.IsNullOrWhiteSpace(descricao));

                        string categoria;
                        do
                        {
                            Console.WriteLine("Categoria:");
                            categoria = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(categoria))
                            {
                                Console.WriteLine("Categoria inválida. Por favor, insira uma categoria.");
                            }
                        } while (string.IsNullOrWhiteSpace(categoria));

                        try
                        {
                            Produto produto = new Produto(nome, preco, descricao, categoria);
                            repositorioProdutos.Adicionar(produto);
                            gestorStocks.AtualizarStock();
                            Console.WriteLine("Produto adicionado com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao adicionar o produto: {ex.Message}");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Adicionar Stock:");

                        int idProduto;
                        while (true)
                        {
                            Console.WriteLine("ID do produto:");
                            string inputId = Console.ReadLine();
                            if (int.TryParse(inputId, out idProduto) && idProduto > 0)
                            {
                                break; // Entrada válida
                            }
                            Console.WriteLine("ID do produto inválido. Por favor, insira um número inteiro positivo.");
                        }

                        int quantidade;
                        while (true)
                        {
                            Console.WriteLine("Quantidade:");
                            string inputQuantidade = Console.ReadLine();
                            if (int.TryParse(inputQuantidade, out quantidade) && quantidade > 0)
                            {
                                break; // Entrada válida
                            }
                            Console.WriteLine("Quantidade inválida. Por favor, insira um número inteiro positivo.");
                        }

                        try
                        {
                            gestorStocks.AdicionarStock(idProduto, quantidade);
                            Console.WriteLine("Stock adicionado com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao adicionar stock: {ex.Message}");
                        }

                        break;
                    case "3":
                        Console.WriteLine("Remover Produto:");

                        int idProdutoRemover;
                        while (true)
                        {
                            Console.WriteLine("ID do produto:");
                            string inputId = Console.ReadLine();
                            if (int.TryParse(inputId, out idProdutoRemover) && idProdutoRemover > 0)
                            {
                                break; // Entrada válida
                            }
                            Console.WriteLine("ID do produto inválido. Por favor, insira um número inteiro positivo.");
                        }

                        try
                        {
                            repositorioProdutos.Remover(idProdutoRemover);
                            gestorStocks.AtualizarStock();
                            Console.WriteLine("Produto removido com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao remover o produto: {ex.Message}");
                        }

                        break;
                    case "4":
                        Console.WriteLine("Remover Stock:");

                        int idProdutoRemoverStock;
                        while (true)
                        {
                            Console.WriteLine("ID do produto:");
                            string inputId = Console.ReadLine();
                            if (int.TryParse(inputId, out idProdutoRemoverStock) && idProdutoRemoverStock > 0)
                            {
                                break; // Entrada válida
                            }
                            Console.WriteLine("ID do produto inválido. Por favor, insira um número inteiro positivo.");
                        }

                        int quantidadeRemover;
                        while (true)
                        {
                            Console.WriteLine("Quantidade:");
                            string inputQuantidade = Console.ReadLine();
                            if (int.TryParse(inputQuantidade, out quantidadeRemover) && quantidadeRemover > 0)
                            {
                                break; // Entrada válida
                            }
                            Console.WriteLine("Quantidade inválida. Por favor, insira um número inteiro positivo.");
                        }

                        try
                        {
                            gestorStocks.RemoverStock(idProdutoRemoverStock, quantidadeRemover);
                            Console.WriteLine("Stock removido com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao remover stock: {ex.Message}");
                        }

                        break;
                    case "5":
                        Console.WriteLine("Listar Produtos:");
                        var produtos = repositorioProdutos.ObterTodos();
                        foreach (var produto in produtos)
                        {
                            Console.WriteLine(produto);
                        }
                        break;
                    case "6":
                        Console.WriteLine("Listar Stock:");
                        var stock = gestorStocks.ObterStock();
                        foreach (var item in stock)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                        break;
                    case "7":
                        Console.WriteLine("Atualizar Produto:");

                        int idProdutoAtualizar;
                        while (true)
                        {
                            Console.WriteLine("ID do produto:");
                            string inputId = Console.ReadLine();
                            if (int.TryParse(inputId, out idProdutoAtualizar) && idProdutoAtualizar > 0)
                            {
                                break; // Entrada válida
                            }
                            Console.WriteLine("ID do produto inválido. Por favor, insira um número inteiro positivo.");
                        }

                        string nomeAtualizar;
                        do
                        {
                            Console.WriteLine("Nome:");
                            nomeAtualizar = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(nomeAtualizar))
                            {
                                Console.WriteLine("Nome inválido. Por favor, insira um nome.");
                            }
                        } while (string.IsNullOrWhiteSpace(nomeAtualizar));

                        double precoAtualizar;
                        while (true)
                        {
                            Console.WriteLine("Preço:");
                            string inputPreco = Console.ReadLine();
                            if (double.TryParse(inputPreco, out precoAtualizar) && precoAtualizar > 0)
                            {
                                break; // Entrada válida
                            }
                            Console.WriteLine("Preço inválido. Por favor, insira um valor numérico positivo.");
                        }

                        string descricaoAtualizar;
                        do
                        {
                            Console.WriteLine("Descrição:");
                            descricaoAtualizar = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(descricaoAtualizar))
                            {
                                Console.WriteLine("Descrição inválida. Por favor, insira uma descrição.");
                            }
                        } while (string.IsNullOrWhiteSpace(descricaoAtualizar));

                        string categoriaAtualizar;
                        do
                        {
                            Console.WriteLine("Categoria:");
                            categoriaAtualizar = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(categoriaAtualizar))
                            {
                                Console.WriteLine("Categoria inválida. Por favor, insira uma categoria.");
                            }
                        } while (string.IsNullOrWhiteSpace(categoriaAtualizar));

                        try
                        {
                            Produto produto = repositorioProdutos.ObterPorID(idProdutoAtualizar);
                            produto.Nome = nomeAtualizar;
                            produto.Preco = precoAtualizar;
                            produto.Descricao = descricaoAtualizar;
                            produto.Categoria = categoriaAtualizar;
                            repositorioProdutos.Atualizar(produto);
                            Console.WriteLine("Produto atualizado com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao atualizar o produto: {ex.Message}");
                        }
                        break;
                    case "8":
                        Console.WriteLine("Listar Utilizadores:");
                        var utilizadores = repositorioUtilizador.ObterTodos();
                        foreach (var utilizador in utilizadores)
                        {
                            Console.WriteLine(utilizador);
                        }
                        break;
                    case "9":
                        Console.WriteLine("Criar Utilizador:");
                        string nomeUtilizador;
                        do
                        {
                            Console.WriteLine("Nome:");
                            nomeUtilizador = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(nomeUtilizador))
                            {
                                Console.WriteLine("Nome inválido. Por favor, insira um nome.");
                            }
                        } while (string.IsNullOrWhiteSpace(nomeUtilizador));
                        string emailUtilizador;
                        do
                        {
                            Console.WriteLine("Email:");
                            emailUtilizador = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(emailUtilizador))
                            {
                                Console.WriteLine("Email inválido. Por favor, insira um email.");
                            }
                        } while (string.IsNullOrWhiteSpace(emailUtilizador));
                        string passwordUtilizador;
                        do
                        {
                            Console.WriteLine("Password:");
                            passwordUtilizador = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(passwordUtilizador))
                            {
                                Console.WriteLine("Password inválida. Por favor, insira uma password.");
                            }
                        } while (string.IsNullOrWhiteSpace(passwordUtilizador));
                        try
                        {
                            Utilizador utilizador = new Utilizador(nomeUtilizador, passwordUtilizador, emailUtilizador);
                            repositorioUtilizador.Adicionar(utilizador);
                            Console.WriteLine("Utilizador criado com sucesso!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao criar o utilizador: {ex.Message}");
                        }
                        break;
                    case "10":
                        Console.WriteLine("Remover Utilizador:");
                        int idUtilizadorRemover;
                        while (true)
                        {
                            Console.WriteLine("ID do utilizador:");
                            string inputId = Console.ReadLine();
                            if (int.TryParse(inputId, out idUtilizadorRemover) && idUtilizadorRemover > 0)
                            {
                                break; // Entrada válida
                            }
                            Console.WriteLine("ID do utilizador inválido. Por favor, insira um número inteiro positivo.");
                        }
                        try
                        {
                            string emailUtilizadorRemover;
                            foreach (var x in repositorioUtilizador.ObterTodos())
                            {
                                if (x.Id == idUtilizadorRemover)
                                {
                                    emailUtilizadorRemover = x.Email;
                                    repositorioUtilizador.Remover(emailUtilizadorRemover);
                                    Console.WriteLine("Utilizador removido com sucesso!");
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao remover o utilizador: {ex.Message}");
                        }
                        break;
                    case "11":
                        Console.WriteLine("Atualizar Utilizador:");
                        int idUtilizadorAtualizar;
                        while (true)
                        {
                            Console.WriteLine("ID do utilizador:");
                            string inputId = Console.ReadLine();
                            if (int.TryParse(inputId, out idUtilizadorAtualizar) && idUtilizadorAtualizar > 0)
                            {
                                break; // Entrada válida
                            }
                            Console.WriteLine("ID do utilizador inválido. Por favor, insira um número inteiro positivo.");
                        }
                        string nomeUtilizadorAtualizar;
                        do
                        {
                            Console.WriteLine("Nome:");
                            nomeUtilizadorAtualizar = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(nomeUtilizadorAtualizar))
                            {
                                Console.WriteLine("Nome inválido. Por favor, insira um nome.");
                            }
                        } while (string.IsNullOrWhiteSpace(nomeUtilizadorAtualizar));
                        string emailUtilizadorAtualizar;
                        do
                        {
                            Console.WriteLine("Email:");
                            emailUtilizadorAtualizar = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(emailUtilizadorAtualizar))
                            {
                                Console.WriteLine("Email inválido. Por favor, insira um email.");
                            }
                        } while (string.IsNullOrWhiteSpace(emailUtilizadorAtualizar));
                        string passwordUtilizadorAtualizar;
                        do
                        {
                            Console.WriteLine("Password:");
                            passwordUtilizadorAtualizar = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(passwordUtilizadorAtualizar))
                            {
                                Console.WriteLine("Password inválida. Por favor, insira uma password.");
                            }
                        } while (string.IsNullOrWhiteSpace(passwordUtilizadorAtualizar));
                        try
                        {
                            utilizadores = repositorioUtilizador.ObterTodos();
                            foreach (var item in utilizadores)
                            {
                                if (item.Id == idUtilizadorAtualizar)
                                {
                                    Utilizador utilizador = item;
                                    utilizador.Nome = nomeUtilizadorAtualizar;
                                    utilizador.Email = emailUtilizadorAtualizar;
                                    utilizador.Password = passwordUtilizadorAtualizar;
                                    repositorioUtilizador.Atualizar(utilizador);
                                    Console.WriteLine("Utilizador atualizado com sucesso!");
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erro ao atualizar o utilizador: {ex.Message}");
                        }

                        break;

                    case "12":
                        Console.WriteLine("Estatísticas de vendas por utilizador:");
                        Console.WriteLine("Insira o ID do utilizador:");
                        int idUtilizadorEstatisticas;
                        while (true)
                        {
                            Console.WriteLine("ID do utilizador:");
                            string inputId = Console.ReadLine();
                            if (int.TryParse(inputId, out idUtilizadorEstatisticas) && idUtilizadorEstatisticas > 0)
                            {
                                break; // Entrada válida
                            }
                            Console.WriteLine("ID do utilizador inválido. Por favor, insira um número inteiro positivo.");
                        }
                        var comprasPorUtilizador = historicoCompras.ObterPorUtilizador(idUtilizadorEstatisticas);
                        double valorTotal = 0.0;
                        foreach (var item in comprasPorUtilizador)
                        {
                            Console.WriteLine($"{item}");
                            valorTotal += item.ValorTotal;

                        }
                        Console.WriteLine($"Valor total das compras: {valorTotal}");
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
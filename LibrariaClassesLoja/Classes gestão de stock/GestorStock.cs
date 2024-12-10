namespace LibrariaClassesLoja
{
    public class GestorStock
    {
        private RepositorioProduto repositorioProduto;
        private static Dictionary<Produto, int> stock = new Dictionary<Produto, int>();

        public GestorStock(RepositorioProduto repositorioProduto)
        {
            this.repositorioProduto = repositorioProduto;
        }

        public void InicializarStock()
        {
            var produtos = repositorioProduto.ObterTodos();
            foreach (var produto in produtos)
            {
                stock.Add(produto, 0);
            }
        }

        public Dictionary<Produto, int> ObterStock()
        {
            return stock;
        }
        public void AtualizarStock()
        {
            var produtos = repositorioProduto.ObterTodos();
            foreach (var produto in produtos)
            {
                if (!stock.ContainsKey(produto))
                {
                    stock.Add(produto, 0);
                }
            }
            // Remove produtos que não existem no repositório
            var produtosRemover = stock.Keys.Except(produtos);
            foreach (var produto in produtosRemover)
            {
                stock.Remove(produto);
            }
        }
        public void AdicionarStock(int id, int quantidade)
        {
            var produto = repositorioProduto.ObterPorID(id);
            if (produto == null)
                throw new Exception("Produto não encontrado.");

            if (stock.ContainsKey(produto))
            {
                stock[produto] += quantidade;
            }
            else
            {
                stock.Add(produto, quantidade);
            }
        }
        public void RemoverStock(int id, int quantidade)
        {
            var produto = repositorioProduto.ObterPorID(id);
            if (produto == null)
                throw new Exception("Produto não encontrado.");

            if (stock.ContainsKey(produto))
            {
                if (stock[produto] < quantidade)
                {
                    throw new Exception("Quantidade insuficiente no estoque.");
                }

                stock[produto] -= quantidade;

                if (stock[produto] <= 0)
                {
                    stock[produto] = 0;
                }
            }
            else
            {
                throw new Exception("Produto não encontrado no estoque.");
            }
        }
    }
}
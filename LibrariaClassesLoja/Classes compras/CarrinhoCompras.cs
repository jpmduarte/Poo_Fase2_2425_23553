namespace LibrariaClassesLoja
{
    public class CarrinhoCompras
    {
        private RepositorioProduto repositorioProduto;
        private GestorStock gestorStock;
        private List<Produto> carrinho = new List<Produto>();


        public CarrinhoCompras(GestorStock gestorStock, RepositorioProduto repositorioProduto)
        {
            this.gestorStock = gestorStock;
            this.repositorioProduto = repositorioProduto;

        }
        public void AdicionarProduto(Produto produto)
        {
            try
            {
                if (gestorStock.ObterStock().ContainsKey(produto) && gestorStock.ObterStock()[produto] == 0)
                {
                    throw new Exception("Produto sem stock.");
                }
                else if (repositorioProduto.ObterPorID(produto.Id) == null)
                {
                    throw new Exception("Produto não encontrado.");
                }
                carrinho.Add(produto);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public void RemoverProdutoCarrinho(Produto produto)
        {
            try
            {
                carrinho.Remove(produto);
            }
            catch (Exception)
            {
                throw new Exception("Produto não encontrado no carrinho.");
            }
            System.Console.WriteLine("Produto removido com sucesso.");
        }
        public double precoTotal()
        {
            double total = 0;
            foreach (var produto in carrinho)
            {
                total += produto.Preco;
            }
            return total;
        }
        public IEnumerable<Produto> ObterProdutos()
        {
            return carrinho;
        }
        public void LimparCarrinho()
        {
            carrinho.Clear();
        }
    }
}
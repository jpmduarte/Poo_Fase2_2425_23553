namespace LibrariaClassesLoja
{
    public class Compra
    {
        private static int contador = 0;

        private readonly int id;
        private readonly Utilizador utilizador;
        private readonly DateTime dataDaCompra;
        private readonly double valorTotal;
        private readonly CarrinhoCompras carrinhoCompras;

        public Compra(Utilizador utilizador, CarrinhoCompras carrinhoCompras)
        {
            if (utilizador == null)
                throw new ArgumentNullException(nameof(utilizador));
            if (carrinhoCompras == null || !carrinhoCompras.ObterProdutos().Any())
                throw new ArgumentException("Carrinho de compras não pode estar vazio.");

            this.id = ++contador;
            this.utilizador = utilizador;
            this.dataDaCompra = DateTime.Now;
            this.valorTotal = carrinhoCompras.precoTotal();
            this.carrinhoCompras = carrinhoCompras;
        }

        // Propriedades com getter explícito
        public int Id
        {
            get { return id; }
        }

        public Utilizador Utilizador
        {
            get { return utilizador; }
        }

        public CarrinhoCompras CarrinhoCompras
        {
            get { return carrinhoCompras; }
        }

        public DateTime DataDaCompra
        {
            get { return dataDaCompra; }
        }

        public double ValorTotal
        {
            get { return valorTotal; }
        }

        public override string ToString()
        {
            return $"Compra ID: {id}, Utilizador: {utilizador.Nome}, Data: {dataDaCompra}, Valor Total: {valorTotal} € , Produtos: {string.Join(", ", carrinhoCompras.ObterProdutos().Select(p => p.Nome))}";
        }
    }
}

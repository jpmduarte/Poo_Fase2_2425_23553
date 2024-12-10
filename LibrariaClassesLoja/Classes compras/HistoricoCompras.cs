namespace LibrariaClassesLoja
{
    public class HistoricoCompras
    {
        private static List<Compra> compras = new List<Compra>();
        public HistoricoCompras()
        {
        }
        public void Adicionar(Compra compra)
        {
            if (compra == null)
                throw new Exception("A compra não pode ser nula.");
            
            compras.Add(compra);
        }
        public IEnumerable<Compra> ObterTodos()
        {
            return compras;
        }
        public IEnumerable<Compra> ObterPorUtilizador(int idUtilizador)
        {
            return compras.Where(c => c.Utilizador.Id == idUtilizador);
        }
        public IEnumerable<Compra> ObterPorProduto(int idProduto)
        {
            return compras.Where(c => c.CarrinhoCompras.ObterProdutos().Any(p => p.Id == idProduto));
        }
        public IEnumerable<Compra> ObterPorData(DateTime data)
        {
            return compras.Where(c => c.DataDaCompra == data);
        }
        public IEnumerable<Compra> ObterPorValor(double valor)
        {
            return compras.Where(c => c.ValorTotal == valor);
        }
        public void Remover(int id)
        {
            var compra = compras.FirstOrDefault(c => c.Id == id);
            if (compra == null)
                throw new Exception("Compra não encontrada.");
            
            compras.Remove(compra);
        }
    }
}
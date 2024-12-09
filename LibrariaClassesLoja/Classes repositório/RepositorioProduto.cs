namespace LibrariaClassesLoja
{
    public class RepositorioProduto : IRepositorioObjetos<Produto>
    {
        private static List<Produto> produtos = new List<Produto>();
        public RepositorioProduto()
        {
        }
        public void Adicionar(Produto item)
        {
            if (item == null)
                throw new Exception("O produto não pode ser nulo.");
            
            produtos.Add(item);
        }
        public void Atualizar(Produto item)
        {
            if (item == null)
                throw new Exception("O produto não pode ser nulo.");

            var indice = produtos.FindIndex(p => p.Id == item.Id);
            if (indice == -1)
                throw new Exception("Produto não encontrado.");

            produtos[indice] = item;
        }
        public  Produto ObterPorID(int Id)
        {
            return produtos.FirstOrDefault(p => p.Id == Id);
        }
        public IEnumerable<Produto> ObterTodos()
        {
            return produtos;
        }
        public void Remover(int id)
        {
            var produto = ObterPorID(id);
            if (produto == null)
                throw new Exception("Produto não encontrado.");
            
            produtos.Remove(produto);
        }

    }
}
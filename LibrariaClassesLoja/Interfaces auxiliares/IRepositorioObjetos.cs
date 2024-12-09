namespace LibrariaClassesLoja
{
    public interface IRepositorioObjetos<T>
    {
        void Adicionar(T item);
        void Atualizar(T item);
        T ObterPorID(int Id);
        IEnumerable<T> ObterTodos();

        void Remover(int id);
    }
}
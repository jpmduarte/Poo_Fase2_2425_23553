namespace LibrariaClassesLoja
{
    public interface IRepositorioUtilizadores<T>
    {
        void Adicionar(T item);
        void Atualizar(T item);
        T ObterPorEmail(string email);
        IEnumerable<T> ObterTodos();
        void Remover(string email);
    }
}
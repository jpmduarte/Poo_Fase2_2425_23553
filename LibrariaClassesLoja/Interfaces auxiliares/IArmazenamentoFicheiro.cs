namespace LibrariaClassesLoja
{
    public interface IArmazenamentoFicheiro<T>
    {
        void GuardarParaFicheiro(List<T> utilizadores, string path);
        List<T> LoadParaFicheiro(string path);
    }
}

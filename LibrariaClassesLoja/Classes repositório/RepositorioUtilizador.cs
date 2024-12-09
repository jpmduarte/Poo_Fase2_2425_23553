namespace LibrariaClassesLoja
{
    public class RepositorioUtilizador : IRepositorioUtilizadores<Utilizador>
    {
        // Lista  para armazenar os Utilizadores
        private static List<Utilizador> utilizadores = new List<Utilizador>();
        public RepositorioUtilizador()
        {
        }
        public void Adicionar(Utilizador item)
        {
            if (item == null)
                throw new Exception("O utilizador não pode ser nulo.");
            
            utilizadores.Add(item);
        }

        public void Atualizar(Utilizador item)
        {
            if (item == null)
                throw new Exception("O utilizador não pode ser nulo.");

            // Encontra o index do Utilizador para atualizar
            var indice = utilizadores.FindIndex(u => u.Id == item.Id);
            if (indice == -1)
                throw new Exception("Utilizador não encontrado.");

            // Substitui o Utilizador antigo pelo atualizado
            utilizadores[indice] = item;
        }

        public Utilizador ObterPorEmail(string email)
        {
            return utilizadores.FirstOrDefault(u => u.Email == email);
        }

        public IEnumerable<Utilizador> ObterTodos()
        {
            return utilizadores;
        }

        public void Remover(string email)
        {
            var utilizador = ObterPorEmail(email);
            if (utilizador == null)
                throw new Exception("Utilizador não encontrado.");
            
            utilizadores.Remove(utilizador);
        }
    }
}

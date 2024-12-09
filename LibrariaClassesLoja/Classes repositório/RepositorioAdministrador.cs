namespace LibrariaClassesLoja
{
    public class RepositorioAdministrador : IRepositorioUtilizadores<Administrador>
    {
        private static List<Administrador> administradores;
        public RepositorioAdministrador()
        {
            administradores = new List<Administrador>();
        }
        public void Adicionar(Administrador item)
        {
            if (item == null)
                throw new Exception("O administrador não pode ser nulo.");
            administradores.Add(item);
        }
        public void Atualizar(Administrador item)
        {
            if (item == null)
                throw new Exception("O utilizador não pode ser nulo.");

            // Encontra o index do Utilizador para atualizar
            var indice = administradores.FindIndex(u => u.Id == item.Id);
            if (indice == -1)
                throw new Exception("Utilizador não encontrado.");

            // Substitui o Utilizador antigo pelo atualizado
            administradores[indice] = item;
        }
        public Administrador ObterPorEmail(string email)
        {
            return administradores.FirstOrDefault(u => u.Email == email);
        }
        public IEnumerable<Administrador> ObterTodos()
        {
            return administradores;
        }
        public void Remover(string email)
        {
            var administrador = ObterPorEmail(email);
            if (administrador == null)
                throw new Exception("Utilizador não encontrado.");
            administradores.Remove(administrador);
            
        }
        
    }
}
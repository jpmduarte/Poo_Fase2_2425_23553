namespace LibrariaClassesLoja
{
    public class Administrador : Pessoa
    {
        private static int contador = 0;
        private int id;
        public Administrador(string nome, string password, string email) : base(nome, password,email)
        {
            this.id = ++contador;
        }

        public int Id
        {
            get { return id; }
        }
    }
}
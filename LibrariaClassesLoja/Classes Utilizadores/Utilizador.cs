using System;

namespace LibrariaClassesLoja
{
    public class Utilizador : Pessoa
    {
        private static int contador = 0;
        private int id;
        public Utilizador(string nome, string password, string email) : base(nome, password, email)
        {
            this.id = ++contador;
        }
        public int Id
        {
            get { return id; }
        }
    }
}

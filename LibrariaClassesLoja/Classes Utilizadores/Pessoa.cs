namespace LibrariaClassesLoja
{
    public abstract class Pessoa
    {
        // atributos
        private string id;
        private string nome = ""; // inicialização para remover aviso CS8618
        private string password = ""; // inicialização para remover aviso CS8618

        private string email = ""; // inicialização para remover aviso CS8618
        // construtor
        public Pessoa(string nome, string password, string email)
        {
            this.Nome = nome;
            this.Password = password;
            this.Email = email;
        }
        // propriedades
        public string Email
        {
            get { return email; }
            set
            {
                if (Validacoes.VerificarEmailValido(value))
                {
                    email = value;
                }
                else
                {
                    throw new ArgumentException("O email não é válido.");
                }
            }
        }
        public string Nome
        {
            get { return nome;}
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    nome = value;
                }
                else
                {
                    throw new ArgumentException("O nome não pode ser nulo.");
                }
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (Validacoes.VerificarPasswordValida(value))
                {
                    password = value;
                }
                else
                {
                    throw new ArgumentException("A senha não atende aos requisitos de segurança.");
                }
            }
        }
    }
}

namespace LibrariaClassesLoja
{
    public class Produto
    {
        // atributos
        private int id;
        private static int contador = 0;
        private string nome = ""; // inicialização para remover aviso CS8618
        private double preco;
        private string descricao = ""; // inicialização para remover aviso CS8618
        // construtor
        public Produto(string nome, double preco, string descricao)
        {
            this.id = ++contador;
            this.Nome = nome;
            this.Preco = preco;
            this.Descricao = descricao;
        }
        // propriedades
        public int Id
        {
            get { return id; }
        }
        public string Nome
        {
            get { return nome; }
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
        public double Preco
        {
            get { return preco; }
            set
            {
                if (value > 0)
                {
                    preco = value;
                }
                else
                {
                    throw new ArgumentException("O preço tem de ser superior a 0.");
                }
            }
        }
       
        public string Descricao
        {
            get { return descricao; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    descricao = value;
                }
                else
                {
                    throw new ArgumentException("A descrição não pode ser nula.");
                }
            }
        }
    }
}
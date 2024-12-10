using System;

namespace LibrariaClassesLoja
{
    public class Utilizador : Pessoa
    {
        private static int contador = 0;
        private int id;

        private double saldo;
        public Utilizador(string nome, string password, string email) : base(nome, password, email)
        {
            this.id = ++contador;
        }
        public double Saldo
        {
            get { return saldo; }
            set
            {
                if (value > 0)
                {
                    saldo = value;
                }
                else
                {
                    throw new ArgumentException("O saldo não pode ser negativo.");
                }
            }
        }
        public int Id
        {
            get { return id; }
        }

        public void CarregarConta(int valor)
        {
            if (valor > 0)
            {
                saldo += valor;
            }
            else
            {
                throw new ArgumentException("O valor a adicionar deve ser positivo.");
            }
        }
        public void Pagar(int valor)
        {
            if (valor > 0)
            {
                saldo -= valor;
            }
            else
            {
                throw new ArgumentException("O valor a remover deve ser positivo.");
            }
        }

        public override string ToString()
        {
            return $"Utilizador ID: {id}, Nome: {Nome}, Email: {Email}";
        }
    }
}

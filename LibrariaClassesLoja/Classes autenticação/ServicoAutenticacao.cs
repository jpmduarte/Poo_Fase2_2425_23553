namespace LibrariaClassesLoja
{
    public class ServicoAutenticacao
{
    private RepositorioUtilizador repositorioUtilizador;
    private RepositorioAdministrador repositorioAdministrador;
    public ServicoAutenticacao(RepositorioUtilizador repositorioUtilizador, RepositorioAdministrador repositorioAdministrador)
    {
        this.repositorioUtilizador = repositorioUtilizador;
        this.repositorioAdministrador = repositorioAdministrador;
    }
    public Utilizador AutenticarUtilizador(string email, string password)
    {
        Utilizador utilizador = repositorioUtilizador.ObterPorEmail(email);
        if (utilizador == null)
        {
            return null;
        }
        if (utilizador.Password == password)
        {
            return utilizador;
        }
        return null;
    }
    public Administrador AutenticarAdministrador(string email, string password)
    {
        Administrador administrador = repositorioAdministrador.ObterPorEmail(email);
        if (administrador == null)
        {
            return null;
        }
        if (administrador.Password == password)
        {
            return administrador;
        }
        return null;
    }
}

}
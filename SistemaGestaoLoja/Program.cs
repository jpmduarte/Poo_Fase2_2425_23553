using LibrariaClassesLoja;
using System;

class Program
{
    static void Main()
    {
        HistoricoCompras historicoCompras = new HistoricoCompras();
        RepositorioAdministrador repositorioAdministrador = new RepositorioAdministrador();
        try
        {
            Administrador administrador = new Administrador("admin","Admin123.","admin@admin.pt");
            repositorioAdministrador.Adicionar(administrador);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        RepositorioUtilizador repositorioUtilizador = new RepositorioUtilizador();
        
        RepositorioProduto repositorioProduto = new RepositorioProduto();
        GestorStock gestorStock = new GestorStock(repositorioProduto);
        gestorStock.InicializarStock();
        MenuPrincipal menuPrincipal = new MenuPrincipal(repositorioUtilizador, repositorioAdministrador,repositorioProduto, gestorStock, historicoCompras);
        menuPrincipal.Mostrar();
    }
}

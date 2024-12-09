using System;
using System.Collections.Generic;
using System.IO;

namespace LibrariaClassesLoja
{
    public class ArmazenamentoUtilizadoresFicheiro : IArmazenamentoFicheiro<Utilizador>
    {
        private List<Utilizador> utilizadores;
        public ArmazenamentoUtilizadoresFicheiro(List<Utilizador> utilizadores)
        {
            this.utilizadores = utilizadores;
        }
        public void GuardarParaFicheiro(List<Utilizador> utilizadores, string path)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(path);
                foreach (var utilizador in utilizadores)
                {
                    writer.WriteLine($"{utilizador.Nome};{utilizador.Password};{utilizador.Email}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar os utilizadores: {ex.Message}");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close(); 
                }
            }
        }
        public List<Utilizador> LoadParaFicheiro(string path)
        {
            List<Utilizador> utilizadoresCarregados = new List<Utilizador>();
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(path);
                string linha;
                while ((linha = reader.ReadLine()) != null)
                {
                    var dados = linha.Split(';');
                    var utilizador = new Utilizador(dados[0], dados[1], dados[2]);
                    utilizadoresCarregados.Add(utilizador);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar utilizadores: {ex.Message}");
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return utilizadoresCarregados;
        }
    }
}

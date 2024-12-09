using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibrariaClassesLoja
{
    public class Validacoes
    {
        /// <summary>
        /// Verifica se a palavra-passe fornecida é válida.
        /// </summary>
        /// <param name="password">A palavra-passe a ser verificada.</param>
        /// <returns>
        /// <c>true</c> se a palavra-passe for válida; caso contrário, 
        /// <c>false</c>.
        /// A palavra-passe é considerada válida se contiver pelo menos 8 caracteres,
        /// pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.
        /// </returns>
        public static bool VerificarPasswordValida(string password)
        {
            // A palavra-passe deve conter pelo menos 8 caracteres, 
            //pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial
            string expressaoRegexPassword = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*(),.?]).{8,}$";
            Regex rg = new Regex(expressaoRegexPassword);
            return rg.IsMatch(password);
        }
        
        /// <summary>
        /// Verifica se o email fornecido é válido.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>
        /// <c>true</c> se o email for válido; caso contrário,
        /// <c>false</c>.
        /// </returns>
        public static bool VerificarEmailValido(string email)
        {
            string expressaoEmailValido = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex rg = new Regex(expressaoEmailValido);
            return rg.IsMatch(email);
        }
    }
}

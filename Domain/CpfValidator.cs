using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class CpfValidator
    {
        public static bool IsValidCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            // Remove caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais (ex.: 111.111.111-11)
            if (cpf.All(c => c == cpf[0]))
                return false;

            // Calcula e verifica os dois dígitos verificadores
            var firstVerifier = CalculateVerifierDigit(cpf, 10);
            var secondVerifier = CalculateVerifierDigit(cpf, 11);

            return cpf[9] == firstVerifier && cpf[10] == secondVerifier;
        }

        private static char CalculateVerifierDigit(string cpf, int multiplier)
        {
            var sum = 0;
            for (int i = 0; i < multiplier - 1; i++)
            {
                sum += (cpf[i] - '0') * multiplier--;
            }

            var remainder = sum % 11;
            return remainder < 2 ? '0' : (char)((11 - remainder) + '0');
        }
    }
}

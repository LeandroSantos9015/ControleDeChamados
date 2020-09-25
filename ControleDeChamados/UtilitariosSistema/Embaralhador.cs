using Customizados.Mensagem;
using System;
using System.Collections.Generic;
using System.Linq;
using UtilitariosSistema;

namespace Customizados
{
    public static class Embaralhador
    {
        public static string Embaralha(string bloco16, int calc, string data)
        {
            //         1234 1234 1234 1234 
            //bloco16 = "BFEB-FBFF-0009-06EA";

            bloco16 = bloco16.RemoverPontoTraco();
            data = data.RemoverPontoTraco();

            //calc = 1; // 1, 2, 3, 4; pegar o caracter do reset e joga no começo da string de retorno
            //BFOO -- FB06 -- EF0E -- BF9A   <- primeiro bloco
            //1
            //EFFBDF
            //BF00-EFFB-DF01-xxxx
            IDictionary<string, string> chave = new Dictionary<string, string>();

            chave.Add("0", "F"); chave.Add("1", "E"); chave.Add("2", "D"); chave.Add("3", "C"); chave.Add("4", "B"); chave.Add("5", "A");
            chave.Add("6", "9"); chave.Add("7", "8"); chave.Add("8", "7"); chave.Add("9", "6"); chave.Add("A", "5"); chave.Add("B", "4");
            chave.Add("C", "3"); chave.Add("D", "2"); chave.Add("E", "1"); chave.Add("F", "0");

            string retorno = Calc(calc, bloco16);

            char[] c = data.ToCharArray();

            for (int i = 0; i < c.Length; i++)
                retorno += chave.Where(x => x.Key.Equals(c[i].ToString())).FirstOrDefault().Value;

            retorno = retorno + "0" + calc.ToString();

            string cifra = retorno.UtilCifrar();

            retorno += cifra.ToUpper().Substring(0, 4);

            return retorno;
        }

        private static string Calc(int n, string texto)
        {
            return texto.Substring(-1 + n, 1) +
                texto.Substring(3 + n, 1) +
                texto.Substring(7 + n, 1) +
                texto.Substring(11 + n, 1);
        }

        public static bool VerificaValidadeChave(string bloco16)
        {
            bloco16 = bloco16.RemoverPontoTraco();

            if (bloco16.Length < 16) return false;

            string cifragem = bloco16.Substring(0, 12).UtilCifrar().Substring(0, 4).ToUpper();
            string cifrado = bloco16.Substring(12, 4);

            if (!cifrado.Equals(cifragem))
            {
                CtrlMensagem.Informacao($"A chave {bloco16.ValidacaoSimples(4, "-")} é inválida ", "");
                return false;
            }

            IDictionary<string, string> chave = new Dictionary<string, string>();

            chave.Add("0", "F"); chave.Add("1", "E"); chave.Add("2", "D"); chave.Add("3", "C"); chave.Add("4", "B"); chave.Add("5", "A");
            chave.Add("6", "9"); chave.Add("7", "8"); chave.Add("8", "7"); chave.Add("9", "6"); chave.Add("A", "5"); chave.Add("B", "4");
            chave.Add("C", "3"); chave.Add("D", "2"); chave.Add("E", "1"); chave.Add("F", "0");

            return true;
        }

        public static bool DescriptografaData(string bloco16)
        {
            string dataCrip = bloco16.Substring(4, 6);
            string retorno = "";

            IDictionary<string, string> chave = new Dictionary<string, string>();

            chave.Add("0", "F"); chave.Add("1", "E"); chave.Add("2", "D"); chave.Add("3", "C"); chave.Add("4", "B"); chave.Add("5", "A");
            chave.Add("6", "9"); chave.Add("7", "8"); chave.Add("8", "7"); chave.Add("9", "6"); chave.Add("A", "5"); chave.Add("B", "4");
            chave.Add("C", "3"); chave.Add("D", "2"); chave.Add("E", "1"); chave.Add("F", "0");

            char[] c = dataCrip.ToCharArray();

            for (int i = 0; i < c.Length; i++)
                retorno += chave.Where(x => x.Key.Equals(c[i].ToString())).FirstOrDefault().Value;

            retorno = retorno.ToString().ValidacaoSimples(2, "-");

            return DateTime.TryParse(retorno, out DateTime date);
        }

        public static DateTime RetornaDataDescripto(string bloco16)
        {
            string dataCrip = bloco16.Substring(4, 6);
            string retorno = "";

            IDictionary<string, string> chave = new Dictionary<string, string>();

            chave.Add("0", "F"); chave.Add("1", "E"); chave.Add("2", "D"); chave.Add("3", "C"); chave.Add("4", "B"); chave.Add("5", "A");
            chave.Add("6", "9"); chave.Add("7", "8"); chave.Add("8", "7"); chave.Add("9", "6"); chave.Add("A", "5"); chave.Add("B", "4");
            chave.Add("C", "3"); chave.Add("D", "2"); chave.Add("E", "1"); chave.Add("F", "0");

            char[] c = dataCrip.ToCharArray();

            for (int i = 0; i < c.Length; i++)
                retorno += chave.Where(x => x.Key.Equals(c[i].ToString())).FirstOrDefault().Value;

            retorno = retorno.ToString().ValidacaoSimples(2, "-");

            DateTime.TryParse(retorno, out DateTime date);

            return date;
        }

        public static bool VerificaProcessadorComChave(string chave)
        {
            string serial = Processos.ProcessadorSerial();
            //0123 4567 89

            Int32.TryParse(chave.Substring(10, 2), out Int32 calc);

            string valida = Calc(calc, serial);

            return chave.StartsWith(valida);

        }
    }
}
using Mensagens.Mensagem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controladores.Excecoes
{
    public class CtrlExcecoes : Exception
    {

        /// <summary>
        /// Testador de futuro controle de exceçõs
        /// </summary>
        /// <param name="excep"></param>
        public static void Excecao(Exception excep, string local)
        {
            LogExcecoes(excep.ToString());
            CtrlMensagem.ErroDesconhecido(local, "Exceção", excep.ToString());

        }

        private static void LogExcecoes(string excecao)
        {
            string dir = Environment.CurrentDirectory;
            string pasta = Environment.CurrentDirectory + @"\Logs";

            string arquivo = $@"{pasta}\{DateTime.Now.ToString("yyyy;MM")}.txt";

            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            FileStream arq = File.Open(arquivo, FileMode.OpenOrCreate);

            arq.Position = arq.Length;

            StreamWriter salvar = new StreamWriter(arq);

            string gravacao = @"Exceção ocorrida em: " + DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss") + "\n" + excecao + "\n";

            salvar.WriteLine(gravacao);
            salvar.Close();
        }

    }
}

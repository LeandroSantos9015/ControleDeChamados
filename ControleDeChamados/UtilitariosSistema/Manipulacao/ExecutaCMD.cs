using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosSistema.Manipulacao
{
    public static class ExecutaCMD
    {

        public static void Teste()
        {
            string saida = ExecutarCMD("net start MSSQL$SQLSERVER");
            // File.WriteAllText("NomeArquivo.txt", saida);

            //MSSQL$ + instancia
        }


        public static string ExecutarCMD(string comando)
        {
            using (Process processo = new Process())
            {
                processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");

                // Formata a string para passar como argumento para o cmd.exe
                processo.StartInfo.Arguments = string.Format("/c net start MSSQL${0}", comando.ToUpper());

                processo.StartInfo.RedirectStandardOutput = true;
                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.CreateNoWindow = true;

                processo.Start();
                //processo.WaitForExit();

                string saida = processo.StandardOutput.ReadToEnd();
                return saida;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;

namespace UtilitariosSistema
{
    public static class GerarArquivoDeTexto 
    {

       static StreamWriter st;

        //public static GerarArquivoDeTexto(string caminho, string dir, string sub)
        //{
        //    DirectoryInfo dic = new DirectoryInfo(dir);
        //    DirectoryInfo subDic = new DirectoryInfo(sub);

        //    subDic.Create();
        //    dic.Create();

        //    st = new StreamWriter(caminho);
        //}

        public static void GravarInformacoes(string conteudo) { st.WriteLine(conteudo); }

        public static void FecharArquivo() { st.Close(); }

        public static string LerArquivoXml(this object obj, string nomeArquivo = null)
        {
            try
            {
                foreach (var a in obj.GetType().CustomAttributes)
                    if (a.AttributeType.Equals(typeof(DescriptionAttribute)))
                        return

                            nomeArquivo == null ?

                               File.ReadAllText(Environment.CurrentDirectory + @"\" + a.ConstructorArguments[0].Value.ToString() + ".xml") :
                               File.ReadAllText(Environment.CurrentDirectory + @"\" + nomeArquivo + ".xml");

                return "";
            }

            catch (FileNotFoundException FileNotFoundException)
            {
              //  FileNotFoundException.ToString();

                MessageBox.Show(FileNotFoundException.Message);

                Application.Exit();

                return "";
            }

            catch (IOException exp)
            {
                MessageBox.Show(exp.Message);

                return "";
            }


        }

    }
}

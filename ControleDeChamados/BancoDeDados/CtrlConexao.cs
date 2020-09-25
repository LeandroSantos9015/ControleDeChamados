using BancoDeDados.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosSistema;

namespace BancoDeDados
{
    public class CtrlConexao
    {
        #region Conexão Principal

        private static ModelConexaoBanco conexaoBanco = null;

        public static ModelConexaoBanco RecuperaConfiguracaoPadraoPeloXml()
        {
            conexaoBanco = new ModelConexaoBanco().ArquivoXmlParaObjeto();

            if (conexaoBanco is null)
            {
                conexaoBanco = new ModelConexaoBanco();

                conexaoBanco.ArquivoPadraoSQLServer.ExportarXML();

                return conexaoBanco.ArquivoXmlParaObjeto();
            }

            return conexaoBanco;
        }

        public static ModelConexaoBanco ConexaoPadraoCache = conexaoBanco ?? RecuperaConfiguracaoPadraoPeloXml();

        public static bool SalvarArquivoDeConfiguracaoPadrao(ModelConexaoBanco conexaoBanco)
        {
            bool valor = conexaoBanco.ExportarXML();

            ConexaoPadraoCache = RecuperaConfiguracaoPadraoPeloXml();

            return valor;
        }


        #endregion
    }
}

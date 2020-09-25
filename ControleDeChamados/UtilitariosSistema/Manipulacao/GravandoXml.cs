using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace UtilitariosSistema.Manipulacao
{
    [Obsolete]
    public static class GravandoXml
    {
        [Obsolete]
        static ModelConexaoBanco modelConexBanco = new ModelConexaoBanco();

        [Obsolete]
        public static void GravarDadosBanco(ModelConexaoBanco configs)
        {

            configs.ExportarXML();

            //XmlTextWriter StwArquivo;

            //StwArquivo = new XmlTextWriter(".\\Config.xml", Encoding.UTF8);  // caminho

            //StwArquivo.WriteStartElement("ConfiguracoesBancoDeDados");
            //StwArquivo.WriteElementString("Hostname", configs.HostName);
            //StwArquivo.WriteElementString("Ip", configs.Ip);
            //StwArquivo.WriteElementString("Instancia", configs.Instancia);
            //StwArquivo.WriteElementString("Banco", configs.Banco);
            //StwArquivo.WriteElementString("Usuario", configs.Usuario);
            //StwArquivo.WriteElementString("Senha", configs.Senha);

            //StwArquivo.WriteEndElement();

            //StwArquivo.Close();
        }

        [Obsolete]
        public static ModelConexaoBanco LerDadosBanco()
        {
            string TextoFinal = "";

            ModelConexaoBanco modelConexaoBanco = new ModelConexaoBanco();

            try
            {
                string ArquivoXML = ".\\ConfiguradorSistema.xml";  // local
                XElement XML = XElement.Load(ArquivoXML);

                foreach (XElement x in XML.Elements())
                {
                 //   modelConexaoBanco.Novo = false;

                    switch (x.Name.ToString())
                    {
                        case "Hostname": modelConexaoBanco.HostName = x.Value; break;

                        case "Ip": modelConexaoBanco.Ip = x.Value; break;

                        case "Banco": modelConexaoBanco.Banco = x.Value; break;

                        case "Instancia": modelConexaoBanco.Instancia = x.Value; break;

                        case "Usuario": modelConexaoBanco.Usuario = x.Value; break;

                        case "Senha": modelConexaoBanco.Senha = x.Value; break;
                    }
                }
                XML = null;
            }
            catch (Exception ex)
            {
                TextoFinal = ex.Message;
                MessageBox.Show("ARQUIVO XML não encontrado.");
            }

            return modelConexaoBanco;
        }

        //[Obsolete]
        //public static void GravaDadosEmpresa(ModeloEmpresa emp)
        //{
        //    XmlTextWriter StwArquivo;

        //    StwArquivo = new XmlTextWriter(".\\Empresa.xml", Encoding.UTF8);  // caminho

        //    StwArquivo.WriteStartElement("Empresa");
        //    StwArquivo.WriteElementString("NomeRazao", emp.NomeRazao);
        //    StwArquivo.WriteElementString("Bairro", emp.Bairro);
        //    StwArquivo.WriteElementString("Cep", emp.Cep);
        //    StwArquivo.WriteElementString("Cidade", emp.Cidade);
        //    StwArquivo.WriteElementString("Cnpj", emp.Cnpj);
        //    StwArquivo.WriteElementString("Endereco", emp.Endereco);
        //    StwArquivo.WriteElementString("Estado", emp.Estado);

        //    StwArquivo.WriteEndElement();

        //    StwArquivo.Close();
        //}

        //public static ModeloEmpresa LerDadosEmpresa()
        //{
        //    string TextoFinal = "";

        //    ModeloEmpresa emp = new ModeloEmpresa();

        //    try
        //    {
        //        string ArquivoXML = ".\\Empresa.xml";  // local
        //        XElement XML = XElement.Load(ArquivoXML);

        //        foreach (XElement x in XML.Elements())
        //        {
        //            switch (x.Name.ToString())
        //            {
        //                case "Bairro": emp.Bairro = x.Value; break;

        //                case "Cep": emp.Cep = x.Value; break;

        //                case "Cidade": emp.Cidade = x.Value; break;

        //                case "Cnpj": emp.Cnpj = x.Value; break;

        //                case "Endereco": emp.Endereco = x.Value; break;

        //                case "Estado": emp.Estado = x.Value; break;

        //                case "Ie": emp.Ie = x.Value; break;

        //                case "NomeRazao": emp.NomeRazao = x.Value; break;

        //                case "Numero": emp.Numero = x.Value; break;
        //            }
        //        }
        //        XML = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        TextoFinal = ex.Message;
        //        MessageBox.Show("ARQUIVO XML não encontrado.");
        //    }

        //    return emp;
        //}

        /// <summary>
        /// Este metodo já tem a consulta do XML armazenada no momento em que o programa é iniciado, tornando o chamado apenas uma vez
        /// </summary>
        //public static ModelConexaoBanco ConexaoBanco() { return modelConexBanco; }

        [Obsolete]
        public static void ExecutaLeituraInicialXML() { modelConexBanco = UtilitariosSistema.Manipulacao.GravandoXml.LerDadosBanco(); }

        [Obsolete]
        private static ModelConexaoBanco Conexao;

        [Obsolete]
        public static ModelConexaoBanco ConexaoBanco()
        {
            Conexao = new ModelConexaoBanco().ArquivoXmlParaObjeto();

            if (Conexao == null)
                ConexaoPadrao().ExportarXML();

            return Conexao;
        }

        [Obsolete]
        public static ModelConexaoBanco RecuperaConexaoBanco()
        {
            if (Conexao == null || Conexao.Banco.Equals("LeandroTeste"))
            {
                MessageBox.Show("Não foi possível se comunicar com o banco de dados\nConfigure o arquivo xml corretamente e tente novamente");
                Application.Exit();

                return null;

            }
            else
            {
                return Conexao;
            }
        }

        [Obsolete]
        private static ModelConexaoBanco ConexaoPadrao()
        {
            return new ModelConexaoBanco
            {
                Banco = "LeandroTeste",
                HostName = "localhost",
                Instancia = "SQLExpress",
                Ip = "localhost",
               // Novo = false,
                Senha = "1qaz2wsX1qaz",
                Usuario = "acesso"
            };
        }

        //[Obsolete]
        //private static ModeloEmpresa EmpresaPadrao()
        //{
        //    return new ModeloEmpresa
        //    {
        //        Bairro = "Jardim Muriaé",
        //        Cep = "86220-000",
        //        Cidade = "Assaí",
        //        Cnpj = "053.414.299-07",
        //        Endereco = "Rua Jasmim",
        //        Estado = "Paraná",
        //        Ie = "ISENTO",
        //        NomeRazao = "Leandro Andrade dos Santos",
        //        Numero = "223"
        //    };
        //}

        //[Obsolete]
        //private static ModeloEmpresa Empresa;

        //[Obsolete]
        //public static ModeloEmpresa RetornaEmpresa()
        //{
        //    Empresa = new ModeloEmpresa().ArquivoXmlParaObjeto();

        //    if (Empresa == null)
        //    {
        //        EmpresaPadrao().ExportarXML();
        //        return EmpresaPadrao();
        //    }

        //    return Empresa;
        //}

        //[Obsolete]
        //public static ModeloEmpresa RecuperaEmpresa()
        //{
        //    return Empresa;
        //}

    }
}

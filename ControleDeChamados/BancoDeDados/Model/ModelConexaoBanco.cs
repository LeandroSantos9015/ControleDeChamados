using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BancoDeDados.Model
{
    [XmlRoot("ConfiguradorSistema")]
    [Description("ConfiguradorSistema")]
    public class ModelConexaoBanco
    {
        public string HostName { get; set; }

        public string Ip { get; set; }

        public string Instancia { get; set; }

        public string Banco { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        //  public bool Novo { get; set; }

        public bool Local { get; set; }

        [XmlIgnore]
        public ModelConexaoBanco ArquivoPadraoLocalDB
        {
            get
            {
                return new ModelConexaoBanco
                {
                    Banco = "BDGerenciador",
                    HostName = "192.168.1.6",
                    Instancia = @"(localdb)\Venda",
                    Ip = "192.168.1.6",
                    //Local = true,
                    Senha = "1234",
                    Usuario = "1234",
                    //   Novo = false

                };
            }
        }

        [XmlIgnore]
        public ModelConexaoBanco ArquivoPadraoSQLServer
        {
            get
            {
                return new ModelConexaoBanco
                {
                    Banco = "ControleChamados",
                    HostName = "LEANDRO-PC",
                    Instancia = "",
                    Ip = "192.168.1.6",
                    Local = false,
                    Senha = "kb74Uwfcq/DRfmAGZd8pkghc52rMpXAGBZXVQOr4pkpIpsK5nt6pDCJE+EF+47wZY8aX87eqCtt/F9vjKBHMNk8jJ/2oVXOtGBcUEMn9cb1txI0Fiv7N+LFzgcfWGJuW",
                    Usuario = "sa",


                };
            }
        }
    }
}
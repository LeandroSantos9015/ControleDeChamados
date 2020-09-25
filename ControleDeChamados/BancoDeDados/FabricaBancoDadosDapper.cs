using BancoDeDados.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    public static class FabricaBancoDadosDapper
    {
        public static String StringConexaoGerenciador()
        {
            // testar com sql server depois

            ModelConexaoBanco conex = CtrlConexao.ConexaoPadraoCache;

            if (conex.Local)
                return String.Format("Data Source={0};Initial Catalog={1};Integrated Security=true;", conex.Instancia, conex.Banco);
            else
                return String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Language=Portuguese; Connection Timeout=5",
                       conex.Instancia, conex.Banco, conex.Usuario, conex.Senha);

        }

        public static String StringConexaoServidor()
        {
            string ipServidor = "LEANDRO-PC";

#if producao
            ipServidor = "leandro.softether.net";
#endif
            ModelConexaoBanco conex = new ModelConexaoBanco
            {
                Banco = "LeandroSistemas",
                HostName = "LEANDRO-PC",
                Instancia = "",
                Ip = ipServidor,
                Usuario = "sa",
                Senha = "kb74Uwfcq/DRfmAGZd8pkghc52rMpXAGBZXVQOr4pkpIpsK5nt6pDCJE+EF+47wZY8aX87eqCtt/F9vjKBHMNk8jJ/2oVXOtGBcUEMn9cb1txI0Fiv7N+LFzgcfWGJuW"
            };

            return String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Language=Portuguese; Connection Timeout=5",
                   conex.Ip, conex.Banco, conex.Usuario, conex.Senha);

        }

    }
}

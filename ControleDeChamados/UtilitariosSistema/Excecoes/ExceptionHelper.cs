using System;
using System.Threading;
using System.Windows.Forms;
//using UtilitariosSistema.Meta.Exceptions.Base;

namespace Customizados.Excecoes
{
    /// <summary>
    /// Classe responsável em determinar certos tipos de Exceptions.
    /// </summary>
    /// <remarks>
    /// Criado por : Fábio Vendramin Guimarães
    /// Data       : 03/07/2008
    /// </remarks>
    public static class ExceptionHelper
    {
        /// <summary>
        /// Método que verifica se uma messagem de exception do NHibernate é referente a 
        /// erro de exclusão de integridade referêncial.
        /// </summary>
        /// <param name="message">Messagem do NHibernate.</param>
        /// <returns>Retorna true se o erro é de integridade referêncial e falso, caso 
        ///          contrário.
        /// </returns>
        public static bool ParserToReferenceConstraint(string message)
        {
            return message.Contains("DELETE statement conflicted with the REFERENCE constraint");
        }

        /// <summary>
        /// Define tratamento geral de exceções, 
        /// para as exceções que forem uma Meta exception apenas chama o controlador padrão para tratamento, 
        /// para demais não tratadas gera um SystemMetaException com a área padrão para tratamento.
        /// </summary>
        /// <param name="areaOcorrenciaExcecao">EArea que que identifica a ocorrência da exceção.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public static void DefinirTratamentoGeralExcecoes()
        {
            Application.ThreadException += (object sender, ThreadExceptionEventArgs threadExceptionEventArgs) =>
            {
                Exception excecaoOrigem = threadExceptionEventArgs.Exception;
                if (typeof(ABaseException).IsAssignableFrom(excecaoOrigem.GetType()))
                {
                   // ControllerExceptionMeta.TratarExcecao(excecaoOrigem);
                }
                else
                {
                    if (excecaoOrigem.Source == "DevExpress.XtraLayout.v13.2") //Exceções internas de componenetes dev express.
                        return;

                    //var systemException = new SystemMetaException(EMsgPadrao.MsgErroNaoEsperadoGenerico, EArea.MetaPosto, threadExceptionEventArgs.Exception, null);
                    //ControllerExceptionMeta.TratarExcecao(systemException);
                }
            };

            AppDomain.CurrentDomain.UnhandledException += (object sender, UnhandledExceptionEventArgs threadExceptionEventArgs) =>
            {
                try
                {
                    Exception excecaoOrigem = threadExceptionEventArgs.ExceptionObject as Exception;
                    if (excecaoOrigem != null && typeof(ABaseException).IsAssignableFrom(excecaoOrigem.GetType()))
                    {
                        //excecaoOrigem.TryCast<ABaseException>().PrioridadeCorrecao = EPrioridadeCorrecao.Urgente;
                        //ControllerExceptionMeta.TratarExcecaoModoSilencioso(excecaoOrigem);
                    }
                    else
                    {
                        //var systemException = new SystemMetaException(EMsgPadrao.MsgErroNaoEsperadoGenerico, areaOcorrenciaExcecao, excecaoOrigem, null);
                        //systemException.PrioridadeCorrecao = EPrioridadeCorrecao.Urgente;
                        //ControllerExceptionMeta.TratarExcecaoModoSilencioso(systemException);
                    }
                }
                catch (Exception ex)
                {
                    //ControllerExceptionMeta.TratarExcecaoModoSilencioso(ex);
                }
                finally
                {
                    // Environment.Exit(1);
                }
            };
        }


        public static Exception ObterUltimaInner(this Exception e)
        {
            Exception exception = e;
            while (exception is null)
            {
                exception = e;
                while (exception is null)
                {
                    exception = exception.InnerException;
                }
            }

            return exception;
        }
    }
}
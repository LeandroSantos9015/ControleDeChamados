using System;
using System.ServiceProcess;
using System.Text;
using System.Xml;

namespace UtilitariosSistema.Manipulacao
{
    public static class Servico
    {
        public static string Verificador(ModelConexaoBanco modelConexao)
        {
            string myServiceName = "MSSQL$SQLEXPRESS"; //service name of SQL Server Express
         
            if (modelConexao == null) return null;

            string instancia = modelConexao.Instancia;

            if (modelConexao.Local)
                myServiceName = "MSSQLLocalDB$" + instancia;
            else
                myServiceName = "MSSQL$" + instancia;

            string status; //service status (For example, Running or Stopped)

            Console.WriteLine("Service: " + myServiceName);

            //display service status: For example, Running, Stopped, or Paused
            ServiceController mySC = new ServiceController(myServiceName);

            try
            {
                status = mySC.Status.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Service not found. It is probably not installed. [exception=" + ex.Message + "]");
                Console.ReadLine();

                return "Stopped";

            }

            //display service status: For example, Running, Stopped, or Paused
            Console.WriteLine("Service status : " + status);

            //if service is Stopped or StopPending, you can run it with the following code.
            if (mySC.Status.Equals(ServiceControllerStatus.Stopped) | mySC.Status.Equals(ServiceControllerStatus.StopPending))
            {
                try
                {
                    Console.WriteLine("Starting the service...");
                    mySC.Start();
                    mySC.WaitForStatus(ServiceControllerStatus.Running);
                    Console.WriteLine("The service is now " + mySC.Status.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in starting the service: " + ex.Message);

                }

            }

            Console.WriteLine("Press a key to end the application...");
            Console.ReadLine();

            return status;

        }



        public static void CriarBloqueio()
        {
            XmlTextWriter StwArquivo;

            StwArquivo = new XmlTextWriter(".\\DocE.xml", Encoding.UTF8);  // caminho

            StwArquivo.WriteStartElement("Empresa");
            StwArquivo.WriteElementString("situacao", "Atualizado");

            StwArquivo.WriteEndElement();

            StwArquivo.Close();
        }

    }
}
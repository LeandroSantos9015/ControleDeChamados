using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosSistema
{
    public static class DataHora
    {
        public static string RetornaHMS()
        {
            string h = DateTime.Now.Hour.ToString();
            string m = DateTime.Now.Minute.ToString();
            string s = DateTime.Now.Second.ToString();

            if (Convert.ToInt64(h) < 10) h += "0";
            if (Convert.ToInt64(m) < 10) m += "0";
            if (Convert.ToInt64(s) < 10) s += "0";

            return String.Format("{0};{1};{2}.txt", h, m, s);
        }

        public static string HMSPadrao()
        {
            string h = DateTime.Now.Hour.ToString();
            string m = DateTime.Now.Minute.ToString();
            string s = DateTime.Now.Second.ToString();

            if (Convert.ToInt64(h) < 10) h = "0" + h;
            if (Convert.ToInt64(m) < 10) m = "0" + m;
            if (Convert.ToInt64(s) < 10) s = "0" + s;

            return String.Format("{0}:{1}:{2}", h, m, s);
        }



        public static string RetornaDiaMesAno()
        {
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string ano = DateTime.Now.Year.ToString();

            if (Convert.ToInt64(dia) < 10) dia = "0" + dia;
            if (Convert.ToInt64(mes) < 10) mes = "0" + mes;

            return String.Format("{0}-{1}-{2}", ano, mes, dia);
        }

        public static string DMAPadrao()
        {
            string dia = DateTime.Now.Day.ToString();
            string mes = DateTime.Now.Month.ToString();
            string ano = DateTime.Now.Year.ToString();

            if (Convert.ToInt64(dia) < 10) dia = "0" + dia;
            if (Convert.ToInt64(mes) < 10) mes = "0" + mes;

            return String.Format("{0}/{1}/{2}", dia, mes, ano);
        }

        public static IList<DateTime> Vencimentos(this DateTime data, long qtdParcelas, long diaVencimento)
        {
            IList<DateTime> lista = new List<DateTime>();

            string diaVencimentoString = null;
            IList<int> rangeMes = new List<int>();

            string retornoMes;

            rangeMes.Add(2); // fev
            rangeMes.Add(4); // abr
            rangeMes.Add(6); // jun
            rangeMes.Add(9); // set
            rangeMes.Add(11);// nov

            for (int i = 0; i < qtdParcelas; i++)
            {
                DateTime proximoMes = DateTime.Now.AddMonths(i + 1).Date;
                proximoMes = proximoMes.AddDays(-proximoMes.Day + 1).Date;

                if (rangeMes.Contains(proximoMes.Month) && diaVencimento > 30)
                {
                    diaVencimentoString = "30";

                    if (proximoMes.Month == 2)
                        diaVencimentoString = "28";
                }
                else
                    diaVencimentoString = diaVencimento.ToString();

                retornoMes = proximoMes.Year + "-" + proximoMes.Month + "-" + diaVencimentoString;

                lista.Add(retornoMes.ToDateTime());
            }

            return lista;

        }

    }
}

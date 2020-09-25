using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UtilitariosSistema
{
    public static class ExtensionsDateTime
    {
        /// <summary>
        /// Retorna a data por extenso ('Dia da semana', 'dia' de 'mês' de 'ano') de um DateTime passado.
        /// </summary>
        /// <param name="dateTime">DateTime que deseja pegar a data.</param>
        /// <returns>A data por extenso</returns>
        public static String PegarDataExtenso(this DateTime dateTime)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            int dia = dateTime.Day;
            int ano = dateTime.Year;
            string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(dateTime.Month));
            string diasemana = culture.TextInfo.ToTitleCase(dtfi.GetDayName(dateTime.DayOfWeek));
            return diasemana + ", " + dia + " de " + mes + " de " + ano;
        }

        /// <summary>
        /// Método para simplificar o teste de DateTime (Data e Hora) dentro de um intervalo de tempo.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataFim"></param>
        /// <returns></returns>
        public static bool Between(this DateTime data, DateTime dataInicio, DateTime dataFim)
        {
            return (data >= dataInicio && data <= dataFim);
        }

        public static DateTime GetDateOrMaxDate(this DateTime? data)
        {
            DateTime menorDataAceitaPeloSqlServer = new DateTime(1753, 1, 1);

            return data.IsNull() || menorDataAceitaPeloSqlServer > data || DateTime.MaxValue < data ? new DateTime(9999, 12, 31) : data.Value;
        }

        public static DateTime GetDateOrMinDate(this DateTime? data)
        {
            DateTime menorDataAceitaPeloSqlServer = new DateTime(1753, 1, 1);

            return data.IsNull() || menorDataAceitaPeloSqlServer > data || DateTime.MaxValue < data ? menorDataAceitaPeloSqlServer : data.Value;
        }

        public static DateTime GetDataValidaAbastecimento(this DateTime data)
        {
            DateTime dataValida = data;
            DateTime menorDataAceitaPeloSqlServer = new DateTime(1753, 1, 1);

            if (data <= menorDataAceitaPeloSqlServer)
                dataValida = DateTime.Now;

            if (data > DateTime.Now)
                dataValida = DateTime.Now;

            return dataValida;
        }

        public static String PegarMesPorExtenso(this DateTime dateTime)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            return culture.TextInfo.ToTitleCase(dtfi.GetMonthName(dateTime.Month));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#")]
        public static void GetDataTextoConteudo(this String textoData, out DateTime? data)
        {
            if (textoData == "  /  /" || String.IsNullOrEmpty(textoData))
                data = null;
            else
            {
                try
                {
                    data = Convert.ToDateTime(textoData);
                }
                catch (FormatException)
                {
                    data = null;
                }
            }
        }

        public static DateTime SetMaxHours(this DateTime data)
        {
            return data.Add(new TimeSpan(23, 59, 59));
        }

        public static DateTime SetMaxHours(this DateTime? data)
        {
            return SetMaxHours(data.GetValueOrDefault());
        }

        public static DateTime RemoverHoraMinutoSegundo(this DateTime data)
        {
            return new DateTime(data.Year, data.Month, data.Day);
        }

        public static DateTime RemoverHoraMinutoSegundo(this DateTime? data)
        {
            return RemoverHoraMinutoSegundo(data.GetValueOrDefault());
        }

        /// <summary>
        /// Retorna um datetime contendo a data com o último dia do mês
        /// para uma data passada por parâmetro.
        /// </summary>
        /// <param name="dataComMesEAno"></param>
        /// <returns></returns>
        public static DateTime UltimoDiaDoMes(this DateTime dataComMesEAno)
        {
            return
                dataComMesEAno
                    .AddMonths(1)
                    .PrimeiroDiaDoMes()
                    .AddDays(-1);
        }

        /// <summary>
        /// Retorna um datetime contendo a data com o primeiro dia do mês
        /// para uma data passada por parâmetro.
        /// </summary>
        /// <param name="dataComMesEAno"></param>
        /// <returns></returns>
        public static DateTime PrimeiroDiaDoMes(this DateTime dataComMesEAno)
        {
            return
            new DateTime(
                   dataComMesEAno.Year,
                   dataComMesEAno.Month,
                   1);
        }

        public static int ObterSemanaDoAno(this DateTime data)
        {
            return new GregorianCalendar().GetWeekOfYear(data, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
        }

        public static int ObterSemanaDoAno(this DateTime data, CalendarWeekRule regraContagemSemana)
        {
            return new GregorianCalendar().GetWeekOfYear(data, regraContagemSemana, DayOfWeek.Sunday);
        }

        public static DateTime ObterDiaSemanaPelaData(this DateTime data, DayOfWeek diaSemana)
        {
            return data.AddDays(-(data.DayOfWeek - diaSemana)).Date;
        }

        public static int ObterUltimoDiaSemana(this DateTime data, int semanaDoMes)
        {
            DateTime dataMes = new DateTime();

            switch (semanaDoMes)
            {
                case 1:
                    dataMes = new DateTime(data.Year, data.Month, 1);
                    break;
                case 2:
                    dataMes = new DateTime(data.Year, data.Month, 8);
                    break;
                case 3:
                    dataMes = new DateTime(data.Year, data.Month, 15);
                    break;
                case 4:
                    dataMes = new DateTime(data.Year, data.Month, 22);
                    break;
                case 5:
                    dataMes = System.DateTime.DaysInMonth(data.Year, data.Month) > 29 ?
                                 new DateTime(data.Year, data.Month, 29) :
                                 new DateTime(data.Year, data.Month, System.DateTime.DaysInMonth(data.Year, data.Month));
                    break;
                case 6:
                    dataMes = new DateTime(data.Year, data.Month, System.DateTime.DaysInMonth(data.Year, data.Month));
                    break;

            }

            if (dataMes.Equals(new DateTime(data.Year, data.Month, System.DateTime.DaysInMonth(data.Year, data.Month))))
                return dataMes.Day;

            return dataMes.AddDays(-(dataMes.DayOfWeek - DayOfWeek.Saturday)).Day;
        }


        public static String RetornaDataNoPadraoAmericano(this DateTime data)
        {
            return data.Date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public static String FormatarPadraoBanco(this DateTime? data)
        {
            return data.IsNull() ? "NULL" : "'" + data.Value.RetornaDataNoPadraoAmericano() + "'";
        }

        public static Boolean VerificarSeEstaNoHorarioVeraoPeloWindows(this DateTime data)
        {
            bool horarioVerao = data.IsDaylightSavingTime();

            if (!horarioVerao) //Caso a dll do windows não tenha retornado verão... faz a verificação por dia fixo (algumas máquinas o retorno é sempre horário normal).
            {
                var horariosPreDeterminados = ObterHorariosVeraoAte2050();

                foreach (var horario in horariosPreDeterminados)
                {
                    if (data > horario.Inicio && data < horario.Fim)
                    {
                        horarioVerao = true;
                        break;
                    }
                }
            }

            return horarioVerao;
        }


        private static IEnumerable<HorarioVerao> ObterHorariosVeraoAte2050()
        {
            //Horários de verão gerados pela dll do windows em máquina de desenvolvimento.
            yield return new HorarioVerao() { Inicio = new DateTime(2016, 10, 16), Fim = new DateTime(2017, 02, 19) };
            yield return new HorarioVerao() { Inicio = new DateTime(2017, 10, 15), Fim = new DateTime(2018, 02, 18) };
            yield return new HorarioVerao() { Inicio = new DateTime(2018, 11, 04), Fim = new DateTime(2019, 02, 17) };
            yield return new HorarioVerao() { Inicio = new DateTime(2019, 10, 20), Fim = new DateTime(2020, 02, 16) };
            yield return new HorarioVerao() { Inicio = new DateTime(2020, 10, 18), Fim = new DateTime(2021, 02, 21) };
            yield return new HorarioVerao() { Inicio = new DateTime(2021, 10, 17), Fim = new DateTime(2022, 02, 20) };
            yield return new HorarioVerao() { Inicio = new DateTime(2022, 10, 16), Fim = new DateTime(2023, 02, 26) };
            yield return new HorarioVerao() { Inicio = new DateTime(2023, 10, 15), Fim = new DateTime(2024, 02, 18) };
            yield return new HorarioVerao() { Inicio = new DateTime(2024, 10, 20), Fim = new DateTime(2025, 02, 16) };
            yield return new HorarioVerao() { Inicio = new DateTime(2025, 10, 19), Fim = new DateTime(2026, 02, 22) };
            yield return new HorarioVerao() { Inicio = new DateTime(2026, 10, 18), Fim = new DateTime(2027, 02, 21) };
            yield return new HorarioVerao() { Inicio = new DateTime(2027, 10, 17), Fim = new DateTime(2028, 02, 20) };
            yield return new HorarioVerao() { Inicio = new DateTime(2028, 10, 15), Fim = new DateTime(2029, 02, 18) };
            yield return new HorarioVerao() { Inicio = new DateTime(2029, 10, 21), Fim = new DateTime(2030, 02, 17) };
            yield return new HorarioVerao() { Inicio = new DateTime(2030, 10, 20), Fim = new DateTime(2031, 02, 16) };
            yield return new HorarioVerao() { Inicio = new DateTime(2031, 10, 19), Fim = new DateTime(2032, 02, 15) };
            yield return new HorarioVerao() { Inicio = new DateTime(2032, 10, 17), Fim = new DateTime(2033, 02, 20) };
            yield return new HorarioVerao() { Inicio = new DateTime(2033, 10, 16), Fim = new DateTime(2034, 02, 26) };
            yield return new HorarioVerao() { Inicio = new DateTime(2034, 10, 15), Fim = new DateTime(2035, 02, 18) };
            yield return new HorarioVerao() { Inicio = new DateTime(2035, 10, 21), Fim = new DateTime(2036, 02, 17) };
            yield return new HorarioVerao() { Inicio = new DateTime(2036, 10, 19), Fim = new DateTime(2037, 02, 22) };
            yield return new HorarioVerao() { Inicio = new DateTime(2037, 10, 18), Fim = new DateTime(2038, 02, 21) };
            yield return new HorarioVerao() { Inicio = new DateTime(2038, 10, 17), Fim = new DateTime(2039, 02, 27) };
            yield return new HorarioVerao() { Inicio = new DateTime(2039, 10, 16), Fim = new DateTime(2040, 02, 19) };
            yield return new HorarioVerao() { Inicio = new DateTime(2040, 10, 21), Fim = new DateTime(2041, 02, 17) };
            yield return new HorarioVerao() { Inicio = new DateTime(2041, 10, 20), Fim = new DateTime(2042, 02, 16) };
            yield return new HorarioVerao() { Inicio = new DateTime(2042, 10, 19), Fim = new DateTime(2043, 02, 22) };
            yield return new HorarioVerao() { Inicio = new DateTime(2043, 10, 18), Fim = new DateTime(2044, 02, 21) };
            yield return new HorarioVerao() { Inicio = new DateTime(2044, 10, 16), Fim = new DateTime(2045, 02, 19) };
            yield return new HorarioVerao() { Inicio = new DateTime(2045, 10, 22), Fim = new DateTime(2046, 02, 18) };
            yield return new HorarioVerao() { Inicio = new DateTime(2046, 10, 21), Fim = new DateTime(2047, 02, 17) };
            yield return new HorarioVerao() { Inicio = new DateTime(2047, 10, 20), Fim = new DateTime(2048, 02, 16) };
            yield return new HorarioVerao() { Inicio = new DateTime(2048, 10, 18), Fim = new DateTime(2049, 02, 21) };
            yield return new HorarioVerao() { Inicio = new DateTime(2049, 10, 17), Fim = new DateTime(2050, 02, 20) };
        }


        /// <summary>
        /// Retorna a data de início do horário de verão de um determinado ano
        /// </summary>
        public static DateTime ObterInicioHorarioVerao(Int32 ano)
        {
            // terceiro domingo de outubro
            DateTime primeiroDeOutubro = new DateTime(ano, 10, 1);

            DateTime primeiroDomingoDeOutubro = primeiroDeOutubro.AddDays((7 - (Int32)primeiroDeOutubro.DayOfWeek) % 7);

            DateTime terceiroDomingoDeOutubro = primeiroDomingoDeOutubro.AddDays(14);

            return terceiroDomingoDeOutubro;
        }

        /// <summary>
        /// Retorna a data de término do horário de verão de um determinado ano
        /// </summary>
        public static DateTime ObterTerminoHorarioVerao(Int32 ano)
        {
            DateTime primeiroDeFevereiro = new DateTime(IncrementarAno(ano), 2, 1);
            DateTime primeiroDomingoDeFevereiro = primeiroDeFevereiro.AddDays((7 - (Int32)primeiroDeFevereiro.DayOfWeek) % 7);
            DateTime terceiroDomingoDeFevereiro = primeiroDomingoDeFevereiro.AddDays(14);

            if (terceiroDomingoDeFevereiro != ObterDomingoDeCarnaval(ano))
                return terceiroDomingoDeFevereiro;
            else
                return terceiroDomingoDeFevereiro.AddDays(7);
        }

        public static Int32 IncrementarAno(Int32 ano)
        {
            if (ano == Int32.MaxValue)
                return Int32.MaxValue;

            return ano + 1;
        }

        /// <summary>
        /// Retorna o domingo de carnaval de um determinado ano
        /// </summary>
        public static DateTime ObterDomingoDeCarnaval(int ano)
        {
            return ObterDomingoDePascoa(ano).AddDays(-49);
        }

        /// <summary>
        /// Retorna o domingo de páscoa de um determinado ano
        /// </summary>
        public static DateTime ObterDomingoDePascoa(int ano)
        {
            Int32 a = ano % 19;
            Int32 b = ano / 100;
            Int32 c = ano % 100;
            Int32 d = b / 4;
            Int32 e = b % 4;
            Int32 f = (b + 8) / 25;
            Int32 g = (b - f + 1) / 3;
            Int32 h = (19 * a + b - d - g + 15) % 30;
            Int32 i = c / 4;
            Int32 k = c % 4;
            Int32 L = (32 + 2 * e + 2 * i - h - k) % 7;
            Int32 m = (a + 11 * h + 22 * L) / 451;
            Int32 mes = (h + L - 7 * m + 114) / 31;
            Int32 dia = ((h + L - 7 * m + 114) % 31) + 1;

            return new DateTime(ano, mes, dia);
        }

        public static String RetornarFusoHorarioAtual(Int32? fusoHorarioNormal, Int32? fusoHorarioVerao)
        {
            if (fusoHorarioNormal.IsNotNull() && fusoHorarioVerao.IsNotNull())
            {
                if (DateTime.Now.VerificarSeEstaNoHorarioVeraoPeloWindows())
                    return String.Concat(String.Format("{0:00}", fusoHorarioVerao), ":00");
                else
                    return String.Concat(String.Format("{0:00}", fusoHorarioNormal), ":00");
            }

            return String.Empty;
        }


        public static String RetornarFusoHorarioAtualPeloServidor(Int32? fusoHorarioNormal, Int32? fusoHorarioVerao, DateTime? diaInicialHorarioVerao, DateTime? diaFinalHorarioVerao)
        {
            if (fusoHorarioNormal.IsNotNull() && fusoHorarioVerao.IsNotNull())
            {
                if (DateTime.Now.Date >= diaInicialHorarioVerao.GetValueOrDefault().Date && DateTime.Now.Date <= diaFinalHorarioVerao.GetValueOrDefault().Date)
                    return String.Concat(String.Format("{0:00}", fusoHorarioVerao), ":00");
                else
                    return String.Concat(String.Format("{0:00}", fusoHorarioNormal), ":00");
            }

            return String.Empty;
        }



        /// <summary>
        /// Método que adiciona a hora corrente à data passada por parâmetro. Caso a data passada por parâmetro seja nula, retorna a data corrente.
        /// </summary>
        /// <param name="data">Data à qual será adicionada a hora.</param>
        /// <returns>Retorna a data com a hora.</returns>
        /// <remarks>
        /// Criado por  : Nailton Magalhães
        /// Data        : 26/12/2016
        /// </remarks>
        public static DateTime AdicionarHoraNaData(this DateTime? data)
        {
            DateTime now = DateTime.Now;
            DateTime retorno = data == null ? now : new DateTime(
                                                                data.Value.Year,
                                                                data.Value.Month,
                                                                data.Value.Day,
                                                                now.Hour,
                                                                now.Minute,
                                                                now.Second);
            return retorno;
        }
    }

    class HorarioVerao
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}

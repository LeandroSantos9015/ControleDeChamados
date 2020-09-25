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
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UtilitariosSistema
{
    /// <summary>
    /// Extensions para String.
    /// </summary>
    /// <remarks>
    /// Criado por   : Fábio Vendramin Guimarães Rosini.
    /// Data         : 30/06/2011.
    /// </remarks>
    public static class ExtensionsString
    {

        //public static TTipo StringXmlParaObjeto<TTipo>(this string xmlTexto)
        //{
        //    if (string.IsNullOrEmpty(xmlTexto)) return default(TTipo);

        //    try
        //    {
        //        using (MemoryStream memoryStream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(xmlTexto)))
        //        {
        //            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TTipo));

        //            return (TTipo)xmlSerializer.Deserialize(memoryStream);
        //        }
        //    }
        //    catch
        //    {
        //        return default(TTipo);
        //    }
        //}

        public static string ConvertParaDateTimeBanco(this String texto)
        {
            DateTime data = DateTime.Now;

            DateTime.TryParse(texto, out data);

            return data.ToString("yyyy-MM-ddTHH:mm:ss");

        }

        public static string ConvertParaDateTimeBanco(this DateTime data)
        {
            return data.ToString("yyyy-MM-ddTHH:mm:ss");

        }

        public static string ConvertParaDateTimeTela(this String texto)
        {
            DateTime data = DateTime.Now;

            DateTime.TryParse(texto, out data);

            return data.ToString("dd/MM/yyyy HH:mm:ss");

        }

        public static String RemoverAcentos(this String texto)
        {
            string s = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            char[] acentos = new char[] { '`', '´', '~' };

            foreach (var caractere in s)
            {
                if (acentos.Contains(caractere))
                    sb.Append('\'');
                else
                {
                    UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(caractere);
                    if (uc != UnicodeCategory.NonSpacingMark)
                        sb.Append(caractere);
                }
            }

            return sb.ToString();
        }

        public static String RemoverPontoTraco(this String texto)
        {
            string s = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            char[] acentos = new char[] { '.', '-', '/', '(', ')', ' ' };

            foreach (var caractere in s)
            {
                if (!acentos.Contains(caractere))
                {
                    UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(caractere);
                    if (uc != UnicodeCategory.NonSpacingMark)
                        sb.Append(caractere);
                }
            }

            return sb.ToString();
        }

        public static String CpfCnpjMascara(this String texto)
        {
            if (!string.IsNullOrEmpty(texto))
                if (texto.Length == 11)
                    return Convert.ToUInt64(texto).ToString(@"000\.000\.000\-00");
                else if (texto.Length == 14)
                    return Convert.ToUInt64(texto).ToString(@"00\.000\.000\/0000\-00");
                else
                    return texto;
            return null;
        }

        public static TextBox CpfCnpj(this TextBox texto)
        {
            string t = texto.Text.RemoverPontoTraco();

            if (!string.IsNullOrEmpty(t))
                if (t.Length == 11)
                    t = Convert.ToUInt64(t).ToString(@"000\.000\.000\-00");
                else if (t.Length == 14)
                    t = Convert.ToUInt64(t).ToString(@"00\.000\.000\/0000\-00");

            texto.Text = t;

            return texto;

        }

        public static TextBox TelefoneMascara(this TextBox texto)
        {
            //999619015
            //43999619015
            //4399619015
            //12345678901
            //99961-9015

            string t = texto.Text.RemoverPontoTraco();

            if (!string.IsNullOrEmpty(t))
                if (t.Length == 8)
                    t = Convert.ToUInt64(t).ToString(@"0000\-0000");
                else if (t.Length == 9)
                    t = Convert.ToUInt64(t).ToString(@"0\ 0000\-0000");
                else if (t.Length == 10)
                    t = Convert.ToUInt64(t).ToString(@"\(00\)0000\-0000");
                else if (t.Length == 11)
                    t = Convert.ToUInt64(t).ToString(@"\(00\)0\ 0000\-0000");

            texto.Text = t;

            return texto;

        }
        public static string TelefoneMascara(this string t)
        {
            //999619015
            //43999619015
            //4399619015
            //12345678901
            //99961-9015

            if (!string.IsNullOrEmpty(t))
                if (t.Length == 8)
                    t = Convert.ToUInt64(t).ToString(@"0000\-0000");
                else if (t.Length == 9)
                    t = Convert.ToUInt64(t).ToString(@"0\ 0000\-0000");
                else if (t.Length == 10)
                    t = Convert.ToUInt64(t).ToString(@"\(00\)0000\-0000");
                else if (t.Length == 11)
                    t = Convert.ToUInt64(t).ToString(@"\(00\)0\ 0000\-0000");

            return t;

        }

        public static string AdicionarMascaraCep(this string cep)
        {
            MaskedTextProvider mask;

            if (cep == null || cep.Equals(String.Empty)) return null;

            if (cep.Length >= 8)
                mask = new MaskedTextProvider(@"00000\-000");
            else
                mask = new MaskedTextProvider(@"");

            if (!string.IsNullOrEmpty(cep))
                mask.Set(cep).ToString();
            else
                return "".ToString();

            return mask.ToString();
        }

        public static String GerarMD5(this String s)
        {
            if (s != null)
            {
                using (MD5 md5Hasher = MD5.Create())
                {
                    Byte[] data = md5Hasher.ComputeHash(Encoding.ASCII.GetBytes(s));

                    StringBuilder sBuilder = new StringBuilder();

                    foreach (var valorByte in data)
                        sBuilder.Append(valorByte.ToString("x2"));

                    return sBuilder.ToString();
                }
            }
            else
                return null;
        }

        /// <summary>
        /// Converte uma string contendo um xml em um XmlDocument.
        /// </summary>
        /// <param name="xmlString">String contendo xml.</param>
        /// <returns>XmlDocument formado pela string.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", MessageId = "System.Xml.XmlNode", Justification = "Foi necessário retornar tipo concreto XmlDocumento.")]
        public static System.Xml.XmlDocument StringXmlParaXmlDocument(string xmlTexto)
        {
            if (string.IsNullOrEmpty(xmlTexto)) return null;

            System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
            xml.LoadXml(xmlTexto);

            return xml;
        }

        /// <summary>
        /// Converte uma string contendo um xml em um Objeto Serializado do xml.
        /// </summary>
        /// <typeparam name="TTipo">Generics do objeto a ser criado.</typeparam>
        /// <param name="xmlString">String contendo xml (encoding UTF-8)</param>
        /// <returns>Objeto de serialização correspondente ao xml.</returns>
        public static TTipo StringXmlParaObjeto<TTipo>(this string xmlTexto)
        {
            if (string.IsNullOrEmpty(xmlTexto)) return default(TTipo);

            try
            {
                using (MemoryStream memoryStream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(xmlTexto)))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(TTipo));

                    return (TTipo)xmlSerializer.Deserialize(memoryStream);
                }
            }
            catch
            {
                return default(TTipo);
            }
        }

        public static List<TTipo> StringXmlParaListaObjeto<TTipo>(this string xmlTexto)
        {
            if (string.IsNullOrEmpty(xmlTexto)) return default(List<TTipo>);

            using (MemoryStream memoryStream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(xmlTexto)))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<TTipo>));

                return (List<TTipo>)xmlSerializer.Deserialize(memoryStream);
            }
        }

        public static String ConverterVazioParaNuloComTrim(this String valor)
        {
            String formatado = valor != null ? valor.Trim() : valor;

            return String.IsNullOrEmpty(formatado) ? null : formatado;
        }

        //public static MensagemValidacao ValidaPlaca(this String placa, String label, Int32 ordem)
        //{
        //    String valor = UtilMascaras.RemoveMascara(placa).ToString().Trim();

        //    if (String.IsNullOrEmpty(valor))
        //        return null;
        //    else
        //    {
        //        Match validacao = Regex.Match(valor, @"^([A-Z]{3}\d{4}|-)$");
        //        if (validacao.Success)
        //            return null;
        //        else
        //        {
        //            String labelFormatado = label.Replace(":", String.Empty);

        //            return new MensagemValidacao(String.Format("O Campo {0} deve ser válido.", labelFormatado), String.Format("Digite um valor válido para o Campo {0}", labelFormatado), ordem);
        //        }
        //    }
        //}

        //public static bool ValidaPlaca(this String placa)
        //{
        //    String valor = UtilMascaras.RemoveMascara(placa).ToString().Trim();

        //    if (String.IsNullOrEmpty(valor))
        //        return true;
        //    else
        //    {
        //        Match validacao = Regex.Match(valor, @"^([A-Z]{3}\d{4}|-)$");
        //        return validacao.Success;
        //    }
        //}

        public static Object Parse(this String valor, Type tipo)
        {
            Object valorConvertido = null;

            if (typeof(String).FullName.Equals(tipo.FullName))
            {
                valorConvertido = valor;
            }
            else
            {
                Type tipoPropriedadeSemNullable = Nullable.GetUnderlyingType(tipo);

                if (tipoPropriedadeSemNullable != null)
                    tipo = tipoPropriedadeSemNullable;

                valorConvertido = tipo.GetMethod("Parse", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, new Type[] { typeof(String) }, null).Invoke(null, new Object[] { valor });
            }

            return valorConvertido;
        }

        //public static ETipoPessoa? VerificaSeCnpjOuCpf(this String cnpjOuCpf)
        //{
        //    Boolean validou = ValidacaoIdentificacao.ValidaCnpj(cnpjOuCpf);

        //    if (validou)
        //        return ETipoPessoa.Juridica;
        //    else
        //    {
        //        validou = ValidacaoIdentificacao.ValidaCpf(cnpjOuCpf);

        //        if (validou)
        //            return ETipoPessoa.Fisica;
        //        else
        //            return null;
        //    }
        //}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "b"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "a"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Body")]
        public static Int32 Levenshtein(this String a, String b)
        {

            if (string.IsNullOrEmpty(a))
            {
                if (!string.IsNullOrEmpty(b))
                {
                    return b.Length;
                }
                return 0;
            }

            if (string.IsNullOrEmpty(b))
            {
                if (!string.IsNullOrEmpty(a))
                {
                    return a.Length;
                }
                return 0;
            }

            Int32 cost;
            Int32[,] d = new int[a.Length + 1, b.Length + 1];
            Int32 min1;
            Int32 min2;
            Int32 min3;

            for (Int32 i = 0; i <= d.GetUpperBound(0); i += 1)
            {
                d[i, 0] = i;
            }

            for (Int32 i = 0; i <= d.GetUpperBound(1); i += 1)
            {
                d[0, i] = i;
            }

            for (Int32 i = 1; i <= d.GetUpperBound(0); i += 1)
            {
                for (Int32 j = 1; j <= d.GetUpperBound(1); j += 1)
                {
                    cost = Convert.ToInt32(!(a[i - 1] == b[j - 1]));

                    min1 = d[i - 1, j] + 1;
                    min2 = d[i, j - 1] + 1;
                    min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }

            return d[d.GetUpperBound(0), d.GetUpperBound(1)];
        }

        public static Boolean RgbValido(this String rgb)
        {
            if (String.IsNullOrEmpty(rgb))
                return false;

            string[] rgbArray = rgb.Split('.');

            if (!rgbArray.Count().Equals(3))
                return false;

            if (rgbArray.Select(x => x.ToCharArray().Select(caracter => char.IsNumber(caracter)).Contains(false)).Contains(true))
                return false;

            if (!rgbArray.Select(x => Convert.ToInt32(x) >= 0 && Convert.ToInt32(x) <= 255).Count().Equals(3))
                return false;

            return true;
        }

        /// <summary>
        /// Extension para tratamento de caracteres especiais do corpo do xml da NFe conforme: 
        /// Manual de Integração - Contribuinte Padrões Técnicos de Comunicação
        /// pg.: 83, Item 5.3 Tratamento de Caracteres Especiais no Texto de XML.
        /// 
        /// Implementação provisória dos caracteres mais comumns.
        /// 
        /// Obs.: Implementado o tratamento dos caracteres:
        /// & (e-comercial),
        /// ‘ (sinal de apóstrofe).
        /// 
        /// Ficando necessária a implementação para
        /// “ (aspas),
        /// (sinal de maior),
        /// (sinal de menor),
        /// Que deverá ser realizada na engine de Validações/Preenchimentos de objetos nfe.
        /// </summary>
        public static string TextoEspecialParaTextoAceitoNaSefaz(this string textoXmlNFe)
        {
            if (!string.IsNullOrEmpty(textoXmlNFe))
            {
                textoXmlNFe = textoXmlNFe.Replace(char.ConvertFromUtf32(38), "&amp;"); // & (38)
                textoXmlNFe = textoXmlNFe.Replace(char.ConvertFromUtf32(39), "&#39;"); // ' (39)
                textoXmlNFe = textoXmlNFe.Replace(char.ConvertFromUtf32(176), "o");    // º (176)
                textoXmlNFe = textoXmlNFe.Replace(char.ConvertFromUtf32(178), "2");    // ² (178)
                textoXmlNFe = textoXmlNFe.Replace(char.ConvertFromUtf32(179), "3");    // ³ (179)
                textoXmlNFe = textoXmlNFe.Replace(char.ConvertFromUtf32(185), "1");    // ¹ (185)
                textoXmlNFe = textoXmlNFe.Replace(char.ConvertFromUtf32(10), "");     // /n (10)
            }

            return textoXmlNFe;
        }

        /// <summary>
        /// Extension para tratamento de caracteres especiais do corpo do xml da NFe conforme: 
        /// Manual de Integração - Contribuinte Padrões Técnicos de Comunicação
        /// pg.: 83, Item 5.3 Tratamento de Caracteres Especiais no Texto de XML.
        /// 
        /// Implementação provisória dos caracteres mais comumns.
        /// 
        /// Obs.: Implementado o tratamento dos caracteres:
        /// & (e-comercial),
        /// ‘ (sinal de apóstrofe).
        /// 
        /// Ficando necessária a implementação para
        /// “ (aspas),
        /// (sinal de maior),
        /// (sinal de menor),
        /// Que deverá ser realizada na engine de Validações/Preenchimentos de objetos nfe.
        /// </summary>
        public static string TextoAceitoNaSefazParaTextoComum(this string textoXmlNFe)
        {
            if (!string.IsNullOrEmpty(textoXmlNFe))
            {
                textoXmlNFe = textoXmlNFe.Replace("&amp;", char.ConvertFromUtf32(38)); // & (38)
                textoXmlNFe = textoXmlNFe.Replace("&#39;", char.ConvertFromUtf32(39)); // ' (39)
            }
            return textoXmlNFe;
        }

        public static string StringNulaParaVazia(this string texto)
        {
            return string.IsNullOrEmpty(texto) ? "" : texto;
        }

        public static string RetornarQuantidadeLinhas(this string texto, int quantidadeLinhas)
        {
            string[] linhas = texto.Split(new string[] { '\n'.ToString(), Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string mensagem = string.Empty;

            if (linhas.Length > quantidadeLinhas)
                mensagem = string.Join('\n'.ToString(), linhas.Take(8).ToArray());
            else
                mensagem = texto;

            return mensagem;
        }

        public static string RetornarQuantidadeLinhas(this string texto, int quantidadeLinhas, int quantidadeColunas)
        {
            string[] linhas = texto.Split(new string[] { '\n'.ToString(), Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string mensagem = string.Empty;

            for (int indice = 0; indice < linhas.Length; indice++)
                linhas[indice] = linhas[indice].Length > quantidadeColunas ? linhas[indice].Substring(0, quantidadeColunas) : linhas[indice];

            mensagem = string.Join('\n'.ToString(), linhas.Take(8).ToArray());

            return mensagem;
        }

        public static string TratarCaracteresEspeciais(this string texto)
        {
            if (String.IsNullOrEmpty(texto)) return texto;

            //Dicionário deve ser alimentado com "Valor Antigo" - "Valor Novo"
            IDictionary<string, string> chaveValorTratamento = new Dictionary<string, string>();

            chaveValorTratamento.Add("Ç", "C");
            chaveValorTratamento.Add("Á", "A");
            chaveValorTratamento.Add("É", "E");
            chaveValorTratamento.Add("Í", "I");
            chaveValorTratamento.Add("Ó", "O");
            chaveValorTratamento.Add("Ú", "U");
            chaveValorTratamento.Add("Ý", "Y");
            chaveValorTratamento.Add("À", "A");
            chaveValorTratamento.Add("È", "E");
            chaveValorTratamento.Add("Ì", "I");
            chaveValorTratamento.Add("Ò", "O");
            chaveValorTratamento.Add("Ù", "U");
            chaveValorTratamento.Add("Ä", "A");
            chaveValorTratamento.Add("Ë", "E");
            chaveValorTratamento.Add("Ï", "I");
            chaveValorTratamento.Add("Ö", "O");
            chaveValorTratamento.Add("Ü", "U");
            chaveValorTratamento.Add("Ã", "A");
            chaveValorTratamento.Add("Õ", "O");
            chaveValorTratamento.Add("Ñ", "N");
            chaveValorTratamento.Add("Â", "A");
            chaveValorTratamento.Add("Ê", "E");
            chaveValorTratamento.Add("Î", "I");
            chaveValorTratamento.Add("Ô", "O");
            chaveValorTratamento.Add("Û", "U");
            chaveValorTratamento.Add("&", "");
            chaveValorTratamento.Add("'", "");
            chaveValorTratamento.Add("º", "o");
            chaveValorTratamento.Add("¹", "1");
            chaveValorTratamento.Add("²", "2");
            chaveValorTratamento.Add("³", "3");
            chaveValorTratamento.Add("|", "");
            chaveValorTratamento.Add(Char.ConvertFromUtf32(141), ""); //Caracter especial não visível.

            foreach (var tratamento in chaveValorTratamento)
            {
                //texto original (UPPER)
                texto = texto.Replace(tratamento.Key, tratamento.Value);
                //texto alterado (LOWER)
                texto = texto.Replace(tratamento.Key.ToLower(), tratamento.Value.ToLower());
            }

            return texto;
        }

        /// <summary>
        /// Se o objeto for nulo, retorna string de sql nulo, senão, retornar a string de entrada
        /// </summary>
        /// <param name="strParametro">String de entrada</param>
        /// <param name="objeto">Objeto a testar</param>
        /// <returns>String "NULL" se o objeto passado for nulo, caso contrário, retorna string de entrada</returns>
        public static String SeObjetoNuloRetornaStringNull(this String strParametro, Object objeto)
        {
            return objeto != null ? strParametro : "NULL";
        }

        /// <summary>
        /// Quebra a string em varias strings na posição desejada, tratando para não cortar a palavra no meio (Quebra somente onde tem ' ')
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="posicaoQuebra"></param>
        /// <returns></returns>
        public static String[] QuebrarTextoEmUmArrayString(this String texto, int posicaoQuebra)
        {
            Int32 tamanho = posicaoQuebra;

            if (tamanho > 0 && texto.Length > tamanho)
            {
                IList<String> textoComQuebra = new List<String>();

                Boolean continuarQuebra = true;

                int localQuebra = Convert.ToInt32(tamanho);

                string textoAtual = texto;

                int iteracao = 0;
                int continuarPosicao = 0;

                while (continuarQuebra)
                {
                    string parteQuebra = textoAtual.Substring(continuarPosicao, (localQuebra - iteracao));

                    if (!(parteQuebra.Last() == ' ') && parteQuebra.Contains(" "))
                        iteracao++;
                    else
                    {
                        textoComQuebra.Add(parteQuebra.TrimEnd().TrimStart());
                        continuarPosicao = (localQuebra - iteracao) + continuarPosicao;
                        iteracao = 0;

                        if (texto.Substring(continuarPosicao).Length <= tamanho)
                        {
                            textoComQuebra.Add(texto.Substring(continuarPosicao));
                            continuarQuebra = false;
                        }
                    }
                }

                return textoComQuebra.ToArray();
            }
            else
                return new String[] { texto };
        }

        //public static string RecuperarCapituloNcm(this string ncm)
        //{
        //    String codigoNcm = UtilMascaras.RemoveMascara(ncm);

        //    if (!String.IsNullOrEmpty(codigoNcm) && UtilMascaras.RemoveMascara(codigoNcm).Length == 8)
        //        return ncm.Substring(0, 2);

        //    return string.Empty;
        //}

        /// <summary>
        /// Faz com que a primeira letra de cada palavra fique maiuscula
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string ToUppercaseWords(this string texto)
        {
            char[] array = texto.ToCharArray();
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

        public static bool IpValido(this string ip)
        {
            if (!String.IsNullOrEmpty(ip))
            {
                string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";

                Regex check = new Regex(pattern);

                return check.IsMatch(ip, 0);
            }

            return false;
        }

        /// <summary>
        /// Retorna apenas os números de uma string.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static String SomenteNumeros(this string textoValor)
        {
            Regex rg = new Regex(@"^[0-9]+$");
            String valor = String.Empty;

            for (int i = 0; i < textoValor.Length; i++)
            {
                if (rg.IsMatch(textoValor[i].ToString()))
                    valor += textoValor[i];
            }

            textoValor = valor;

            return textoValor;
        }

        public static Int64? StringParaNumeroOuNulo(this string textoValor)
        {
            Int64 numero;

            if (Int64.TryParse(textoValor, out numero))
                return numero;

            return null;
        }

        public static String SeNumeroNuloEntaoNumeroPadrao(this Int64? numero, Int64 valorQueVaiFicar)
        {
            return numero == null ? valorQueVaiFicar.ToString() : numero.ToString();
        }

        public static String SeNumeroNuloEntaoNumeroPadrao(this Decimal? numero, Int64 valorQueVaiFicar)
        {
            return numero.SeNumeroNuloEntaoNumeroPadrao(valorQueVaiFicar);
        }

        public static String SeNumeroNuloEntaoNumeroPadrao(this Decimal numero, Int64 valorQueVaiFicar)
        {
            return numero == null ? valorQueVaiFicar.ToString() : numero.ToString();
        }


        public static Int64 StringParaNumero(this string textoValor)
        {
            Int64 numero;

            if (Int64.TryParse(textoValor, out numero))
                return numero;

            return 0;
        }

        public static Decimal StringParaNumeroDecimal(this string textoValor)
        {
            Decimal numero = decimal.Zero;

            if (Decimal.TryParse(textoValor, out numero))
                return numero;

            return 0;
        }

        /// <summary>
        /// Retorna apenas números e vírgulas de uma string.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static String SomenteNumerosEVirgula(this string textoValor)
        {
            Regex rg = new Regex(@"^[0-9,]+$");
            String valor = String.Empty;

            for (int i = 0; i < textoValor.Length; i++)
            {
                if (rg.IsMatch(textoValor[i].ToString()))
                    valor += textoValor[i];
            }

            return valor;
        }

        /// <summary>
        /// Verifica se a string contém caracteres diferente de números.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static Boolean ContemSomenteNumero(this string str)
        {
            Regex rg = new Regex(@"^[0-9]+$");

            if (rg.IsMatch(str))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifica se a string contém caracteres diferente de números e virgula.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static Boolean ContemSomenteNumeroEVirgula(this string str)
        {
            Regex rg = new Regex(@"^[0-9,]+$");

            if (rg.IsMatch(str))
                return true;
            else
                return false;
        }


        /// <summary>
        /// Adiciona máscara em telefone com DDD.
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static String AdicionarMascaraTelefoneDDD(this string str)
        {
            String ddd = String.Empty;
            String numero = String.Empty;
            String numeroSemDDD = String.Empty;

            if ((!String.IsNullOrEmpty(str) && str.Length > 6) && !str.Contains("("))
            {
                numeroSemDDD = str.Substring(2, str.Length - 2);
                numeroSemDDD = numeroSemDDD.Insert((numeroSemDDD.Length - 4), "-");
                ddd = str.Substring(0, 2);
                numero = String.Concat("(", ddd, ")", numeroSemDDD);
            }

            return !String.IsNullOrEmpty(numero) ? numero : str;
        }

        public static String RemoverMascaraTelefoneDDD(this string str)
        {
            return str.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
        }

        public static Int64 StringToInt64(this string inteiro)
        {
            return Convert.ToInt64(inteiro);
        }

        /// <summary>
        /// Retorna Array de string partido pela quantidade split atribuída.
        /// </summary>
        /// <param name="value">string que será dividida</param>
        /// <param name="split">quantidade de caracteres partidos</param>
        /// <returns> Array de string partido pela quantidade split atribuída</returns>
        public static string[] Split(this string value, int split)
        {
            int tamanho = value.Length;
            int posicao = 0;
            string[] retornoSplit = new string[tamanho / split];

            while (posicao < tamanho)
            {
                retornoSplit[posicao / split] = value.Substring(posicao, split);
                posicao += split;
            }

            return retornoSplit;
        }

        /// <summary>
        /// Get substring of specified number of characters on the right.
        /// </summary>
        public static string Right(this string value, int length)
        {
            return value.Substring(value.Length - length);
        }

        //public static string Alinhar(this string texto, byte quantidadeColunas, ETipoAlinhamento tipo)
        //{
        //    switch (tipo)
        //    {
        //        case ETipoAlinhamento.Centralizado:
        //            int colunaInicial = (quantidadeColunas - texto.Length) / 2;
        //            if (colunaInicial > 0)
        //                return "".PadLeft(colunaInicial, ' ') + texto;
        //            else
        //                return (texto.Length <= quantidadeColunas) ? texto : texto.Substring(0, quantidadeColunas);

        //        case ETipoAlinhamento.Direita:
        //            return texto.PadLeft(quantidadeColunas, ' ');

        //        default: return texto;
        //    }
        //}

        //public static T PegarEnumPeloXmlEnumValue<T>(this String valor)
        //{
        //    foreach (T item in Enum.GetValues(typeof(T)))
        //    {
        //        if ((item as Enum).XmlEnumValor().Equals(valor))
        //            return item;
        //    }

        //    return default(T);
        //}

        public static String CalcularEspacosDeAcordoValorVariavel(this String descricao, int quantidadeEspacoPadrao, int quantidadeEspacoPadraoValor, String valor)
        {
            int tamanhoValor = valor.Length;

            int diferenca = quantidadeEspacoPadraoValor - tamanhoValor;

            return descricao.PadRight(quantidadeEspacoPadrao + diferenca);
        }

        public static String Truncar(this String texto, Int32 quantidade)
        {
            if (!String.IsNullOrEmpty(texto))
                return texto.Length > quantidade ? texto.Substring(0, quantidade) : texto;

            return texto;
        }

        public static String AllTrim(this String valor)
        {
            if (!String.IsNullOrEmpty(valor))
                return valor.TrimStart().TrimEnd().Trim();

            return String.Empty;
        }

        public static Boolean DnsEmailValido(this String email)
        {
            try
            {
                String dns = email.Split('@')[1];

                System.Net.Dns.GetHostEntry(dns);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static Boolean SalvarParaArquivo(this String[] conteudo, String arquivo)
        {
            try
            {

                System.IO.File.WriteAllLines(arquivo, conteudo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean SalvarParaArquivo(this String conteudo, String arquivo)
        {
            try
            {

                System.IO.File.WriteAllText(arquivo, conteudo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static String[] CarregarDoArquivo(this String arquivo)
        {
            return System.IO.File.ReadAllLines(arquivo);
        }

        public static String CheckSumCode(this String conteudo)
        {
            try
            {
                //string key = "test";
                string key = "test";
                string retValue = "1";

                int i = 0;
                int x = 0;

                int[] cipher = new int[conteudo.Length];
                x = 0;

                for (i = 0; i < conteudo.Length; i++)
                {
                    //retValue = retValue + (char)((conteudo[i] ^ key[x]));
                    retValue = "" + (char)(retValue[0] ^ (conteudo[i] ^ key[x]));
                    cipher[i] = (conteudo[i] ^ key[x]);
                    x++;
                    if (x >= key.Length)
                        x = 0;
                }
                retValue = ((int)retValue[0]).ToString().PadLeft(3, '0');
                return retValue;
            }
            catch
            {
                return "";
            }
        }

        public static String GetComAspas(this String Texto)
        {
            return "'" + Texto + "'";
        }

        public static String Copy(this String Texto, int posInicial, int tamanho)
        {
            if ((!String.IsNullOrEmpty(Texto)) && Texto.Length - posInicial > 0)
            {
                return Texto.Substring(posInicial, Texto.Length - posInicial).Truncar(tamanho);
            }
            else
                return String.Empty;
        }

        //public static Object PegarEnumPeloDescription(this String description, Type tipoEnumerator)
        //{
        //    if (String.IsNullOrEmpty(description))
        //        return null;

        //    foreach (Enum item in Enum.GetValues(tipoEnumerator))
        //    {
        //        if (item.Descricao().Equals(description))
        //            return item;
        //    }

        //    return null;
        //}

        //public static Object PegarEnumPelaDescricaoReduzida(this String description, Type tipoEnumerator)
        //{
        //    if (String.IsNullOrEmpty(description))
        //        return null;

        //    foreach (Enum item in Enum.GetValues(tipoEnumerator))
        //    {
        //        if (item.DescricaoReduzida().Equals(description))
        //            return item;
        //    }

        //    return null;
        //}

        public static String DecodeFromUTF8(this String Texto)
        {
            string utf8_String = Texto;
            byte[] bytes = Encoding.Default.GetBytes(utf8_String);
            return Encoding.UTF8.GetString(bytes);
        }

        public static Boolean IsIPv4(this String ip)
        {
            IPAddress address;

            return IPAddress.TryParse(ip, out address) && System.Net.Sockets.AddressFamily.InterNetwork.Equals(address.AddressFamily);
        }

        public static Boolean IsIPv6(this String ip)
        {
            IPAddress address;

            return IPAddress.TryParse(ip, out address) && System.Net.Sockets.AddressFamily.InterNetworkV6.Equals(address.AddressFamily);
        }

        /// <summary>
        /// Adiciona os colchetes [  ] entre o ip caso for IPv6
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static String IPV6ValidoWCF(this String ip)
        {
            IPAddress address;

            if (IPAddress.TryParse(ip, out address))
            {
                switch (address.AddressFamily)
                {
                    case System.Net.Sockets.AddressFamily.InterNetworkV6:
                        if (ip[0] != '[' || ip[ip.Length - 1] != ']')
                            ip = String.Concat("[", ip, "]");
                        break;
                }
            }

            return ip;
        }

        public static String ObterIPValido(this String ipAddress)
        {
            System.Net.Sockets.AddressFamily? addressFamily = ExtensionsString.ObterAddresFamily(ipAddress);

            return ExtensionsString.ObterIPValido(ipAddress, addressFamily);
        }

        public static String ObterIPValido(this String ipAddress, System.Net.Sockets.AddressFamily? addressFamily)
        {
            switch (addressFamily)
            {
                case System.Net.Sockets.AddressFamily.InterNetwork:
                    return ipAddress;

                case System.Net.Sockets.AddressFamily.InterNetworkV6:
                    return ipAddress.IPV6ValidoWCF();

                default:
                    return ipAddress.ObterIpValidoPeloHostName();
            }
        }

        public static String ObterIpValidoPeloHostName(this String hostName)
        {
            return ExtensionsString.ObterIpValidoPeloHostName(hostName, System.Net.Sockets.AddressFamily.InterNetwork);
        }

        public static String ObterIpValidoPeloHostName(this String hostName, System.Net.Sockets.AddressFamily addressFamily)
        {
            IPAddress[] lista = Dns.GetHostAddresses(hostName);

            String ipAddressValido = String.Empty;

            foreach (IPAddress item in lista.Where(x => x.AddressFamily == addressFamily))
            {
                String ipAddress = item.ToString();

                switch (addressFamily)
                {
                    case System.Net.Sockets.AddressFamily.InterNetwork:
                        ipAddressValido = ipAddress.IsIPv4() ? ipAddress : String.Empty;
                        break;

                    case System.Net.Sockets.AddressFamily.InterNetworkV6:
                        ipAddressValido = ipAddress.IsIPv6() ? ipAddress : String.Empty;
                        break;

                    default:
                        ipAddressValido = String.Empty;
                        break;
                }

                if (!String.IsNullOrWhiteSpace(ipAddressValido))
                    return ipAddressValido;
            }

            return String.Empty;
        }

        public static System.Net.Sockets.AddressFamily? ObterAddresFamily(this String ipAddress)
        {
            if (ipAddress.IsIPv4())
                return System.Net.Sockets.AddressFamily.InterNetwork;

            if (ipAddress.IsIPv6())
                return System.Net.Sockets.AddressFamily.InterNetworkV6;

            return null;
        }

        /// <summary>
        /// Recebe uma string contendo uma data e retorna um DateTime. Caso não consiga converter a string para DateTime, retorna a data corrente do Windows.
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this String strData)
        {
            DateTime retorno = DateTime.Now;
            DateTime.TryParse(strData, out retorno);
            return retorno;
        }

        /// <summary>
        /// Recebe uma string contendo um numero e retorna um Int32. Caso não consiga converter a string em um Int32, retorna 0.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        public static Int32 ToInt32(this String strNumero)
        {
            Int32 ret;
            Int32.TryParse(strNumero, out ret);
            return ret;
        }

        public static String SepararPorBlocos(this String conteudo, byte tamanhoBlocos, String separador = " ")
        {
            if (String.IsNullOrWhiteSpace(conteudo))
                return null;
            else
            {
                StringBuilder conteudoSeparado = new StringBuilder();

                for (int indice = 0; indice < conteudo.Length; indice += tamanhoBlocos)
                {
                    conteudoSeparado.Append(conteudo.Substring(indice, tamanhoBlocos) + separador);
                }

                return conteudoSeparado.ToString();
            }
        }

        public static bool ValidarEmail(this String email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            else
                return (Regex.Match(email, "(?<user>[^@]+)@(?<host>.+)").Success);
        }

        public static double Truncar(this double valor, int qtCasas)
        {
            valor *= (10 ^ qtCasas);

            valor = Math.Truncate(valor);

            valor /= (10 ^ qtCasas);



            return valor;

        }

        public static bool ExportarXML(this object obj)
        {
            string campo = "padrao";

            foreach (var a in obj.GetType().CustomAttributes)
                if (a.AttributeType.Equals(typeof(DescriptionAttribute)))
                    campo = a.ConstructorArguments[0].Value.ToString();

            string arquivo = String.Format(@"{0}\{1}.xml", Environment.CurrentDirectory, campo);

            try
            {
                FileStream stream = new FileStream(arquivo, FileMode.Create);
                XmlSerializer serializador = new XmlSerializer(obj.GetType());
                serializador.Serialize(stream, obj);

                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
                return false;
            }
        }

        public static TTipo ArquivoXmlParaObjeto<TTipo>(this TTipo tTipo)
        {
            // TTipo tTipo = default(TTipo);

            string xmlTexto = tTipo.LerArquivoXml();

            if (string.IsNullOrEmpty(xmlTexto)) return default(TTipo);

            try
            {
                using (MemoryStream memoryStream = new MemoryStream(ASCIIEncoding.UTF8.GetBytes(xmlTexto)))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(TTipo));

                    return (TTipo)xmlSerializer.Deserialize(memoryStream);
                }
            }
            catch (Exception e)
            {
                return default(TTipo);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="qtdColunasSeparando"> tem que ser divisível com a quantidade de caracteres do texto</param>
        /// <returns></returns>
        public static string ValidacaoSimples(this string texto, int qtdColunasSeparando, string separador)
        {
            texto = texto.RemoverPontoTraco();

            int q = texto.Length;

            if (q % qtdColunasSeparando != 0 || q == 0)
                return texto;

            int qtdAux = 0;
            string ini;
            string aux = "";

            for (int i = 0; i < q / qtdColunasSeparando; i++)
            {
                ini = texto.Substring(qtdAux, qtdColunasSeparando);
                qtdAux += qtdColunasSeparando;
                aux += ini;
                if (qtdAux != q)
                    aux += separador;
            }

            texto = aux;

            return texto.ToString();
        }
    }
}

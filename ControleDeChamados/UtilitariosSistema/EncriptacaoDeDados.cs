using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UtilitariosSistema
{
    /// <summary>
    /// Classe destinada a resolver problemas relacionados à encriptação de dados.
    /// </summary>
    /// <remarks>
    /// Criado por  : Leonardo Justino
    /// Data        : 16/01/2009
    /// </remarks>
    public static class EncriptacaoDeDados
    {
        #region Constantes

        private const String chavePadrao = "LeandroSantosSistemas1234";

        #endregion

        #region Membros Privados

        #region Refatoracao

        private static RijndaelManaged padraoAvancadoDeEncriptacao = new RijndaelManaged();
        private static MemoryStream fluxoDeMemoria;
        private static CryptoStream fluxoDeTransformacao;

        #endregion

        #region Tratamento de Erros

        private static void TratarErrosGenerico(Byte[] informacao, Byte[] chave)
        {
            if (informacao == null)
                //throw new ArgumentoNuloSystemMetaException(EMsgPadrao.MsgArgumentoNulo, EArea.Utilitarios, "informacao");
                if (chave == null)
                    //throw new ArgumentoNuloSystemMetaException(EMsgPadrao.MsgArgumentoNulo, EArea.Utilitarios, "chave");

                    try
                    {
                        padraoAvancadoDeEncriptacao.Key = chave;
                    }
                    catch
                    {
                        //throw new ArgumentoInvalidoSystemMetaException(EMsgPadrao.MsgArgumentoInvalido, EArea.Utilitarios, "chave");
                    }
        }

        private static void TratarErrosCifrar(Byte[] informacao, Byte[] chave)
        {
            TratarErrosGenerico(informacao, chave);

            if (informacao.Length == 0)
            {
                //throw new ArgumentoInvalidoSystemMetaException(EMsgPadrao.MsgArgumentoNulo, EArea.Utilitarios, "informacao");
            }

        }

        private static void TratarErrosDecifrar(Byte[] informacaoCifrada, Byte[] chave)
        {
            TratarErrosGenerico(informacaoCifrada, chave);

            if (informacaoCifrada.Length == 0)
            {
                //  throw new ArgumentoInvalidoSystemMetaException(EMsgPadrao.MsgArgumentoNulo, EArea.Utilitarios, "informacaoCifrada");
            }

        }

        #endregion

        #endregion

        #region Membros Públicos

        /// <summary>
        /// Gera uma chave aleatória para ser usada nas operações de Cifrar e Decifrar
        /// </summary>
        /// <returns>Chave aleatória</returns>
        public static Byte[] GerarChave()
        {
            padraoAvancadoDeEncriptacao.GenerateKey();

            return padraoAvancadoDeEncriptacao.Key;
        }

        /// <summary>
        /// Cifra dados usando uma chave personalizada
        /// </summary>
        /// <param name="informacao">Informação à ser cifrada</param>
        /// <param name="chave">Chave personalizada</param>
        /// <returns>Os dados cifrados</returns>
        public static Byte[] Cifrar(this Byte[] informacao, Byte[] chave)
        {
            TratarErrosCifrar(informacao, chave);

            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(chave, chave);
            fluxoDeMemoria = new MemoryStream();
            fluxoDeTransformacao = new CryptoStream(fluxoDeMemoria, padraoAvancadoDeEncriptacao.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16)), CryptoStreamMode.Write);

            fluxoDeTransformacao.Write(informacao, 0, informacao.Length);
            fluxoDeTransformacao.Close();

            Byte[] dadosCifrados = fluxoDeMemoria.ToArray();

            fluxoDeMemoria.Close();

            return dadosCifrados;
        }

        /// <summary>
        /// Decifra dados usando uma chave personalizada
        /// </summary>
        /// <param name="informacao">Informação à ser decifrada</param>
        /// <param name="chave">Chave personalizada</param>
        /// <returns>Dados decifrados</returns>
        public static Byte[] Decifrar(this Byte[] informacaoCifrada, Byte[] chave)
        {
            TratarErrosDecifrar(informacaoCifrada, chave);

            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(chave, chave);
            fluxoDeMemoria = new MemoryStream(informacaoCifrada);
            fluxoDeTransformacao = new CryptoStream(fluxoDeMemoria, padraoAvancadoDeEncriptacao.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16)), CryptoStreamMode.Read);

            byte[] retorno = new byte[informacaoCifrada.Length];
            int quantidade = fluxoDeTransformacao.Read(retorno, 0, retorno.Length);

            Array.Resize<byte>(ref retorno, quantidade);
            //List<Byte> retorno = new List<Byte>();

            //for (Int32 dado = fluxoDeTransformacao.ReadByte(); dado >= 0; dado = fluxoDeTransformacao.ReadByte())
            //    retorno.Add((Byte)dado);

            fluxoDeTransformacao.Close();
            fluxoDeMemoria.Close();

            return retorno;
        }

        #endregion

        #region Criptografia Por String

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public static string Cifrar(this string s, string chave)
        {
            if (String.IsNullOrEmpty(s))
                return s;

            using (RijndaelManaged RijndaelCipher = new RijndaelManaged())
            {
                byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(s);

                // Then, we need to turn the password into Key and IV 
                // We are using salt to make it harder to guess our key
                // using a dictionary attack - 
                // trying to guess a password by enumerating all possible words. 
                PasswordDeriveBytes secretKey = new PasswordDeriveBytes(chave,
                    new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
                0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

                //Creates a symmetric encryptor object. 
                ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    //Defines a stream that links data streams to cryptographic transformations
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
                    cryptoStream.Write(PlainText, 0, PlainText.Length);
                    //Writes the final state and clears the buffer
                    cryptoStream.FlushFinalBlock();
                    byte[] CipherBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                    string EncryptedData = Convert.ToBase64String(CipherBytes);
                    return EncryptedData;
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
        public static string Decifrar(this string s, string chave)
        {
            try
            {
                if (String.IsNullOrEmpty(s))
                    return s;

                using (RijndaelManaged RijndaelCipher = new RijndaelManaged())
                {
                    byte[] EncryptedData = Convert.FromBase64String(s);

                    // Then, we need to turn the password into Key and IV 
                    // We are using salt to make it harder to guess our key
                    // using a dictionary attack - 
                    // trying to guess a password by enumerating all possible words. 
                    PasswordDeriveBytes secretKey = new PasswordDeriveBytes(chave,
                        new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
                            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

                    //Creates a symmetric Rijndael decryptor object.
                    ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));
                    using (MemoryStream memoryStream = new MemoryStream(EncryptedData))
                    {
                        //Defines the cryptographics stream for decryption.THe stream contains decrpted data
                        CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
                        byte[] PlainText = new byte[EncryptedData.Length];
                        int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                        cryptoStream.Close();

                        //Converting to string
                        string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
                        return DecryptedData;
                    }
                }
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        #endregion

        #region Padrão

        public static string UtilCifrar(this string s)
        {
            return s.Cifrar(chavePadrao);
        }

        public static string UtilDecifrar(this string s)
        {
            return s.Decifrar(chavePadrao);
        }

        #endregion
    }
}
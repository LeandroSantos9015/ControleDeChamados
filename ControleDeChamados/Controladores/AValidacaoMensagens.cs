using Enumeradores;
using Mensagens.Mensagem;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UtilitariosSistema;

namespace Controladores
{
    /// <summary>
    /// Classe abstrata destinada a todas as validações de textos
    /// </summary>
    public abstract class AValidacaoMensagens
    {
        public string CaixaDeTextoVazia(TextBox texto, string descricao)
        {
            string retorno = null;

            if (texto != null)
            {
                if (texto.Text.Equals(String.Empty) || texto.Text == null)
                {
                    retorno = String.Format("Campo {0} vazío", descricao);
                }
            }

            return retorno;
        }

        public string CampoObrigatorio(TextBox texto, string descricao)
        {
            string retorno = null;

            if (texto != null)
            {
                if (texto.Text.Equals(String.Empty) || texto.Text == null)
                {
                    retorno = String.Format("Campo {0} é obrigatório", descricao);
                }
            }

            return retorno;
        }

        public string SenhaIncorreta(TextBox texto, string senhaCorreta)
        {
            string retorno = null;

            if (texto != null && texto.Text != null && !texto.Text.Equals(String.Empty))
            {
                if (!texto.Text.Equals(senhaCorreta))
                {
                    retorno = String.Format("Senha incorreta");

                    texto.Focus();
                    texto.Text = String.Empty;
                }
            }

            return retorno;
        }

        public string Intervalo(TextBox texto, Int64 inicio, Int64 fim, string nomeCampo)
        {
            Int64.TryParse(texto.Text, out Int64 valor);

            string tx = null;

            bool maior = valor >= inicio;
            bool menor = valor <= fim;

            if (!(maior && menor))
                tx = $"{nomeCampo} está fora do intervalo";

            return tx;
        }


        public static string ComboBoxVazia(ComboBox combo, string valor)
        {
            string retorno = null;

            if (combo.Items.Count > 0)
            {
                if (combo.SelectedIndex == -1)
                {
                    combo.Focus();
                    combo.SelectedIndex = 0;

                    retorno = String.Format("Campo {0} vazío", valor);
                }
            }
            return retorno;
        }

        public static string CampoComValorIncorreto(TextBox texto, ETipoCampo campo, string nomeDoCampo)
        {
            string retorno = null;

            switch (campo)
            {
                case ETipoCampo.Cep:
                    break;
                case ETipoCampo.Cnpj:
                    if (!texto.Text.CnpjValido())
                        retorno = String.Format("O valor do campo {0} é inválido", nomeDoCampo);
                    break;
                case ETipoCampo.Cpf:
                    if (!texto.Text.CpfValido())
                        retorno = String.Format("O valor do campo {0} é inválido", nomeDoCampo);
                    break;
                case ETipoCampo.CpfCnpj:
                    string temp = texto.Text.SomenteNumeros();

                    texto.Text = temp;

                    if (texto.Text.Length == 11 || texto.Text.Length == 14)
                    {
                        if (texto.Text.Length == 11 && !texto.Text.CpfValido())
                            retorno = String.Format("O CPF do campo {0} é inválido", nomeDoCampo);
                        else
                            if (texto.Text.Length == 14 && !texto.Text.CnpjValido())
                            retorno = String.Format("O CNPJ do campo {0} é inválido", nomeDoCampo);
                    }
                    else
                        retorno = String.Format("Quantidade de caractéres do campo {0} é inválido.", nomeDoCampo);

                    break;
            }

            return retorno;
        }

        /// <summary>
        /// Apresenta a mensagem sem precisar fazer qualquer validação
        /// </summary>
        /// <param name="exibeMensagens"></param>
        /// <param name="local"></param>
        public void Informacao(string exibeMensagens, string local)
        {
            CtrlMensagem.Informacao(exibeMensagens, local);
        }

        public bool ExibeValidacoes(Dictionary<int, string> Validacoes, string local)
        {
            string exibeMensagem = string.Empty;

            foreach (string mensagem in Validacoes.Values)
            {
                if (!(mensagem == null || mensagem.Equals(String.Empty)))
                    exibeMensagem += mensagem + '\n';
            }

            if (!exibeMensagem.Equals(String.Empty))
            {
                CtrlMensagem.Informacao(exibeMensagem, local);
            }

            return !exibeMensagem.Equals(String.Empty);
        }

        public static bool ExibeValidacoesEstatica(Dictionary<int, string> Validacoes, string local)
        {
            string exibeMensagem = string.Empty;

            foreach (string mensagem in Validacoes.Values)
            {
                if (!(mensagem == null || mensagem.Equals(String.Empty)))
                    exibeMensagem += mensagem + '\n';
            }

            if (!exibeMensagem.Equals(String.Empty))
            {
                CtrlMensagem.Informacao(exibeMensagem, local);
            }

            return !exibeMensagem.Equals(String.Empty);
        }


        public void SalvoComSucesso(string local)
        {
            CtrlMensagem.Salvo(local);
        }

        public void ProcessadoComSucesso(string local)
        {
            CtrlMensagem.Processado(local);
        }

        public void ExcluidoComSucesso(string local)
        {
            CtrlMensagem.Excluido(local);
        }

        public void Alerta(string local, string tipoAlerta)
        {
            CtrlMensagem.Alerta(local, tipoAlerta);
        }

        public void ErroDesconhecido(string local, string tipoErro, String mensagemDoErro)
        {
            CtrlMensagem.ErroDesconhecido(local, tipoErro, mensagemDoErro);
        }

        public string JaExiste(string nomeDoCampo, string valor)
        {
            if (!valor.Equals(String.Empty) && valor != null)
                return String.Format("Já existe um {0} cadastrado com o valor {1}.", nomeDoCampo, valor);

            return null;
        }

        public DialogResult Pergunta(string local, string pergunta)
        {
            return CtrlMensagem.Pergunta(local, pergunta);
        }

        public string JaExisteItem(string itemTela, string itemBanco)
        {
            if (itemTela.Equals(itemBanco))
            {
                return String.Format("{0} Já existe", itemTela);
            }

            return null;
        }

        public string JaExisteItemComEstaChave(string chaveTela, string chaveBanco, string item, Int64? IdTela = null, Int64? IdBanco = null)
        {
            if (chaveTela.Equals(chaveBanco) && IdTela != IdBanco)
            {
                return String.Format("O valor {0} já está presente no {1}", chaveTela, item);
            }

            return null;
        }

        public string ValorDeveSerMaiorQueZero(TextBox texto, string descricao)
        {
            string retorno = null;

            if (texto != null)
            {
                if (!texto.Text.Equals(String.Empty))
                {
                    decimal valor = Convert.ToDecimal(texto.Text);
                    if (valor <= 0)
                        retorno = String.Format("Campo {0} não pode conter valor menor ou igual a zero!", descricao);
                }
                else
                    retorno = String.Format("Campo {0} deve ter um valor!", descricao);
            }

            return retorno;
        }
    }
}
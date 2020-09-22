using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mensagens.Mensagem.MensagemLivre
{
    public interface IMsgLivre
    {
        Form MensagemLivreView { get; }

        Button BtnCopiar { get; }

        Button BtnSair { get; }

        RichTextBox Texto { get; }

        String Titulo { get; }
    }
}

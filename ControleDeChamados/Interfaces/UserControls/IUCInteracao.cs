using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaces.UserControls
{
    public interface IUCInteracao
    {
        UserControl UCInteracaoView { get; }

        Label LblNumero { get; }

        Label LblUsuario { get; }

        MemoEdit TextDesc { get; }

        Int64? Id { get; }


    }
}

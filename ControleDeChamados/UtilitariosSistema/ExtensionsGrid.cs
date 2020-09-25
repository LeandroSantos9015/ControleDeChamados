using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customizados
{
    public static class ExtensionsGrid
    {

        static IList<object> ListaPai = new List<object>();
        static IList<object> ListaFilho;

        private static IList<object> CastingPadrao()
        {


            return null;
        }

        public static GridView MasterDetail(this GridView gridControl, IList<object> ListaPai, IList<object> ListaFilho)
        {

            gridControl.MasterRowEmpty += MasterRowEmpty;
            gridControl.MasterRowGetChildList += MasterRowGetChildList;
            gridControl.MasterRowGetRelationCount += MasterRowGetRelationCount;
            gridControl.MasterRowGetRelationName += MasterRowGetRelationName;


            return gridControl;
        }

        private static void MasterRowGetRelationName(object sender, MasterRowGetRelationNameEventArgs e)
        {
            e.RelationName = "Detail";
        }

        private static void MasterRowGetRelationCount(object sender, MasterRowGetRelationCountEventArgs e)
        {
            // seta 1 : detalhe
            e.RelationCount = 1;
        }

        private static void MasterRowGetChildList(object sender, MasterRowGetChildListEventArgs e)
        {
            // carrega data para grid detail

            GridView view = sender as GridView;
            object pai = view.GetRow(e.RowHandle) as object;
            if (pai != null)
            {
                //e.ChildList = ListaFilho.Where(x => x.IdPai == pai.Id).OrderBy(y => y.Parcela).ToList();// cast IEnumerable to List ou IList

                //this.ParceiroPrazo.GridDetalhe.GridControl.ForeColor = Color.Red;


            }
        }

        private static void MasterRowEmpty(object sender, MasterRowEmptyEventArgs e)
        {
            // se pai n tem filho, um plus é aberto
            GridView view = sender as GridView;
            object pai = view.GetRow(e.RowHandle) as object;
            //if (pai != null)
            //    e.IsEmpty = !ListaFilho.Any(x => x.IdPai == pai.Id);
        }

    }
}

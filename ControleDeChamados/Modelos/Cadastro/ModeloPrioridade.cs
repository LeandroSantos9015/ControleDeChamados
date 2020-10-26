using Interfaces.PesquisarDTO;
using Modelos.TelaPadrao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Cadastro
{
    /// <summary>
    /// Modelo pra tela DTO para banco utilizar o conversor
    /// </summary>
    public class ModeloPrioridade : IConsultaPesquisar
    {
        public Int64? Id { get; set; }

        public String Descricao { get; set; }

        public bool Ativo { get; set; }

        public string Consulta => Descricao;

    }

    public class PrioridadeDTO
    {
        public Int64? Id { get; set; }

        public String Descricao { get; set; }

        public bool Ativo { get; set; }

    }

    public static class ConvertePrioridade
    {
        public static PrioridadeDTO Converte(this ModeloPrioridade m)
        {
            return new PrioridadeDTO
            {
                Descricao = m.Descricao,
                Id = m.Id,
                Ativo = m.Ativo
            };
        }
    }

}

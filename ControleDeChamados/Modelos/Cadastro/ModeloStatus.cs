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
    public class ModeloStatus : IConsultaPesquisar
    {
        public Int64? Id { get; set; }

        public String Descricao { get; set; }

        public bool Ativo { get; set; }

        public string Consulta => Descricao;

    }

    public class StatusDTO
    {
        public Int64? Id { get; set; }

        public String Descricao { get; set; }

        public bool Ativo { get; set; }

    }

    public static class ConverteStatus
    {
        public static StatusDTO Converte(this ModeloStatus m)
        {
            return new StatusDTO
            {
                Descricao = m.Descricao,
                Id = m.Id,
                Ativo = m.Ativo
            };
        }
    }

}

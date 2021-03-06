﻿using Interfaces.PesquisarDTO;
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
    public class ModeloDepartamento : IConsultaPesquisar
    {
        public Int64? Id { get; set; }

        public String Descricao { get; set; }

        public bool Ativo { get; set; }

        public string Consulta => Descricao;

    }

    public class DepartamentoDTO
    {
        public Int64? Id { get; set; }

        public String Descricao { get; set; }

        public bool Ativo { get; set; }

    }

    public static class ConverteDepartamento
    {
        public static DepartamentoDTO Converte(this ModeloDepartamento m)
        {
            return new DepartamentoDTO
            {
                Descricao = m.Descricao,
                Id = m.Id,
                Ativo = m.Ativo
            };
        }
    }

}

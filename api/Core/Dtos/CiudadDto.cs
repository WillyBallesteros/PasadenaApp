﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Domain;

namespace Core.Dtos
{
    public class CiudadDto
    {
        public int CiudadId { get; set; }
        public int? DepartamentoId { get; set; }
        public string CiudadNombre { get; set; }
    }
}
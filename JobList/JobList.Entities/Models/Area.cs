﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Entities.Models
{
    public class Area
    {
        public int idArea { get; set; }
        public string descripcion { get; set; }
        public int idDivision { get; set; }
        public bool banderaEliminar { get; set; }
    }
}

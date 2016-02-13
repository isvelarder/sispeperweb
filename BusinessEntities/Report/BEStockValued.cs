using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessEntities.Report
{
    public class BEStockValued
    {
        public int COD_COMP { get; set; }
        public string COD_ALMA { get; set; }
        public string ALF_CODI_ARTI { get; set; }
        public string ALF_ARTI { get; set; }
        public int NUM_STOC { get; set; }
        public decimal NUM_COST_UNIT { get; set; }
        public decimal NUM_COST_VALO { get; set; }
        public decimal NUM_VENT_UNIT { get; set; }
        public decimal NUM_VENT_VALO { get; set; }
    }
}

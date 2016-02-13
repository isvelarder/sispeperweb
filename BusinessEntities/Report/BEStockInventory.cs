using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessEntities.Report
{
    public abstract class BEStockInventory
    {
        public string ALF_ALMA { get; set; }
        public string ALF_CODI_ARTI { get; set; }
        public string ALF_ARTI { get; set; }
        public int NUM_STOC_REAL { get; set; }
        public int NUM_STOC_MALO { get; set; }
        public int NUM_STOC_TRAN { get; set; }
        public int NUM_STOC_MALO_TRAN { get; set; }
        public int NUM_DISP { get; set; }
        public int NUM_MALO_DISP { get; set; }

        public abstract BEStockInventory Clone();
    }

    public class BECloneStockInventoy : BEStockInventory
    {
        public override BEStockInventory Clone()
        {
            return this.MemberwiseClone() as BEStockInventory;
        }
    }
}

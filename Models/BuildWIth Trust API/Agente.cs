using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSeguridad.Models.BuildWIth_Trust_API
{
    public class Script
    {
        public string Id { get; set; }
    }

    public class DbRecord
    {
        public int EarliestRecord { get; set; }
        public int LatestUpdate { get; set; }
        public int PremiumTechs { get; set; }
        public bool LiveTechs { get; set; }
        public bool AffiliateLinks { get; set; }
        public bool PaymentOptions { get; set; }
        public bool Ecommerce { get; set; }
        public bool Parked { get; set; }
        public int Spend { get; set; }
        public bool Established { get; set; }
        public bool DbIndexed { get; set; }
    }

    public class Result
    {
        public List<Script> Scripts { get; set; }
        public string Domain { get; set; }
        public DbRecord DbRecord { get; set; }
        public string Status { get; set; }
    }
}

using System.Collections.Generic;

namespace Edelweiss.DAL.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Utc { get; set; }

        public ICollection<Tariff> Tariffs { get; set; }
        public int? CountQty { get; set; }

        public virtual ICollection<Agent> Agents { get; set; }
        public virtual ICollection<CellPhoneMask> CellPhoneMasks { get; set; }
    }
}

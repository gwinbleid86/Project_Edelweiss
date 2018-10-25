using System.Collections.Generic;

namespace Edelweiss.DAL.Entities
{
    public class Range
    {
        public int Id { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public ICollection<Tariff> Tariffs { get; set; }
    }
}

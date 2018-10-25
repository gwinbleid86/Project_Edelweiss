using System;

namespace Edelweiss.DAL.Entities
{
    public class Tariff
    {
        public int Id { get; set; }

        public int? AgentId { get; set; }
        public Agent Agent { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public int? RangeId { get; set; }
        public Range Range { get; set; }

        //public virtual SysTransaction Transaction { get; set; }
        public DateTime StartTime { get; set; }
        public int CommissionType { get; set; }
        public decimal Value { get; set; }
    }
}

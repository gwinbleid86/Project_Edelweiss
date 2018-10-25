using System;
using System.Collections.Generic;
using System.Text;

namespace Edelweiss.DAL.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Tariff> Tariffs { get; set; }
    }
}

namespace Edelweiss.DAL.Entities
{
    public class Commission
    {
        public int Id { get; set; }

        public int AgentId { get; set; }
        public Agent Agent { get; set; }

        public int TransactionId { get; set; }
        public SysTransaction Transaction { get; set; }

        public decimal Value { get; set; }
        //public decimal AgentFromCommission { get; set; }
        //public decimal AgentToCommission { get; set; }
        //public decimal SystemCommission { get; set; }
    }
}

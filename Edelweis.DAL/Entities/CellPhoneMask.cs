namespace Edelweiss.DAL.Entities
{
    public class CellPhoneMask
    {
        public int Id { get; set; }
        public int Mask { get; set; }
        public string CellPhone { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}

namespace ZestrApi.Models
{
    public class SaleRecord
    {
        // Sale Record Id line
        public Guid Id { get; set; }

        //staff Id - will link tot he Id in StaffMember table 
        public Guid StaffId { get; set; }

        public Dictionary<string, int> ItemSales { get; set; }

        public DateTime WeekCommencing { get; set; }
    }
}
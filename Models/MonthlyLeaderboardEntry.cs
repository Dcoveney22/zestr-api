namespace ZestrApi.Models
{
    public class MonthlyLeaderboardEntry
    {
        public Guid StaffId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int Place { get; set; }
        public int PositionPoints { get; set; }
        public int TotalSalesScore { get; set; }
        public int GoldCount { get; set; }
        public int SilverCount { get; set; }
        public int BronzeCount { get; set; }
    }
}
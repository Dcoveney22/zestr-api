namespace ZestrApi.Models
{
    public class WeeklyResult
    {
        public Guid Id { get; set; }
        public Guid StaffId { get; set; }
        public DateTime WeekCommencing { get; set; }
        public LeaderboardPosition Position { get; set; }
        public int WeeklyScore { get; set; }
    }
}
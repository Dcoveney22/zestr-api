namespace ZestrApi.Models
{
    public class LeaderBoardEntry
    {
        public Guid StaffId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public int TotalScore { get; set; }
        public DateTime WeekCommencing { get; set; }
        public int Place { get; set; }

    }
}
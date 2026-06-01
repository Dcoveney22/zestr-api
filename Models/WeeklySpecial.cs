using System.ComponentModel.DataAnnotations;

namespace ZestrApi.Models
{
    public class WeeklySpecial
    {

        public Guid? Id { get; set; }
        public Guid MenuItemId { get; set; }
        public SpecialLevel SpecialLevel { get; set; }

        public DateTime WeekCommencing { get; set; }

        public bool IsActive { get; set; }
    }
}
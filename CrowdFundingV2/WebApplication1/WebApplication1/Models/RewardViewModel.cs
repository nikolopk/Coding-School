using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class RewardViewModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Minimum Required Amount")]
        public int MinAmount { get; set; }

        [Required]
        [Display(Name = "Maximum Required Amount")]
        public int MaxAmount { get; set; }
        [Display(Name = "Max Available")]
        [Required]
        public int MaxAvailable { get; set; }
        public int CurrentAvailable { get; set; }
    }
}
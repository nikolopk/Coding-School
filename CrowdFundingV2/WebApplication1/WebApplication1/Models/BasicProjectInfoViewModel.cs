using System;

namespace WebApplication1.Models
{
    public class BasicProjectInfoViewModel 
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreatorFullName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Ratio { get; set; }

        public int CurrentBackerCount { get; set; }

        public decimal CurrentFund { get; set; }

        public DateTime  DueDate { get; set; }

        public int DaysLeft
        {
            get
            {
                return (DueDate - DateTime.Now).Days;
            }
        }

        public int NoComments { get; set; }
    }
}

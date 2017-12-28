using System;
using System.ComponentModel.DataAnnotations;

namespace AuBoulot.Web.Models
{
    public class Activity
    {
        public Guid Id { get; set; }

        [Required]
        public JobOpportunity JobOpportunity { get; set; }

        public int? Direction { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Range(0, 100)]
        public int? Rating { get; set; }

        public int State { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [DataType(DataType.Date)]
        public DateTime EstimatedDateTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime ActualDateTime { get; set; }

        [DataType(DataType.Duration)]
        public int? Duration { get; set; }

        public Activity NextActivity { get; set; }
    }
}

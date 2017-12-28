using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AuBoulot.Web.Models
{
    public class Company
    {
        
        public Guid Id { get; set; }

        [Display(Name ="Name")]
        [Required]
        [StringLength(50)]
        public string SimpleName { get; set; }

        [Display(Name = "Full Name")]
        [StringLength(200)]
        public string FullName { get; set; }

        [DataType(DataType.Url)]
        public string WebSite { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public ICollection<JobOpportunity> JobOpportunityList { get; set; }

        

    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuBoulot.Web.Models
{
    public class JobOpportunity
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string Source { get; set; }

        //monthly in K RMB 18 000= 18K
        [DataType(DataType.Currency)]
        [Range(0, 200)]
        [Display(Name ="Min. Salary")]
        public int? MinSalary { get; set; } 

        [DataType(DataType.Currency)]
        [Range(0, 200)]
        [Display(Name = "Max. Salary")]
        public int? MaxSalary { get; set; }

        public int Salary
        {
            get =>(MinSalary.HasValue && MaxSalary.HasValue)?
                ( (MinSalary.Value + MaxSalary.Value) / 2):0;
        }

        [Range(0, 100)]        
        public int? Rating { get; set; }

        [Required(ErrorMessage ="Parent Company is Required.")]
        public Guid ParentCompanyId { get; set; }

        public virtual Company ParentCompany { get; set; }

        public virtual Address WorkAddress { get; set; }
        
        public virtual ICollection<Activity> ActivityList { get; set; }

       

    }
}

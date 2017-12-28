using System;
using System.ComponentModel.DataAnnotations;

namespace AuBoulot.Web.Models
{
    public class Address
    {
        public Guid Id { get; set; }

        [Required]
        public string Street { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOS
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
        public bool IsSubScribedToNewsLetter { get; set; }
        public byte MembershipTypeId { get; set; }

    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Resource
    {
        [Required] public int Id { get; set; }
        [Required] public String Name { get; set; }
        public int Quantity { get; set; }
    }
}
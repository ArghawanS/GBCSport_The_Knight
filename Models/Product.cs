using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace GBCSport_The_Knight.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please input a product code")]
        public String ProductCode { get; set; }

        [Required(ErrorMessage = "Please input a product Name")]
        [RegularExpression("^[a-zA-Z0-9_ .,!':]+$",
            ErrorMessage = "Please input a valid, properly formatted Product Name")]
        public String ProductName { get; set; }

        [Required(ErrorMessage = "Please input a price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<Registration> Registrations { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace Kino.Domain.DomainModels
{
    public class Product:BaseEntity
    {
        [Required]
        [Display(Name = "Movie Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Poster")]
        public string ProductImage { get; set; }
        [Required]
        [Display(Name = "Ticket Price")]
        public int Price { get; set; }
        [Required]
        [Display(Name = "Rating")]
        public int Rating { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime data { get; set; }
        public virtual ICollection<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
        public IEnumerable<ProductInOrder> ProductInOrders { get; set; }
    }
}

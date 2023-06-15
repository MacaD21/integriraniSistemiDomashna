using Kino.Domain.Identity;
using System.Collections.Generic;

namespace Kino.Domain.DomainModels
{
    public class ShoppingCart:BaseEntity
    {
        public string OwnerId { get; set; }
        public KinoUser Owner { get; set; }
        public virtual ICollection<ProductInShoppingCart> ProductInShoppingCarts { get; set; }

    }
}

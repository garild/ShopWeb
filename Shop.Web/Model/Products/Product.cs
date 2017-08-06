using System.Collections.Generic;

namespace Shop.Web.Products.Shop
{
    public class ShopCart
    {
        public List<Product> Product { get; set; }
        public int Quantity { get; set; }
    }
    public class Product
    {
        public int CoverId { get; set; }
        public int EditionId { get; set; }
        public int MediumId { get; set; }
        public int PublisherId { get; set; }
    }
}
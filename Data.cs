using System.Collections.Generic;

namespace RestAPIGetter
{
    public class Data
    {
        public IList<Products> Products { get; set; }
        public IList<Categories> Categories { get; set; }
    }

    public class Products
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int CategoryId { get; set; }
    }

    public class Categories
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}

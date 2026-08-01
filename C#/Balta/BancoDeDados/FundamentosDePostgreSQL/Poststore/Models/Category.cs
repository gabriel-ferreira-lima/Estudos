namespace Poststore.Models {
    public class Category {

        public int Id { get; set; }
        public Heading Heading { get; set; } = new Heading();

        public List<Product> Products { get; set; } = [];
    }
}

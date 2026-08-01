namespace Poststore.Models {
    public class Product {

        public int Id { get; set; }
        public Heading Heading { get; set; } = new Heading();
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        public string DefautLanguage { get; set; } = "en-us";

        public List<Translation> Translations { get; set; } = new List<Translation>();
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}

namespace Aula02.Model {
    internal class Role {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public IList<User> Users { get; set; }

    }
}

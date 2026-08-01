using Aula05Exercicios.ContentContext.Enums;

namespace Aula05Exercicios.ContentContext {
    public class Course : Content {

        public Course(string tittle, string url) : base(tittle, url) {
            Modules = new List<Module>();
        }
        public string Tag { get; set; }
        public IList<Module> Modules { get; set; }
        public EContentLevel Level { get; set; }
    }

}

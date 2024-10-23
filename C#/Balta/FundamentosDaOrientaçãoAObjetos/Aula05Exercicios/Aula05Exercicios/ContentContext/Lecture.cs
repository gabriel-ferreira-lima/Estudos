using Aula05Exercicios.ContentContext.Enums;
using Aula05Exercicios.SharedContext;

namespace Aula05Exercicios.ContentContext {
    public class Lecture : Base{
        public int Order { get; set; }
        public string Title { get; set; }
        public int DurationInMinutes  { get; set; }
        public EContentLevel Level  { get; set; }
    }
}

using Aula05Exercicios.SharedContext;

namespace Aula05Exercicios.ContentContext {
    public abstract class Content : Base{

        protected Content(string tittle, string url)
        { 
            Tittle = tittle;
            Url = url;
        }
        public string Tittle { get; set; }
        public string Url { get; set; }
    }
}

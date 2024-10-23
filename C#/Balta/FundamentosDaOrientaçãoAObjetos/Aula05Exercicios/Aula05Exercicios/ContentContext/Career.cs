namespace Aula05Exercicios.ContentContext {
    public class Career : Content {

        public Career(string tittle, string url) : base (tittle,url) {
            Items = new List<CareerItem>();
        }

        public List<CareerItem> Items { get; set; }
        public int TotalCourses  => Items.Count; // ao invez de usar o ger e informar o return que ele deve ter,
                                                 // eu posso usar essa expression body para simplificar.
    }
}

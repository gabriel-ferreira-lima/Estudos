namespace AulaGuids {
    internal class Program {
        static void Main(string[] args) {

            Guid id = Guid.NewGuid();
            id.ToString();

            id = new Guid("2ea0b36b-cecb-421e-8e58-b53a74079b96");
            
            if (id == Guid.NewGuid()) 
            Console.WriteLine(id.ToString().Substring(0,8));
        }
    }
}

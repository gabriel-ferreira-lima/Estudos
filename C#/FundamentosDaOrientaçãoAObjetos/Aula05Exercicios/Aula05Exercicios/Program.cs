using Aula05Exercicios.ContentContext;
using Aula05Exercicios.SubscriptionContext;
using System.Linq;

namespace Aula05Exercicios {
    internal class Program {
        static void Main(string[] args) {

            var articles = new List<Article>();

            articles.Add(new Article("Artigo sobre OOP", "orientacao-objetos"));
            articles.Add(new Article("Artigo sobre C#", "csharp"));
            articles.Add(new Article("Artigo sobre .NET", "dotnet"));

            //foreach (var article in articles) {
            //    Console.WriteLine(article.Id);
            //    Console.WriteLine(article.Tittle);
            //    Console.WriteLine(article.Url);
            //    Console.WriteLine();
            //}

            var courses = new List<Course>();
            var courseOOP = new Course("Fundamentos OOP", "fundamentos-oop");
            var courseCsharp = new Course("Fundamentos c#", "fundamentos-csharp");
            var courseAspNet = new Course("Fundamentos ASP.NET", "fundamentos-aspnet");


            courses.Add(courseOOP);
            courses.Add(courseCsharp);
            courses.Add(courseAspNet);

            var careers = new List<Career>();
            var careerDotnet = new Career("Especialista .NET", "especialista-dotnet");
            var careerItem2 = new CareerItem(2, "Aprenda OOP", "", null);
            var careerItem = new CareerItem(1, "Comece por aqui", "", courseCsharp);
            var careerItem3 = new CareerItem(3, "Aprenda .NET", "", courseAspNet);
            careerDotnet.Items.Add(careerItem2);
            careerDotnet.Items.Add(careerItem3);
            careerDotnet.Items.Add(careerItem);
            careers.Add(careerDotnet);

            foreach (var career in careers) {
                Console.WriteLine(career.Tittle);
                foreach (var item in career.Items.OrderBy(x=>x.Order)) {
                    Console.WriteLine($"{item.Order} - {item.Title}");
                    Console.WriteLine(item.Course?.Tittle);
                    Console.WriteLine(item.Course?.Level);

                    foreach (var notification in item.Notifications) {
                        Console.WriteLine($"{notification.Property} - {notification.Message}");
                    }
                }

            }

            var payPalSubscription = new PayPalSubscription();
            var studant = new Studant();
            studant.CreateSubscription(payPalSubscription);
       
        }
    }
}

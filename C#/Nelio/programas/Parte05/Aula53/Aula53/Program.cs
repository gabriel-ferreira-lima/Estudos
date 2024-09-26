using Aula53.Entities;
using Aula53.Entities.Enums;
using System.Globalization;

namespace Aula53 {
    internal class Program {
        static void Main(string[] args) {

            List<Shape> list = new List<Shape>();

            Console.Write("Enter the number of shapes: ");
            int c = int.Parse(Console.ReadLine());
            for (int i = 1; i <= c; i++) {

                Console.WriteLine("Shape #" + i + " data:");
                Console.Write("Rectangle or Circle (r/c)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Color (Black/Blue/Red): ");
                Color color = Enum.Parse<Color>(Console.ReadLine());
                if (type == 'r' || type == 'R') {
                    Console.Write("Width: ");
                    double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Height: ");
                    double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Rectangle(color, width, height));
                }
                else {
                    Console.Write("Radius: ");
                    double radius = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                    list.Add(new Circle(color, radius));
                }

            }

            Console.WriteLine();
            Console.WriteLine("SHAPE AREAS:");

            foreach (Shape shape in list) {
                Console.WriteLine(shape.Area().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}

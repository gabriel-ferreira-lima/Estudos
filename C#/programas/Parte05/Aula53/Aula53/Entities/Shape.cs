using Aula53.Entities.Enums;

namespace Aula53.Entities {
    abstract internal class Shape {

        public Color Color { get; set; }

        public Shape(Color color) { 
            Color = color;
        }

        abstract public double Area();
    }
}

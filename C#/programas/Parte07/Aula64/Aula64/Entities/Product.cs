using System.Globalization;

namespace Aula64.Entities {
    internal class Product {

        public string Name { get; set; }
        public double Value { get; set; }
        public int Quantity { get; set; }

        public Product() { 
        }

        public Product(string name, double value, int quantity) {
            Name = name;
            Value = value;
            Quantity = quantity;
        }


        public double SumValue() {
            return Value * Quantity;
        }

        public override string ToString() {
            return Name + "," + SumValue().ToString("f2", CultureInfo.InvariantCulture);
        }
    }
}

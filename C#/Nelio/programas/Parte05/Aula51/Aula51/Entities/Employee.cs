namespace Aula51.Entities {
    internal class Employee {

        public string Name { get; set; }
        public int Hour { get; set; }
        public double ValuePerHour { get; set; }

        public Employee() { 
        }

        public Employee(string name, int hour, double valuePerHour) {
            Name = name;
            Hour = hour;
            ValuePerHour = valuePerHour;
        }

        public virtual double Payment() {
            return Hour * ValuePerHour;
        }
    }
}

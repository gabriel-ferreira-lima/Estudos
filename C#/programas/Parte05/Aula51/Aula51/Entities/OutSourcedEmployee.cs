namespace Aula51.Entities {
    internal class OutSourcedEmployee : Employee {

        public Double AdditionalCharge { get; set; }

        public OutSourcedEmployee() {
        }

        public OutSourcedEmployee(string name, int hour, double valuePerHour, double additionalCharge)
            : base(name, hour, valuePerHour) {
            AdditionalCharge = additionalCharge;
        }

        public override double Payment() {
            return base.Payment() + 1.1 * AdditionalCharge;

        }
    }
}

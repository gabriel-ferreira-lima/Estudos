namespace Aula54.Entities {
    internal class Individual : TaxPayer {

        public double HealthExpenditures { get; set; }

        public Individual() {
        }

        public Individual(string name, double anualIncome, double healthExpenditures) : base(name, anualIncome) {
            HealthExpenditures = healthExpenditures;
        }

        public override double Tax() {
            if (AnualIncome < 20000.00) {
                if (HealthExpenditures > 0) {
                    return (AnualIncome * 0.15) - (HealthExpenditures / 2);
                }
                else {
                    return AnualIncome * 0.15;
                }
            }
            else {
                if (HealthExpenditures > 0) {
                    return (AnualIncome * 0.25) - (HealthExpenditures / 2);
                }
                else {
                    return AnualIncome * 0.25;
                }
            }
        }

    }
}

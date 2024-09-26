using System.Globalization;

namespace Aula65.Entities {

    internal class Invoice {
        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice() {
        }

        public Invoice(double basicPayment, double tax) {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public double TotalPayment {
            get { return BasicPayment + Tax; }
        }

        public override string ToString() {
            return "Basic payment: " + BasicPayment.ToString("F2", CultureInfo.InvariantCulture)
                + "\r\nTax: " + Tax.ToString("F2", CultureInfo.InvariantCulture)
                + "\r\nTotalPayment: " + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
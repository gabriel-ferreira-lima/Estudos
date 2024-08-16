using System.Globalization;


namespace Aula52.Entities {
    internal class ImportedProduct : Product {

        public double CustomsFee { get; set; }

        public ImportedProduct() {
        }

        public ImportedProduct(string name, double price, double customsFee) : base(name, price) {
            CustomsFee = customsFee;
        }

        public sealed override string PriceTag() {
            return Name
                + " $ "
                + TotalPrice().ToString("F2", CultureInfo.InvariantCulture)
                + " (Customs fee: $ "
                + CustomsFee.ToString("F2", CultureInfo.InvariantCulture)
                + ")";
        }

        public double TotalPrice() { 
            return Price + CustomsFee;
        }
    }
}

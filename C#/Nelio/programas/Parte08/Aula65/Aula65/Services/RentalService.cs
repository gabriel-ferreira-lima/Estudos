using Aula65.Entities;

namespace Aula65.Services {

    internal class RentalService {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private ITaxServices _taxServices;

        public RentalService() {
        }

        public RentalService(double pricePerHour, double pricePerDay, ITaxServices taxServices) {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxServices = taxServices;
        }

        public void ProcessInvoice(CarRental carRental) {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;
            if (duration.TotalHours <= 12.0) {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _taxServices.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
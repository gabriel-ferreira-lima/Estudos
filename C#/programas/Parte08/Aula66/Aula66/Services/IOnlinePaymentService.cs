namespace Aula66.Services {
    internal interface IOnlinePaymentService {

        double PaymentFee(double amount);
        public double Interest(double amount, int months);
    }
}

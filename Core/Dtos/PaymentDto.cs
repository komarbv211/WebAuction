namespace Core.Dtos
{
    public class PaymentDto
    {
        public int LotId { get; set; }
        public string LotName { get; set; }
        public decimal Amount { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVC { get; set; }
        public string CardHolderName { get; set; }
    }
}
